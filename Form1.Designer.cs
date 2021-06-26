
namespace marathon_crypt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.file_path_txt = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.crypt_btn = new System.Windows.Forms.Button();
            this.decrypt_btn = new System.Windows.Forms.Button();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "open_file";
            // 
            // file_path_txt
            // 
            this.file_path_txt.Location = new System.Drawing.Point(12, 12);
            this.file_path_txt.Name = "file_path_txt";
            this.file_path_txt.Size = new System.Drawing.Size(575, 31);
            this.file_path_txt.TabIndex = 0;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(593, 9);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(194, 34);
            this.browse_btn.TabIndex = 1;
            this.browse_btn.Text = "BROWSE";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // crypt_btn
            // 
            this.crypt_btn.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crypt_btn.Location = new System.Drawing.Point(12, 93);
            this.crypt_btn.Name = "crypt_btn";
            this.crypt_btn.Size = new System.Drawing.Size(188, 82);
            this.crypt_btn.TabIndex = 2;
            this.crypt_btn.Text = "ENCRYPT";
            this.crypt_btn.UseVisualStyleBackColor = true;
            this.crypt_btn.Click += new System.EventHandler(this.crypt_btn_Click);
            // 
            // decrypt_btn
            // 
            this.decrypt_btn.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.decrypt_btn.Location = new System.Drawing.Point(206, 93);
            this.decrypt_btn.Name = "decrypt_btn";
            this.decrypt_btn.Size = new System.Drawing.Size(188, 82);
            this.decrypt_btn.TabIndex = 3;
            this.decrypt_btn.Text = "DECRYPT";
            this.decrypt_btn.UseVisualStyleBackColor = true;
            this.decrypt_btn.Click += new System.EventHandler(this.encrypt_btn_Click);
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(150, 56);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(637, 31);
            this.password_txt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your password:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 185);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.decrypt_btn);
            this.Controls.Add(this.crypt_btn);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.file_path_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MARATHON CRYPT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox file_path_txt;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Button crypt_btn;
        private System.Windows.Forms.Button encrypt_btn;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button decrypt_btn;
    }
}

