using System.Windows;

namespace BaiTap_CheckBox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChkToanBo_Checked(object sender, RoutedEventArgs e)
        {
            chkCongNghe.IsChecked = true;
            chkDuLich.IsChecked = true;
            chkDaBong.IsChecked = true;
            chkXemPhim.IsChecked = true;
        }

        private void ChkToanBo_Unchecked(object sender, RoutedEventArgs e)
        {
            chkCongNghe.IsChecked = false;
            chkDuLich.IsChecked = false;
            chkDaBong.IsChecked = false;
            chkXemPhim.IsChecked = false;
        }

        private void chkSub_CheckedChange(object sender, RoutedEventArgs e)
        {
            if (chkCongNghe.IsChecked == true &&
                chkDuLich.IsChecked == true &&
                chkDaBong.IsChecked == true &&
                chkXemPhim.IsChecked == true)
            {
                chkToanBo.IsChecked = true;
            }
            else if(chkCongNghe.IsChecked == false &&
                chkDuLich.IsChecked == false &&
                chkDaBong.IsChecked == false &&
                chkXemPhim.IsChecked == false)
            {
                chkToanBo.IsChecked = false;
            }
        }
    }
}
