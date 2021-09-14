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
    public partial class Form5 : Form
    {
        public DateTime chipInfo;
        private int whaleId;
        private double latitude, longitude;
        private DateTime start;

        public Form5(int whId, double lat, double lon, DateTime dt)
        {
            InitializeComponent();
            whaleId = whId;
            latitude = lat;
            longitude = lon;
            start = dt;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (finishDate.Value.Year > start.Year || finishDate.Value.Month > start.Month)
            {                
                chipInfo = finishDate.Value;
                Close();
            }
            else
                lblError.Text = "Маячок должен проработать\nхотя бы месяц от\n" + start.ToString();
        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
