using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BattleCity.GameLib;
using BattleCity.GameLib.Generators;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace BattleCity.MapEditor
{
    /// <summary>
    /// Main window of map editor
    /// </summary>
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
        private EditorMode editorMode;

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

        /// <summary>
        /// Instruments buttons click event handler. Sets current command according to the button.
        /// </summary>
        /// <param name="sender">Button, which was clicked</param>
        /// <param name="e">Event arguments</param>
        private void InstrimentButton_Click(object sender, EventArgs e)
        {
            //if brick button editorMode = ..., etc.
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            // TODO: Size increase redraw problem
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            DrawGrid();
        }

        private void DrawGrid()
        {
            if (gridToolStripMenuItem.Checked)
            {
                for (double i = 0; i < 19; i++)
                {
                    GL.Begin(BeginMode.Lines);
                    {
                        GL.Color3(1.0, 1.0, 1.0);

                        GL.Vertex2(-1.0 + 2.0/19*i, -1.0);
                        GL.Vertex2(-1.0 + 2.0/19*i, 1.0);
                    }
                    GL.End();
                }
                for (double i = 0; i < 20; i++)
                {
                    GL.Begin(BeginMode.Lines);
                    {
                        GL.Color3(1.0, 1.0, 1.0);

                        GL.Vertex2(-1.0, -1.0 + 2.0/20*i);
                        GL.Vertex2(1.0, -1.0 + 2.0/20*i);
                    }
                    GL.End();
                }

                glControl.SwapBuffers();
            }
            else
            {
                
            }
        }

        private void gridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            DrawGrid();
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
