using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labka1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*  public static string Round2(double abs)
          {
              char[] abs1 = abs.ToString().ToCharArray();
              int leng = abs1.Length;
              string abs2 = "";
              for (int i = 0; i < leng; i++)
              {
                  abs2 = abs2 + abs1[i].ToString();
              }
              return abs2;
          }*/
        public static double Round1(double abs)
        {
            //   string abs1 = abs1.
            char[] abs1 = abs.ToString().ToCharArray();
            int leng = abs1.Length;
            string abs2 = "";
            int index = 0;
            if (abs1[0].CompareTo('0') != 0)
            {
                abs = abs * 1000;
                abs1 = abs.ToString().ToCharArray();
                leng = abs1.Length + 3;
                abs1 = new char[leng];
                int j = 0;
                for (int i = 0; i < leng; i++)
                {
                    if (i == 2)
                    {
                        abs1[i] = '0';
                        abs1[i + 1] = '0';
                        abs1[i + 2] = '0';
                        i = i + 3;
                    }
                    abs1[i] = abs.ToString()[j];
                    j++;
                }

            }
            for (int i = 0; i < leng; i++)
            {
                if (abs1[i].CompareTo('0') > 0)
                {
                    if (i < leng - 1)
                    {
                        if (abs1[i + 1].CompareTo('9') == 0)
                        {
                            abs1[i + 1] = '0';
                            if (abs1[i].CompareTo('9') == 0)
                            {
                                abs1[i] = '0';
                                abs1[i - 1] = '1';
                                index = i;
                            }
                            else
                            {
                                abs1[i] = (char)(abs1[i] + 1);
                                index = i + 1;
                            }

                        }
                        else
                        {
                            abs1[i + 1] = (char)(abs1[i + 1] + 1);
                            index = i + 2;
                        }
                        abs2 = new string(abs1);
                        break;
                    }
                }
            }
            // mess = abs2;
            abs2 = abs2.Remove(index, leng - index);
            //   mess = mess + "\n" + abs2;
            double.TryParse(abs2, out abs);
            //    mess = mess + "\n" + abs.ToString();
            return abs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int b = 0, c = 0;
            int.TryParse(textBox3.Text, out b);
            int.TryParse(textBox4.Text, out c);
            double res = (double)b / c;
            double a1 = 0;
            double.TryParse(textBox5.Text, out a1);
            double abs1 = Math.Abs(res - a1);
            string mess = "";
            abs1 = Round1(abs1);
            double relative1 = 0;
            relative1 = abs1 / a1;
            relative1 = Round1(relative1) * 100;
            int d = 0;
            int.TryParse(textBox1.Text, out d);
            double a2 = 0;
            double.TryParse(textBox2.Text, out a2);
            if (b == 0 || c == 0 || a1 == 0 || a2 == 0 || d == 0)
            {
                richTextBox1.Text = "Fill in the required fields!";
                return;
            }
            double res2 = Math.Sqrt(d);
            double abs2 = Math.Abs(res2 - a2);
            abs2 = Round1(abs2);
            double relative2 = 0;
            relative2 = abs2 / a2;
            relative2 = Round1(relative2) * 100;
            mess ="Δa1 = " + abs1.ToString() + "\n" + "ба1 = " + relative1.ToString() + "%\n" + "Δa2 = " + abs2.ToString() + "\n" + "ба2 = " + relative2.ToString() + "%";
            if (relative1 < relative2)
                mess = mess + "\n" + "Оскільки ба1 < ба2 то рівність 1 більш точніша ніж 2 ";
            else
                mess = mess + "\n" + "Оскільки ба1 > ба2 то рівність 2 більш точніша ніж 1 ";
            richTextBox1.Text = mess;
        }
        public static int Rightnum(double a, ref int m)
        {
            char[] a1 = a.ToString().ToCharArray();
            int leng = a1.Length;
            int count = 0;
            int alarm = 0;
            for (int i = 0; i < leng; i++)
            {
                if (a1[i].CompareTo('0') == 0)
                {
                    if (alarm == 0)
                        return -1;
                    else
                        count++;
                }
                if (a1[i].CompareTo('0') > 0)
                {
                    count++;
                    alarm = 1;
                }
            }
            if (count > 0)
                m = a1[0] - 48;
            return count;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double a = 0;
            if (double.TryParse(textBox8.Text, out a))
            {
                int m = 0;
                int n = Rightnum(a, ref m);
                double abs = 0;
                double relative = 0;
                if (n > 0)
                {
                    string mess = "";
                    abs = 0.5 * Math.Pow(10, m - n + 1);
                    relative = abs / a;
                    mess = "У вузьму розумінні:\n Δa = " + abs + "\n" + "ба = " + relative + "\n";
                    abs = Math.Pow(10, m - n + 1);
                    relative = abs / a;
                    mess = mess + "У широкому розумінні:\n Δa = " + abs + "\n" + "ба = " + relative;
                    richTextBox3.Text = mess;
                }
                else
                    richTextBox3.Text = "All of figures in the number a must be correct significant!";
            }
        }
        public static int CorrectF(double a)
        {
            char[] a1 = a.ToString().ToCharArray();
            int leng = a1.Length;
            int count = 0;
            int alarm = 0;
            for (int i = 0; i < leng; i++)
            {
                if (a1[i].CompareTo(',') == 0)
                    alarm = 1;
                if (a1[i].CompareTo('0') == 0)
                {
                    if (alarm == 1)
                        count++;
                }
                if (a1[i].CompareTo('0') > 0)
                {
                    count++;
                    break;
                }
            }
            return count;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double a = 0;
            double.TryParse(textBox6.Text, out a);
            double relative = 0;
            double abs;
            double.TryParse(textBox7.Text, out relative);
            double.TryParse(textBox9.Text, out abs);
            if (relative == 0 & abs == 0)
            {
                richTextBox2.Text = "Fill in the required fields!";
                return;
            }
            if (a == 0)
            {
                richTextBox2.Text = "Fill in the required fields!";
                return;
            }
            if (abs == 0)
            {
                relative = relative / 100;
                abs = a * relative;
            }
            string mess = "";
            int curF = CorrectF(abs);
            curF = curF - figBefore(a);
            double a1 = Math.Round(a, curF);
            double absr = a - a1;
            double abs1 = abs + absr;
            absr = Math.Round(absr, 4);
            abs1 = Math.Round(abs1, 4);
            mess = "Δa = " + abs + "\na1 = " + a1 + "\nΔa1 = " + abs + " + " + absr + " = " + abs1;
            richTextBox2.Text = mess;
        }
        public static int figBefore(double a)
        {
            char[] a1 = a.ToString().ToCharArray();
            int leng = a1.Length;
            int count = 0;
            for (int i = 0; i < leng; i++)
            {
                if (a1[i].CompareTo(',') == 0)
                    break;
                if (a1[i].CompareTo('0') >= 0)
                    count++;

            }
            return count;
        }
    }
}
