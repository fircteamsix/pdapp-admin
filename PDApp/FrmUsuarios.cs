﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDApp
{
    public partial class FrmUsuarios : Form
    {
        public static FrmUsuarios instance;
        public Label lab1;
        public FrmUsuarios()
        {
            InitializeComponent();
            instance = this;
            lab1 = label1;
        }
    }
}
