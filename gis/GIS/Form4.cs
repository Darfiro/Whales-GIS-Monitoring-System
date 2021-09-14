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
    public partial class Form4 : Form
    {
        private int whaleId;
        private int scientistId;
        private DataTables data;
        private Boolean initialization;
        private DateTime chipDate;
        private Boolean added, chipped;
        Form5 frm5;

        public Form4(int whId, int scId, DataTables dt, Boolean newWhale)
        {
            InitializeComponent();
            whaleId = whId;
            scientistId = scId;
            data = dt;
            added = newWhale;
            chipped = false;
            if (newWhale)
                SetNewWhaleForm();
            else
                SetDataForm();
        }

        private void SetNewWhaleForm()
        {
            List<String> species = data.GetSpecies();
            specie.Items.Add("вид");
            foreach (String st in species)
            {
                specie.Items.Add(st);
            }
            specie.SelectedIndex = 0;

            gender.Items.Add("пол");
            gender.Items.Add("Female");
            gender.Items.Add("Male");
            gender.SelectedIndex = 0;

            ageUp.Minimum = 0;
            weigthUpDown.Value = weigthUpDown.Minimum;

            SetPonds();
        }

        private void SetDataForm()
        {
            List<String> info = data.GetWhaleForForm(whaleId);
            specie.Text = info[0];
            gender.Text = info[1];
            ageUp.Minimum = Convert.ToInt32(info[2]);
            weigthUpDown.Value = Convert.ToInt32(info[3]);
            if (Convert.ToBoolean(info[4]))
            {
                initialization = true;
                chipBox.Checked = true;
                chipBox.Enabled = false;
            }
            SetPonds();
        }

        private void SetPonds()
        {
            List<String> ponds = new List<string>();
            ponds.Add("North Pacific");
            ponds.Add("South Pacific");
            ponds.Add("North Atlantic");
            ponds.Add("South Atlantic");
            ponds.Add("Southern");
            ponds.Add("Indian");
            ponds.Add("Arctic");
            foreach (String p in ponds)
                pondBox.Items.Add(p);
        }

        private void chipBox_CheckedChanged(object sender, EventArgs e)
        {

            if (initialization)
                initialization = false;
            else if (chipBox.Checked)
            {
                chipped = true;
                double lat = 0, lon = 0;
                if (!added)
                {
                    if (Double.TryParse(latBox.Text, out lat) && Double.TryParse(lonBox.Text, out lon) && frm5 == null)
                    {
                        lblError.Text = "";
                        DateTime date = dateSpotted.Value;
                        frm5 = new Form5(whaleId, lat, lon, date);
                        frm5.FormClosed += frm5_FormClosed;
                        frm5.Show(this);
                    }
                    else
                    {
                        chipBox.Checked = false;
                        lblError.Text = "Вы не ввели данные о встрече";
                    }
                }
                else
                {
                    if (specie.SelectedItem.ToString() != "вид" && gender.SelectedItem.ToString() != "пол" && double.TryParse(latBox.Text, out lat) && Double.TryParse(lonBox.Text, out lon) && pondBox.SelectedItem.ToString() != "Водоем")
                    {
                        lblError.Text = "";
                        DateTime date = dateSpotted.Value;
                        frm5 = new Form5(whaleId, lat, lon, date);
                        frm5.FormClosed += frm5_FormClosed;
                        frm5.Show(this);
                    }
                    else
                    {
                        chipBox.Checked = false;
                        lblError.Text = "Вы не ввели данные о встрече";
                    }
                }
            }
            else
                chipped = false;
        }

        public void frm5_FormClosed(object sender, FormClosedEventArgs e)
        {
            chipDate = frm5.chipInfo;
            frm5 = null;
            Show();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            double lat = 0;
            double lon = 0;
            if (!added)
            {
                if (Double.TryParse(latBox.Text, out lat) && Double.TryParse(lonBox.Text, out lon) && pondBox.SelectedItem.ToString() != "Водоем")
                {
                    lblError.Text = "";
                    DateTime date = dateSpotted.Value;
                    data.InsertMeeting(lat, lon, pondBox.SelectedItem.ToString(), date, scientistId, whaleId);
                    data.UpdateWhale(whaleId, Convert.ToInt32(ageUp.Value), Convert.ToInt32(weigthUpDown.Value));
                    if (chipped)
                        data.InsertChip(whaleId, date, chipDate, lat, lon);
                    Close();
                }
                else
                {
                    lblError.Text = "Вы не ввели данные о встрече";
                }
            }
            else
            {
                if (specie.SelectedItem.ToString() != "вид" && gender.SelectedItem.ToString() != "пол" && double.TryParse(latBox.Text, out lat) && Double.TryParse(lonBox.Text, out lon) && pondBox.SelectedItem.ToString() != "Водоем")
                {
                    lblError.Text = "";
                    DateTime date = dateSpotted.Value;
                    data.InsertWhale(whaleId, gender.SelectedItem.ToString(), Convert.ToInt32(ageUp.Value), Convert.ToInt32(weigthUpDown.Value), specie.SelectedIndex);
                    data.InsertMeeting(lat, lon, pondBox.SelectedItem.ToString(), date, scientistId, whaleId);
                    if (chipped)
                        data.InsertChip(whaleId, date, chipDate, lat, lon);
                    Close();
                }
                else
                {
                    lblError.Text = "Вы не ввели данные о встрече";
                }
            }     
        }

        private void dateSpotted_ValueChanged(object sender, EventArgs e)
        {
            if (chipped)
            {
                chipBox.Checked = false;                
            }
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
