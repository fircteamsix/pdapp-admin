using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PDApp.ApiEntity;
using static System.Net.WebRequestMethods;

namespace PDApp
{
    public partial class Login : Form
    {
        public static Login instance;
        public TextBox tb1;
        public Login()
        {
            InitializeComponent();
            instance = this;
            this.ActiveControl = txtUsuario; // Seta o foco no txtUsuario.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Aqui a logica para logar na api
            string username = txtUsuario.Text;
            string password = txtSenha.Text;
            //password = GenerateMD5(password+""+username);
            this.Logar(username, password);
            //
            //this.Hide();
            //Menu m = new Menu();
            //m.ShowDialog();
            //this.Close();
        }

        public string GenerateMD5(string value)
        {
            Console.WriteLine(value);
            MD5 md5Hasher = MD5.Create();
            byte[] valueCript = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < valueCript.Length; i++)
            {
                stringBuilder.Append(valueCript[i].ToString());
            }
            return stringBuilder.ToString();
        }

        public async Task Logar(string email, string senha)
        {
            HttpClient Cliente = new HttpClient { BaseAddress = new Uri("http://localhost:3000") };
            var response = await Cliente.GetAsync("/usuario/"+email + "/"+senha);
            var content = await response.Content.ReadAsStringAsync();

            //var json = JsonConvert.SerializeObject(user);
            //var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            //var response = await Cliente.PostAsync("/usuario", data);
            //var content = await response.Content.ReadAsStringAsync();

            var responseApi = JsonConvert.DeserializeObject<UserResponse>(content);
            if (responseApi.usuario.admin == "true")
            {
                this.Hide();
                Menu m = new Menu(responseApi.usuario);
                m.ShowDialog();
                this.Close();
            }
            else
            {
                labelErroLogin.Visible = true;
                labelErroLogin.Text = "Usuario não autorizado ou invalido";
            }
            //Console.WriteLine(responseApi.usuario);
        }

    }
}
