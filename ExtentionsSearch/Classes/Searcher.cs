using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ExtentionsSearch.Model;
using System.ComponentModel;

namespace ExtentionsSearch.Classes
{
    public struct extentionProperties
    {
        public extentionProperties(Int32 numberOfFiles, Int64 totalSize, FileInfo smallestFile, FileInfo bigestFile)
        {
            this.numberOfFiles = numberOfFiles;
            this.totalSize = totalSize;
            this.smallestFile = smallestFile;
            this.bigestFile = bigestFile;
        }
        public Int32 numberOfFiles;
        public Int64 totalSize;
        public FileInfo smallestFile;
        public FileInfo bigestFile;
    }
    public class Searcher
    {
        private BackgroundWorker worker;
        private DirectoryInfo Root;
        private Dictionary<string, extentionProperties> resultsOfSearch;
        public Dictionary<string, extentionProperties> ResultsOfSearch
        { get { return resultsOfSearch; } }
        public BackgroundWorker Worker
        { 
         get { return worker; }
         set { worker= value; }
        }
        public Searcher()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
        public void ScanFolder(DirectoryInfo root)
        {
            Root = root;
            resultsOfSearch = new Dictionary<string, extentionProperties>();
            worker.RunWorkerAsync();
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_ComletedWork);           
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WalkDirectoryTree(Root);
        }

        private void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException)
            {

            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    if (resultsOfSearch.ContainsKey(fi.Extension))
                    {
                        extentionProperties ex = resultsOfSearch[fi.Extension];
                        ex.numberOfFiles += 1;
                        ex.totalSize += fi.Length;
                        if (fi.Length > ex.bigestFile.Length) ex.bigestFile = fi;
                        if (fi.Length < ex.smallestFile.Length) ex.smallestFile = fi;
                        resultsOfSearch[fi.Extension] = ex;
                    }
                    else
                    {
                        resultsOfSearch.Add(fi.Extension, new extentionProperties(1, fi.Length, fi, fi));
                    }
                }
            }
            try
            {
                subDirs = root.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {

            }
            if (subDirs != null)
            {
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }

        }
    }
}
