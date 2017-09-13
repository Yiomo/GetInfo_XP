using System;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.IO;

namespace GetInfo_XP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string machineName = Environment.MachineName;
            label2.Text = machineName;

            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    label3.Text = mo["Manufacturer"].ToString();
                }
            }

            string PCM = "";
            foreach (ManagementObject mo1 in moc)
            {
                PCM = mo1["Model"].ToString();
            }
            label4.Text = PCM;

            if (IntPtr.Size == 8)
            {
                label5.Text = "64位";
            }
            else if (IntPtr.Size == 4)
            {
                label5.Text = "32位";
            }
            else
            {
                label5.Text = "不支持的系统或CPU";
            }

            try
            {
                using (ManagementClass mc1 = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (ManagementObjectCollection moc1 = mc1.GetInstances())
                    {
                        string macAddress = "";
                        foreach (ManagementObject mo2 in moc1 )
                        {
                            if ((bool)mo2["IPEnabled"]==true)
                            {
                                macAddress = mo2["MacAddress"].ToString();
                                break;
                            }
                        }
                        label6.Text = macAddress;
                    }
                }
            }
            catch { label6.Text = "未知"; }
            finally { }

            ShowIP();

            string IP = "";
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            for (int i = 0;i<addressList.Length;i++)
            {
                IP = addressList[i].ToString();
            }
            label8.Text = IP;

            string HDSN = "";
            string HDMO = "";
            long capacity;
            long totalcapacity = 0;
            ManagementClass mc2 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc2 = mc2.GetInstances();
            foreach (ManagementObject mo3 in moc2)
            {
                HDMO = mo3.Properties["Model"].Value.ToString();
            }
            foreach (ManagementObject mo5 in moc2)
            {
                capacity = Convert.ToInt64(mo5["Size".ToString()].ToString());
                totalcapacity += capacity / 1000 / 1000 / 1000;
            }

            ManagementClass mc3 = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc3 = mc3.GetInstances();
            foreach (ManagementObject mo4 in moc3)
            {
                HDSN = mo4.Properties["SerialNumber"].Value.ToString().Trim();
                break;
            }

            label9.Text = HDMO;
            label10.Text = HDSN;
            label11.Text = totalcapacity.ToString ()+"GB";

            long space;
            long totalspace=0;
            ManagementClass mc4 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc4 = mc4.GetInstances();
            foreach (ManagementObject mo6 in moc4)
            {
                space= Convert.ToInt64(mo6["Capacity".ToString()].ToString());
                totalspace += space/1000/1000/1000;
            }
            label13.Text = totalspace.ToString() + "GB";

            string currentScreenSize = Screen.PrimaryScreen.Bounds.Width.ToString() + " * " + Screen.PrimaryScreen.Bounds.Height.ToString();
            label12.Text = currentScreenSize;

            void ShowIP()
            {
                foreach (string ip in GetLocalIpv4())
                {
                    label7.Text = ip.ToString ();
                }
                return;
            }
            string[] GetLocalIpv4()
            {
                IPAddress[] localIPs;
                localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                StringCollection IPcollection = new StringCollection();
                foreach (IPAddress ip in localIPs)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        IPcollection.Add(ip.ToString ());
                }
                string[] IpArray = new string[IPcollection.Count];
                IPcollection.CopyTo(IpArray, 0);
                return IpArray;
            }
            
        }

        public bool isl1c = false;
        public bool isl2c = false;
        public bool isl3c = false;
        public bool isl4c = false;
        public bool isl5c = false;
        public bool isl6c = false;
        public bool isl7c = false;
        public bool isl8c = false;
        public bool isl9c = false;
        public bool isl10c = false;
        public bool isl11c = false;
        public bool isl12c = false;

        private void label2_Click(object sender, EventArgs e)
        {
            isl1c = !isl1c;
            if (isl1c == true)
            {
                label2.ForeColor = Color.Red;
                textBox1.Text +=label2.Text + "\r\n";
            }
            else
            {
                label2.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label2.Text + "\r\n", "");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            isl2c = !isl2c;
            if (isl2c == true)
            {
                label3.ForeColor = Color.Red;
                textBox1.Text += label3.Text + "\r\n";
            }
            else
            {
                label3.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label3.Text + "\r\n", "");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            isl3c = !isl3c;
            if (isl3c == true)
            {
                label4.ForeColor = Color.Red;
                textBox1.Text += label4.Text + "\r\n";
            }
            else
            {
                label4.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label4.Text + "\r\n", "");
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            isl4c = !isl4c;
            if (isl4c == true)
            {
                label5.ForeColor = Color.Red;
                textBox1.Text += label5.Text + "\r\n";
            }
            else
            {
                label5.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label5.Text + "\r\n", "");
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            isl5c = !isl5c;
            if (isl5c == true)
            {
                label6.ForeColor = Color.Red;
                textBox1.Text += label6.Text + "\r\n";
            }
            else
            {
                label6.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label6.Text + "\r\n", "");
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {
            isl6c = !isl6c;
            if (isl6c == true)
            {
                label7.ForeColor = Color.Red;
                textBox1.Text += label7.Text + "\r\n";
            }
            else
            {
                label7.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label7.Text + "\r\n", "");
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            isl7c = !isl7c;
            if (isl7c == true)
            {
                label8.ForeColor = Color.Red;
                textBox1.Text += label8.Text + "\r\n";
            }
            else
            {
                label8.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label8.Text + "\r\n", "");
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
            isl8c = !isl8c;
            if (isl8c == true)
            {
                label9.ForeColor = Color.Red;
                textBox1.Text += label9.Text + "\r\n";
            }
            else
            {
                label9.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label9.Text + "\r\n", "");
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {
            isl9c = !isl9c;
            if (isl9c == true)
            {
                label10.ForeColor = Color.Red;
                textBox1.Text += label10.Text + "\r\n";
            }
            else
            {
                label10.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label10.Text + "\r\n", "");
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            isl10c = !isl10c;
            if (isl10c == true)
            {
                label11.ForeColor = Color.Red;
                textBox1.Text += label11.Text + "\r\n";
            }
            else
            {
                label11.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label11.Text + "\r\n", "");
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {
            isl11c = !isl11c;
            if (isl11c == true)
            {
                label12.ForeColor = Color.Red;
                textBox1.Text += label12.Text + "\r\n";
            }
            else
            {
                label12.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label12.Text + "\r\n", "");
            }
        }
        private void label13_Click(object sender, EventArgs e)
        {
            isl11c = !isl11c;
            if (isl11c == true)
            {
                label13.ForeColor = Color.Red;
                textBox1.Text += label13.Text + "\r\n";
            }
            else
            {
                label13.ForeColor = Color.Black;
                textBox1.Text = textBox1.Text.Replace(label13.Text + "\r\n", "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\" + label2.Text + ".txt";
            string name = label2.Text;
            if (!File.Exists(path))
            {
                StreamWriter info = new StreamWriter(path);
                textBox1.Text = textBox1.Text.TrimEnd(new char[] {'\n'});
                textBox1.Text = textBox1.Text.TrimEnd(new char[] { '\r' });
                info.Write(textBox1.Text.Replace("\n", "\r\n"));
                info.Flush();
                info.Close();
                DialogResult done = MessageBox.Show("Done.");
                if (done == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(path);
                    Close();
                }
            }
            else
            {
                Rewrite rewrite = new Rewrite();
                textBox1 .Text = textBox1 .Text.TrimEnd(new char[] { '\n' });
                rewrite.getName = name;
                rewrite.getPath = path;
                rewrite.getContent = textBox1 .Text.Replace("\n", "\r\n");
                rewrite.ShowDialog();
            }
        }
    }
}
