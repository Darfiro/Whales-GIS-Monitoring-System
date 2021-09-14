using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace GIS
{
    public class MapPin
    {
        private string pinColor;
        private bool withChip;
        private double latitude, longtitude;
        private string date;
        private int whaleId;

        public void SetPin(double? lat, double? lng, string colorName, bool chip, string dt, int id)
        {
            latitude = Convert.ToDouble(lat);
            longtitude = Convert.ToDouble(lng);
            pinColor = colorName.Trim();
            withChip = chip;
            date = dt.Split(' ')[0];
            whaleId = id;
        }

        public void SetPinColor(string colorName)
        {
            pinColor = colorName;
        }

        public void SetChip(bool chip)
        {
            withChip = chip;
        }   
        
        public MapPin()
        {
            withChip = false;
            latitude = 0;
            longtitude = 0;
            pinColor = "black";
        }

        public string GetPinColor()
        {
            return pinColor;
        }

        public PointLatLng GetCoordinates() { return new PointLatLng(latitude, longtitude); }

        private GMarkerGoogleType GetPinType()
        {            
            switch (pinColor)
            {
                case "red": if (withChip)
                                return GMarkerGoogleType.red_dot;
                            else
                                return GMarkerGoogleType.red;
                case "yellow": if (withChip)
                                   return GMarkerGoogleType.yellow_dot;
                               else
                                   return GMarkerGoogleType.yellow;
                case "blue": if (withChip)
                                return GMarkerGoogleType.blue_dot;
                             else
                                return GMarkerGoogleType.blue;
                default: return GMarkerGoogleType.black_small;
            }
        }

        public Color GetColor()
        {
            Color col = new Color();
            switch (pinColor)
            {
                case "red":
                    col = Color.Red;
                    break;
                case "yellow":
                    col = Color.Yellow;
                    break;
                case "blue":
                    col = Color.Blue;
                    break;
                default:
                    col = Color.Black;
                    break;
            }
            return col;
        }
        
        public GMapMarker GetPin()
        {            
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longtitude), GetPinType());
            return marker;
        }

        public String GetPinText()
        {
            String line = latitude.ToString() + ", " + longtitude.ToString() + "\n";
            line += "дата: " + date + "\n";
            line += "id кита: " + whaleId;
            return line;
        }
    }
}
