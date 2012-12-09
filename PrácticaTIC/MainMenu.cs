using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrácticaTIC
{
    public partial class Compressor : Form
    {
        OpenFileDialog file;
        public Compressor()
        {

            InitializeComponent();
            file= new OpenFileDialog();
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
            if (file.ShowDialog() == DialogResult.OK)
            {
                String ext = file.FileName.Split('.')[1];

                if (ext == "rar" || ext == "zip" || ext=="huf")
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

        private void btAction_Click(object sender, EventArgs e)
        {            
            if (btAction.Text == "Comprimir")
            {
                List<byte> bytes = File.ReadAllBytes(file.FileName).ToList<byte>();
                Huffman huffman = new Huffman();
                string textocod = huffman.copiarCodigo(bytes);

                string[] split = file.FileName.Split('\\');
                string nombre = split[split.Length - 1].Split('.')[0] + ".huf";
                string ruta = "";


                for (int i = 0; i < split.Count() - 1; i++)
                {
                    ruta += split[i];
                    ruta += "\\";
                }
                System.IO.File.WriteAllText(ruta + nombre, textocod);
            }
            else
            {             
                string[] split = file.FileName.Split('\\');
                string nombre = split[split.Length - 1].Split('.')[0] + ".trad";
                string ruta = "";
                for (int i = 0; i < split.Count() - 1; i++)
                {
                    ruta += split[i];
                    ruta += "\\";
                }
                Huffman huffman = new Huffman();
                string[] contenido=File.ReadAllLines(file.FileName);               
                int indice = huffman.getCabecera(contenido);

                string textocod=huffman.descodificar(contenido, indice);
                System.IO.File.WriteAllText(ruta + nombre, textocod);
            }            
        }
    }
}
