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
    public partial class Form2 : Form
    {
        Form3 frm3;
        Form6 frm6;
        public Boolean authorized;
        private DataTables data;

        public Form2(DataTables dt, Form3 frm)
        {
            InitializeComponent();
            data = dt;
            frm3 = frm;
            passwordBox.PasswordChar = '*';
            authorized = false;
        }
        
        private void loginBtn_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text.Trim();
            String password = passwordBox.Text.Trim();
            scientists sc = data.CheckAuthoriztion(login, password);
            if (sc != null) 
            {
                authorizationLbl.Text = "";
                frm3.SetData(sc, data);
                frm3.Show(Owner);
                authorized = true;
                Close();
            }
            else
                authorizationLbl.Text = "Неверная пара логин/пароль";
        }

        private void newPersonBtn_Click(object sender, EventArgs e)
        {
            if (frm6 == null)
            {
                frm6 = new Form6(data);
                frm6.FormClosed += frm6_FormClosed;
            }
            frm6.Show(this);
            Hide();
        }

        public void frm6_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm6 = null;
            Show();            
            data.SetTables();
        }
    }
}
