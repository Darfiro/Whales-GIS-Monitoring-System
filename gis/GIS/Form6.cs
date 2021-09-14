using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIS
{
    public partial class Form6 : Form
    {
        private DataTables data;
        private Boolean change1, change2;
        private const int OK = 0,
                          NO_NAME = -1,
                          NOT_ENG_NAME = -2,
                          NO_COUNTRY = -3,
                          NO_LOGIN = -4,
                          NOT_ENG_LOGIN = -5,
                          NO_PASSWORD = -6,
                          NOT_ENG_PASSWORD = -7,
                          NO_CHECK = -8,
                          NOT_CHECKED = -9,
                          ALREADY_EXIST = -10;

        private void passwordCheck_TextChanged(object sender, EventArgs e)
        {
            if (change1)
            {
                passwordCheck.PasswordChar = '*';
                passwordCheck.Text = "";
                change1 = false;
            }               
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (change2)
            {
                passwordBox.PasswordChar = '*';
                passwordBox.Text = "";
                change2 = false;
            }
        }

        public Form6(DataTables dt)
        {
            InitializeComponent();
            data = dt;
            initializeCountries();
            errLbl.Text = "";
            change1 = true;
            change2 = true;
        }

        private void initializeCountries()
        {
            countryBox.Items.Clear();
            List<String> countries = File.ReadAllLines("country_list.txt").ToList();
            countryBox.Items.Add("Страна");
            foreach (String ct in countries)
            {
                countryBox.Items.Add(ct);
            }
            countryBox.SelectedIndex = 0;
        }

        private int checkData()
        {
            int ret = OK;

            if (fullnameBox.Text.Equals("Полное имя (латинские буквы)") || fullnameBox.Text == "")
                ret = NO_NAME;
            else if (!Regex.IsMatch(fullnameBox.Text, "^[a-zA-Z0-9 ]*$"))
                ret = NOT_ENG_NAME;
            else if (countryBox.SelectedIndex == 0)
                ret = NO_COUNTRY;
            else if (loginBox.Text.Equals("Логин") || loginBox.Text == "")
                ret = NO_LOGIN;
            else if (!Regex.IsMatch(loginBox.Text, "^[a-zA-Z0-9_!@#№$%^&?<>]*$"))
                ret = NOT_ENG_LOGIN;
            else if (passwordBox.Text.Equals("Пароль") || passwordBox.Text == "")
                ret = NO_PASSWORD;
            else if (!Regex.IsMatch(passwordBox.Text, "^[a-zA-Z0-9_!@#№$%^&?<>]*$"))
                ret = NOT_ENG_PASSWORD;
            else if (passwordCheck.Text.Equals("Повторите пароль"))
                ret = NO_CHECK;
            else if (!passwordBox.Text.Equals(passwordCheck.Text))
                ret = NOT_CHECKED;
            else if (data.CheckIfExists(loginBox.Text))
                ret = ALREADY_EXIST;
            return ret;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            int ret = checkData();
            switch (ret)
            {
                case NO_NAME: errLbl.Text = "Укажите полное имя";
                    break;
                case NOT_ENG_NAME: errLbl.Text = "Имя должно быть указано латиницей";
                    break;              
                case NO_COUNTRY: errLbl.Text = "Укажите страну";
                    break;
                case NO_LOGIN: errLbl.Text = "Укажите логин";
                    break;
                case NOT_ENG_LOGIN: errLbl.Text = "Логин должен быть указан латиницей\nбез пробелов.\nВозможные символы:_!@#№$%^&?<>";
                    break;
                case NO_PASSWORD: errLbl.Text = "Укажите пароль";
                    break;
                case NOT_ENG_PASSWORD: errLbl.Text = "Пароль должен быть указан латиницей\nбез пробелов.\nВозможные символы:_!@#№$%^&?<>";
                    break;
                case NO_CHECK: errLbl.Text = "Введите пароль еще раз";
                    break;
                case NOT_CHECKED: errLbl.Text = "Пароль не совпал";
                    break;
                case ALREADY_EXIST: errLbl.Text = "Логин уже занят другим\nпользователем";
                    break;
                case OK: errLbl.Text = "";
                         String fullname = fullnameBox.Text;
                         String country = countryBox.SelectedItem.ToString();
                         String login = loginBox.Text;
                         String password = passwordBox.Text;
                         DateTime date = DateTime.Now;
                         data.InsertScientist(fullname, login, password, date, country);
                         Close();
                    break;
            }
        }
    }
}
