using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class frmUser : Form
    {
        DataTable DTable;
        SqlDataAdapter DAdapter;
        SqlCommand Dcommand;
        BindingSource DBindingSource;
        int idcolumn = 0;
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            this.BindMainGrid();
            this.FormatGrid();
        }

        private void BindMainGrid()
        {
            if(Globals.glOpenSqlConn())
            {
                this.Dcommand = new SqlCommand("spGetAllUsers", Globals.sqlconn);
                this.DAdapter = new SqlDataAdapter(this.Dcommand);

                this.DTable = new DataTable();

                this.DAdapter.Fill(DTable);

                this.DBindingSource = new BindingSource();

                this.DBindingSource.DataSource = DTable;

                dgvMain.DataSource = this.DBindingSource;

                this.bNavMain.BindingSource = this.DBindingSource;
            }
        }

        private void FormatGrid()
        {
            this.dgvMain.Columns["id"].Visible = false;

            this.dgvMain.Columns["loginname"].HeaderText = "Login Name";
            this.dgvMain.Columns["active"].HeaderText = "Active";
            this.dgvMain.Columns["email"].HeaderText = "Email";
            this.dgvMain.Columns["smtphost"].HeaderText = "SMPT Host";
            this.dgvMain.Columns["smptport"].HeaderText = "SMPT Port";
            this.dgvMain.Columns["gender"].HeaderText = "Gender";
            this.dgvMain.Columns["birthdate"].HeaderText = "Birthday";
        }
    }
}
