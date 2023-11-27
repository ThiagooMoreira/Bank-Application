using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP___CA2_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        //Calling dao and hascode objects
        DAO dao = new DAO();
        HashCode hc = new HashCode();


        //calling the objects do open the windows depending of what is clicked
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            NewUser nw = new NewUser();
            nw.Show();
        }

        private void _Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
        }

        private void _Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnNewAcc_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        //whem the user click "login" then it sets user and pass and reads the stored procedure uspLogin
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text;
            string pass = hc.PassHash(pswBox.ToString());

           

            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspLogin";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@un", user);
            cmd.Parameters.AddWithValue("@pw", pass);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            //If matches with the data from the database then show the message and open the program, otherwise shows message invalid password.

            if(dr.Read())
            {
                MessageBox.Show("Login successfull, welcome!");
                txtUsername.Clear();
                pswBox.Clear();
                Welcome w = new Welcome();
                w.Show();
                


            }
            else
            {
                MessageBox.Show("Invalid Password. Try again.");
            }
            dao.CloseCon();












        }
    }
}
