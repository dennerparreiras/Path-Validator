using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Validator.App_Code
{
    class Statistics
    {
        public int EmptyFolder { get; set; }
        public int FolderWithFiles { get; set; }
        public int TotalFilesFound { get; set; }
        public List<String> EmptyFolderList { get; set; }
        public List<String> FolderWithFilesList { get; set; }
        public String FinalReport { get; set; }

        public Statistics()
        {
            this.EmptyFolder = 0;
            this.FolderWithFiles = 0;
            this.TotalFilesFound = 0;
            this.EmptyFolderList = new List<string>();
            this.FolderWithFilesList = new List<string>();
        }
    }
}
