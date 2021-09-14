using System;
using System.Collections.Generic;

namespace dataGeneratorProgramm
{
    class Program
    {
               
        static String GenerateDate()
        {
            Random rnd = new Random();
            int year = 2017;
            int month = rnd.Next(1, 7);
            int day = 1;
            if (month == 4 || month == 6)
            {
                day = rnd.Next(1, 31);
            }
            else if (month == 2)
            {
                day = rnd.Next(1, 28);
            }
            else
            {
                day = rnd.Next(1, 32);
            }
            String date = "";
            if (day < 10)
            {
                date = "0";
            }
            date += day.ToString() + "/";
            if (month < 10)
            {
                date += "0";
            }
            date += month.ToString() + "/";
            date += year.ToString();
            return date;
        }

        static KeyValuePair<double, double> GenerateLatLon(String ocean)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();            
            double lat = 0, lon = 0;
            switch (ocean)
            {
                case "North Pacific":
                    {
                        lat = (30 * rnd1.NextDouble());
                        lon = (35 * rnd2.NextDouble()) + 140;
                        break;
                    }
                case "South Pacific":
                    {
                        lat = (50 * rnd1.NextDouble()) - 60;
                        lon = (60 * rnd2.NextDouble()) - 150;
                        break;
                    }
                case "North Atlantic":
                    {
                        lat = (30 * rnd1.NextDouble()) + 10;
                        lon = (30 * rnd2.NextDouble()) - 60;
                        break;
                    }
                case "South Atlantic":
                    {
                        lat = (40 * rnd1.NextDouble()) - 50;
                        lon = (35 * rnd2.NextDouble()) - 30;
                        break;
                    }
                case "Indian":
                    {
                        lat = (35 * rnd1.NextDouble()) - 40;
                        lon = (40 * rnd2.NextDouble()) + 60;
                        break;
                    }
                case "Southern":
                    {
                        lat = (10 * rnd1.NextDouble()) - 60;
                        lon = (10 * rnd2.NextDouble()) + 130;
                        break;
                    }
                case "Arctic":
                    {
                        lat = (8 * rnd1.NextDouble()) + 72;
                        lon = (40 * rnd2.NextDouble()) - 170;
                        break;
                    }
            }
            KeyValuePair<double, double> pair = new KeyValuePair<double, double>(lat, lon);
            return pair;
        }

        static String GenerateWhaleLine(int i)
        {
            String res = (i + 1).ToString();
            Random rnd = new Random();
            int g = rnd.Next(0, 2);
            if (g == 0)
                res += ", Female, ";
            else
                res += ", Male, ";
            int age = rnd.Next(2, 100);
            res += age.ToString() + ", ";
            double weight = rnd.Next(1000,100000);
            res += weight.ToString() + "\n"; 

            return res;
        }

        static String GenerateLink(int id, int numLines, ref int sp)
        {
            String res = (id + 1).ToString();
            Random rnd = new Random();
            int link = rnd.Next(1, numLines + 1);
            sp = link;
            res += ", " + (id + 1).ToString() + ", " + link.ToString() + "\n";
            return res;
        }

        static String GeneratePond(int specie)
        {
            Random rnd = new Random();
            String res = "";
            int index = 0;
            if (specie == 1 || specie == 2)
            {
                List<String> blue_hump = new List<String>();
                blue_hump.Add("North Pacific");
                blue_hump.Add("South Pacific");
                blue_hump.Add("North Atlantic");
                blue_hump.Add("South Atlantic");
                blue_hump.Add("Southern");
                blue_hump.Add("Indian");
                blue_hump.Add("Arctic");
                index = rnd.Next(0, 7);
                res = blue_hump[index];
            }
            else
            {
                List<String> gray = new List<String>();
                gray.Add("North Pacific");
                gray.Add("South Pacific");
                gray.Add("Arctic");
                index = rnd.Next(0, 3);
                res = gray[index];
            }
            return res;
        }

        static String GenerateMeetings(int index, String pond, ref String date, int numSc)
        {
            String res = (index + 1).ToString() + ", ";
            Random rnd = new Random();
            int link = rnd.Next(1, numSc + 1);
            KeyValuePair<double, double> gen = GenerateLatLon(pond);
            double lat = gen.Key;
            double lon = gen.Value;
            res += lat.ToString("0.0000000000", System.Globalization.CultureInfo.InvariantCulture) + " , " + lon.ToString("0.0000000000", System.Globalization.CultureInfo.InvariantCulture);
            res += ", " + pond + ", ";
            date = GenerateDate();
            res += date + ", " + link + "\n";
            return res;
        }

        static String GenerateDateFrom(String date)
        {
            String newdt = "";
            String [] dt = date.Split("/");            
            String month = dt[1];
            String day = dt[0], year = dt[2];
            int dy = Convert.ToInt32(day);
            if (dy > 28)
                day = "28";
            int mn = Convert.ToInt32(month);
            if (mn + 1 > 12)
            {
                month = "01";
                year = (Convert.ToInt32(year) + 1).ToString();
            }
            else
            {
                mn++;
                if (mn < 10)
                    month = "0" + mn.ToString();
                else
                    month = mn.ToString();
            }
            newdt = day + "/" + month + "/" + year;

            return newdt;
        }

        static String GenerateChip(int index, String date)
        {
            String res = (index + 1).ToString() + ", ";
            String year = "2030";
            String month = date.Split("/")[1];
            String day = date.Split("/")[0];
            res += date + ", ";
            res += day + "/" + month + "/" + year + "\n";
            return res;
        }

        static String GenerateLinkId(int id, int id1, int id2)
        {
            String res = (id + 1).ToString() + ", ";
            res += (id1 + 1).ToString() + ", " + (id2 + 1).ToString() + "\n";
            return res;
        }

        static String GenerateChipLocation(int id, String pond, ref String date, int chipId)
        {
            String res = (id + 1).ToString() + ", ";
            date = GenerateDateFrom(date);
            KeyValuePair<double, double> gen = GenerateLatLon(pond);
            double lat = gen.Key;
            double lon = gen.Value;
            res += lat.ToString("0.0000000000", System.Globalization.CultureInfo.InvariantCulture) + " , " + lon.ToString("0.0000000000", System.Globalization.CultureInfo.InvariantCulture);
            res += ", " + date + ", " + chipId + "\n";
            return res;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<String> whales = new List<String>(); // gen age weight
            List<String> chip = new List<String>();  // date from date to
            List<String> chip_location = new List<String>();  // lat lon date
            List<String> meetings = new List<String>();  // lat lon pond date 
            List<String> whales_meeting = new List<String>(); // whale id -> meeting id
            List<String> meeting_scientist = new List<String>();  // meeting id -> scientist id 
            List<String> whales_chip = new List<String>();  // whale id -> chip id
            List<String> whales_specie = new List<String>();  // whale id -> specie id
            List<String> whales_scientist = new List<String>();  // whale id -> scientist id
            int hasChip = 0, meetingCount = 0, sp = 1;
            String date = "";

            for (int i = 0; i < 500; i++)
            {
                whales.Add(GenerateWhaleLine(i));
                whales_scientist.Add(GenerateLink(i, 200, ref sp));
                whales_specie.Add(GenerateLink(i, 3, ref sp));
                meetingCount = rnd.Next(1, 6);
                hasChip = rnd.Next(0, 2);
                String pond = GeneratePond(sp);

                meetings.Add(GenerateMeetings(meetings.Count, pond, ref date, 200));
                whales_meeting.Add(GenerateLinkId(whales_meeting.Count, i, meetings.Count - 1));
                meeting_scientist.Add(GenerateLink(meeting_scientist.Count, 200, ref sp));                    

                if (hasChip == 1)
                {
                    chip.Add(GenerateChip(chip.Count, date));
                    whales_chip.Add(GenerateLinkId(whales_chip.Count, i, chip.Count - 1));
                    for (int k = 0; k < 25; k ++)
                    {
                        chip_location.Add(GenerateChipLocation(chip_location.Count, pond, ref date, chip.Count));                        
                    }
                }

                for (int j = 0; j < meetingCount - 1; j++)
                {
                    meetings.Add(GenerateMeetings(meetings.Count, pond, ref date, 200));
                    whales_meeting.Add(GenerateLinkId(whales_meeting.Count, i, meetings.Count - 1));
                }
            }
           
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\whales.csv", whales.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\whales_chip.csv", whales_chip.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\whales_meeting.csv", whales_meeting.ToArray());
            
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\chip_location.csv", chip_location.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\chip.csv", chip.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\meetings.csv", meetings.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\chip_location.csv", chip_location.ToArray());
            System.IO.File.WriteAllLines(@"C:\Users\dvfir\Documents\3 course\Базы данных\курсовая\бд\whales_specie.csv", whales_specie.ToArray());
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
