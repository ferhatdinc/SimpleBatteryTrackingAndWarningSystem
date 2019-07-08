using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryTracking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var task = Task.Run(async () =>
            {
                for (; ; )
                {
                    await Task.Delay(30000);
                    float batteryPercent = CheckBatteryLifePercent();
                    
                    if (batteryPercent == 100)
                    {
                        MessageBox.Show("Pili Koruma Moduna Al : " + batteryPercent + "%");
                    }
                }
            });

        }

        public float CheckBatteryLifePercent()
        {
            return SystemInformation.PowerStatus.BatteryLifePercent * 100;
        }
    }
}
