using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Path_Validator
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashClock_Tick(object sender, EventArgs e)
        {
            if (this.SplahProgress.Value < 100)
            {
                this.SplahProgress.Value += 10;
            }
            else
            {
                this.SplashClock.Enabled = false;
                this.Dispose();
            }
        }
    }
}
