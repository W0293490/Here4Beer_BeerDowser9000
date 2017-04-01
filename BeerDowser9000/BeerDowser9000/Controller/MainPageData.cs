using BeerDowser9000.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BeerDowser9000
{
    public class MainPageData : INotifyPropertyChanged
    {

        public string Greeting { get; set; } = "I need a beer!";
        public ObservableCollection<BeerModel> BeerPlaces { get; set; }
        private BeerModel _selectedBeerPlace;
        private string _filter; 
        public string LocationFilter { get; set; }
        public string LocationFilterFurther { get; set; } 


        private List<BeerModel> _beerPlaces = new List<BeerModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        private BeerModel _selectedBeer;
        

        public BeerModel SelectedNameday
        {
            get
            {
                return _selectedBeer;
            }
            set
            {
                _selectedBeer = value;
                if (value == null)
                {
                    Greeting = "Hello World!";
                }
                else
                {
                    Greeting = "Hello " + value.NamesAsString;
                }
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("Greeting"));
                //CheckCommand.FireCanExecuteChanged();
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
                d => d.NamesAsString.ToLowerInvariant()
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




            LoadData("City", "Halifax");
        }


        public async void LoadData(string loc, string filterFurther)
        {
            //BeerPlaces = new ObservableCollection<BeerModel>();
            _beerPlaces = await Repository.GetAllBeersAsync(loc, filterFurther);
            PerformFiltering();
        }

    }
}
