using ManageStaffDBApp.Model;
using System.Windows;

namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
        }

        private bool IsRegMode = false;
        public bool IsAuthorize { get; private set; } = false;
        private void bt_reg_Click(object sender, RoutedEventArgs e)
        {
            if (IsRegMode)
            {
                if (!string.IsNullOrEmpty(tx_uname.Text) && !string.IsNullOrEmpty(tx_pass.Password) && tx_repass.Password.Equals(tx_pass.Password))
                {
                    MessageBox.Show(DataWorker.CreateEmploye(tx_uname.Text, tx_pass.Password));

                    IsAuthorize = true;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("не всё введено");
                }
            }
            else
            {
                IsRegMode = !IsRegMode;
                tx_repass.Visibility = Visibility.Visible;
                tb_repass.Visibility = Visibility.Visible;
                lb_ti.Content = "Регистрация";
            }
        }

        private void bt_in_Click(object sender, RoutedEventArgs e)
        {
            if (IsRegMode)
            {
                IsRegMode = !IsRegMode;
                tx_repass.Visibility = Visibility.Collapsed;
                tb_repass.Visibility = Visibility.Collapsed;
                lb_ti.Content = "Авторизация";
            }
            else
            {
                if (!string.IsNullOrEmpty(tx_uname.Text) && !string.IsNullOrEmpty(tx_pass.Password))
                {
                    if (DataWorker.CanLogIn(tx_uname.Text, tx_pass.Password))
                    {
                        IsAuthorize = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("не знаю таких","иди нахуй");
                    }
                }
                else
                {
                    MessageBox.Show("не всё введено");
                }
            }

        }
    }
}
