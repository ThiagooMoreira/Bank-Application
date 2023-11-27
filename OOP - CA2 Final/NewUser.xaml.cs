using DAL;
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
using System.Data.SqlClient;

namespace OOP___CA2_Final
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
        }

        //calling objects.
        DAO dao = new DAO();
        HashCode hc = new HashCode();


        //show windows depending on user's choice
        private void _nuLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
        }

        private void _nuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //when the user's hit the button register, it gets the informations and stores in the database
        //uspAdduser is the stored procedure used.
        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            string fn = txtFullname.Text;
            string un = txtUser.Text;
            string pw = hc.PassHash(passBox.ToString());

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAddUser";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@un", un);
            cmd.Parameters.AddWithValue("@pw", pw);

            cmd.ExecuteNonQuery();
            dao.CloseCon();

            txtFullname.Clear();
            txtUser.Clear();
            passBox.Clear();


            MessageBox.Show("Thanks for choosing us, user successfully created.");

            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
            this.Close();
        }
    }
}
