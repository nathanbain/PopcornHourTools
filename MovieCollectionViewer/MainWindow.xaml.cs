using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PopcornHourTools.CollectionUtils;

namespace MovieCollectionViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<string> movieCollection;
        private const string movieCollectionFlieLocation = @"G:\Projects\PopcornHourTools\MovieCollectionViewer\movie_list.txt";

        private const string greenImageIconLocation = @"/MovieCollectionViewer;component/images/circle-green.png";
        private const string orangeImageIconLocation = @"/MovieCollectionViewer;component/images/circle-orange.png";
        private Uri imageSourceUri;


        public MainWindow()
        {
            InitializeComponent();
            movieCollection = MovieFolderFinder.ReadFullMovieListFromTextFile(string.Format("{0}", movieCollectionFlieLocation));
            UpdateResultsLabel();
        }

        private void UpdateResultsLabel()
        {
            resultsLabel.Content = string.Format("Collection contains {0} movies.", movieCollection.Count);
        }

        private void refreshCollectionBtn_Click(object sender, RoutedEventArgs e)
        {
            // Change colour while updating
            UpdateImageIcon(statusImage, orangeImageIconLocation);
            resultsLabel.Content = "Checking movies..";
            DoEvents();

            // Change colour after update
            UpdateImageIcon(statusImage, greenImageIconLocation);
            UpdateResultsLabel();
        }

        private void UpdateImageIcon(Image image, string imageLocation)
        {

            imageSourceUri = new Uri(imageLocation, UriKind.RelativeOrAbsolute);
            var imageBitmap = new BitmapImage(imageSourceUri);

            image.SetCurrentValue(Image.SourceProperty, imageBitmap);
        }

        private void searchMoviesBtn_Click(object sender, RoutedEventArgs e)
        {
            searchMoviesBtn.Content = "Searching..";
            searchResultsTextBlock.Text = "";
            DoEvents();

            movieCollection.ForEach(CheckIfResultMatchesSearchCriteriaAndAddResultToSearchResultsTextBlock);

            // Change colour after update
            searchMoviesBtn.Content = "Search";

        }

        public void CheckIfResultMatchesSearchCriteriaAndAddResultToSearchResultsTextBlock(string result)
        {
            var searchCriteria = searchCriteriaTextBox.Text;

            if (string.IsNullOrEmpty(searchCriteria))
            {
                AddResultToSearchResultsTextBlock(result);
                return;
            }

            if (result.ToUpper().Contains(searchCriteria.ToUpper()))
                AddResultToSearchResultsTextBlock(result);
        }

        public void AddResultToSearchResultsTextBlock(string result)
        {
            searchResultsTextBlock.Text += result;
            searchResultsTextBlock.Text += Environment.NewLine;
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(
             DispatcherPriority.Background,
             new ThreadStart(DoEvents_DoNothing)
             );
        }

        private static void DoEvents_DoNothing()
        {
            //Just a wrapper for the DoEvents method ...
        }
    }
}
