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


namespace _7het
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileOk += (sender, e) =>
                {
                    try
                    {
                        using (var sr = new StreamReader(openFileDialog1.FileName))
                        {
                            list.Items.Clear();
                            while (!sr.EndOfStream)
                            {
                                list.Items.Add(sr.ReadLine());
                            }
                        }
                    }
                    catch (IOException)
                    {

                        MessageBox.Show("Hiba! Nem sikerult a betoltes!");
                    }
                };
        }

        //enter-el való hozzáadás
        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt1.Text.Trim() !="")
            {
                list.Items.Add(txt1.Text);
                txt1.Text = "";
            }
        }
        //mentes
        private void Mentes_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            // csak szam lehet

            //if (Int32.Parse(txtSzulDatum.Text.Trim()) != 0)
            //{
            //    MessageBox.Show("A születési dátum csak szám lehet");
            //}


        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    //név fáljba írása

                    foreach (var item in "Név: "+txtNev.Text+"\n")
                    {
                        sw.Write(item);
                    }


                    //datum fáljba írása


                    if (Int32.Parse(txtSzulDatum.Text.Trim()) == 0)
                    {
                        foreach (var item in "Születési Dátuma: " + txtSzulDatum.Text + "\n")
                        {
                            sw.Write(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("A születési dátum csak szám lehet");
                    }



                    //ferfi faljba irasa

                    if (rbtnFerfi.Checked == true)
                    {

                        foreach (var item in  rbtnFerfi.Text)
                        {
                            sw.WriteLine(item);
                        }

                    }

                    //nő faljba irasa
                    if (rbtnNo.Checked == true)
                    {
                        foreach (var item in rbtnNo.Text)
                        {
                        sw.WriteLine(item);
                         }

                    }

                    //kivalasztott hobbi faljba irasa

                    for (int i = 0; i < list.SelectedItems.Count; i++)
                    {
                        string text = list.GetItemText(list.SelectedItem);
                        sw.WriteLine(text);
                    }



                }
            }

            

            catch (IOException)
            {

                MessageBox.Show("Hiba, sikertelen mentés!");
            }
        }

        //betoltes 
        private void Betoltes_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        //hozzáadás gomb (Ugyan az a hobbi nem lehet 2x-er)
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (list.Items.Count == 0 && txt1.Text != "")
            {
                list.Items.Add(txt1.Text);
                txt1.Text = "";
            }
            else
            {
                if (list.Items.Contains(txt1.Text) == false && txt1.Text != "")
                {
                    list.Items.Add(txt1.Text);
                    txt1.Text = "";
                }
                else
                {
                    MessageBox.Show("Ugyan azt a hobbit nem adhatja meg.!");
                }
            }




        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
