using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    class FolderItem : DirectoryItem
    {
        public FolderItem(FileInfo fileInfo) : base(fileInfo)
        {
        }
    }
}
