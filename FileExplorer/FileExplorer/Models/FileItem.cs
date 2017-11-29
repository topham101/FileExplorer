using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorer
{
    public class FileItem : DirectoryItem
    {
        public ImageSource ImageSource { get; set; }
        public FileItem(FileInfo fileInfo) : base(fileInfo)
        {
            ImageSource = IconManager.FindIconForFilename(Name, true);
        }
    }
}
