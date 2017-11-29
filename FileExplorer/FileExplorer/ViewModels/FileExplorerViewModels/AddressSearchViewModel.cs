using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorer
{
    public class AddressSearchViewModel : NotifyPropertyChanged
    {
        private DirectoryDisplayViewModel directoryDisplayViewModel;

        public AddressSearchViewModel(DirectoryDisplayViewModel directoryDisplayViewModel)
        {
            this.directoryDisplayViewModel = directoryDisplayViewModel;

            GoToCommand = new GoToCommand(GoTo);
            this.directoryDisplayViewModel.ActiveDirectoryChanged += ActiveDirectoryChanged;
        }

        /// <summary>
        /// Go to directory / Search for - Enter Key in Address Bar
        /// </summary>
        private void GoTo(object parameter)
        {
            string addressBarText = parameter as string;

            if (addressBarText == null)
                return;

            if (addressBarText == DirectoryDisplayViewModel.MyComputer
                || addressBarText == string.Empty) // Go to Drive View
            {
                directoryDisplayViewModel.SetDriveView();
            }
            else if (Directory.Exists(addressBarText)) // Go to Directory
            {
                directoryDisplayViewModel.SetDirectory(addressBarText);
            }
            else if (!string.IsNullOrWhiteSpace(addressBarText)) // Search
            {
                // Search here
            }
        }
        private void ActiveDirectoryChanged(object sender, string directory)
        {
            AddressBarText = directory;
            RaisePropertyChanged("AddressBarText");
        }

        public string AddressBarText { get; set; }

        public ICommand GoToCommand { get; set; }
    }
}
