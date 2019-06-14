namespace PROYECTO_FINAL
{
    partial class MENU_RECETA
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
            this.e = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_registrar
            // 
            this.bt_registrar.Location = new System.Drawing.Point(198, 65);
            this.bt_registrar.Name = "bt_registrar";
            this.bt_registrar.Size = new System.Drawing.Size(234, 85);
            this.bt_registrar.TabIndex = 0;
            this.bt_registrar.Text = "REGISTRAR - ACTUALIZAR RECETA";
            this.bt_registrar.UseVisualStyleBackColor = true;
            // 
            // e
            // 
            this.e.Location = new System.Drawing.Point(495, 358);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(124, 23);
            this.e.TabIndex = 0;
            this.e.Text = "VOLVER";
            this.e.UseVisualStyleBackColor = true;
            this.e.Click += new System.EventHandler(this.e_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(198, 200);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(234, 91);
            this.bt_buscar.TabIndex = 0;
            this.bt_buscar.Text = "BUSCAR RECETA";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // MENU_RECETA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 393);
            this.Controls.Add(this.e);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.bt_registrar);
            this.Name = "MENU_RECETA";
            this.Text = "MENU_RECETA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_registrar;
        private System.Windows.Forms.Button e;
        private System.Windows.Forms.Button bt_buscar;
    }
}