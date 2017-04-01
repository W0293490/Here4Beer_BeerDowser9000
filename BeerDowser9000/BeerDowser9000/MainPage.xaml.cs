using BeerDowser9000.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BeerDowser9000
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Repository repo = new Repository();
        MainPageData mpd = new MainPageData();
        public string LocationFilter;


        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void PlaySound()
        {
            var element = new MediaElement();
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            var file = await folder.GetFileAsync("beer2.wav");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            element.SetSource(stream, "");
            element.Play();
        }


        private void listViewLocations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBoxSearchTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void btnFindLocations_Click(object sender, RoutedEventArgs e)
        {
            //mpd.BeerPlaces = new ObservableCollection<BeerModel>();
            //mpd.LoadData(comboBoxSearchTypes.SelectedValue.ToString(), txtBoxSearchQuery.Text);
            //MainPageData;
            //PlaySound();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            PlaySound();
            Frame.Navigate(typeof(About));

        }
             
    }
}
