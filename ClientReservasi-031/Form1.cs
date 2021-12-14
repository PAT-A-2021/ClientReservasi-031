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
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Form1()
        {
            InitializeComponent();

            DisplayData();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string IDReservasi = tbxIDReservasi.Text;
            string NamaCustomer = tbxNama.Text;
            string NoTelepon = tbxNoTelepon.Text;
            int JumlahPemesanan = int.Parse(tbxJmlPemesanan.Text);
            string IDLokasi = tbxIDLokasi.Text;

            var a = service.pemesanan(IDReservasi, NamaCustomer, NoTelepon, JumlahPemesanan, IDLokasi);
            MessageBox.Show(a);
            DisplayData();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string IDReservasi = tbxIDReservasi.Text;
            string NamaCustomer = tbxNama.Text;
            string NoTelepon = tbxNoTelepon.Text;

            var a = service.editPemesanan(IDReservasi, NamaCustomer, NoTelepon);
            MessageBox.Show(a);
            DisplayData();
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string IDReservasi = tbxIDReservasi.Text;

            var a = service.deletePemesanan(IDReservasi);
            MessageBox.Show(a);
            DisplayData();
            Clear();
        }

        public void DisplayData()
        {
            var List = service.Pemesanan1();
            dgvPemesanan.DataSource = List;
        }

        public void Clear()
        {
            tbxIDReservasi.Clear();
            tbxNama.Clear();
            tbxNoTelepon.Clear();
            tbxJmlPemesanan.Clear();
            tbxIDLokasi.Clear();

            tbxJmlPemesanan.Enabled = true;
            tbxIDLokasi.Enabled = true;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            tbxIDReservasi.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxIDReservasi.Text = Convert.ToString(dgvPemesanan.Rows[e.RowIndex].Cells[0].Value);
            tbxJmlPemesanan.Text = Convert.ToString(dgvPemesanan.Rows[e.RowIndex].Cells[1].Value);
            tbxIDLokasi.Text = Convert.ToString(dgvPemesanan.Rows[e.RowIndex].Cells[2].Value);
            tbxNama.Text = Convert.ToString(dgvPemesanan.Rows[e.RowIndex].Cells[3].Value);
            tbxNoTelepon.Text = Convert.ToString(dgvPemesanan.Rows[e.RowIndex].Cells[4].Value);

            tbxJmlPemesanan.Enabled = false;
            tbxIDLokasi.Enabled = false;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Enabled = false;
            tbxIDReservasi.Enabled = false;
        }
    }
}
