using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.MapEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            isLoaded = true;
        }

        //Needs for glControl correct work
        private bool isLoaded = false;

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!isLoaded)
                return;
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            glControl.SwapBuffers();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new AboutWindow();
            aboutForm.ShowDialog();
        }
    }
}
