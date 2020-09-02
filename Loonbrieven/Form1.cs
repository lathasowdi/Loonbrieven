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
        public List<Category> categorylist = new List<Category>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Category category1 = new Category("Programmeur");
            categorylist.Add(category1);
            Category category2 = new Category("ITSupport");
            categorylist.Add(category2);
            Category category3 = new Category("CustomersSupport");
            categorylist.Add(category3);
            Category category4 = new Category("Werknemer");
            categorylist.Add(category4);
            comboBox1.DataSource = null;
            comboBox1.DataSource = categorylist;
            Werknemer nemer1 = new Werknemer("Siva", "Man", new DateTime(1983, 06, 09), "83.02.12-582.82", new DateTime(2015, 06, 08),38,false);
            Werknemer nemer2 = new Werknemer("Rama", "Man", new DateTime(1980, 03, 12), "80.02.12-652.79", new DateTime(2019, 07, 10),38,false);
            Werknemer nemer3 = new Werknemer("Sanjay", "Man", new DateTime(1985, 05, 02), "80.02.12-652.79", new DateTime(2018, 02, 12),38,false, typecontract: "Deeltijds");
            Werknemer programmeur1 = new Programmeur("Jeyan", "Man", new DateTime(1983, 04, 09), "83.04.09-582.79", new DateTime(2019, 01, 06),38,true,true);
            Werknemer programmeur2 = new Programmeur("Latha", "Vrouw", new DateTime(1985, 04, 02), "85.04.02-241.98", new DateTime(2020, 01, 04), 38,true,true);
            Werknemer programmeur3 = new Programmeur("Ramya", "Vrouw", new DateTime(1985, 05, 08), "85.05.08-611.63", new DateTime(2017, 01, 05),38,false, false);
            Werknemer Itsupport1 = new ITSupport("Priya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01),38,false);
            Werknemer Itsupport2 = new ITSupport("Banu", "Vrouw", new DateTime(1978, 08, 10), "78.08.10-525.21", new DateTime(2019, 05, 10),38,false);
            Werknemer Itsupport3 = new ITSupport("Mona", "Vrouw", new DateTime(1975, 07, 09), "75.07.09-441.21", new DateTime(2018, 03, 05),38,false);
            Werknemer customersupport1 = new CustomerSupport("Jaya", "Vrouw", new DateTime(1978, 07, 09), "78.07.09-450.21", new DateTime(2019, 01, 01),38,false);
            Werknemer customersupport2 = new CustomerSupport("Vishnu", "Vrouw", new DateTime(1981, 08,10), "81.08.10-550.21", new DateTime(2020, 04, 06),38,false);
            Werknemer customersupport3 = new CustomerSupport("Vasuki", "Vrouw", new DateTime(1981, 05, 06), "81.05.06-350.98", new DateTime(2017, 02, 03),38,false);
            
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
            comboBox2.DataSource = categorylist[comboBox1.SelectedIndex].WerknemersLijst;
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
            string BestandsLocatie = Environment.CurrentDirectory ;
            if (!Directory.Exists(BestandsLocatie))
            {
                Directory.CreateDirectory(BestandsLocatie);
            }

            foreach (Werknemer nemer in categorylist[comboBox1.SelectedIndex].WerknemersLijst)
            {
                nemer.MaakLoonBrief(BestandsLocatie);
            }
            MessageBox.Show("LOONBRIEF GEMAAKT.",
    "GEDAAN!",
    MessageBoxButtons.OK,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button1);
            
        }
    }
    }

