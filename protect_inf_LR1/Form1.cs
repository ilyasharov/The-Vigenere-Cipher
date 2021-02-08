using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            N = characters.Length;
        }

        char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0' };

        private int N; //длина алфавита

        //зашифровать
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (radioButtonGamma.Checked)
            {
                string s;

                StreamReader sr = new StreamReader("in.txt");
                StreamWriter sw = new StreamWriter("out.txt");

                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(Encrypt(s, Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }

                sr.Close();
                sw.Close();
            }
            else
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s;

                    StreamReader sr = new StreamReader("in.txt");
                    StreamWriter sw = new StreamWriter("out.txt");

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(Encrypt(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }

        //расшифровать
        private void buttonDecipher_Click(object sender, EventArgs e)
        {

            if (radioButtonGamma.Checked)
            {
                string s;

                StreamReader sr = new StreamReader("in.txt");
                StreamWriter sw = new StreamWriter("out.txt");

                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(Dencrypt(s, Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }

                sr.Close();
                sw.Close();
            }

            else
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s;

                    StreamReader sr = new StreamReader("in.txt");
                    StreamWriter sw = new StreamWriter("out.txt");

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(Dencrypt(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                }

                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }

        //зашифровать
        private string Encrypt(string source, string key)
        {
            source = source.ToUpper();
            key = key.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in source)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, key[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == key.Length)
                    keyword_index = 0;
            }

            return result;
        }

        //расшифровать
        private string Dencrypt(string encrypted, string key)
        {
            encrypted = encrypted.ToUpper();
            key = key.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in encrypted)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, key[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == key.Length)
                    keyword_index = 0;
            }

            return result;
        }

        private string Generate_Pseudorandom_KeyWord(int lenght, int startSeed)
        {
            Random rand = new Random(startSeed);

            string result = "";

            for (int i = 0; i < lenght; i++)
                result += characters[rand.Next(0, characters.Length)];

            return result;
        }

        private void radioButtonVizhener_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonGamma_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
