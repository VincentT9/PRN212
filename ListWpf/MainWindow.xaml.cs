using System.Collections.Generic;
using System.Windows;

namespace ListWpf
{
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTri.Text);
            dsDuLieu.Add(x);
            HienThiDanhSach();
            txtGiaTri.Text = "";
        }

        private void BtnChen_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTriChen.Text);
            int vt = int.Parse(txtViTriChen.Text);
            dsDuLieu.Insert(vt, x);
            HienThiDanhSach();
            txtViTriChen.Text = "";
            txtGiaTriChen.Text = "";
        }

        private void BtnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Sort();
            HienThiDanhSach();
        }

        private void BtnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Sort();
            dsDuLieu.Reverse();
            HienThiDanhSach();
        }

        private void BtnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }

            dsDuLieu.RemoveAt(lstDuLieu.SelectedIndex);
            HienThiDanhSach();
        }

        private void BtnXoaNhieuPhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }

            while (lstDuLieu.SelectedItems.Count > 0)
            {
                int data = (int)lstDuLieu.SelectedItems[0];
                dsDuLieu.Remove(data);
                lstDuLieu.Items.Remove(data);
            }
        }

        private void BtnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear();
            HienThiDanhSach();
        }

        void HienThiDanhSach()
        {
            lstDuLieu.Items.Clear();
            foreach (int x in dsDuLieu)
            {
                lstDuLieu.Items.Add(x);
            }
        }
    }
}
