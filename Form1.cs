using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;

//Based on https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp

namespace marathon_crypt
{
    public partial class Form1 : Form
    {

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
        public Form1()
        {
            InitializeComponent();
        }

        
        public static byte[] GenerateRandomSalt()
        {
            byte[] d = new byte[32];
            using(RNGCryptoServiceProvider rng=new RNGCryptoServiceProvider())
            {
                for(int i=0;i<10;i++)
                {
                    rng.GetBytes(d);
                }
            }

            return d;
        }
        private void browse_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse file",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true

            };

            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                file_path_txt.Text = openFileDialog1.FileName;
            }
        }

        private void crypt_btn_Click(object sender, EventArgs e)
        {
            byte[] generated_salt = GenerateRandomSalt();
            string file_path = file_path_txt.Text;
            string password = password_txt.Text;

            FileStream file_crypt = new FileStream(file_path + ".aes", FileMode.Create);

            byte[] pass_byte = System.Text.Encoding.UTF8.GetBytes(password);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(pass_byte, generated_salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            file_crypt.Write(generated_salt, 0, generated_salt.Length);

            CryptoStream crypto_stream = new CryptoStream(file_crypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream file_in = new FileStream(file_path, FileMode.Open);

            byte[] buffer = new byte[1048576];

            int reader;

            try
            {
                while((reader=file_in.Read(buffer,0,buffer.Length))>0)
                {
                    Application.DoEvents();
                    crypto_stream.Write(buffer, 0, reader);
                }
                file_in.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                crypto_stream.Close();
                file_crypt.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void encrypt_btn_Click(object sender, EventArgs e)
        {
            string file_path;
            DialogResult mess_result = MessageBox.Show("Save the file");
            if (mess_result == DialogResult.OK)
            {
                using (var dialog = new System.Windows.Forms.SaveFileDialog())
                {
                    dialog.Filter = "All files (*.*)|*.*";
                    DialogResult res = dialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        file_path = dialog.FileName;




                        string password = password_txt.Text;

                        byte[] pass_byte = System.Text.Encoding.UTF8.GetBytes(password);
                        byte[] salt = new byte[32];

                        FileStream file_crypt = new FileStream(file_path_txt.Text, FileMode.Open);

                        file_crypt.Read(salt, 0, salt.Length);

                        RijndaelManaged AES = new RijndaelManaged();
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(pass_byte, salt, 50000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);
                        AES.Padding = PaddingMode.PKCS7;
                        AES.Mode = CipherMode.CBC;

                        CryptoStream crypto_stream = new CryptoStream(file_crypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

                        FileStream stream_out = new FileStream(file_path, FileMode.Create);

                        int reader;
                        byte[] buffer = new byte[1048576];

                        try
                        {
                            while ((reader = crypto_stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                Application.DoEvents();
                                stream_out.Write(buffer, 0, reader);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wrong password");
                            Console.WriteLine(ex.ToString());
                        }

                        try
                        {
                            crypto_stream.Close();
                            MessageBox.Show("File decrypted");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
