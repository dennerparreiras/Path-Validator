using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Path_Validator.App_Code
{
    class DirectoryTree
    {
        public Statistics FolderTreeStats;

        public DirectoryTree(string p_MainPath)
        {
            FolderTreeStats = new Statistics();
            SearchDirectoryTree(p_MainPath);
            FolderTreeStats.FinalReport = GenerateFinalReport();
        }

        private void SearchDirectoryTree(string p_MainPath)
        {
            foreach (string Folder in Directory.GetDirectories(p_MainPath))
            {
                try
                {
                    if (Directory.EnumerateFiles(Folder).Any() || Directory.EnumerateDirectories(Folder).Any() || Directory.EnumerateFileSystemEntries(Folder).Any())
                    {
                        this.FolderTreeStats.FolderWithFiles++;
                        this.FolderTreeStats.FolderWithFilesList.Add(Folder);
                        this.FolderTreeStats.TotalFilesFound += Directory.EnumerateFiles(Folder).ToList().Count;
                        Output.Print(@"[Search Directory] OK: " + Folder);
                    }
                    else
                    {
                        this.FolderTreeStats.EmptyFolder++;
                        this.FolderTreeStats.EmptyFolderList.Add(Folder);
                        Console.WriteLine(@"[Search Directory] Empty: " + Folder);
                    }
                    SearchDirectoryTree(Folder);
                }
                catch (Exception ex)
                {
                    Output.Error(@"SearchDirectoryTree: " + ex.Message, true);
                }
            }
        }

        private string GenerateFinalReport()
        {
            string Report;

            string Header = "\r\n\r\n\r\n";
            Header += "*******************************************************************************************\r\n";
            Header += "                                   RESULTADOS DA BUSCA\r\n";
            Header += "*******************************************************************************************\r\n";
            Header += "\r\n";
            Header += " 	RESUMO:\r\n";
            Header += "				- Diretórios vazios: " + this.FolderTreeStats.EmptyFolder.ToString() + "\r\n";
            Header += "				- Diretórios que possuem pastas ou arquivos: " + this.FolderTreeStats.FolderWithFiles.ToString() + "\r\n";
            Header += "				- Total de diretórios varridos: " + (this.FolderTreeStats.EmptyFolder + this.FolderTreeStats.FolderWithFiles).ToString() + "\r\n";

            Report = Header;

            //Report += "\r\n";
            //Report += "-------------------------------------------------------------------------------------------\r\n";
            //Report += " 	Diretórios vazios\r\n";
            //Report += "-------------------------------------------------------------------------------------------\r\n";
            //Report += "\r\n";

            //foreach(string Folder in this.FolderTreeStats.EmptyFolderList)
            //{
            //    Report += Folder + "\r\n";
            //}

            Report += "\r\n\r\n";

            return Report;
        }
    }
}
