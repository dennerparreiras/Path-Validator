using System;
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

namespace Path_Validator
{
    public partial class MainScreen : Form
    {
        private const string path_OK_Files = @"\results\OK_Files";
        private const string path_ERROR_Files = @"\results\Error_Files";

        public string v_Name_OK;
        public string v_Name_Err;

        private int ExecPiece = 0;

        private enum Procedimento
        {
            WEB,
            Arquivo
        }

        public MainScreen()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                this.MainProgress.Value = 0;
                ValidatePath(this.tb_Urls.Text, ((this.rb_Arquivo.Checked) ? Procedimento.Arquivo : Procedimento.WEB));
            //}
            //catch
            //{
            //    Error();
            //}
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog v_OpenDialog = new OpenFileDialog();
                v_OpenDialog.ShowDialog();

                foreach (var item in File.ReadAllLines(v_OpenDialog.FileName))
                {
                    this.tb_Urls.Text += item + "\r\n";
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

            v_Name_OK = GenerateDateName(path_OK_Files);
            v_Name_Err = GenerateDateName(path_ERROR_Files);

            VerifyFileToSave(v_Name_OK);
            VerifyFileToSave(v_Name_Err);

            string[] v_Lines = p_Path.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            switch (p_Proc)
            {
                case Procedimento.WEB:
                    v_Success = ValidateWEB(v_Lines);
                    break;
                case Procedimento.Arquivo:
                default:
                    v_Success = ValidateArquivo(v_Lines);
                    break;
            }

            return v_Success;
        }

        private bool ValidateArquivo(string[] p_Lines)
        {
            foreach (var v_url in p_Lines)
            {

                try
                {

                    if (Directory.Exists(v_url))
                    {
                        using (StreamWriter v_ArquivosCertos = new StreamWriter(v_Name_OK, true))
                        {
                            v_ArquivosCertos.WriteLine(v_url);
                            this.tb_Console.Text += ("[Directory] OK: " + v_url + "\r\n");
                        }
                    }
                    else
                    {
                        using (StreamWriter v_ArquivosErrados = new StreamWriter(v_Name_Err, true))
                        {
                            v_ArquivosErrados.WriteLine(v_url);
                            this.tb_Console.Text += ("[Directory] Not found/Error: " + v_url + "\r\n");
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

                    using (StreamWriter v_ArquivosCertos = new StreamWriter(v_Name_OK, true))
                    {
                        v_ArquivosCertos.WriteLine(v_url);
                        this.tb_Console.Text += ("[WEB] OK: " + v_url + "\r\n");
                    }
                }
                catch (WebException ex)
                {
                    /* A WebException will be thrown if the status of the response is not `200 OK` */
                    using (StreamWriter v_ArquivosErrados = new StreamWriter(v_Name_Err, true))
                    {
                        v_ArquivosErrados.WriteLine(v_url);
                        this.tb_Console.Text += ("[WEB] Not found/Error: " + v_url + "\r\n");
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

        public string GenerateDateName(string p_Name)
        {
            DateTime v_Date = new DateTime();
            return p_Name  + ("_" + v_Date.ToShortDateString() + "_" + v_Date.ToShortTimeString() + ".txt").ToString().Replace("/", "-");
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

        public static void Error(string p_ErrorMessage = "")
        {
            string v_ErrorMessage, v_ErrorTitle;

            v_ErrorMessage = (!String.IsNullOrEmpty(p_ErrorMessage)) ? p_ErrorMessage : "Houve uma falha ao realizar o procedimento.\r\nFavor revisar as configurações de execução.";
            v_ErrorTitle = "Falha durante execução do procedimento!";

            MessageBox.Show(v_ErrorMessage, v_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}