using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorer
{
    public class GoToCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> GoAction;

        public GoToCommand(Action<object> GoAction)
        {
            this.GoAction = GoAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            GoAction.Invoke(parameter);
        }
    }
}
