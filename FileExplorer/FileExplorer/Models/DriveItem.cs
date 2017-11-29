using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileExplorer
{
    public class DriveItem : DirectoryItem
    {
        private static readonly string WindowsDrive = Path.GetPathRoot(Environment.SystemDirectory);
        
        public ImageSource ImageSource { get; private set; }
        
        public DriveItem(FileInfo fileInfo) : base(fileInfo)
        {
            string driveLetter = fileInfo.FullName.Substring(0, 1);

            if (fileInfo.FullName == WindowsDrive)
            {
                string path = @"Assets\Drives\WindowsDrive.ico";
                ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            }
            else
            {
                string path = $"Assets\\Drives\\{driveLetter}.ico";
                ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            }
            
        }
    }
}
