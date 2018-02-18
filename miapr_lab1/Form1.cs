using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace miapr_lab1
{
    
    using CustomImageType = miapr_lab1.Image;


    public partial class Form1 : Form
    {
        private Manager manager;
        private KAvarage kAvarage;
        private Generator generator;

        public Form1()
        {
            manager = new Manager();
            InitializeComponent();

            drawPanelEx1.Register(manager);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 imagesCount = InputCheck.CheckInputField(textBox1.Text);
            Int32 classCount = InputCheck.CheckInputField(textBox2.Text);
            if (!InputCheck.CompareCountOfVariables(imagesCount,classCount))
            {
                MessageBox.Show("Проверьте введенные днные.");
                return;
            }

            generator = new Generator(drawPanelEx1.Width, drawPanelEx1.Height);
            generator.ImagesCount = imagesCount;
            generator.ClassCount = classCount;
            
            generator.PrepareAll();

            kAvarage = new KAvarage(generator.centers, generator.images, generator.classes);
            kAvarage.CalculateDistance();
            kAvarage.DevideByClasses();
            kAvarage.FullGroups();
            manager.SimulateDraw(drawPanelEx1.CreateGraphics(), drawPanelEx1.ClientRectangle, kAvarage.classes);
            label1.Text = kAvarage.classes[0].Center.X.ToString() + "-" + kAvarage.classes[0].Center.Y.ToString()+" ";
        }

        private void drawPanelEx1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //drawPanelEx1.Refresh();
            label1.Text = kAvarage.GetReadyClasses(checkBox1.Checked).ToString();
            manager.SimulateDraw(drawPanelEx1.CreateGraphics(), drawPanelEx1.ClientRectangle, kAvarage.classes);
        }
    }
}
