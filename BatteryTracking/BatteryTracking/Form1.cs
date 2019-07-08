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
                    float batteryPercent; 
                    BatteryChargeStatus chargeStatus = CheckBatteryChargeStatus();
                    switch (chargeStatus)
                    {
                        case BatteryChargeStatus.Critical:
                            await Task.Delay(450000);//45minutes
                            break;
                        case BatteryChargeStatus.Low:
                            await Task.Delay(450000);//45minutes
                            break;
                        case BatteryChargeStatus.High:
                            {
                                batteryPercent = CheckBatteryLifePercent();
                                if (batteryPercent == 100)
                                {
                                    MessageBox.Show("Please Activate Save Mode");
                                    await Task.Delay(5000);//5second
                                }
                                else await Task.Delay(50000);//5minutes
                            }
                            break;
                        default:
                            break;
                    } 
                }
            });

        }

        public float CheckBatteryLifePercent()
        {
            return SystemInformation.PowerStatus.BatteryLifePercent * 100;
                    
        }
        public BatteryChargeStatus CheckBatteryChargeStatus()
        {
            return SystemInformation.PowerStatus.BatteryChargeStatus;
        }
    }
}
