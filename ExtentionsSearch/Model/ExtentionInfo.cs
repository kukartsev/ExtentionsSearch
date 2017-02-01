using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace ExtentionsSearch.Model
{
    [Serializable]
    public class ExtentionInfo : INotifyPropertyChanged
    {
        private string name;
        private int numberOfFiles;
        private long totalSize;
        private FileInfo smallestFile;
        private FileInfo bigestFile;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public Int32 NumberOfFiles
        {
            get { return numberOfFiles; }
            set
            {
                numberOfFiles = value;
                OnPropertyChanged("NumberOfFiles");
            }
        }
        public Int64 TotalSize
        {
            get { return totalSize; }
            set
            {
                totalSize = value;
                OnPropertyChanged("TotalSize");
            }
        }
        public FileInfo SmallestFile
        {
            get { return smallestFile; }
            set
            {
                smallestFile = value;
                OnPropertyChanged("SmallestFile");
            }
        }
        public FileInfo BigestFile
        {
            get { return bigestFile; }
            set
            {
                bigestFile = value;
                OnPropertyChanged("BigestFile");
            }
        }

        public ExtentionInfo(string name, Int32 numberOfFiles, Int64 totalSize, FileInfo smallestFile, FileInfo bigestFile)
        {
            this.name = name;
            this.numberOfFiles = numberOfFiles;
            this.totalSize = totalSize;
            this.smallestFile = smallestFile;
            this.bigestFile = bigestFile;
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
    }

    [Serializable]
    public struct SerealizedData
    {
        public ObservableCollection<ExtentionInfo> serealizedExtentionsList;
        public DateTime time;
        public SerealizedData(ObservableCollection<ExtentionInfo> serealizedExtentionsList, DateTime time)
        {
            this.serealizedExtentionsList = serealizedExtentionsList;
            this.time = time;
        }
    }
}
