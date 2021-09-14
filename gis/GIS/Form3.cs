using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIS
{
    public partial class Form3 : Form
    {
        private DataTables data;
        private scientists scientist;
        Form4 frm4;
        Boolean added;

        public Form3()
        {
            InitializeComponent();
            whales.SelectedIndexChanged += whales_SelectedIndexChanged;
        }           

        private void SetWhales()
        {
            whales.Items.Clear();
            List<String> whaleInfo = data.GetWhales();
            foreach (String st in whaleInfo)
            {
                whales.Items.Add(st);
            }
        }

        public void SetData(scientists sc, DataTables dt)
        {
            data = dt;
            scientist = sc;
            SetWhales();
        }

        void whales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frm4 == null)
            {
                int id = whales.SelectedIndex + 1;
                frm4 = new Form4(id, scientist.id, data, false);
                frm4.FormClosed += frm4_FormClosed;
            }
            frm4.Show(this);
            added = false;
            Hide();
        }

        public void frm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm4 = null;
            Show();
            
            data.SetTables();
            if (added)
            {
                SetWhales();
                added = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void addMoreBtn_Click(object sender, EventArgs e)
        {
            added = true;
            if (frm4 == null)
            {
                int whaleId = whales.Items.Count + 1;
                frm4 = new Form4(whaleId, scientist.id, data, true); 
                frm4.FormClosed += frm4_FormClosed;
            }

            frm4.Show(this);
            Hide();
        }
    }
}
