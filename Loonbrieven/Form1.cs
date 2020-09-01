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

namespace Loonbrieven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Werknemer> werknemer = new List<Werknemer>();
        private void Form1_Load(object sender, EventArgs e)
        {

            Werknemer nemer1 = new Werknemer("Siva", "Man", new DateTime(1983, 06, 09), "83.02.12-582.82", new DateTime(2015, 06, 08),30,false,typecontract:"Deeltijds");
            Werknemer nemer2 = new Werknemer("Rama", "Man", new DateTime(1980, 03, 12), "80.02.12-652.79", new DateTime(2019, 07, 10),38,false);
            Werknemer nemer3 = new Werknemer("Sanjay", "Man", new DateTime(1985, 05, 02), "80.02.12-652.79", new DateTime(2018, 02, 12),25,false, typecontract: "Deeltijds");
            Werknemer programmeur1 = new Programmeur("Sujithra", "Vrouw", new DateTime(1983, 04, 09), "83.04.09-582.79", new DateTime(2019, 01, 06),38,true,true);
            Werknemer programmeur2 = new Programmeur("Latha", "Vrouw", new DateTime(1985, 04, 02), "85.04.02-241.98", new DateTime(2020, 01, 04), 38,true,true);
            Werknemer programmeur3 = new Programmeur("Ramya", "Vrouw", new DateTime(1985, 05, 08), "85.05.08-611.63", new DateTime(2017, 01, 05),38,false, false);
            Werknemer Itsupport1 = new ITSupport("Priya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01),30,false);
            Werknemer Itsupport2 = new ITSupport("Banu", "Vrouw", new DateTime(1978, 08, 10), "78.08.10-525.21", new DateTime(2019, 05, 10),32,false);
            Werknemer Itsupport3 = new ITSupport("Mona", "Vrouw", new DateTime(1975, 07, 09), "75.07.09-441.21", new DateTime(2018, 03, 05),33,false);
            Werknemer customersupport1 = new CustomerSupport("Jaya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01),36,false);
            Werknemer customersupport2 = new CustomerSupport("Vishnu", "Vrouw", new DateTime(1981, 08,10), "81.08.10-550.21", new DateTime(2020, 04, 06),37,false);
            Werknemer customersupport3 = new CustomerSupport("Vasuki", "Vrouw", new DateTime(1981, 05, 06), "81.05.06-350.98", new DateTime(2017, 02, 03),38,false);
            comboBox1.Items.Add("Werknemer");
            comboBox1.Items.Add("Programmeur");
            comboBox1.Items.Add("ITSupport");
            comboBox1.Items.Add("CustomersSupport");
            werknemer.Add(nemer1);
            werknemer.Add(nemer2);
            werknemer.Add(nemer3);
            werknemer.Add(programmeur1);
            werknemer.Add(programmeur2);
            werknemer.Add(programmeur3);
            werknemer.Add(Itsupport1);
            werknemer.Add(Itsupport2);
            werknemer.Add(Itsupport3);
            werknemer.Add(customersupport1);
            werknemer.Add(customersupport2);
            werknemer.Add(customersupport3);
            comboBox1.SelectedIndex = -1;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Programmeur":
                    List<Programmeur> programmeurs = new List<Programmeur>();

                    foreach (var item in werknemer.OfType<Programmeur>())
                    {
                        programmeurs.Add(item);
                    }

                    comboBox2.DataSource = null;
                    comboBox2.DataSource = programmeurs;
                    break;

                case "ITSupport":
                    List<ITSupport> itsupports = new List<ITSupport>();

                    foreach (var item in werknemer.OfType<ITSupport>())
                    {
                        itsupports.Add(item);
                    }

                    comboBox2.DataSource = null;
                    comboBox2.DataSource = itsupports;
                    break;
                case "CustomersSupport":
                    List<CustomerSupport> cussupports = new List<CustomerSupport>();

                    foreach (var item in werknemer.OfType<CustomerSupport>())
                    {
                        cussupports.Add(item);
                    }

                    comboBox2.DataSource = null;
                    comboBox2.DataSource = cussupports;
                    break;

                default:
                case "Werknemer":
                    comboBox2.DataSource = null;
                    comboBox2.DataSource = werknemer;
                    break;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string BestandsLocatie = Environment.CurrentDirectory ;
            if (!Directory.Exists(BestandsLocatie))
            {
                Directory.CreateDirectory(BestandsLocatie);
            }

            foreach (Werknemer nemer in werknemer)
            {
                nemer.MaakLoonBrief(BestandsLocatie);
            }
        }
    }
    }

