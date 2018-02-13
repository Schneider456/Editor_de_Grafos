namespace EditordeGrafos {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grafoNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarAcciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(884, 20);
            this.textBox1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.grafoNuevoToolStripMenuItem,
            this.agregarVérticeToolStripMenuItem,
            this.eliminarVérticeToolStripMenuItem,
            this.agregarAristaToolStripMenuItem,
            this.eliminarAristaToolStripMenuItem,
            this.cancelarAcciónToolStripMenuItem,
            this.moverVérticeToolStripMenuItem,
            this.moverGrafoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grafoNuevoToolStripMenuItem
            // 
            this.grafoNuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigidoToolStripMenuItem,
            this.noDirigidoToolStripMenuItem});
            this.grafoNuevoToolStripMenuItem.Name = "grafoNuevoToolStripMenuItem";
            this.grafoNuevoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.grafoNuevoToolStripMenuItem.Text = "Grafo Nuevo";
            // 
            // dirigidoToolStripMenuItem
            // 
            this.dirigidoToolStripMenuItem.Name = "dirigidoToolStripMenuItem";
            this.dirigidoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dirigidoToolStripMenuItem.Text = "Dirigido";
            this.dirigidoToolStripMenuItem.Click += new System.EventHandler(this.dirigidoToolStripMenuItem_Click);
            // 
            // noDirigidoToolStripMenuItem
            // 
            this.noDirigidoToolStripMenuItem.Name = "noDirigidoToolStripMenuItem";
            this.noDirigidoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noDirigidoToolStripMenuItem.Text = "No dirigido";
            this.noDirigidoToolStripMenuItem.Click += new System.EventHandler(this.noDirigidoToolStripMenuItem_Click);
            // 
            // agregarVérticeToolStripMenuItem
            // 
            this.agregarVérticeToolStripMenuItem.Name = "agregarVérticeToolStripMenuItem";
            this.agregarVérticeToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.agregarVérticeToolStripMenuItem.Text = "Agregar Vértice";
            this.agregarVérticeToolStripMenuItem.Click += new System.EventHandler(this.agregarVérticeToolStripMenuItem_Click);
            // 
            // eliminarVérticeToolStripMenuItem
            // 
            this.eliminarVérticeToolStripMenuItem.Name = "eliminarVérticeToolStripMenuItem";
            this.eliminarVérticeToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.eliminarVérticeToolStripMenuItem.Text = "Eliminar Vértice";
            this.eliminarVérticeToolStripMenuItem.Click += new System.EventHandler(this.eliminarVérticeToolStripMenuItem_Click);
            // 
            // agregarAristaToolStripMenuItem
            // 
            this.agregarAristaToolStripMenuItem.Name = "agregarAristaToolStripMenuItem";
            this.agregarAristaToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.agregarAristaToolStripMenuItem.Text = "Agregar Arista";
            this.agregarAristaToolStripMenuItem.Click += new System.EventHandler(this.agregarAristaToolStripMenuItem_Click);
            // 
            // eliminarAristaToolStripMenuItem
            // 
            this.eliminarAristaToolStripMenuItem.Name = "eliminarAristaToolStripMenuItem";
            this.eliminarAristaToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.eliminarAristaToolStripMenuItem.Text = "Eliminar Arista";
            this.eliminarAristaToolStripMenuItem.Click += new System.EventHandler(this.eliminarAristaToolStripMenuItem_Click);
            // 
            // cancelarAcciónToolStripMenuItem
            // 
            this.cancelarAcciónToolStripMenuItem.Name = "cancelarAcciónToolStripMenuItem";
            this.cancelarAcciónToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.cancelarAcciónToolStripMenuItem.Text = "Cancelar Acción";
            this.cancelarAcciónToolStripMenuItem.Click += new System.EventHandler(this.cancelarAcciónToolStripMenuItem_Click);
            // 
            // moverVérticeToolStripMenuItem
            // 
            this.moverVérticeToolStripMenuItem.Name = "moverVérticeToolStripMenuItem";
            this.moverVérticeToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.moverVérticeToolStripMenuItem.Text = "Mover Vértice";
            this.moverVérticeToolStripMenuItem.Click += new System.EventHandler(this.moverVérticeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.nuevoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // moverGrafoToolStripMenuItem
            // 
            this.moverGrafoToolStripMenuItem.Name = "moverGrafoToolStripMenuItem";
            this.moverGrafoToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.moverGrafoToolStripMenuItem.Text = "Mover grafo";
            this.moverGrafoToolStripMenuItem.Click += new System.EventHandler(this.moverGrafoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Editor de Grafos";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem grafoNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dirigidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noDirigidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarVérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAristaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cancelarAcciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverVérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverGrafoToolStripMenuItem;
    }
}

