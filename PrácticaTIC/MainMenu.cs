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
            groupBox1.Visible = true;
            gbAcercaDe.Visible = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                String[] ext = file.FileName.Split('.');

                if (ext[ext.Length-1]=="huf")
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
                lbName.Text = path[path.Length - 1];
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
                accion(1);
            else
                accion(2);                       
        }

        private void tsAction_Click(object sender, EventArgs e)
        {
            if (btAction.Text == "Comprimir")
                accion(1);
            else
                accion(2);
        }

        public void accion(int opcion)
        {
            groupBox1.Visible = true;
            gbAcercaDe.Visible = false;
            //progressBar1.Visible = true;
            //progressBar1.Value = 1;
            //progressBar1.Step = 1;
            lbAction.Visible = true;           

            if (opcion == 1)
            {
                lbAction.Text = "Comprimiendo...";    
                List<byte> bytes = File.ReadAllBytes(file.FileName).ToList<byte>();                
                Huffman huffman = new Huffman();

                string  textocod = huffman.copiarCodigo(bytes);
                string[] split = file.FileName.Split('\\');
                string nombre = split[split.Length - 1].Split('.')[0] + "." + split[split.Length - 1].Split('.')[1] + ".huf";
                string ruta = "";

                for (int i = 0; i < split.Count() - 1; i++)
                {
                    ruta += split[i];
                    ruta += "\\";
                }
              
                FileStream f = new FileStream(ruta + nombre, FileMode.Create);
                foreach(byte b in textocod)
                {
                    //progressBar1.Increment(1);
                    //progressBar1.PerformStep();
                     f.WriteByte(b);                     
                }

                f.Close();
                //progressBar1.Step = 0;
            }
            else
            {                
                lbAction.Text = "Descomprimiendo...";         
                string[] split = file.FileName.Split('\\');
                string nombre = split[split.Length - 1].Split('.')[0] + "." + split[split.Length - 1].Split('.')[1];
                string ruta = "";

                for (int i = 0; i < split.Count() - 1; i++)
                {
                    ruta += split[i];
                    ruta += "\\";
                }
                Huffman huffman = new Huffman();
                
                List<Byte> contenido = File.ReadAllBytes(file.FileName).ToList<byte>();               


                int indice = huffman.getCabecera(contenido);
               
                string textocod = huffman.descodificar(contenido, indice);
               
                System.IO.File.WriteAllText(ruta + nombre, textocod);
            }
            lbAction.Visible = false;
            //progressBar1.Value = 0;
            //progressBar1.Visible = false;            
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            gbAcercaDe.Visible = true;
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gbAcercaDe.Visible = false;
            groupBox1.Visible = true;            
        }
    }
}
