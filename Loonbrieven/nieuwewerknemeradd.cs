using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loonbrieven
{
    public partial class nieuwewerknemeradd : Form
    {
        public Werknemer werknemer { get; set; } = null;
        public nieuwewerknemeradd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        public nieuwewerknemeradd(Werknemer werknemer)
        {
            this.werknemer = werknemer;
            InitializeComponent();
        }
        private void nieuwewerknemeradd_Load(object sender, EventArgs e)
        {

        }

        
    }
}
