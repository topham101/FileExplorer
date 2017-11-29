using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorer
{
    public class FileExplorerViewModel
    {
        public FileExplorerViewModel()
        {
            DirectoryDisplayViewModel = new DirectoryDisplayViewModel();
            NavigationDisplayViewModel = new NavigationDisplayViewModel(DirectoryDisplayViewModel);
            AddressSearchViewModel = new AddressSearchViewModel(DirectoryDisplayViewModel);

            BackButton = DirectoryDisplayViewModel.UpDirectoryCommand;
        }

        public DirectoryDisplayViewModel DirectoryDisplayViewModel { get; private set; }
        public NavigationDisplayViewModel NavigationDisplayViewModel { get; private set; }
        public AddressSearchViewModel AddressSearchViewModel { get; private set; }

        public ICommand BackButton { get; private set; }
    }
}
