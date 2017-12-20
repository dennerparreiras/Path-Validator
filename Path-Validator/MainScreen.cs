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

namespace Path_Validator
{

    public partial class MainScreen : Form
    {
        public struct Constantes
        {
            public const string path_Results = @"Results/";

            public struct FileNames
            {
                public const string OK = "OK";
                public const string ERROR = "ERROR";
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

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //NativeMethods.AllocConsole();
            //Console.WriteLine("Debug Console");
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            this.MainProgress.Value = 0;
            if (!ValidatePath(this.tb_Urls.Text, ((this.rb_Arquivo.Checked) ? Procedimento.Arquivo : Procedimento.WEB)))
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
            catch
            {
                Error("Falha ao abrir arquivo!\r\nVerifique o arquivo selecionado e tente novamente.");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private bool ValidatePath(string p_Path, Procedimento p_Proc)
        {
            bool v_Success = false;

            if (VerifyResultsDirectory())
            {
                GlobalVar.v_Name_OK = GenerateFilePath(Constantes.FileNames.OK);
                GlobalVar.v_Name_Err = GenerateFilePath(Constantes.FileNames.ERROR);

                //VerifyFileToSave(GlobalVar.v_Name_OK);
                //VerifyFileToSave(GlobalVar.v_Name_Err);

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
                        v_Success = WipeDirectories(v_Lines);
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
            foreach (var v_url in p_Lines)
            {
                try
                {
                    if (Directory.Exists(v_url))
                    {
                        using (StreamWriter v_ArquivosCertos = new StreamWriter(GlobalVar.v_Name_OK, true))
                        {
                            v_ArquivosCertos.WriteLine(v_url);
                            ConsoleLog("[Directory] OK: " + v_url + "\r\n");
                        }
                    }
                    else
                    {
                        using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                        {
                            v_ArquivosErrados.WriteLine(v_url);
                            ConsoleLog("[Directory] Not found/Error: " + v_url + "\r\n");
                        }
                    }

                }
                catch (Exception ex)
                {
                    ConsoleLog(ex.Message);
                }
            }

            return true;
        }

        private bool ValidateWEB(string[] p_Lines)
        {
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
                        ConsoleLog("[WEB] OK: " + v_url + "\r\n");
                    }
                }
                catch (WebException ex)
                {
                    /* A WebException will be thrown if the status of the response is not `200 OK` */
                    using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                    {
                        v_ArquivosErrados.WriteLine(v_url);
                        ConsoleLog("[WEB] Not found/Error: " + v_url + "\r\n");
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

        private bool WipeDirectories(string[] p_Lines)
        {
            foreach (var v_url in p_Lines)
            {

                try
                {

                    if (Directory.Exists(v_url))
                    {
                        using (StreamWriter v_ArquivosCertos = new StreamWriter(GlobalVar.v_Name_OK, true))
                        {
                            v_ArquivosCertos.WriteLine(v_url);
                            ConsoleLog("[Directory] OK: " + v_url + "\r\n");
                        }
                    }
                    else
                    {
                        using (StreamWriter v_ArquivosErrados = new StreamWriter(GlobalVar.v_Name_Err, true))
                        {
                            v_ArquivosErrados.WriteLine(v_url);
                            ConsoleLog("[Directory] Not found/Error: " + v_url + "\r\n");
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Falha ao executar o procedimento para validação de diretórios.");
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

        public void Error(string p_ErrorMessage = "")
        {
            string v_ErrorMessage, v_ErrorTitle;

            v_ErrorMessage = (!String.IsNullOrEmpty(p_ErrorMessage)) ? p_ErrorMessage : "Houve uma falha ao realizar o procedimento.\r\nFavor revisar as configurações de execução.";
            v_ErrorTitle = "Falha durante execução do procedimento!";

            ConsoleLog("[ERROR]" + v_ErrorTitle + ": " + v_ErrorMessage);
            MessageBox.Show(v_ErrorMessage, v_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rb_Varredura_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_DiretorioPai.Enabled = (bool)(this.rb_Varredura.Checked);
            this.tb_DiretorioPai.Visible = (bool)(this.rb_Varredura.Checked);
            this.labelDiretorioPai.Visible = (bool)(this.rb_Varredura.Checked);
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
            //this.tb_Console.Text += p_Message;
            //System.Diagnostics.Debug.WriteLine(p_Message);
            Console.WriteLine(p_Message);
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            this.fb_DiretorioPai.ShowDialog();
            this.tb_DiretorioPai.Text = this.fb_DiretorioPai.SelectedPath.ToString();
        }
    }
}