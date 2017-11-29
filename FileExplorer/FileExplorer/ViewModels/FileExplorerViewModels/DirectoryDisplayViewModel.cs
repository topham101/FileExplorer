using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileExplorer
{

    public class DirectoryDisplayViewModel : NotifyPropertyChanged
    {
        public const string MyComputer = "My Computer";
        private string activeDirectoryName;

        public event EventHandler<string> ActiveDirectoryChanged;
        
        public ICommand OpenDirectoryItemCommand { get; private set; }
        public ICommand UpDirectoryCommand { get; private set; }

        public string ActiveDirectoryName {
            get
            {
                return activeDirectoryName;
            }
            set
            {
                if (activeDirectoryName != value)
                {
                    activeDirectoryName = value;
                    RaisePropertyChanged("ActiveDirectoryName");
                    ActiveDirectoryChanged?.Invoke(this, value);
                }
            }
        }
        public ObservableCollection<DirectoryItem> ActiveDirectoryCollection { get; private set; }
        
        public DirectoryDisplayViewModel()
        {
            ActiveDirectoryCollection = new ObservableCollection<DirectoryItem>();
            SetDirectory(@"C:\");
            OpenDirectoryItemCommand = new OpenDirectoryItemCommand(SetDirectory);
            UpDirectoryCommand = new UpCommand(UpDirectory);
        }
        
        public void SetDirectory(string directoryPath)
        {
            try
            {
                ActiveDirectoryName = directoryPath;
                var directoryFolderEntries = Directory.GetDirectories(directoryPath);
                var directoryFileEntries = Directory.GetFiles(directoryPath);

                ActiveDirectoryCollection.Clear();

                foreach (var folderName in directoryFolderEntries)
                    ActiveDirectoryCollection.Add(new FolderItem(new FileInfo(folderName)));
                foreach (var fileName in directoryFileEntries)
                    ActiveDirectoryCollection.Add(new FileItem(new FileInfo(fileName)));

                ActiveDirectoryCollection = new ObservableCollection<DirectoryItem>(
                        ActiveDirectoryCollection.OrderBy((x) => { return x.Name; }).ToList());
                RaisePropertyChanged("ActiveDirectoryCollection");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBoxResult result = MessageBox.Show("Error: Unauthorised Access.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SetDriveView()
        {
            ActiveDirectoryName = MyComputer;

            var drives = Directory.GetLogicalDrives();

            ActiveDirectoryCollection.Clear();
            foreach (string drivePath in drives)
                ActiveDirectoryCollection.Add(new DriveItem(new FileInfo(drivePath)));
            ActiveDirectoryCollection = new ObservableCollection<DirectoryItem>(
                    ActiveDirectoryCollection.OrderBy((x) => { return x.Name; }).ToList());
            RaisePropertyChanged("ActiveDirectoryCollection");
        }
        public bool CanUpDirectory()
        {
            return ActiveDirectoryName != MyComputer;
        }
        public void UpDirectory()
        {
            if (ActiveDirectoryName == MyComputer)
                return;

            var parentDir = Directory.GetParent(ActiveDirectoryName);
            if (parentDir != null)
                SetDirectory(parentDir.FullName);
            else SetDriveView();
        }
        
    }
}
