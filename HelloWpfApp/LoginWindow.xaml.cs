using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // giả lập account là: 
            // username: obama, password: 123
            if (txtUserName.Text == "obama" && txtPassword.Password == "123")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                //đóng cửa sổ đăng nhập
                Close();
                //hoặc gọi
                //btnDangNhap.RaiseEvent(e);
            }
            else
            {
                MessageBox.Show("Login failed! Please check your username and password.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
