using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject
{
    partial class MapImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 529);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9,
            this.col10,
            this.col11,
            this.col12,
            this.col13,
            this.col14,
            this.col15,
            this.col16,
            this.col17,
            this.col18,
            this.col19});
            this.dataGridView1.Location = new System.Drawing.Point(13, 12);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(574, 529);
            this.dataGridView1.TabIndex = 1;
            // 
            // col1
            // 
            this.col1.HeaderText = "";
            this.col1.Name = "col1";
            this.col1.Width = 20;
            // 
            // col2
            // 
            this.col2.HeaderText = "";
            this.col2.Name = "col2";
            this.col2.Width = 20;
            // 
            // col3
            // 
            this.col3.HeaderText = "";
            this.col3.Name = "col3";
            this.col3.Width = 20;
            // 
            // col4
            // 
            this.col4.HeaderText = "";
            this.col4.Name = "col4";
            this.col4.Width = 20;
            // 
            // col5
            // 
            this.col5.HeaderText = "";
            this.col5.Name = "col5";
            this.col5.Width = 20;
            // 
            // col6
            // 
            this.col6.HeaderText = "";
            this.col6.Name = "col6";
            this.col6.Width = 20;
            // 
            // col7
            // 
            this.col7.HeaderText = "";
            this.col7.Name = "col7";
            this.col7.Width = 20;
            // 
            // col8
            // 
            this.col8.HeaderText = "";
            this.col8.Name = "col8";
            this.col8.Width = 20;
            // 
            // col9
            // 
            this.col9.HeaderText = "";
            this.col9.Name = "col9";
            this.col9.Width = 20;
            // 
            // col10
            // 
            this.col10.HeaderText = "";
            this.col10.Name = "col10";
            this.col10.Width = 20;
            // 
            // col11
            // 
            this.col11.HeaderText = "";
            this.col11.Name = "col11";
            this.col11.Width = 20;
            // 
            // col12
            // 
            this.col12.HeaderText = "";
            this.col12.Name = "col12";
            this.col12.Width = 20;
            // 
            // col13
            // 
            this.col13.HeaderText = "";
            this.col13.Name = "col13";
            this.col13.Width = 20;
            // 
            // col14
            // 
            this.col14.HeaderText = "";
            this.col14.Name = "col14";
            this.col14.Width = 20;
            // 
            // col15
            // 
            this.col15.HeaderText = "";
            this.col15.Name = "col15";
            this.col15.Width = 20;
            // 
            // col16
            // 
            this.col16.HeaderText = "";
            this.col16.Name = "col16";
            this.col16.Width = 20;
            // 
            // col17
            // 
            this.col17.HeaderText = "";
            this.col17.Name = "col17";
            this.col17.Width = 20;
            // 
            // col18
            // 
            this.col18.HeaderText = "";
            this.col18.Name = "col18";
            this.col18.Width = 20;
            // 
            // col19
            // 
            this.col19.HeaderText = "";
            this.col19.Name = "col19";
            this.col19.Width = 20;
            // 
            // MapImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 552);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "MapImage";
            this.Text = "MapImage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn col5;
        private DataGridViewTextBoxColumn col6;
        private DataGridViewTextBoxColumn col7;
        private DataGridViewTextBoxColumn col8;
        private DataGridViewTextBoxColumn col9;
        private DataGridViewTextBoxColumn col10;
        private DataGridViewTextBoxColumn col11;
        private DataGridViewTextBoxColumn col12;
        private DataGridViewTextBoxColumn col13;
        private DataGridViewTextBoxColumn col14;
        private DataGridViewTextBoxColumn col15;
        private DataGridViewTextBoxColumn col16;
        private DataGridViewTextBoxColumn col17;
        private DataGridViewTextBoxColumn col18;
        private DataGridViewTextBoxColumn col19;
    }
}