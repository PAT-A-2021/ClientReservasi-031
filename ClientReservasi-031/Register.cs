using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_031
{
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

        public Register()
        {
            InitializeComponent();
            TampilData();
            tbxID.Visible = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        public void TampilData()
        {
            var list = service.DataRegist();
            dgvRegister.DataSource = list;
        }

        public void Clear()
        {
            tbxUsername.Clear();
            tbxPassword.Clear();
            cbxKategori.SelectedItem = null;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;
            string kategori = cbxKategori.Text;
            string a = service.Register(username, password, kategori);

            if (tbxUsername.Text == "" || tbxPassword.Text == "" || cbxKategori.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!!!");
            }
            else
            {
                MessageBox.Show("Sukses menambahkan data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
                TampilData();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;
            string kategori = cbxKategori.Text;
            int id = Convert.ToInt32(tbxID.Text);
            string a = service.UpdateRegister(username, password, kategori, id);

            if (tbxUsername.Text == "" || tbxPassword.Text == "" || cbxKategori.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!!!");
            }
            else
            {
                MessageBox.Show("Sukses mengupdate data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                TampilData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;

            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username); // Mengambil return value servis
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                TampilData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells[0].Value);
            tbxUsername.Text = Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells[1].Value);
            tbxPassword.Text = Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells[2].Value);
            cbxKategori.Text = Convert.ToString(dgvRegister.Rows[e.RowIndex].Cells[3].Value);

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Enabled = false;
        }
    }
}
