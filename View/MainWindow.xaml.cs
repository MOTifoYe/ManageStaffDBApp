using ManageStaffDBApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllDepartmentsView;
        public static ListView AllPositionsView;
        public static ListView AllUsersView;
        public MainWindow()
        {
            if (!Authorize())
            {
                Application.Current.Shutdown(1);
            }
            InitializeComponent();
            DataContext = new DataManageVM();
            AllDepartmentsView = ViewAllDepartments;
            AllPositionsView = ViewAllPositions;
            AllUsersView = ViewAllUsers;
        }

        private bool Authorize()
        {
            AuthWin auth = new AuthWin();
            auth.ShowDialog();
            return auth.IsAuthorize;
        }
    }
}
