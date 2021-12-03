using Newtonsoft.Json;
using PDApp.ApiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDApp
{
    public partial class FrmHemocentros : Form
    {
        public FrmHemocentros()
        {
            InitializeComponent();
            string json = (new WebClient()).DownloadString("http://localhost:3000/hemocentros");
            dataHemocentros.DataSource = JsonConvert.DeserializeObject<Hemocentro[]>(json);
            dataHemocentros.Columns[0].Visible = false; // Oculta o campo Id
            dataHemocentros.Columns[2].Width = 300;
            dataHemocentros.Columns[3].Width = 300;
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
