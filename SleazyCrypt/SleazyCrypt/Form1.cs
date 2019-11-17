using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace SleazyCrypt
{
    public partial class Form1 : Form
    {
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 200;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            
        }
        private static byte[] encodeBytes(byte[] bytes, String pass)
        {
            byte[] XorBytes = Encoding.Unicode.GetBytes(pass);

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= XorBytes[i % 16];
            }

            return bytes;
        }

        class Program
        {
            static void Main(string[] args)
            {
                //No Arguments -> Exit
                if (args.Length < 2)
                {
                    Console.WriteLine("Syntax: crypter.exe <Exe/Dll to get Encrypted> <Password> (Optional: output file name)");
                    Environment.Exit(0);
                }

                String file = args[0];
                String pass = args[1];
                String outFile = "Crypted.exe";

                //If Output Name is specified -> Set it
                if (args.Length == 3)
                {
                    outFile = args[2];
                }

                //File doesn't exist -> Exit
                if (!File.Exists(file))
                {
                    Console.WriteLine("[!] The selected File doesn't exist!");
                    Environment.Exit(0);
                }

                //Everything seems fine -> Reading bytes
                Console.WriteLine("[*] Reading Data...");
                byte[] plainBytes = File.ReadAllBytes(file);

                //Yep, got bytes -> Encoding
                Console.WriteLine("[*] Encoding Data...");
                byte[] encodedBytes = encodeBytes(plainBytes, pass);

                Console.Write("[*] Save to Output File... ");
                File.WriteAllBytes(outFile, encodedBytes);
                Console.WriteLine("Done!");

                Console.WriteLine("\n[*] File successfully encoded!");
            }
        }

    private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
