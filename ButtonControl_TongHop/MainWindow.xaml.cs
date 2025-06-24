using System.Windows;

namespace ButtonControl_TongHop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Thoát
        }

        private void BtnTong_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txtA.Text);
            int b = int.Parse(txtB.Text);
            int tong = a + b;
            tbKetQua.Text = tong + "";
        }
    }
}