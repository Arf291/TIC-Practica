namespace PrácticaTIC
{
    partial class Compressor
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compressor));
            this.btSelec = new System.Windows.Forms.Button();
            this.btAction = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAction = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbAcercaDe = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAction = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.gbAcercaDe.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSelec
            // 
            this.btSelec.BackColor = System.Drawing.Color.Transparent;
            this.btSelec.Location = new System.Drawing.Point(42, 30);
            this.btSelec.Name = "btSelec";
            this.btSelec.Size = new System.Drawing.Size(109, 23);
            this.btSelec.TabIndex = 0;
            this.btSelec.Text = "Seleccionar archivo";
            this.btSelec.UseVisualStyleBackColor = false;
            this.btSelec.Click += new System.EventHandler(this.btSelec_Click);
            // 
            // btAction
            // 
            this.btAction.BackColor = System.Drawing.Color.Transparent;
            this.btAction.Location = new System.Drawing.Point(42, 99);
            this.btAction.Name = "btAction";
            this.btAction.Size = new System.Drawing.Size(109, 23);
            this.btAction.TabIndex = 1;
            this.btAction.UseVisualStyleBackColor = false;
            this.btAction.Visible = false;
            this.btAction.Click += new System.EventHandler(this.btAction_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(55, 69);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "label1";
            this.lbName.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Tan;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarToolStripMenuItem,
            this.tsAction,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // seleccionarToolStripMenuItem
            // 
            this.seleccionarToolStripMenuItem.Name = "seleccionarToolStripMenuItem";
            this.seleccionarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.seleccionarToolStripMenuItem.Text = "Seleccionar";
            this.seleccionarToolStripMenuItem.Click += new System.EventHandler(this.seleccionarToolStripMenuItem_Click);
            // 
            // tsAction
            // 
            this.tsAction.Enabled = false;
            this.tsAction.Name = "tsAction";
            this.tsAction.Size = new System.Drawing.Size(152, 22);
            this.tsAction.Text = "Comprimir";
            this.tsAction.Click += new System.EventHandler(this.tsAction_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // gbAcercaDe
            // 
            this.gbAcercaDe.Controls.Add(this.label4);
            this.gbAcercaDe.Controls.Add(this.label3);
            this.gbAcercaDe.Controls.Add(this.label2);
            this.gbAcercaDe.Controls.Add(this.label1);
            this.gbAcercaDe.Location = new System.Drawing.Point(29, 66);
            this.gbAcercaDe.Name = "gbAcercaDe";
            this.gbAcercaDe.Size = new System.Drawing.Size(232, 136);
            this.gbAcercaDe.TabIndex = 4;
            this.gbAcercaDe.TabStop = false;
            this.gbAcercaDe.Text = "Componentes";
            this.gbAcercaDe.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Universidad de Alicante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Teoría de la Información y la Codificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alberto Real Fernández";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Francisco José Bueno Nieves";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAction);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btSelec);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.btAction);
            this.groupBox1.Location = new System.Drawing.Point(118, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 148);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de archivo";
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(42, 128);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(35, 13);
            this.lbAction.TabIndex = 7;
            this.lbAction.Text = "label5";
            this.lbAction.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(117, 128);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(34, 14);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // Compressor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(455, 335);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAcercaDe);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Compressor";
            this.Text = "Compressor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Compressor_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbAcercaDe.ResumeLayout(false);
            this.gbAcercaDe.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSelec;
        private System.Windows.Forms.Button btAction;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsAction;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbAcercaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbAction;
    }
}

