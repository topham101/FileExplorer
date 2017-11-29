using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FileExplorer
{
    public abstract class DirectoryItem
    {
        public string FullName
        {
            get
            {
                return fileInfo.FullName;
            }
        }
        public string Name
        {
            get
            {
                return fileInfo.Name;
            }
        }
        public string Directory
        {
            get
            {
                return fileInfo.DirectoryName;
            }
        }

        private FileInfo fileInfo;

        public DirectoryItem(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }
    }
}
