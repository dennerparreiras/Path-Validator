﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using Path_Validator.App_Code;

namespace Path_Validator
{
    public partial class MainScreen : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();


        private void MainScreen_Load(object sender, EventArgs e)
        {
            AllocConsole();
            Console.WriteLine(Constantes.Console.HEADER);
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        public MainScreen()
        {
            InitializeComponent();
        }

        public struct Constantes
        {

            public const string path_Results = @"Results/";

            public struct FileNames
            {
                public const string OK = "OK";
                public const string ERROR = "ERROR";
            }

            public struct Console
            {
                public const string HEADER = @"
###########################################################################################
  _____                               _____                    _               
 |  __ \                             |  __ \                  (_)              
 | |  | | ___ _ __  _ __   ___ _ __  | |__) |_ _ _ __ _ __ ___ _ _ __ __ _ ___ 
 | |  | |/ _ \ '_ \| '_ \ / _ \ '__| |  ___/ _` | '__| '__/ _ \ | '__/ _` / __|
 | |__| |  __/ | | | | | |  __/ |    | |  | (_| | |  | | |  __/ | | | (_| \__ \
 |_____/ \___|_| |_|_| |_|\___|_|_   |_|   \__,_|_|  |_|  \___|_|_|  \__,_|___/

__________         __  .__      ____   ____      .__  .__    .___       __                
\______   \_____ _/  |_|  |__   \   \ /   /____  |  | |__| __| _/____ _/  |_  ___________ 
 |     ___/\__  \\   __\  |  \   \   Y   /\__  \ |  | |  |/ __ |\__  \\   __\/  _ \_  __ \
 |    |     / __ \|  | |   Y  \   \     /  / __ \|  |_|  / /_/ | / __ \|  | (  <_> )  | \/
 |____|    (____  /__| |___|  /    \___/  (____  /____/__\____ |(____  /__|  \____/|__|   
                \/          \/                 \/             \/     \/                  
###########################################################################################";
            }
        }

        public struct GlobalVar
        {
            public static string v_Name_OK;
            public static string v_Name_Err;
            public static int ExecPiece = 0;
        }

        private enum Procedimento
        {
            WEB,
            Arquivo,
            Varredura
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeConsole();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            this.MainProgress.Value = 0;
            this.labelProgress.Text = this.MainProgress.Value.ToString() + "%";

            backgroundWorker.RunWorkerAsync();
            backgroundWorker.CancelAsync();

            this.Cursor = Cursors.Default;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Procedimento v_ProcAtual;

            if (rb_WEB.Checked)
            {
                v_ProcAtual = Procedimento.WEB;
            }
            else if (rb_Varredura.Checked)
            {
                v_ProcAtual = Procedimento.Varredura;
            }
            else
            {
                v_ProcAtual = Procedimento.Arquivo;
            }

            if (!ValidatePath(this.tb_Urls.Text, v_ProcAtual))
            {
                Error();
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            string v_URLs = String.Empty;
            try
            {
                OpenFileDialog v_OpenDialog = new OpenFileDialog();
                v_OpenDialog.ShowDialog();

                if (File.Exists(v_OpenDialog.FileName))
                {
                    foreach (var item in File.ReadAllLines(v_OpenDialog.FileName))
                    {
                        v_URLs += item + "\r\n";
                    }

                    if (v_URLs.Length < Int32.MaxValue)
                    {
                        this.tb_Urls.Text = v_URLs;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    Error("Arquivo de Paths: Verifique o arquivo selecionado e tente novamente.");
                }
            }
            catch
            {
                Error("Arquivo de Paths: Verifique o arquivo selecionado e tente novamente.");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile = new SaveFileDialog();
                SaveFile.Filter = "TXT files|*.txt";
                SaveFile.Title = "Save URLs from INPUT";
                SaveFile.ShowDialog();

                if (SaveFile.FileName != "")
                {
                    using (StreamWriter v_Arquivos = new StreamWriter(SaveFile.FileName, true))
                    {
                        foreach (var line in this.tb_Urls.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
                        {
                            v_Arquivos.WriteLine(line);
                        }
                        v_Arquivos.Close();
                    }

                    ConsoleLog("File saved sucessfully!");
                }
                else
                {
                    Error("The file is not saved!", true);
                }
            }
            catch (Exception ex)
            {
                Error("The file is not saved!", false);
                Error(ex.Message, false);
            }

        }

        private bool ValidatePath(string p_Path, Procedimento p_Proc)
        {

            bool v_Success = false;

            if (VerifyResultsDirectory())
            {
                GlobalVar.v_Name_OK = GenerateFilePath(Constantes.FileNames.OK);
                GlobalVar.v_Name_Err = GenerateFilePath(Constantes.FileNames.ERROR);

                string[] v_Lines = p_Path.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );

                switch (p_Proc)
                {
                    case Procedimento.WEB:
                        v_Success = ValidateWEB(v_Lines);
                        break;
                    case Procedimento.Varredura:
                        {
                            DirectoryTree FolderTree = new DirectoryTree(this.tb_DiretorioPai.Text);
                            Output.Print(FolderTree.FolderTreeStats.FinalReport);
                            v_Success = true;
                        }
                        break;
                    case Procedimento.Arquivo:
                    default:
                        v_Success = ValidateFileDirectories(v_Lines);
                        break;
                }

                return v_Success;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateFileDirectories(string[] p_Lines)
        {
            ProgressDivisor(p_Lines.Length);

            foreach (var v_url in p_Lines)
            {
                try
                {
                    if (Directory.Exists(v_url))
                    {
                        using (StreamWriter v_ArquivosCertos = new StreamWriter(GlobalVar.v_Name_OK, true))
                        {
                            v_ArquivosCertos.WriteLine(v_url);
                            ConsoleLog("[Directory] OK: " + v_url);
                        }
                    }
                    else
                    {
                        using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                        {
                            v_ArquivosErrados.WriteLine(v_url);
                            ConsoleLog("[Directory] Not found/Error: " + v_url);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                }
            }

            return true;
        }

        private bool ValidateWEB(string[] p_Lines)
        {
            ProgressDivisor(p_Lines.Length);

            foreach (var v_url in p_Lines)
            {
                HttpWebResponse response = null;

                try
                {

                    var request = (HttpWebRequest)WebRequest.Create(v_url);
                    request.Method = "HEAD";

                    response = (HttpWebResponse)request.GetResponse();

                    using (StreamWriter v_ArquivosCertos = new StreamWriter(GlobalVar.v_Name_OK, true))
                    {
                        v_ArquivosCertos.WriteLine(v_url);
                        ConsoleLog("[WEB] OK: " + v_url);
                    }
                }
                catch 
                {
                    /* A WebException will be thrown if the status of the response is not `200 OK` */
                    using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                    {
                        v_ArquivosErrados.WriteLine(v_url);
                        ConsoleLog("[WEB] Not found/Error: " + v_url);
                    }
                }
                finally
                {
                    /* Close your response. */
                    if (response != null)
                    {
                        response.Close();
                    }
                }
            }
            return true;
        }

        private bool SearchDirectoryTree(string p_MainPath)
        {
            ProgressDivisor(100);

            foreach (string d in Directory.GetDirectories(p_MainPath))
            {

                try
                {
                    if (Directory.EnumerateFiles(d).Any() || Directory.EnumerateDirectories(d).Any() || Directory.EnumerateFileSystemEntries(d).Any())
                    {
                        using (StreamWriter v_ArquivosCertos = new StreamWriter(GlobalVar.v_Name_OK, true))
                        {
                            ConsoleLog(@"[Search Directory] OK: " + d);
                            v_ArquivosCertos.WriteLine(d);
                        }
                    }
                    else
                    {
                        ConsoleLog(@"[Search Directory] Empty: " + d);
                        using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                        {
                            v_ArquivosErrados.WriteLine(d);
                        }
                    }
                    SearchDirectoryTree(d);
                }
                catch (Exception ex)
                {
                    Error(@"SearchDirectoryTree: " + ex.Message, true);
                }
            }

            return true;
        }

        public string GenerateFilePath(string p_Name)
        {
            DateTime v_Date = DateTime.Now;
            string v_FileName = ToSafeFileName(p_Name + ("_" + v_Date.ToShortDateString().Replace("/", "-") + "_" + v_Date.ToShortTimeString() + ".txt"));
            return Path.Combine(Constantes.path_Results, v_FileName);
        }

        public static string ToSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }

        public static void VerifyFileToSave(string p_FilePath)
        {

            if (File.Exists(p_FilePath))
            {
                File.Delete(p_FilePath);
            }
            else
            {
                File.Create(p_FilePath);
            }
        }

        public void Error(string p_ErrorMessage = "", bool p_IgnoreMessageBox = false)
        {
            string v_ErrorMessage, v_ErrorTitle;

            v_ErrorMessage = (!String.IsNullOrEmpty(p_ErrorMessage)) ? p_ErrorMessage : @"Houve uma falha ao realizar o procedimento.\r\nFavor revisar as configurações de execução.";
            v_ErrorTitle = @"Alerta";

            ConsoleLog(@"[ERROR] | " + v_ErrorTitle + @": " + v_ErrorMessage);

            if (!p_IgnoreMessageBox)
            {
                MessageBox.Show(v_ErrorMessage, v_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProgressDivisor(int p_Length)
        {
            if ((int)(p_Length / 100) == 0)
            {
                GlobalVar.ExecPiece = (int)(100);
            }
            else
            {
                GlobalVar.ExecPiece = (int)(p_Length / 100);
            }
        }

        private void rb_Varredura_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_DiretorioPai.Enabled = (bool)(this.rb_Varredura.Checked);
            this.tb_DiretorioPai.Visible = (bool)(this.rb_Varredura.Checked);
            this.SelectDirectoryButton.Enabled = (bool)(this.rb_Varredura.Checked);
            this.SelectDirectoryButton.Visible = (bool)(this.rb_Varredura.Checked);
        }

        private bool VerifyResultsDirectory()
        {
            bool v_isOK = false;

            try
            {
                if (Directory.Exists(Constantes.path_Results))
                {
                    return true;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(Constantes.path_Results);

                if (Directory.Exists(Constantes.path_Results))
                {
                    v_isOK = true;
                }
                else
                {
                    v_isOK = false;
                }
            }
            catch
            {
                v_isOK = false;
            }

            return v_isOK;
        }

        public void ConsoleLog(string p_Message = "Action executed.")
        {
            Console.WriteLine(p_Message);
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            this.fb_DiretorioPai.ShowDialog();
            this.tb_DiretorioPai.Text = this.fb_DiretorioPai.SelectedPath.ToString();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.MainProgress.Value = e.ProgressPercentage;
            this.labelProgress.Text = this.MainProgress.Value.ToString() + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.MainProgress.Value = 100;
            this.labelProgress.Text = this.MainProgress.Value.ToString() + "%";
            this.Enabled = true;

            MessageBox.Show("A execução do procedimento foi finalizada.\r\nVerifique os arquivos de log para avaliar os resultados obtidos.", "Concluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}