using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIS
{
    public class DataTables
    {
        private String connectionString = @"Data Source = DESKTOP-3OU1766; Database = GIS; Integrated Security = true";
        private static DataClassesDataContext db;
        private Table<chip> chipWhale;
        private Table<chip_location> chipLocation;
        private Table<whales> whalesTable;
        private Table<whales_chip> whaleChipIDTable;
        private Table<whales_meeting> whaleMeetingIDTable;
        private Table<scientists> scientistsInfo;
        private Table<species> speciesWhale;
        private Table<whales_specie> whaleSpecieIDTable;
        private Table<meetings> whaleMeeting;

        public DataTables() { }       

        public void SetTables()
        {
            if (db != null)
                db.Dispose();
            db = new DataClassesDataContext(connectionString);
            chipWhale = db.GetTable<chip>();
            whalesTable = db.GetTable<whales>();
            whaleChipIDTable = db.GetTable<whales_chip>();
            whaleMeetingIDTable = db.GetTable<whales_meeting>();
            scientistsInfo = db.GetTable<scientists>();
            speciesWhale = db.GetTable<species>();
            whaleSpecieIDTable = db.GetTable<whales_specie>();
            whaleMeeting = db.GetTable<meetings>();
            chipLocation = db.GetTable<chip_location>();
        }

        // Возвращает список чипированных китов 
        private IQueryable<whales> GetChipedWhales()
        {
            IQueryable<whales> allChips = from ch in whalesTable
                                          join idt in whaleChipIDTable on ch.id equals idt.whale_id
                                          select ch;
            return allChips;
        }

        // Возвращает информацию по чипу данного кита
        private IQueryable<chip> GetChipInfo(int id)
        {
            IQueryable<chip> chIn = from ch in chipWhale
                                          join idt in whaleChipIDTable on ch.id equals idt.chip_id
                                          where idt.whale_id == id
                                          select ch;
            return chIn;
        }

        // Возвращает информацию о перемещениях данного чипа
        private IQueryable<chip_location> GetChipLocationInfo(int id)
        {
            IQueryable<chip_location> chIn = from ch in chipLocation
                                             where ch.chip_id == id
                                             select ch;
            return chIn;
        }

        // Возвращает информацию о встречах с данным китом
        private IQueryable<meetings> GetWhaleMeetingsInfo(int id)
        {
            IQueryable<meetings> chIn = from ch in whaleMeeting
                                        join idt in whaleMeetingIDTable on ch.id equals idt.meeting_id
                                        where idt.whale_id == id
                                        select ch;
            return chIn;
        }

        // Возвращает информацию о последней встрече с данным китом
        private meetings GetLastWhaleMeeting(int id)
        {
            IQueryable<meetings> chIn = GetWhaleMeetingsInfo(id);
            List<meetings> meetings = chIn.OrderBy(meet => meet.date_spotted).ToList();
            return meetings.Last<meetings>();
        }

        // Возвращает информацию о последнем сообщении маячка данного чипа
        private chip_location GetLastWhaleChip(int id)
        {            
            IQueryable<chip_location> chIn = GetChipLocationInfo(id);
            List<chip_location> lc = chIn.OrderBy(loc => loc.date_located).ToList();
            return lc.Last();
        }
      
        // Возвращает информацию об ученом, сделавшем данную запись о встрече
        private IQueryable<scientists> GetScientistsByMeetingId(int idm)
        {
            IQueryable<scientists> sct = from s in scientistsInfo
                                         where s.id == idm
                                         select s;
            return sct;
        }
        

        // Возвращает вид по id кита
        private IQueryable<species> GetSpecieByWhale(int id)
        {
            IQueryable<species> spColor = from sp in speciesWhale
                                          join idt in whaleSpecieIDTable on sp.id equals idt.specie_id
                                          where idt.whale_id == id
                                          select sp;
            return spColor;
        }

        // Возвращает цвет маркера по виду
        private string GetColorBySpecie(string specie)
        {
            var spColor = from sp in speciesWhale
                          where sp.specie_name.Trim() == specie
                          select sp.color;
            return spColor.SingleOrDefault<string>();
        }

        // Возвращает информацию о виде
        private species GetSpecie(string specie)
        {
            var spId = from sp in speciesWhale
                       where sp.specie_name.Trim() == specie
                       select sp;
            return spId.Single<species>();
        }

        // Возвращает информацию о ките
        private whales GetWhale(int id)
        {
            IQueryable<whales> wh = from w in whalesTable
                                    where w.id == id
                                    select w;
            return wh.Single<whales>();
        }

        // Возвращает список китов данного вида
        private IQueryable<whales> GetWhaleBySpecie(string specie)
        {
            int id = GetSpecie(specie).id;
            IQueryable<whales> wh = from w in whalesTable
                                    join idt in whaleSpecieIDTable on w.id equals idt.whale_id
                                    where idt.specie_id == id
                                    select w;
            return wh;
        }

        // Возвращает ученого по логину и паролю
        private IQueryable<scientists> GetScientistAuthorized(String login, String password)
        {
            IQueryable<scientists> sc = from s in scientistsInfo                                 
                                        where s.login.Trim() == login && s.password.Trim() == password
                                        select s;
            return sc;
        }

        // Генерирует строку о данном виде
        public List<string> GetSpecieInfo(string specie)
        {
            List<string> info = new List<string>();
            species sp = GetSpecie(specie);
            info.Add("Название вида на латыне: " + sp.latin_name + "\n");
            info.Add("Название вида: " + sp.specie_name + "\n");
            info.Add("Ареал обитания: " + sp.areal + "\n");
            info.Add("Популяция: " + sp.population.ToString() + "\n");
            info.Add("Статус: " + sp.status + "\n");
            info.Add("Опасности: " + sp.dangers + "\n");
            return info;
        }

        // Генерирует строку о данном ките
        private List<string> GetWhaleStatInfo(int id)
        {
            List<string> info = new List<string>();
            whales wh = GetWhale(id);
            info.Add("Пол: " + wh.gender + "\n");
            info.Add("Возвраст: " + wh.age.ToString() + "\n");
            info.Add("Вес (кг.): " + wh.weight.ToString() + "\n");
            info.Add("\n");
            return info;
        }

        // Генерирует строку о встречах с китом
        private List<string> GetMeetingInfo(meetings mt)
        {
            List<string> info = new List<string>();
            scientists st = GetScientistsByMeetingId((int)mt.scientist_id).Single<scientists>();
            String dt = mt.date_spotted.ToString().Split(' ')[0];
            info.Add("Место встречи: " + mt.pond_name + "\n");
            info.Add("Координаты: " + mt.latitude.ToString() + " , " + mt.longitude.ToString() + "\n");
            info.Add("Дата встречи: " + dt + "\n");
            info.Add("Ученый: " + st.fullname.Trim() + "\n");
            info.Add("Страна ученого: " + st.country.Trim() + "\n");
            info.Add("Дата регистрации ученого: " + st.register_date.ToString().Replace("0:00:00","") + "\n");
            return info;
        }

        // Генерирует строку о чипе кита
        private List<string> GetWhaleChipInfo(chip ch)
        {
            List<string> info = new List<string>();
            String dt = ch.date_start.ToString().Split(' ')[0];
            info.Add("Дата активации чипа: " + dt + "\n");
            dt = ch.date_finish.ToString().Split(' ')[0];
            info.Add("Дата окончания срока службы чипа: " + dt + "\n");
            return info;
        }

        public List<string> GetWhaleForForm(int id)
        {
            List<string> info = new List<string>();
            whales wh = GetWhale(id);
            species sp = GetSpecieByWhale(id).SingleOrDefault<species>();
            IQueryable<chip> chip = GetChipInfo(id);
            Boolean chipped = false;
            foreach(var ch in chip)
            {
                if (ch.date_finish > DateTime.Now)
                    chipped = true;
            }

            info.Add(sp.specie_name.Trim());            
            info.Add(wh.gender.Trim());
            info.Add(wh.age.ToString());
            info.Add(wh.weight.ToString());
            info.Add(chipped.ToString());
            return info;
        }

        // Создает список id всех китов для меню
        public List<String> GetWhales()
        {
            List<String> whInfo = new List<String>();

            var grId = from gr in whalesTable
                       select gr.id;
            foreach(int gr in grId)
            {
                String info = gr.ToString() + " " + GetSpecieByWhale(gr).Single<species>().specie_name.Trim();
                whInfo.Add(info);
            }                       

            return whInfo;
        }

        // Создает список всех видов для меню
        public List<String> GetSpecies()
        {
            List<String> species = new List<String>();

            var specieName = from sp in speciesWhale
                             select sp.specie_name;
            foreach (string sp in specieName)
            {
                species.Add(sp.Trim());
            }

            return species;
        }

        // Возвращает маркеры всех встреч с данным китом
        public List<MapPin> GetPinsByWhaleId(int id, ref List<string> info)
        {
            List<MapPin> pins = new List<MapPin>();
            var whaleIsHere = GetWhaleMeetingsInfo(id).OrderBy(meet => meet.date_spotted);
            species sp = GetSpecieByWhale(id).SingleOrDefault<species>();
            string whaleColor = sp.color;            
            int k = 1;

            info.Add("Вид: " + sp.specie_name + "\n");
            info.AddRange(GetWhaleStatInfo(id));

            foreach (var lt in whaleIsHere)
            {
                MapPin pin = new MapPin();
                pin.SetPin(lt.latitude, lt.longitude, whaleColor, false, lt.date_spotted.ToString(), id);
                pins.Add(pin);
                info.Add("Информация о встрече № " + k.ToString() + "\n");
                info.AddRange(GetMeetingInfo(lt));
                info.Add("\n");
                k++;
            }

            return pins;
        }

        // Возвращает маркеры всех сообщений маячка данного кита
        public List<MapPin> GetPinsByWhaleChip(int id, ref List<string> info)
        {
            List<MapPin> pins = new List<MapPin>();
            species sp = GetSpecieByWhale(id).SingleOrDefault<species>();
            string whaleColor = sp.color;

            var chip = GetChipInfo(id);

            info.Add("Вид: " + sp.specie_name + "\n");
            info.AddRange(GetWhaleStatInfo(id));

            if (chip.Count<chip>() != 0)
            {
                foreach(var ch in chip)
                {
                    info.AddRange(GetWhaleChipInfo(ch));
                    var chipInfo = GetChipLocationInfo(ch.id);

                    foreach (var lt in chipInfo)
                    {
                        MapPin pin = new MapPin();
                        pin.SetPin(lt.latitude, lt.longitude, whaleColor, true, lt.date_located.ToString(), id);
                        pins.Add(pin);
                    }
                }                
            }
            else
                info.Add("У кита нет маячка\n");

            return pins;
        }

        // Возвращает маркеры последней встречи с каждым китом этого вида
        public List<MapPin> GetPinsBySpecieMeeting(string specie)
        {
            List<MapPin> pins = new List<MapPin>();
            var whs = GetWhaleBySpecie(specie);
            string color = GetColorBySpecie(specie);

            foreach (var w in whs)
            {
                meetings mt = GetLastWhaleMeeting(w.id);
                MapPin pin = new MapPin();
                pin.SetPin(mt.latitude, mt.longitude, color, false, mt.date_spotted.ToString(), w.id);
                pins.Add(pin);
            }

            return pins;
        }

        // Возвращает маркеры последнеего сообщения каждого маячка этого вида
        public List<MapPin> GetPinsBySpecieChip(string specie)
        {
            List<MapPin> pins = new List<MapPin>();
            var whs = GetWhaleBySpecie(specie);
            string color = GetColorBySpecie(specie);

            foreach (var w in whs)
            {
                IQueryable<chip> chip = GetChipInfo(w.id);
                foreach(var ch in chip)
                {
                    chip_location mt = GetLastWhaleChip(ch.id);
                    MapPin pin = new MapPin();
                    pin.SetPin(mt.latitude, mt.longitude, color, true, mt.date_located.ToString(), w.id);
                    pins.Add(pin);
                }            
            }

            return pins;
        }

        // Возвращает маркеры последнего сообщения каждого маячка
        public List<MapPin> GetPinsAllChip()
        {
            List<MapPin> pins = new List<MapPin>();
            IQueryable<species> species = from s in speciesWhale
                                                select s;
            string name;
            foreach (var s in species)
            {
                name = s.specie_name.Trim();
                pins.AddRange(GetPinsBySpecieChip(name));
            }
            return pins;
        }
        
        // Возвращает маркеры последней встречи с каждым китом
        public List<MapPin> GetPinsAllWhale()
        {
            List<MapPin> pins = new List<MapPin>(); IQueryable<species> species = from s in speciesWhale
                                                                                        select s;
            string name;
            foreach (var s in species)
            {
                name = s.specie_name.Trim();
                pins.AddRange(GetPinsBySpecieMeeting(name));
            }
            return pins;
        }

        // Проверка логина пароля
        public scientists CheckAuthoriztion(String login, String password)
        {
            IQueryable<scientists> check = GetScientistAuthorized(login, password);
            scientists sc = null;
            if (check.Count<scientists>() != 0)
                sc = check.Single<scientists>();
            return sc;
        }

        public Boolean CheckIfExists(String login)
        {
            Boolean exist = false;
            IQueryable<scientists> check = from s in scientistsInfo
                                           where s.login.Trim() == login
                                           select s;
            if (check.Count<scientists>() != 0)
                exist = true;
            return exist;
        }

        // Вставка кита 
        public void InsertWhale(int id, String gender, int age, int weight, int specie)
        {            
            whales whale = new whales();
            whale.id = id;
            whale.gender = gender;
            whale.age = age;
            whale.weight = weight;
            whalesTable.InsertOnSubmit(whale);

            whales_specie connection = new whales_specie();
            connection.id = whaleSpecieIDTable.Count<whales_specie>() + 1;
            connection.whale_id = id;
            connection.specie_id = specie;
            whaleSpecieIDTable.InsertOnSubmit(connection);

            Console.WriteLine(specie);

            db.SubmitChanges();
        }

        // Вставка встречи
        public void InsertMeeting(double lat, double lon, String pond, DateTime date, int scientist, int whale)
        {
            meetings mt = new meetings();
            whales_meeting connection2 = new whales_meeting();            

            mt.id = whaleMeeting.Count<meetings>() + 1;
            mt.latitude = (float?)lat;
            mt.longitude = (float?)lon;
            mt.pond_name = pond;
            mt.date_spotted = date;
            mt.scientist_id = scientist;
            whaleMeeting.InsertOnSubmit(mt);

            connection2.id = whaleMeetingIDTable.Count<whales_meeting>() + 1;
            connection2.meeting_id = mt.id;
            connection2.whale_id = whale;
            whaleMeetingIDTable.InsertOnSubmit(connection2);

            db.SubmitChanges();
        }

        // Вставка нового вида
        public void InsertSpecie(int id, String latName, String name, String areal, int population, String status, String dangers, String color)
        {
            species specie = new species();
            specie.id = id;
            specie.latin_name = latName;
            specie.specie_name = name;
            specie.areal = areal;
            specie.population = population;
            specie.status = status;
            specie.dangers = dangers;
            specie.color = color;
            speciesWhale.InsertOnSubmit(specie);
            db.SubmitChanges();
        }

        // Вставка нового ученого
        public void InsertScientist(String name, String login, String password, DateTime date, String country)
        {
            scientists sc = new scientists();
            sc.id = scientistsInfo.Count<scientists>() + 1;
            sc.fullname = name;
            sc.login = login;
            sc.password = password;
            sc.register_date = date;
            sc.country = country;
            scientistsInfo.InsertOnSubmit(sc);
            db.SubmitChanges();
        }

        // Вставка информации по чипу
        public void InsertChip(int whale, DateTime start, DateTime finish, double lat, double lon)
        {
            int id = chipWhale.Count<chip>() + 1;
            chip chip = new chip();
            whales_chip connection1 = new whales_chip();
            chip_location firstLoc = new chip_location();

            chip.id = id;
            chip.date_start = start;
            chip.date_finish = finish;
            chipWhale.InsertOnSubmit(chip);

            connection1.id = whaleChipIDTable.Count<whales_chip>() + 1;
            connection1.chip_id = id;
            connection1.whale_id = whale;
            whaleChipIDTable.InsertOnSubmit(connection1);

            firstLoc.id = chipLocation.Count<chip_location>() + 1;
            firstLoc.latitude = (float?)lat;
            firstLoc.longitude = (float?)lon;
            firstLoc.date_located = start;
            firstLoc.chip_id = id;
            chipLocation.InsertOnSubmit(firstLoc);
            db.SubmitChanges();
        }

        // Обновление информации о ките
        public void UpdateWhale(int id, int age, int weight)
        {
            var whale = from w in whalesTable
                        where w.id == id
                        select w;
            foreach(var w in whale)
            {
                w.age = age;
                w.weight = weight;                
            }
            db.SubmitChanges();            
        }
    }
}
