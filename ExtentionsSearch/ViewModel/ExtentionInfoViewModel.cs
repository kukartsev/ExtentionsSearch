using ExtentionsSearch.Classes;
using ExtentionsSearch.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ExtentionsSearch.ViewModel
{
    class ExtentionInfoViewModel : INotifyPropertyChanged
    {
        private Searcher searcher;
        private double progress;
        private Boolean indeterminate;
        private Boolean vayOfSort;
        private ObservableCollection<ExtentionInfo> extentionsList;
        private ObservableCollection<ExtentionInfo> extentionsListForPie;
        private string targetPath;
        private string lastCheckInfo;
        public event PropertyChangedEventHandler PropertyChanged;
        public ExtentionInfoViewModel()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            searcher = new Searcher();
            searcher.Worker.RunWorkerCompleted+= new RunWorkerCompletedEventHandler(worker_ComletedWork);
            extentionsList = new ObservableCollection < ExtentionInfo >();
            extentionsListForPie = new ObservableCollection < ExtentionInfo > ();
            if (File.Exists("lastchecking.dat"))
                {
                    using (FileStream fs = new FileStream("lastchecking.dat", FileMode.OpenOrCreate))
                    {
                        SerealizedData savedData = (SerealizedData)formatter.Deserialize(fs);
                        ExtentionsList = new ObservableCollection<ExtentionInfo>(savedData.serealizedExtentionsList.OrderByDescending(ext => ext.TotalSize));
                        ExtentionsListForPie = new ObservableCollection<ExtentionInfo>(ExtentionsList.Take(20));                        
                        LastCheckInfo = "Последняя проверка производилась " + savedData.time.ToString();
                    }
                }            
        }

        public ObservableCollection<ExtentionInfo> ExtentionsList
        {
            get { return extentionsList; }
            set
            {
                extentionsList = value;
                OnPropertyChanged("ExtentionsList");
            }
        }

        public ObservableCollection<ExtentionInfo> ExtentionsListForPie
        {
            get { return extentionsListForPie; }
            set
            {
                extentionsListForPie = value;
                OnPropertyChanged("ExtentionsListForPie");
            }
        }

        public string TargetPath
        {
            get { return targetPath; }
            set
            {
                targetPath = value;
                OnPropertyChanged("TargetPath");
            }
        }

        public double Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public Boolean Indeterminate
        {
            get { return indeterminate; }
            set
            {
                indeterminate = value;
                OnPropertyChanged("Indeterminate");
                OnPropertyChanged("Busy");
            }
        }

        public Boolean Busy
        {
            get { return !indeterminate; }
        }

        public Boolean VayOfSort
        {
            get { return vayOfSort; }
            set
            {
                vayOfSort = value;
                OnPropertyChanged("VayOfSort");
            }
        }

        public string LastCheckInfo
        {
            get { return lastCheckInfo; }
            set
            {
                lastCheckInfo = value;
                OnPropertyChanged("LastCheckInfo");
            }
        }

        private DelegateCommand chooseDirectory;
        public DelegateCommand ChooseDirectoryCommand
        {
            get
            {
                return chooseDirectory ?? (chooseDirectory = new DelegateCommand(ChooseDirectory));
            }
        }        
        private void ChooseDirectory(object arg)
        {
            LastCheckInfo = "";
            ExtentionsList.Clear();
            ExtentionsListForPie.Clear();
            Progress = 0;
            FolderBrowserDialog targetPathDlg = new FolderBrowserDialog();
            targetPathDlg.ShowDialog();
            Indeterminate = true;
            TargetPath = targetPathDlg.SelectedPath;
            searcher.ScanFolder(new DirectoryInfo(targetPath));           
        }

        private void worker_ComletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            Indeterminate = false;
            int itemsCount = searcher.ResultsOfSearch.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                ExtentionsList.Add(new ExtentionInfo(searcher.ResultsOfSearch.ElementAt(i).Key,
                    searcher.ResultsOfSearch.ElementAt(i).Value.numberOfFiles,
                    searcher.ResultsOfSearch.ElementAt(i).Value.totalSize / 1000,
                    searcher.ResultsOfSearch.ElementAt(i).Value.smallestFile,
                    searcher.ResultsOfSearch.ElementAt(i).Value.bigestFile));
                Progress += 100.0 / itemsCount;
            }
            ExtentionsList = new ObservableCollection<ExtentionInfo>(ExtentionsList.OrderByDescending(ext => ext.TotalSize));
            ExtentionsListForPie = new ObservableCollection<ExtentionInfo>(ExtentionsList.Take(20));
        }

        private DelegateCommand sortByTotalSize;
        public DelegateCommand SortByTotalSizeCommand
        {
            get
            {
                return sortByTotalSize ?? (sortByTotalSize = new DelegateCommand(SortByTotalSize));
            }
        }
        private void SortByTotalSize(object arg)
        {
            VayOfSort = false;
            ExtentionsList = new ObservableCollection<ExtentionInfo>(ExtentionsList.OrderByDescending(ext => ext.TotalSize));
            ExtentionsListForPie = new ObservableCollection<ExtentionInfo>(ExtentionsList.Take(20));
        }

        private DelegateCommand sortByNumberOfFiles;
        public DelegateCommand SortByNumberOfFilesCommand
        {
            get
            {
                return sortByNumberOfFiles ?? (sortByNumberOfFiles = new DelegateCommand(SortByNumberOfFiles));
            }
        }
        private void SortByNumberOfFiles(object arg)
        {
            VayOfSort = true;
            ExtentionsList = new ObservableCollection<ExtentionInfo>(ExtentionsList.OrderByDescending(ext => ext.NumberOfFiles));
            ExtentionsListForPie = new ObservableCollection<ExtentionInfo>(ExtentionsList.Take(20));
        }

        public void SerializeIt()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("lastchecking.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, new SerealizedData(extentionsList, DateTime.Now));
            }
        }

        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

    }
}
