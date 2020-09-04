using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loonbrieven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Category> CategoryLijst = new List<Category>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Category category1 = new Category("Programmeur");
            CategoryLijst.Add(category1);
            Category category2 = new Category("ITSupport");
            CategoryLijst.Add(category2);
            Category category3 = new Category("CustomersSupport");
            CategoryLijst.Add(category3);
            Category category4 = new Category("Werknemer");
            CategoryLijst.Add(category4);
            comboBox1.DataSource = null;
            comboBox1.DataSource = CategoryLijst;
            Werknemer nemer1 = new Werknemer("Siva", "Man", new DateTime(1983, 06, 09), "83.02.12-582.82", new DateTime(2015, 06, 08), 30, "BE18 1534 6678 8800", startloon:1900,typecontract:"Deeltijds");
            Werknemer nemer2 = new Werknemer("Rama", "Man", new DateTime(1980, 03, 12), "80.02.12-652.79", new DateTime(2019, 07, 10), 38, "BE12 1534 6678 8811");
            Werknemer nemer3 = new Werknemer("Sanjay", "Man", new DateTime(1985, 05, 02), "80.02.12-652.79", new DateTime(2018, 02, 12), 25, "BE16 1534 6678 7500", typecontract: "Deeltijds");
            Werknemer programmeur1 = new Programmeur("Jeyan", "Man", new DateTime(1983, 04, 09), "83.04.09-582.79", new DateTime(2019, 01, 06), 38, "BE19 1534 6678 9600", true);
            Werknemer programmeur2 = new Programmeur("Latha", "Vrouw", new DateTime(1985, 04, 02), "85.04.02-241.98", new DateTime(2008, 01, 04), 38, "BE18 1534 6678 5200", true);
            Werknemer programmeur3 = new Programmeur("Ramya", "Vrouw", new DateTime(1985, 05, 08), "85.05.08-611.63", new DateTime(2017, 01, 05), 38, "BE18 1534 6678 7800", false);
            Werknemer Itsupport1 = new ITSupport("Priya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01), 38, "BE13 1534 6678 2100");
            Werknemer Itsupport2 = new ITSupport("Banu", "Vrouw", new DateTime(1978, 08, 10), "78.08.10-525.21", new DateTime(2019, 05, 10), 38, "BE16 1534 6678 5800");
            Werknemer Itsupport3 = new ITSupport("Mona", "Vrouw", new DateTime(1975, 07, 09), "75.07.09-441.21", new DateTime(2018, 03, 05), 38, "BE14 1534 6614 8800");
            Werknemer customersupport1 = new CustomerSupport("Jaya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01), 38, "BE18 1234 6676 8800");
            Werknemer customersupport2 = new CustomerSupport("Vishnu", "Vrouw", new DateTime(1981, 08, 10), "81.08.10-550.21", new DateTime(2020, 04, 06), 38, "BE18 1234 6878 8800");
            Werknemer customersupport3 = new CustomerSupport("Vasuki", "Vrouw", new DateTime(1981, 05, 06), "81.05.06-350.98", new DateTime(2017, 02, 03), 38, "BE18 1634 6278 8800");

            category4.WerknemersLijst.Add(nemer1);
            category4.WerknemersLijst.Add(nemer2);
            category4.WerknemersLijst.Add(nemer3);
            category1.WerknemersLijst.Add(programmeur1);
            category1.WerknemersLijst.Add(programmeur2);
            category1.WerknemersLijst.Add(programmeur3);
            category2.WerknemersLijst.Add(Itsupport1);
            category2.WerknemersLijst.Add(Itsupport2);
            category2.WerknemersLijst.Add(Itsupport3);
            category3.WerknemersLijst.Add(customersupport1);
            category3.WerknemersLijst.Add(customersupport2);
            category3.WerknemersLijst.Add(customersupport3);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            comboBox2.DataSource = null;
            comboBox2.DataSource = CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst;
        }




        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            Werknemer selected = (Werknemer)comboBox2.SelectedItem;

            if (comboBox2.DataSource != null)
            {
                label1.Text = selected.Beschrijf();
                label3.Text = selected.Loonbrieven();
            }
            else
            {
                label1.Text = "";
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string BestandsLocatie = Environment.CurrentDirectory;
            if (!Directory.Exists(BestandsLocatie))
            {
                Directory.CreateDirectory(BestandsLocatie);
            }
                CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst[comboBox2.SelectedIndex].MaakLoonBrief(BestandsLocatie);
            MessageBox.Show("LOONBRIEF GEMAAKT.",
                              "GEDAAN!",
                 MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nieuwewerknemeradd oef = new nieuwewerknemeradd();
            if (oef.ShowDialog() == DialogResult.OK)
            {
                oef.groupBox4.Visible = false;
                string naam = "";
                string rijks = "";
                string iban = "";
                bool check = true;
                if (oef.textBox1.Text.Trim().Length > 0)
                {
                    naam = oef.textBox1.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Geef de Naam a.u.b");
                    check = false;
                }
                if (Regex.IsMatch(oef.textBox2.Text, @"[0-9].-$") && oef.textBox2.Text.Trim().Length > 0)
                {
                    rijks = oef.textBox2.Text;
                }
                else
                {
                    MessageBox.Show("Geef jouw Juist RijksRegiserNummer a.u.b");
                    check = false;
                }
                if (Regex.IsMatch(oef.maskedTextBox1.Text, @"\d{2}\d{4}\d{4}\d{4}$"))
                {
                    iban= oef.maskedTextBox1.Text;
                }
                else
                {
                    MessageBox.Show("Geef Geldig IBAN Nummer a.u.b");
                    check = false;
                }
                string geslacht = "";
                foreach (var item in oef.groupBox1.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                        geslacht = item.Text;
                    else
                        MessageBox.Show("Select de Geslacht a.u.b");
                    check = false;
                }
                string functie = "";
                foreach (var item in oef.groupBox2.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                        functie = item.Text;
                    else
                        MessageBox.Show("Select de Functie a.u.b");
                    check = false;
                }
                string typecontract = "";
                foreach (var item in oef.groupBox3.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                        typecontract = item.Text;
                    else
                        MessageBox.Show("Select de TypeContract a.u.b");
                    check = false;
                }
                if(functie=="Programmeur")
                {
                    oef.groupBox4.Visible = true;
                    oef.groupBox4.Enabled = true;
                }
                
                DateTime geboort;
                geboort = oef.dateTimePicker1.Value;
                DateTime indatum;
                indatum = oef.dateTimePicker2.Value;
                int uren = (int)oef.numericUpDown1.Value;
                if (naam.Length > 0 && rijks.Length > 0 && check)
                {
                    CategoryLijst[comboBox1.SelectedIndex].WerknemerAdd(new Werknemer(naam, geslacht, geboort, rijks, indatum, uren,iban, functie,typecontract));
                    comboBox2.DataSource = null;
                    comboBox2.DataSource = CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst;
                    MessageBox.Show("Nieuwe Werknemer Toegevoegd.",
                                  "SUCESS!",
                             MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);

                }
            }
        }

            private void button2_Click(object sender, EventArgs e)
            {
                CategoryLijst[comboBox1.SelectedIndex].WerknemerRemove(comboBox2.SelectedItem as Werknemer);
                comboBox2.DataSource = null;
                comboBox2.DataSource = CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst;
                MessageBox.Show(" Werknemer Verwijdered.",
                       "Gedaan!",
                       MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
            }

            private void button4_Click(object sender, EventArgs e)
            {
                if (comboBox2 != null)
                {
                    nieuwewerknemeradd werknemer = new nieuwewerknemeradd(comboBox2.SelectedItem as Werknemer);
                    if (werknemer.ShowDialog() == DialogResult.OK)
                    {
                    CategoryLijst[comboBox1.SelectedIndex].WerknemerRemove(comboBox2.SelectedItem as Werknemer);
                    CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst.Add(werknemer.werknemer);
                    MessageBox.Show(" Werknemer Aangepast.",
                              "Gedaan!",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1);
                    comboBox2.DataSource = null;
                    comboBox2.DataSource = CategoryLijst[comboBox1.SelectedIndex].WerknemersLijst;
                }
                
            }

        }

        }
    } 
    

