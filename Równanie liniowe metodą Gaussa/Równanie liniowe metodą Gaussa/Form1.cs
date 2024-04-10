using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibKlas;
using System.Numerics;
using BibKlas.AlgebraLiniowa;

namespace Równanie_liniowe_metodą_Gaussa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Formatuj();
        }

        int k = 1 , n = 4;
        double[] B, X;
        double[,] A;
        Complex[] Bc, Xc;
        Complex[,] Ac;
        void Formatuj()
        {
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;

            dataGridView2.RowCount = n;
            dataGridView2.ColumnCount = 1;

            dataGridView3.RowCount = n;
            dataGridView3.ColumnCount = 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            Formatuj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random los = new Random();

            if(k == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dataGridView1[i, j].Value = (los.Next(-100, 100) + los.NextDouble()).ToString("0.000");

                    }
                    dataGridView3[0, i].Value = (los.Next(-100, 100) + los.NextDouble()).ToString("0.000");

                }
            }
            else
            {
                Complex losuj , losuj1;

                Bc = new Complex[n + 1];
                Xc = new Complex[n + 1];
                Ac = new Complex[n + 1, n + 1];

                for (int i = 0; i < n; i++)
                {
                    losuj1 = new Complex(los.Next(-100, 100), los.Next(-100, 100));
                    for (int j = 0; j < n; j++)
                    {
                        losuj = new Complex(los.Next(-100, 100), los.Next(-100, 100));
                        dataGridView1[i, j].Value = losuj;
                        Ac[j + 1, i + 1] = losuj;
                    }
                    dataGridView3[0, i].Value = losuj1;
                    Bc[i + 1] = losuj1;
                }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random los = new Random();
            if (k == 1)
            {
                
                double y, suma = 0;

                for (int i = 0; i < n; i++)
                {
                    suma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        y = los.Next(20);
                        dataGridView1[j, i].Value = y;
                        suma += y;
                    }
                    dataGridView3[0, i].Value = suma;
                }
            }
            else
            {
               
                Complex y, suma = 0;
                Bc = new Complex[n + 1];
                Xc = new Complex[n + 1];
                Ac = new Complex[n + 1, n + 1];

                for (int i = 0; i < n; i++)
                {
                    suma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        y = new Complex(los.Next(20), los.Next(-10,10));
                        dataGridView1[j, i].Value = y;
                        Ac[i + 1, j + 1] = y;
                        suma += y;

                    }
                    dataGridView3[0, i].Value = suma;
                    Bc[i + 1] = suma;
                }
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            k = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            k = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(k == 1)
            {
                A = new double[n + 1, n + 1];
                B = new double[n + 1];
                X = new double[n + 1];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A[i + 1, j + 1] = double.Parse(dataGridView1[j, i].Value.ToString());
                        B[i + 1] = double.Parse(dataGridView3[0, i].Value.ToString());
                    }
                }
                int zz = MetodaGaussa.RozRowMacGaussa(A, B, X, 1e-6);

                for (int i = 0; i < n; i++)
                {
                    dataGridView2[0, i].Value = X[i + 1].ToString("0.##");
                }
            }
            else
            {
               // int zz = MetodaGaussa.RozRowMacGaussa(Ac, Bc, Xc, 1e-6);

                //for (int i = 0; i < n; i++)
                //{
                //    dataGridView2[0, i].Value = Xc[i + 1].ToString("#.##");
                //}
            }
        }
    }
}
