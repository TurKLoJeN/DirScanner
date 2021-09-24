using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Http;

namespace DirScanner_TurKLoJeN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Thread islem;

        async void Tarama()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = listBox1.Items.Count;

            int kactane = listBox1.Items.Count;
            for (int i = 0; i < kactane; i++)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string url = textBox1.Text.Trim() + listBox1.Items[i].ToString();
                        client.DefaultRequestHeaders.Add("User-Agent", "DirScanner");

                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode == true || response.StatusCode.ToString() == "OK")
                        {
                           listBox2.Items.Add(listBox1.Items[i].ToString() + " ||    OK ");
                           listBox3.Items.Add(textBox1.Text + listBox1.Items[i].ToString());
                           int adet = listBox3.Items.Count;
                           label4.Text = Convert.ToString(adet);
                           // MessageBox.Show($"URL Address : {url}\n İstek Sonucu : {response.IsSuccessStatusCode.ToString()}\nİstek Kodu : {response.StatusCode.ToString()}");
                        }
                        else if (response.IsSuccessStatusCode == false || response.StatusCode.ToString() == "NotFound")
                        {
                            listBox2.Items.Add(listBox1.Items[i].ToString() + $" ||   UNSUCCESSFUL || ");
                            //MessageBox.Show($"{url} adresi bulunamadı. {response.StatusCode.ToString()} hatası alınmaktadır.");
                        }
                    }
                }
                catch (Exception ex)
                {
                   
                }

                progressBar1.Value = i+1;

                //try
                //{
                //    var url = textBox1.Text + listBox1.Items[i].ToString();
                //    HttpWebRequest istek = (HttpWebRequest)HttpWebRequest.Create(url);
                //    istek.UserAgent = "rwar";

                //    HttpWebResponse cevap = (HttpWebResponse)istek.GetResponse();
                //    string durum = cevap.StatusCode.ToString();
                //    label9.Text = istek.ToString();
                //    label10.Text = cevap.ToString();
                //    label11.Text = durum.ToString();

                //    if (durum == "OK")
                //    {
                //        listBox2.Items.Add(listBox1.Items[i].ToString() + " ||    SUCCESSFUL ");
                //        listBox3.Items.Add(textBox1.Text + listBox1.Items[i].ToString());
                //        int adet = listBox3.Items.Count;
                //        label4.Text = Convert.ToString(adet);
                //    }
                //    else
                //    {

                //    }
                //}
                //catch (Exception ex)
                //{

                //    listBox2.Items.Add(listBox1.Items[i].ToString() + $" ||   UNSUCCESSFUL || {ex.Message} ");
                //}
                //progressBar1.Value = i;
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(System.IO.File.ReadAllLines("list/big.txt"));
            CheckForIllegalCrossThreadCalls = false;

            int adet = listBox1.Items.Count;

            label3.Text = Convert.ToString(adet);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(System.IO.File.ReadAllLines("list/medium.txt"));
            CheckForIllegalCrossThreadCalls = false;

            int adet = listBox1.Items.Count;

            label3.Text = Convert.ToString(adet);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(System.IO.File.ReadAllLines("list/medium2.txt"));
            CheckForIllegalCrossThreadCalls = false;

            int adet = listBox1.Items.Count;

            label3.Text = Convert.ToString(adet);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(System.IO.File.ReadAllLines("list/small.txt"));
            CheckForIllegalCrossThreadCalls = false;

            int adet = listBox1.Items.Count;

            label3.Text = Convert.ToString(adet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked ==false && radioButton2.Checked ==false && radioButton3.Checked ==false && radioButton4.Checked ==false)
            {
                MessageBox.Show("Please choose list");
            }
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            islem = new Thread(new ThreadStart(Tarama));
            islem.Start();
        }
    }
}
