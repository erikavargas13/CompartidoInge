namespace PROYECTO_FINAL
{
    partial class ControlDeMerma
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_usuario = new System.Windows.Forms.TextBox();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_verificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CÓDIGO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CONTRASEÑA";
            // 
            // tb_usuario
            // 
            this.tb_usuario.Location = new System.Drawing.Point(249, 134);
            this.tb_usuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_usuario.Name = "tb_usuario";
            this.tb_usuario.Size = new System.Drawing.Size(161, 20);
            this.tb_usuario.TabIndex = 1;
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(249, 183);
            this.tb_pass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.PasswordChar = '*';
            this.tb_pass.Size = new System.Drawing.Size(161, 20);
            this.tb_pass.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "BIENVENIDO";
            // 
            // bt_verificar
            // 
            this.bt_verificar.Location = new System.Drawing.Point(186, 242);
            this.bt_verificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_verificar.Name = "bt_verificar";
            this.bt_verificar.Size = new System.Drawing.Size(160, 41);
            this.bt_verificar.TabIndex = 3;
            this.bt_verificar.Text = "VERIFICAR USUARIO";
            this.bt_verificar.UseVisualStyleBackColor = true;
            this.bt_verificar.Click += new System.EventHandler(this.bt_verificar_Click);
            // 
            // ControlDeMerma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 340);
            this.Controls.Add(this.bt_verificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.tb_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ControlDeMerma";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ControlDeMerma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_usuario;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_verificar;
    }
}

