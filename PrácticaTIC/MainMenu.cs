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

        private void btSelec_Click(object sender, EventArgs e)
        {
            selectFile();
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFile();
        }

        private void selectFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                String ext = file.FileName.Split('.')[1];

                if (ext == "rar" || ext == "zip")
                {
                    btAction.Text = "Descomprimir";
                    tsAction.Text = "Descomprimir";
                }
                else
                {
                    btAction.Text = "Comprimir";
                    tsAction.Text = "Comprimir";
                }

                String[] path = file.FileName.Split('\\');
                lbName.Text = "Archivo: " + path[path.Length - 1];
                lbName.Visible = true;
                btAction.Visible = true;
                tsAction.Enabled = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void Compressor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir?", "Confirmación de salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
