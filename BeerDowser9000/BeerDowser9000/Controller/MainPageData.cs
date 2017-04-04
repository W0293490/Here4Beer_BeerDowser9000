using BeerDowser9000.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace BeerDowser9000
{
    public class MainPageData : INotifyPropertyChanged
    {

        public string Greeting { get; set; } = "Are you thirsty?...";
        public string NoImage { get; set; } = "No Image(s) Found.";

        public ObservableCollection<BeerModel> BeerPlaces { get; set; }
        public ObservableCollection<ImageModel> PlaceImages { get; set; }

        private string _filter; 
        public string LocationFilter { get; set; }
        public string LocationFilterFurther { get; set; }

        private List<BeerModel> _beerPlaces = new List<BeerModel>();
        private List<ImageModel> _placeImages = new List<ImageModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        private BeerModel _selectedBeerPlace;
        private ImageModel _selectedImage;

        public BeerModel SelectedBeerPlace
        {
            get
            {
                return _selectedBeerPlace;
            }
            set
            {
                _selectedBeerPlace = value;
                if (value == null)
                {
                    Greeting = "Are you thirsty?...";
                }
                else
                {
                    Greeting = value.Info;
                    LoadImages(_selectedBeerPlace.id);
                }
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("Greeting"));
            }
        }

        public ImageModel SelectedImage
        {
            get
            {
                return _selectedImage;
            }
        }

        public int SelectedPlaceId
        {
            get
            {
                return SelectedBeerPlace.id;
            }
        }
               
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (value == _filter)
                {
                    return;
                }
                _filter = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(Filter)));
                PerformFiltering();
            }
        }

        private void PerformFiltering()
        {
            if (_filter == null)
            {
                _filter = "";
            }
            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();
            var result = _beerPlaces.Where(
                d => d.Info.ToLowerInvariant()
                        .Contains(lowerCaseFilter)).ToList();
            var toRemove = BeerPlaces.Except(result).ToList();
            foreach (var x in toRemove)
            {
                BeerPlaces.Remove(x);
            }
            // Add back in the correct order.
            var resultcount = result.Count;
            for (int i = 0; i < resultcount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > BeerPlaces.Count || !BeerPlaces[i].Equals(resultItem))
                {
                    BeerPlaces.Insert(i, resultItem);
                }
            }
        }

        public MainPageData()
        {
            BeerPlaces = new ObservableCollection<BeerModel>();
            PlaceImages = new ObservableCollection<ImageModel>();
        }

        public async void LoadData(string loc, string filterFurther)
        {
            _beerPlaces = await Repository.GetAllBeersAsync(loc, filterFurther);
            PerformFiltering();
        }

        public async void LoadImages(int id) 
        {
            if (_placeImages != null) // If list contains images, clear it (so it doesn't continue to append for next)
            {
                _placeImages.Clear();
                PlaceImages.Clear();
            }
            _placeImages = await Repository.GetImagesAsync(id);

            if (Int32.Parse(_selectedBeerPlace.imagecount) == 0) // If no images found
            {
                _placeImages.Clear(); // Clear placeholder
                PlaceImages.Clear();
                Debug.WriteLine("No images found"); // Insert default placeholder image
            }

            for (int i = 0; i < _placeImages.Count; i++) // For image count, insert image to image list
            {
                PlaceImages.Insert(i, _placeImages[i]);
            }
            NoImage = "";
        }
    }
}
