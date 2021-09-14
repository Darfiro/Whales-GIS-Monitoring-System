using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIS
{
    public partial class Form1 : Form
    {
        Form2 frm2;
        Form3 frm3;
        private DataTables data;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            map.MapProvider = GMapProviders.BingHybridMap;
            data = new DataTables();
            data.SetTables();

            SetSpecies();
            SetWhales();                       
        }

        private void SetSpecies()
        {
            List<String> species = data.GetSpecies();
            specieWhale.Items.Add("все");
            foreach (String st in species)
            {
                specieWhale.Items.Add(st);
            }
            specieWhale.SelectedIndex = 0;            
        }

        private void SetWhales()
        {
            whaleId.Items.Clear();
            List<String> whaleInfo = data.GetWhales();
            whaleId.Items.Add("все");
            foreach (String st in whaleInfo)
            {
                whaleId.Items.Add(st);
            }
            whaleId.SelectedIndex = 0;
        }

        private void showWhales_Click(object sender, EventArgs e)
        {
            map.Overlays.Clear();
            GMapOverlay markers = new GMapOverlay("markers");
            List<MapPin> pins = new List<MapPin>();
            List<string> info = new List<string>();
            if (whaleId.SelectedIndex != 0)
            {
                if (GroupRdBtn.Checked)
                    pins = data.GetPinsByWhaleId(whaleId.SelectedIndex, ref info);
                else if (ChipRdBtn.Checked)
                    pins = data.GetPinsByWhaleChip(whaleId.SelectedIndex, ref info);
            }
            else if (specieWhale.SelectedItem.ToString() != "все")
            {                
                if (GroupRdBtn.Checked)
                    pins = data.GetPinsBySpecieMeeting(specieWhale.SelectedItem.ToString());
                else if (ChipRdBtn.Checked)
                    pins = data.GetPinsBySpecieChip(specieWhale.SelectedItem.ToString());
                info = data.GetSpecieInfo(specieWhale.SelectedItem.ToString());
            }
            else
            {
                infoBox.Clear();
                if (GroupRdBtn.Checked)
                    pins = data.GetPinsAllWhale();
                else if (ChipRdBtn.Checked)
                    pins = data.GetPinsAllChip();
            }

            if (ChipRdBtn.Checked && whaleId.SelectedIndex != 0)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (MapPin pin in pins)
                {
                    points.Add(pin.GetCoordinates());
                    GMapMarker marker = CreateMarker(pin);
                    markers.Markers.Add(marker);                   
                }
                if (pins.Count != 0)
                {
                    GMapRoute route = new GMapRoute(points, "route");
                    route.Stroke = new Pen(pins.Last<MapPin>().GetColor(), 2);
                    markers.Routes.Add(route);
                }                
            }
            else
            {
                foreach (MapPin pin in pins)
                {
                    GMapMarker marker = CreateMarker(pin);
                    markers.Markers.Add(marker);
                }
            }

            if (info.Count() != 0)
                ParseInfo(info);

            map.Overlays.Add(markers);
        }

        private GMapMarker CreateMarker(MapPin pin)
        {
            GMapMarker marker = pin.GetPin();
            MarkerTooltipMode mode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTip = new GMapToolTip(marker);
            marker.ToolTipMode = mode;
            Brush ToolTipBackColor = new SolidBrush(Color.White);
            marker.ToolTip.Fill = ToolTipBackColor;
            marker.ToolTipText = pin.GetPinText();
            return marker;
        }

        private void ParseInfo(List<string> info)
        {
            infoBox.Clear();
            infoBox.ReadOnly = false;
            foreach (string line in info)
                infoBox.AppendText(line);
            infoBox.ReadOnly = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (frm3 == null)
            {
                frm3 = new Form3();
                frm3.FormClosed += frm3_FormClosed;
            }

            if (frm2 == null)
            {
                frm2 = new Form2(data, frm3);   
                frm2.FormClosed += frm2_FormClosed;  
            }
            frm2.Show(this);  
            Hide();
        }

        public void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!frm2.authorized)
            {
                Show();
                data.SetTables();
            }
            frm2 = null;
        }

        public void frm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm3 = null;
            Show();
            
            data.SetTables();
            SetWhales();
        }
    }
}
