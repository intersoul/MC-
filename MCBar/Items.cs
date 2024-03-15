using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MCBar
{
    public partial class Items : Form
    {
        private string[] buttonPaths = new string[20];
        private Icon[] ButtonIcons = new Icon[20];
        private Point mPoint;

        public Items()
        {
            InitializeComponent();

            Form1 form1Instance = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            //隐藏标题栏
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.FromArgb(37, 34, 23);
            this.BackColor = Color.FromArgb(37, 34, 23);

            //初始化按钮路径
            InitializeButtonPaths();
            for (int i = 0; i < 20; i++)
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

            if (form1Instance != null)
            {
                int mheight = form1Instance.mheight;
                int AvailablePhysicalMemory = form1Instance.AvailablePhysicalMemory;
                int BatteryPercent = form1Instance.BatteryPercent;

                label2.Text = "CPU: " + mheight.ToString() + "%";
                label3.Text = "内存: " + AvailablePhysicalMemory.ToString() + " MB";
                label4.Text = "电量: " + BatteryPercent.ToString() + " %";

                // 在这里可以使用获取到的数据进行操作
            }

        }

        private void button1_DragEnter(object sender, DragEventArgs e)
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

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[0] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[0] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button1.Invalidate();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[0] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[0], destRect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonPaths[0] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[0]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
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

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[1] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[1] = Icon.ExtractAssociatedIcon(buttonPaths[1]);

            // 强制重绘按钮以应用新的图标
            button2.Invalidate();
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[1] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
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

        private void button3_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[2] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[2] = Icon.ExtractAssociatedIcon(buttonPaths[2]);

            // 强制重绘按钮以应用新的图标
            button3.Invalidate();
        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[2] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
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

        private void button4_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[3] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[3] = Icon.ExtractAssociatedIcon(buttonPaths[3]);

            // 强制重绘按钮以应用新的图标
            button4.Invalidate();
        }

        private void button4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[3] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
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

        private void button5_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[4] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[4] = Icon.ExtractAssociatedIcon(buttonPaths[4]);

            // 强制重绘按钮以应用新的图标
            button5.Invalidate();
        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[4] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[4], destRect);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (buttonPaths[4] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[0]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
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

        private void button6_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[5] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[5] = Icon.ExtractAssociatedIcon(buttonPaths[5]);

            // 强制重绘按钮以应用新的图标
            button6.Invalidate();
        }

        private void button6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[5] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[0], destRect);
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

        private void button7_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[6] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[6] = Icon.ExtractAssociatedIcon(buttonPaths[6]);

            // 强制重绘按钮以应用新的图标
            button7.Invalidate();
        }

        private void button7_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[6] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
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

        private void button8_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[7] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[7] = Icon.ExtractAssociatedIcon(buttonPaths[7]);

            // 强制重绘按钮以应用新的图标
            button8.Invalidate();
        }

        private void button8_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[7] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[7], destRect);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buttonPaths[7] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[0]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button9_DragEnter(object sender, DragEventArgs e)
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

        private void button9_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[8] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[8] = Icon.ExtractAssociatedIcon(buttonPaths[8]);

            // 强制重绘按钮以应用新的图标
            button9.Invalidate();
        }

        private void button9_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[8] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[8], destRect);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (buttonPaths[8] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[8]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button10_DragEnter(object sender, DragEventArgs e)
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

        private void button10_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[9] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[9] = Icon.ExtractAssociatedIcon(buttonPaths[9]);

            // 强制重绘按钮以应用新的图标
            button10.Invalidate();
        }

        private void button10_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[9] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[9], destRect);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (buttonPaths[9] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[9]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button11_DragEnter(object sender, DragEventArgs e)
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

        private void button11_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[10] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[10] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button11.Invalidate();
        }

        private void button11_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[10] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[10], destRect);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (buttonPaths[10] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[10]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button12_DragEnter(object sender, DragEventArgs e)
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

        private void button12_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[11] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[11] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button12.Invalidate();
        }

        private void button12_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[11] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[11], destRect);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (buttonPaths[11] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[11]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button13_DragEnter(object sender, DragEventArgs e)
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

        private void button13_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[12] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[12] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button13.Invalidate();
        }

        private void button13_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[12] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[12], destRect);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (buttonPaths[12] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[12]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }
        private void button14_DragEnter(object sender, DragEventArgs e)
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

        private void button14_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[13] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[13] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button14.Invalidate();
        }

        private void button14_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[13] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[13], destRect);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (buttonPaths[13] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[13]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button15_DragEnter(object sender, DragEventArgs e)
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

        private void button15_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[14] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[14] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button15.Invalidate();
        }

        private void button15_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[14] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[14], destRect);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (buttonPaths[14] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[14]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button16_DragEnter(object sender, DragEventArgs e)
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

        private void button16_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[15] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[15] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button16.Invalidate();
        }

        private void button16_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[15] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[15], destRect);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (buttonPaths[15] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[15]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }
        private void button17_DragEnter(object sender, DragEventArgs e)
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

        private void button17_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[16] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[16] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button17.Invalidate();
        }

        private void button17_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[16] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[16], destRect);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (buttonPaths[16] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[16]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button18_DragEnter(object sender, DragEventArgs e)
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

        private void button18_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[17] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[17] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button18.Invalidate();
        }

        private void button18_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[17] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[17], destRect);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (buttonPaths[17] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[17]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button19_DragEnter(object sender, DragEventArgs e)
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

        private void button19_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[18] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[18] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button19.Invalidate();
        }

        private void button19_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            //g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[18] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[18], destRect);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (buttonPaths[18] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[18]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button20_DragEnter(object sender, DragEventArgs e)
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

        private void button20_DragDrop(object sender, DragEventArgs e)
        {
            buttonPaths[19] = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ButtonIcons[19] = Icon.ExtractAssociatedIcon(buttonPaths[0]);

            // 强制重绘按钮以应用新的图标
            button20.Invalidate();
        }

        private void button20_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //创建一把SolidBrush并用它来填充一个矩形区域 
           // SolidBrush Buttonback = new SolidBrush(Color.FromArgb(100, 37, 34, 23));
            //画一个填充颜色的矩形
            ////g.FillRectangle(Buttonback, 2, 2, 37, 34);
            if (ButtonIcons[19] != null)
            {
                Rectangle destRect = new Rectangle(6, 6, 25,25); // 根据需要调整尺寸
                g.DrawIcon(ButtonIcons[19], destRect);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (buttonPaths[19] != null)
            {
                // 使用 Process.Start 方法打开文本文件
                Process.Start(buttonPaths[19]);
            }
            else
            {

                MessageBox.Show("请放入文件");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }
        private void SaveData()
        {
            string filePath = "Box.txt";

            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                // 如果不存在，则创建新文件
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // 将数据写入文件
                for (int i = 0; i < 20; i++)
                {
                    if (buttonPaths[i] == null)
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

        private string[] lines;
        private void InitializeButtonPaths()
        {
            string filePath = "Box.txt";
            string[] buttonPaths = new string[8];

            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

    }
}

