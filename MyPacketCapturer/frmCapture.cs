using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;

namespace MyPacketCapturer
{
    public partial class frmCapture : Form
    {
        CaptureDeviceList devices;
        public static ICaptureDevice device;
        public static string stringPackets = "";
        static int numPackets = 0;
        Boolean blockAll = false;
        frmSend fSend; //class variable for the send window form
        frmSmurf fSmurf;
        frmARPPoison fARP;

        public frmCapture()
        {
            InitializeComponent();
            devices = CaptureDeviceList.Instance;

            if (devices.Count < 1)
            {
                MessageBox.Show("No Capture Devices Found!!");
                Application.Exit();
            }

            foreach(ICaptureDevice dev in devices)
            {
                cmbDevices.Items.Add(dev.Description);
            }

            device = devices[0];
            cmbDevices.Text = device.Description;

            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);


            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs packet) 
        {
            //Increment
            numPackets ++;

            //Put the packet number in the capture window
            stringPackets += "Packet Number: " + Convert.ToString(numPackets);
            stringPackets += Environment.NewLine;

            //Array to store data
            byte[] data = packet.Packet.Data;

            //Count bytes
            int byteCounter = 0;


            stringPackets += "Destination MAC Address: ";
            //Parsing the packets
            foreach (byte b in data)
            {
                if (byteCounter <= 13)
                {
                    stringPackets += b.ToString("X2") + " ";
                }
                byteCounter++;

                switch (byteCounter)
                {
                    case 6: stringPackets += Environment.NewLine;
                        stringPackets += "Source MAC Address: ";
                        break;
                    case 12: stringPackets += Environment.NewLine;
                        stringPackets += "EtherType: ";
                        break;
                    case 14: if (data[12] == 8 )
                        {
                            if (data[13] == 0)
                            {
                                stringPackets += "(IP)";
                                if (data[14] ==69)
                                {
                                    stringPackets += " Version 4";
                                }
                            }
                            if (data[13] == 6)
                            {
                                stringPackets += "(ARP)";
                            }
                        }
                        break;
                   /** case 22: stringPackets += Environment.NewLine;
                        stringPackets += "Time To Live: ";
                        break;
                    case 23: stringPackets += Environment.NewLine;
                        stringPackets += "Protocol: ";
                        if (data[23] == 6)
                        {
                            stringPackets += "TCP";
                        }
                        else if (data[23] == 17)
                        {
                            stringPackets += "UDP";
                        }
                        break;**/
                }
            }


            byteCounter = 0;
            stringPackets += Environment.NewLine + Environment.NewLine + "Raw Data" + Environment.NewLine;

            //Process each byte
            foreach (byte b in data)
            {
                stringPackets += b.ToString("X2") + " ";
                byteCounter++;

                if (byteCounter == 16)
                {
                    byteCounter = 0;
                    stringPackets += Environment.NewLine;
                }
            }
            stringPackets += Environment.NewLine;
            stringPackets += Environment.NewLine;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartStop.Text == "Start")
                {
                    device.StartCapture();
                    timer1.Enabled = true;
                    btnStartStop.Text = "Stop";
                }
                else
                {
                    device.StopCapture();
                    timer1.Enabled = false;
                    btnStartStop.Text = "Start";
                }
            } catch (Exception exp)
            {
                 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCapturedData.AppendText(stringPackets);
            stringPackets = "";
            txtNumPackets.Text = Convert.ToString(numPackets);
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = devices[cmbDevices.SelectedIndex];
            cmbDevices.Text = device.Description;
            txtGUID.Text = device.Name;

            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog1.Title = "Save Captured Packets";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtCapturedData.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog1.Title = "Open Captured Packets";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                txtCapturedData.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCapturedData.Text = "";
            txtNumPackets.Text = "0";
        }

        private void sendWindwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSend.instantiations == 0)
            {
                fSend = new frmSend(); //Creates a new window
                fSend.Show();

            }
                //add code to have a popup   
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sMURFAttackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSmurf.instantiations == 0)
            {
                fSmurf = new frmSmurf(); //Creates a new window
                fSmurf.Show();

            }
            //add code to have a popup   

        }

        private void aRPCachePoisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmARPPoison.instantiation == 0)
            {
                fARP = new frmARPPoison();
                fARP.Show();
            }
        }
    }
}
