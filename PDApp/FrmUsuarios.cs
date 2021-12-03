using Newtonsoft.Json;
using PDApp.ApiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace PDApp
{
    public partial class FrmUsuarios : Form
    {
        string idSelected;
        public static FrmUsuarios instance;
        public Label lab1;
        public FrmUsuarios()
        {
            InitializeComponent();
            string json = (new WebClient()).DownloadString("http://localhost:3000/usuario");
            dataGridView1.DataSource = JsonConvert.DeserializeObject<User[]>(json);
            dataGridView1.Columns[0].Visible = false; // Oculta o campo Id
            dataGridView1.Columns[3].Visible = false; // Oculta o campo Senha
            dataGridView1.Columns[12].Visible = false; // Oculta o campo Foto
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                idSelected = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                btnExcluirUsuario.Enabled = true;
                btnBanir.Enabled = true;
            }
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            if(idSelected != null)
            {
                Console.WriteLine(this.Deletar(int.Parse(idSelected)));
                string json = (new WebClient()).DownloadString("http://localhost:3000/usuario");
                dataGridView1.DataSource = JsonConvert.DeserializeObject<User[]>(json);
            }
        }

        public async Task<string> Deletar(int id)
        {
            HttpClient Cliente = new HttpClient { BaseAddress = new Uri("http://localhost:3000") };
            string json = JsonConvert.SerializeObject(new User(id));
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Cliente.PostAsync("/usuario/deletar", httpContent);
            var content = await response.Content.ReadAsStringAsync();
            var responseApi = JsonConvert.DeserializeObject<UserResponse>(content);
            return responseApi.mensagem;
        }

        private void btnBanir_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.Banir(int.Parse(idSelected)));
            string json = (new WebClient()).DownloadString("http://localhost:3000/usuario");
            dataGridView1.DataSource = JsonConvert.DeserializeObject<User[]>(json);
        }

        public async Task<string> Banir(int id)
        {
            User user = new User(int.Parse(idSelected), 4);
            HttpClient Cliente = new HttpClient { BaseAddress = new Uri("http://localhost:3000") };
            string json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Cliente.PutAsync("/usuario/banir", httpContent);
            var content = await response.Content.ReadAsStringAsync();
            var responseApi = JsonConvert.DeserializeObject<UserResponse>(content);
            return responseApi.mensagem;
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            FrmAddUsuario f2 = new FrmAddUsuario();
            f2.ShowDialog(); // Shows Form2
        }
    }
}
