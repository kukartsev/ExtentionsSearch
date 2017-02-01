using System;
using System.Windows;
using ExtentionsSearch.ViewModel;

namespace ExtentionsSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Variables
        private readonly ExtentionInfoViewModel extentionInfoViewModel;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            extentionInfoViewModel = new ExtentionInfoViewModel();
            DataContext = extentionInfoViewModel;
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            extentionInfoViewModel.SerializeIt();            
        }

        private void SortByNumberOfFilesRB_Checked(object sender, RoutedEventArgs e)
        {
            PieSeries.DependentValueBinding = new System.Windows.Data.Binding("NumberOfFiles");
        }

        private void SortByTotalSizeRB_Checked(object sender, RoutedEventArgs e)
        {
            PieSeries.DependentValueBinding = new System.Windows.Data.Binding("TotalSize");
        }
    }
}
