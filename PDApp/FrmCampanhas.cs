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
    public partial class FrmCampanhas : Form
    {
        public FrmCampanhas()
        {
            InitializeComponent();
            string json = (new WebClient()).DownloadString("http://localhost:3000/campanhas");
            dataCampanhas.DataSource = JsonConvert.DeserializeObject<Campanha[]>(json);
            dataCampanhas.Columns[0].Visible = false;
            dataCampanhas.Columns[1].Width = 240;
            dataCampanhas.Columns[6].Visible = false;
            dataCampanhas.Columns[8].Visible = false;
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
