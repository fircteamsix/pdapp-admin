using PDApp.ApiEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.Serialization;

namespace PDApp
{
    public partial class Menu : Form
    {
        private Form frmAtivo;
        public Menu instance;
        public User user;
        public Menu(User user)
        {
            InitializeComponent();
            instance = this;
            this.user = user;
            DateTime dataLogada = DateTime.Now;
            toolStripStatusLabel1.Text = "Usuario logado: " + user.nome + " | Horario do ultimo login: " + dataLogada;
        }

        private void FormShow(Form frm)
        {
            ActiveFormClose();
            frmAtivo = frm;
            frm.TopLevel = false;
            painelForm.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void ActiveFormClose()
        {
            if (frmAtivo != null) frmAtivo.Close();
        }

        private void ActiveButton(Button frmAtivo)
        {
            // Implementar melhor a logica de deixar o botão selecionado.

            //foreach (Control ctrl in painelPrincipal.Controls)
            //    ctrl.ForeColor = Color.White;
            //frmAtivo.BackColor = Color.White;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //ActiveButton(btnUsuarios);
            //ActiveFormClose();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ActiveButton(btnUsuarios);
            FormShow(new FrmUsuarios());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActiveButton(btnUsuarios);
            ActiveFormClose();
        }

        private void btnCampanhas_Click(object sender, EventArgs e)
        {
            ActiveButton(btnUsuarios);
            FormShow(new FrmCampanhas());
        }

        private void btnHemocentros_Click(object sender, EventArgs e)
        {
            ActiveButton(btnUsuarios);
            FormShow(new FrmHemocentros());
        }
    }
}
