using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void XoattGiaoDien1()
        {
            txtLoaiSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtLoaiSach.Text != "" && txtTenSach.Text != "" && txtTacGia.Text != "" && txtNXB.Text != "" && txtSoLuong.Text != "" && txtGiaTien.Text != "")
            {
                try
                {
                    int soluong = Convert.ToInt32(txtSoLuong.Text);
                    try
                    {
                        int giatien = Convert.ToInt32(txtGiaTien.Text);
                        dataGridViewKho.Rows.Add(txtLoaiSach.Text, txtTenSach.Text, txtTacGia.Text, txtNXB.Text, txtSoLuong.Text, txtGiaTien.Text);
                        XoattGiaoDien1();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Nhập sai dữ liệu giá tiền!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nhập sai dữ liệu sô lượng!");
                }
            }
            else
            {
                MessageBox.Show("Các thông tin trên là bắt buộc!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            dataGridViewKho[0, vitri].Value = txtLoaiSach.Text;
            dataGridViewKho[1, vitri].Value = txtTenSach.Text;
            dataGridViewKho[3, vitri].Value = txtTacGia.Text;
            dataGridViewKho[3, vitri].Value = txtNXB.Text;
            dataGridViewKho[4, vitri].Value = txtSoLuong.Text;
            dataGridViewKho[5, vitri].Value = txtGiaTien.Text;
            XoattGiaoDien1();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            int vitri = dataGridViewKho.CurrentCell.RowIndex;
            if (MessageBox.Show("Bạn có muốn xóa thông tin này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridViewKho.Rows.RemoveAt(vitri);
            }
        }

        private void dataGridViewKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridViewKho.SelectedCells.Count != 0)
            //{
            //    DataGridViewRow row = dataGridViewKho.Rows[dataGridViewKho.CurrentCell.RowIndex];
            //    txtLoaiSach.Text = row.Cells[0].Value.ToString();
            //    txtLoaiSach.Text = row.Cells[1].Value.ToString();
            //    txtLoaiSach.Text = row.Cells[2].Value.ToString();
            //    txtLoaiSach.Text = row.Cells[3].Value.ToString();
            //    txtLoaiSach.Text = row.Cells[4].Value.ToString();
            //    txtLoaiSach.Text = row.Cells[5].Value.ToString();
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridViewTiemKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[0,i].Value.ToString() == txtLoaiSach1.Text)
                    {
                        dataGridViewTiemKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1,i].Value, dataGridViewKho[2,i].Value);
                    }
                }
            }
            else if (checkBox2.Checked)
            {
                dataGridViewTiemKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[2, i].Value.ToString() == txtTacGia.Text)
                    {
                        dataGridViewTiemKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value);
                    }
                }
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                dataGridViewTiemKiem.Rows.Clear();
                for (int i = 0; i < dataGridViewKho.Rows.Count - 1; i++)
                {
                    if (dataGridViewKho[0, i].Value.ToString() == txtLoaiSach1.Text && dataGridViewKho[2, i].Value.ToString() == txtTacGia.Text)
                    {
                        dataGridViewTiemKiem.Rows.Add(dataGridViewKho[0, i].Value, dataGridViewKho[1, i].Value, dataGridViewKho[2, i].Value);
                    }
                }
            }
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (txtTenSach1.Text != "" && txtSoLuong1.Text != "" && txtGiaTien1.Text != "")
            {
                try
                {
                int soluong = Convert.ToInt32(txtSoLuong1.Text);
                    try
                    {
                        int giatien = Convert.ToInt32(txtGiaTien1.Text);
                        for (int i = 0; i < dataGridViewKho.Rows.Count-1; i++)
                        {
                            //Nếu sách có trong kho
                            if (dataGridViewKho[1,i].Value.ToString() == txtTenSach1.Text)
                            {
                                // Điều kiện số sách trong kho còn
                                if (Convert.ToInt32(dataGridViewKho[4, i].Value) - Convert.ToInt32(txtSoLuong1.Text) >= 0)
                                {
                                    int gia1 = Convert.ToInt32(dataGridViewKho[5, i].Value) / Convert.ToInt32(dataGridViewKho[4, i].Value);
                                    int gia2 = Convert.ToInt32(txtGiaTien1.Text) / Convert.ToInt32(txtSoLuong1.Text);
                                    int TienLai = (gia2 - gia1) * Convert.ToInt32(txtSoLuong1.Text);
                                    dataGridViewMua.Rows.Add(dataGridViewKho[0, i].Value, txtTenSach1.Text, txtSoLuong1.Text, TienLai.ToString(), dateTimePicker1.Text);
                                    dataGridViewKho[4, i].Value = Convert.ToInt32(dataGridViewKho[4, i].Value) - Convert.ToInt32(txtSoLuong1.Text);
                                    dataGridViewKho[5, i].Value = Convert.ToInt32(dataGridViewKho[4, i].Value) * gia1;
                                }
                                else
                                {
                                    MessageBox.Show("Sách không đủ, chỉ còn " + dataGridViewKho[4, i].Value);
                                }    
                            }
                        }
                    }
                    catch (FormatException)
                    {
                    MessageBox.Show("Nhập sai dữ liệu giá tiền!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nhập sai dữ liệu số lượng!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewMua[0, i].Value.ToString() == txtLoaiSach2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0,i].Value, dataGridViewMua[1, i].Value, dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);
                    }
                }
            }
            else if (checkBox4.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewMua[4, i].Value.ToString() == dateTimePicker2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0, i].Value, dataGridViewMua[1, i].Value, dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);
                    }
                }
            }
            else if (checkBox3.Checked && checkBox4.Checked)
            {
                dataGridViewThongKe.Rows.Clear();
                for (int i = 0; i < dataGridViewMua.Rows.Count - 1; i++)
                {
                    if (dataGridViewMua[0, i].Value.ToString() == txtLoaiSach2.Text && dataGridViewMua[4, i].Value.ToString() == dateTimePicker2.Text)
                    {
                        dataGridViewThongKe.Rows.Add(dataGridViewMua[0, i].Value, dataGridViewMua[1, i].Value, dataGridViewMua[2, i].Value, dataGridViewMua[3, i].Value, dataGridViewMua[4, i].Value);
                    }
                }
            }
        }

        private void dataGridViewMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKho.SelectedCells.Count != 0)
            {
                DataGridViewRow row = dataGridViewKho.Rows[dataGridViewKho.CurrentCell.RowIndex];
                txtLoaiSach.Text = row.Cells[0].Value.ToString();
                txtTenSach.Text = row.Cells[1].Value.ToString();
                txtTacGia.Text = row.Cells[2].Value.ToString();
                txtNXB.Text = row.Cells[3].Value.ToString();
                txtSoLuong.Text = row.Cells[4].Value.ToString();
                txtGiaTien.Text = row.Cells[5].Value.ToString();
            }
        }

        private void tabPage1_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }
    }
}
