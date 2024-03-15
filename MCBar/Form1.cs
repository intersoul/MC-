using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using Image = System.Drawing.Image;
using MCBar.Properties;

namespace MCBar
{
   
    public partial class Form1 : Form
    {
        public int mheight { get; private set; }
        public int AvailablePhysicalMemory{ get; private set; }
        public int BatteryPercent { get; private set; }
        //private Icon Button1Icon;
        //private string Button1path;
        private string[] buttonPaths = new string[10]; 
        private Icon[] ButtonIcons = new Icon[8];
        private Point mPoint;
        //private int mheight;
        Image image1, image2;

        /*        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
                public static extern bool GetSystemPowerStatus(ref SystemPowerStatus systemPowerStatus);
        */
        public Form1()
        {
            //buttonPaths[1] = "hello world";
            InitializeComponent();

            //隐藏标题栏
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(37, 34, 23);
            this.BackColor = Color.FromArgb(37, 34, 23);

            //初始化按钮路径
            InitializeButtonPaths();
            for (int i = 0; i < 8; i++)
            {
                
                if (lines[i] == "error")
                {
                    continue;
                }
                else
                {
                    buttonPaths[i] = lines[i];
                    ButtonIcons[i] = Icon.ExtractAssociatedIcon(buttonPaths[i]);
                }
               
            }
            buttonPaths[8] = lines[8];
            buttonPaths[9] = lines[9];
            this.Location = new Point(int.Parse(buttonPaths[8]), int.Parse(buttonPaths[9]));
            
            //button1.Invalidate();
        }

        private void myuser()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject myobj in searcher.Get())
            {
                mheight = Convert.ToInt32(myobj["LoadPercentage"]);
            }
            // 更新label1的文本内容为mheight的值
            //label1.Text = "CPU 使用率: " + mheight.ToString() + "%";
            Jievalue = (int)((float)mheight / 10 + 1);
            //label1.Text = "CPU 使用率: " + Jievalue.ToString() + "%";
            //Jievalue = (int)Math.Ceiling((double)mheight / 10);
            panel3.Invalidate();
        }


        //获取内存占用
        private void PhysicalMemory()
        {
            Computer myinfo = new Computer();
            //总内存
            var TotalPhysicalMemory = myinfo.Info.TotalPhysicalMemory / 1024 / 1024 ;
            //this.label3.Text = TotalPhysicalMemory.ToString();
            //可用内存
            AvailablePhysicalMemory = (int)(myinfo.Info.AvailablePhysicalMemory / 1024 / 1024);
            //this.label2.Text = AvailablePhysicalMemory.ToString();
            //label2.Text = "内存 可使用: " + AvailablePhysicalMemory.ToString() + " MB";
            EXPvalue = (int)(((float) TotalPhysicalMemory - (float)AvailablePhysicalMemory) / (float)TotalPhysicalMemory * 396);
            //MessageBox.Show(temp.ToString());
            panel1.Invalidate();

        }

        //电量表示
        public enum ACLineStatus_ : byte
        {
            Offline = 0,
            Online = 1,  // 
            UnknowStatus = 255  // 未知
        }

        public enum BatteryFlag_ : byte
        {  // 虽然是枚举，但可以有多个值
            Middle = 0,  // 电池未充电并且电池容量介于高电量和低电量之间
            High = 1,  // 电池电量超过66％
            Low = 2,  // 电池电量不足33％
            Critical = 4,  // 电池电量不足百分之五
            Charging = 8,  // 	充电中
            NoSystemBattery = 128,  // 无系统电池
            UnknowStatus = 255  // 无法读取电池标志信息
        }

        public enum SystemStatusFlag_ : byte
        {
            Off = 0,  //  节电功能已关闭
            On = 1  //  节电功能已打开，节省电池。尽可能节约能源
        }

        public struct SystemPowerStatus
        {  // 顺序不可更改
            public ACLineStatus_ ACLineStatus;  // 交流电源状态
            public BatteryFlag_ BatteryFlag;  // 电池充电状态
            public byte BatteryLifePercent;  // 剩余电量的百分比。该成员的值可以在0到100的范围内，如果状态未知，则可以是255
            public SystemStatusFlag_ SystemStatusFlag;  //  省电模式
            public int BatteryLifeTime;  //  剩余电池寿命的秒数。如果未知剩余秒数或设备连接到交流电源，则为–1
            public int BatteryFullLifeTime;  // 充满电时的电池寿命秒数。如果未知电池的完整寿命或设备连接到交流电源，则为–1。
        }


        [DllImport("Kernel32.dll")]
        public static extern bool GetSystemPowerStatus(ref SystemPowerStatus systemPowerStatus);

        private void Battery()
        {
            SystemPowerStatus status = new SystemPowerStatus();
            if (GetSystemPowerStatus(ref status))
            {  // 如果成功调用
                //Console.WriteLine("当前电量：" + status.BatteryLifePercent + "%");
                BatteryPercent = status.BatteryLifePercent;
                //label3.Text = "电量: " + status.BatteryLifePercent.ToString() + " %";
                Hreadvalue = status.BatteryLifePercent/10;
                panel2.Invalidate();
            }

        }
        //定时器更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            //异步定时器
            Task.Run(() =>
            {
                myuser();
                PhysicalMemory();
                Battery();
            });
        }

        //按钮控件

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button1.BackgroundImage = image1;
            //button1.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.qian;
            button1.BackgroundImage = image2;
            //button1.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\qian.png");
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect= DragDropEffects.None;
            }
        }

        private void button1_DragLeave(object sender, EventArgs e)
        {

        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[0] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[0] = Icon.ExtractAssociatedIcon(buttonPaths[0]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button1.Invalidate();
            //MessageBox.Show(buttonPaths[0]);
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[0] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[0], destRect);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(buttonPaths[0] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[0]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }

        }


        /* Button2*/
        //private Icon Button2Icon;
        //private string Button2path;
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button2.BackgroundImage = image1;
            //button2.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button2.BackgroundImage = image2;
            //button2.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button2_DragLeave(object sender, EventArgs e)
        {

        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[1] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[1] = Icon.ExtractAssociatedIcon(buttonPaths[1]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button2.Invalidate();
            //MessageBox.Show(buttonPaths[1]);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[1] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[1], destRect);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (buttonPaths[1] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[1]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }

        }



        /* Button3*/
        //private Icon Button3Icon;
        //private string Button3path;
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button3.BackgroundImage = image1;
            //button3.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button3.BackgroundImage = image2;
            button3.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button3_DragLeave(object sender, EventArgs e)
        {

        }

        private void button3_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[2] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[2] = Icon.ExtractAssociatedIcon(buttonPaths[2]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button3.Invalidate();
            //MessageBox.Show(buttonPaths[2]);
        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[2] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[2], destRect);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonPaths[2] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[2]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }

        /* Button4*/
        //private Icon Button4Icon;
        //private string Button4path;
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button4.BackgroundImage = image1;
            //button4.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button4.BackgroundImage = image2;
            //button4.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button4_DragLeave(object sender, EventArgs e)
        {

        }

        private void button4_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[3] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[3] = Icon.ExtractAssociatedIcon(buttonPaths[3]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button4.Invalidate();
            //MessageBox.Show(buttonPaths[3]);
        }

        private void button4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[3] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[3], destRect);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (buttonPaths[3] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[3]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }

        /* Button5*/
        //private Icon Button5Icon;
        //private string Button5path;
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button5.BackgroundImage = image1;
            //button5.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button5.BackgroundImage = image2;
            //button5.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button5_DragLeave(object sender, EventArgs e)
        {

        }

        private void button5_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[4] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[4] = Icon.ExtractAssociatedIcon(buttonPaths[4]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button5.Invalidate();
            //MessageBox.Show(buttonPaths[4]);
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[4] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[4], destRect);
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (buttonPaths[4] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[4]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }


        /* Button6*/
       //private Icon Button6Icon;
        //private string Button6path;
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button6.BackgroundImage = image1;
            //button6.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button6.BackgroundImage = image2;
            //button6.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button6_DragLeave(object sender, EventArgs e)
        {

        }

        private void button6_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[5] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[5] = Icon.ExtractAssociatedIcon(buttonPaths[5]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button6.Invalidate();
            //MessageBox.Show(buttonPaths[5]);
        }

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[5] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[5], destRect);
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (buttonPaths[5] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[5]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }

        /* Button7*/
        //private Icon Button7Icon;
        //private string Button7path;
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button7.BackgroundImage = image1;
            //button7.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button7.BackgroundImage = image2;
            //button7.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\zhong.png");
        }

        private void button7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button7_DragLeave(object sender, EventArgs e)
        {

        }

        private void button7_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[6] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[6] = Icon.ExtractAssociatedIcon(buttonPaths[6]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button7.Invalidate();
            //MessageBox.Show(buttonPaths[6]);
        }

        private void button7_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[6] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[6], destRect);
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (buttonPaths[6] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[6]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }


        /* Button8*/
        //private Icon Button8Icon;
        //private string Button8path;


        private void button8_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button8.BackgroundImage = image1;
            //button8.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.zhong;
            button8.BackgroundImage = image2;
            //button8.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\\\zhong.png");
        }

        private void button8_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void button8_DragLeave(object sender, EventArgs e)
        {

        }

        private void button8_DragDrop(object sender, DragEventArgs e)
        {
            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            buttonPaths[7] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ButtonIcons[7] = Icon.ExtractAssociatedIcon(buttonPaths[7]);
            //Icon icon = Icon.ExtractAssociatedIcon(path);

            /*            if (icon != null)
                        {
                            button1.BackgroundImage = icon.ToBitmap();
                        }*/

            // 强制重绘按钮以应用新的图标
            button8.Invalidate();
            //MessageBox.Show(buttonPaths[7]);
        }

        private void button8_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 6, 6, 33, 32);
            if (ButtonIcons[7] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 32, 32); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[7], destRect);
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (buttonPaths[7] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[7]);
            }
            else
            {
                MessageBox.Show("请放入文件");
            }
        }


        /* Button9*/
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            image1 = Properties.Resources.liang;
            button8.BackgroundImage = image1;
            button9.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\liang.png");
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            image2 = Properties.Resources.hou;
            button9.BackgroundImage = image2;
            //button9.BackgroundImage = new Bitmap("C:\\D\\Project\\winform\\MCBar\\MCBar\\Resources\\hou.png");
        }
        private void button9_Paint(object sender, PaintEventArgs e)
        {
/*            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
            SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            g.FillRectangle(Buttonback, 5, 6, 34, 32);*/

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //保存关闭的位置。
            buttonPaths[8] = this.Location.X.ToString();
            buttonPaths[9] = this.Location.Y.ToString();

            // 这里添加你的数据保存代码
            SaveData();
            try
            {
                e.Cancel = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SaveData()
        {
            string filePath = "pathcfg.txt";

            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                // 如果不存在，则创建新文件
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // 将数据写入文件
                for (int i = 0; i < 10; i++)
                {
                    if(buttonPaths[i] == null)
                    {
                        writer.WriteLine("error");
                    }
                    else
                    {
                        string buttonPath = buttonPaths[i];
                        writer.WriteLine($"{buttonPath}");
                    }

                }
            }
        }
        //读文件
        private string[] lines;
        private void InitializeButtonPaths()
        {
            string filePath = "pathcfg.txt";
            string[] buttonPaths = new string[10];

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Items item = new Items();
            item.ShowDialog();
        }

            /*            item.Visible = false; // 将窗体设置为不可见
                        ShowDialog(item);*/



        //经验条
        private int EXPvalue;
        private int width;
        private int height;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            width = panel1.Width;
            height = panel1.Height;

            //填充背景
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(60, 74, 57));

            e.Graphics.FillRectangle(solidBrush, 2, 2, width - 4, height - 4);

            solidBrush.Color = Color.FromArgb(161, 223, 119);
            e.Graphics.FillRectangle(solidBrush, 2, 2, EXPvalue - 4, height - 4);
            // 创建一个2像素宽的黑色画笔对象
            Pen blackPen = new Pen(Color.Black, 2);

            // 第一排
            e.Graphics.DrawLine(blackPen, 1, 1, width - 2, 0); // 顶部线条

            // 最后一排
            e.Graphics.DrawLine(blackPen, 2, height - 1, width - 2, height - 1); // 底部线条

            // 第一列
            e.Graphics.DrawLine(blackPen, 1, 1, 0, height - 2); // 左侧线条

            // 最后一列
            e.Graphics.DrawLine(blackPen, width - 1, 1, width - 2, height - 2); // 右侧线条


            // 根据panel高度的两倍绘制竖线
            for (int y = height * 2; y < width; y += height * 2)
            {
                e.Graphics.DrawLine(blackPen, y, 1, y, height - 2);
            }
            // 释放资源
            blackPen.Dispose();
            solidBrush.Dispose();
        }
        //血条
        private int Hreadvalue;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int width2 = panel2.Width;
            int height2 = panel2.Height;
            int height3 = 1;
            // 创建画笔对象
            Pen redPen = new Pen(Color.Black, 1);

            for (int x = 0; x < 10; x++)
            {
                // 绘制爱心
                Point[] heartShape = new Point[]
                {
                new Point(height2 / 2+height3    ,     height2 / 4),
                new Point(height2 / 6*2+height3  ,     1),
                new Point(height2 / 6+height3    ,     1),
                new Point(height3                ,     height2 / 5),
                new Point(height3                ,     height2 /2),
                new Point(height2 / 2+height3    ,     height2-1),
                new Point(height2-1+height3      ,     height2 /2),
                new Point(height2-1+height3      ,     height2 / 5),
                new Point(height2 / 6*5+height3  ,     1),
                new Point(height2 / 6*4+height3  ,     1),
                new Point(height2 / 2+height3    ,     height2 / 4),
                };
                // 创建填充刷子对象
                SolidBrush redBrush = new SolidBrush(Color.Red);
                // 绘制填充的爱心
                if (x < Hreadvalue)
                {
                    e.Graphics.FillClosedCurve(redBrush, heartShape);

                    redBrush.Color = Color.White;
                    e.Graphics.FillRectangle(redBrush, height2 / 6 + height3, height2 / 4, height2 / 6, height2 / 6);
                }

                e.Graphics.DrawCurve(redPen, heartShape);
                height3 += height2;
                redBrush.Dispose();
            }
            redPen.Dispose();

        }
        //饥饿值
        private int Jievalue;
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int width3 = panel3.Width;
            int height3 = panel3.Height;
            int height4 = 0;
            // 创建画笔对象
            Pen hungryPen = new Pen(Color.Black, 1);

            for (int x = 0; x < 10; x++)
            {
                // 绘制饥饿
                Point[] hungryShape = new Point[]
                {
                new Point(height3 / 3+height4    ,     1),
                new Point(height4              ,     height3 / 3),
                new Point(height3 / 5+height4    ,     height3 / 3*2),
                new Point(height3 / 2+height4    ,  height3 / 3*2),
                new Point(height3 / 5*4+height4    ,     height3-1),
                new Point(height3-2+height4    ,     height3 / 10 *9),
                new Point(height3 / 3 * 2+height4      ,     height3 / 5*3),
                new Point(height3 / 3 *2+height4     ,     height3 / 4),
                new Point(height3 / 3+height4    ,     1),
                };

                Point[] hungryligthShape = new Point[]
                {
                new Point(height3 / 3+height4    ,     1),
                new Point(height4              ,     height3 / 3),
                new Point(height3 / 10+height4    ,     height3 / 3*2),
                new Point(height3 / 2+1+height4    ,     height3 /20 *17+1),
                new Point(height3 / 3+height4   ,     1),
                };
                // 创建填充刷子对象
                SolidBrush hungryBrush = new SolidBrush(Color.FromArgb(91, 56, 34));
                if (x < Jievalue)
                {
                    // 绘制填充的饥饿
                    e.Graphics.FillClosedCurve(hungryBrush, hungryShape);
                    //填充红色
                    hungryBrush.Color = Color.FromArgb(174, 1, 19);
                    e.Graphics.FillClosedCurve(hungryBrush, hungryligthShape);
                }

                //外部线条
                e.Graphics.DrawCurve(hungryPen, hungryShape);
                height4 += height3;

            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized) // 当程序是最小化的状态时显示程序页面
                {
                    this.WindowState = FormWindowState.Normal;
                }

                this.Activate();
                this.Visible = true;
                this.ShowInTaskbar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Set_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(buttonPaths[9]);
            this.Location = new Point(int.Parse(buttonPaths[8]), int.Parse(buttonPaths[9]));
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //保存关闭的位置。
            buttonPaths[8] = this.Location.X.ToString();
            buttonPaths[9] = this.Location.Y.ToString();

            SaveData();
            if (result == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }
    }
}
