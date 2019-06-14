namespace PROYECTO_FINAL
{
    partial class MENU_PRODUCTOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.bt_registrar = new System.Windows.Forms.Button();
            this.bt_volver = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_registrar
            // 
            this.bt_registrar.Location = new System.Drawing.Point(146, 45);
            this.bt_registrar.Name = "bt_registrar";
            this.bt_registrar.Size = new System.Drawing.Size(231, 64);
            this.bt_registrar.TabIndex = 0;
            this.bt_registrar.Text = "PRODUCTOS";
            this.bt_registrar.UseVisualStyleBackColor = true;
            this.bt_registrar.Click += new System.EventHandler(this.bt_registrar_Click);
            // 
            // bt_volver
            // 
            this.bt_volver.Location = new System.Drawing.Point(348, 266);
            this.bt_volver.Name = "bt_volver";
            this.bt_volver.Size = new System.Drawing.Size(131, 23);
            this.bt_volver.TabIndex = 0;
            this.bt_volver.Text = "VOLVER";
            this.bt_volver.UseVisualStyleBackColor = true;
            this.bt_volver.Click += new System.EventHandler(this.bt_volver_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(146, 148);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(231, 62);
            this.bt_buscar.TabIndex = 0;
            this.bt_buscar.Text = "INSUMOS";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // MENU_PRODUCTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 312);
            this.Controls.Add(this.bt_volver);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.bt_registrar);
            this.Name = "MENU_PRODUCTOS";
            this.Text = "MENU_PRODUCTOS";
            this.Load += new System.EventHandler(this.MENU_PRODUCTOS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_registrar;
        private System.Windows.Forms.Button bt_volver;
        private System.Windows.Forms.Button bt_buscar;
    }
}