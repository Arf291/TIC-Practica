using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrácticaTIC
{
    public partial class Compressor : Form
    {
        public Compressor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                String ext = file.FileName.Split('.')[1];

                if (ext == "rar" || ext == "zip")
                {
                    btAction.Text = "Descomprimir";
                }
                else
                    btAction.Text = "Comprimir";

                String[] path = file.FileName.Split('\\');
                lbName.Text = "Archivo: " + path[path.Length-1];
                lbName.Visible = true;
                btAction.Visible = true;
            }
        }
    }
}
