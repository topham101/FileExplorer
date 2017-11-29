using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorer
{
    public class NavigationDisplayViewModel
    {
        private DirectoryDisplayViewModel directoryDisplayViewModel;

        public NavigationDisplayViewModel(DirectoryDisplayViewModel directoryDisplayViewModel)
        {
            this.directoryDisplayViewModel = directoryDisplayViewModel;
            NavigationBarDirectory = new ObservableCollection<DirectoryItem>();
            GoToCommand = new GoToCommand(GoTo);

            // Populate Navigation Bar
            var drives = Directory.GetLogicalDrives();
            foreach (string drivePath in drives)
                NavigationBarDirectory.Add(new DriveItem(new FileInfo(drivePath)));
            NavigationBarDirectory = new ObservableCollection<DirectoryItem>(
                    NavigationBarDirectory.OrderBy((x) => { return x.Name; }).ToList());
        }

        private void GoTo(object parameter)
        {
            DriveItem drive = parameter as DriveItem;

            if (drive == null)
                return;

            if (Directory.Exists(drive.FullName))
            {
                directoryDisplayViewModel.SetDirectory(drive.FullName);
            }
        }

        public ObservableCollection<DirectoryItem> NavigationBarDirectory { get; set; }

        public ICommand GoToCommand { get; private set; }
    }
}
