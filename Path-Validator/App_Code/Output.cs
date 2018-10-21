using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Path_Validator.App_Code
{
    static class Output
    {
        public static void Error(string p_ErrorMessage = "", bool p_IgnoreMessageBox = false)
        {
            string v_ErrorMessage, v_ErrorTitle;

            v_ErrorMessage = (!String.IsNullOrEmpty(p_ErrorMessage)) ? p_ErrorMessage : @"Houve uma falha ao realizar o procedimento.\r\nFavor revisar as configurações de execução.";
            v_ErrorTitle = @"Alerta";

            Print(@"[ERROR] | " + v_ErrorTitle + @": " + v_ErrorMessage);

            if (!p_IgnoreMessageBox)
            {
                MessageBox.Show(v_ErrorMessage, v_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Print(string p_Message = "Action executed.")
        {
            Console.WriteLine(p_Message);
        }
    }
}
