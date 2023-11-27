using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace OOP___CA2_Final
{
    /// <summary>
    /// Interaction logic for EditAccounts.xaml
    /// </summary>
    public partial class EditAccounts : Window
    {
        public EditAccounts()
        {
            InitializeComponent();
        }

        //calling the objects
        DAO dao = new DAO();
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        CollectionViewSource cs = new CollectionViewSource();
        SqlCommandBuilder sb;



        //show windows depending on user's choice
        private void _eNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void _eEditAccount_Click(object sender, RoutedEventArgs e)
        {
            EditAccounts ed = new EditAccounts();
            ed.Show();
        }

        private void _eDepositFunds_Click(object sender, RoutedEventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void _eWithdrawFunds_Click(object sender, RoutedEventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void _eTransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void _eViewTransactions_Click(object sender, RoutedEventArgs e)
        {
            AllTransactions allt = new AllTransactions();
            allt.Show();
        }


        //closes all windows and displays a message
        private void _eLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for using our systems! ");
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
            this.Close();
        }

        private void _eExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombo();
        }


        //method to populate combobox.
        void PopulateCombo()
        {
            CollectionViewSource cs = new CollectionViewSource();
            da = new SqlDataAdapter();
            dt = new DataTable();


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllAccounts";
            cmd.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = cmd;
            da.Fill(dt);
            cs.Source = dt.DefaultView;
            dgvEdit.ItemsSource = cs.View;

            dao.CloseCon();

        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {


        }

        private void dgvEdit_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {


        }

        private void dgvEdit_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void dgvEdit_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }


        //btnsave, this affects the database with the new information inserted by the user
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            string firstName = txtfirstn.Text;
            string surname = txtsurn.Text;
            int initialBalance = int.Parse(txtinitbaal.Text);

            DataRowView dv = (DataRowView)dgvEdit.SelectedItem;
            if (dv != null)
            {
                int rowIndex = dt.Rows.IndexOf(dv.Row);
                DataRow row = dt.Rows[rowIndex];
                row["FirstName"] = firstName;
                row["Surname"] = surname;
                row["InitialBalance"] = initialBalance * 100;
                row.EndEdit();
            }

            sb = new SqlCommandBuilder(da);
            da.UpdateCommand = sb.GetUpdateCommand();
            da.Update(dt);

            MessageBox.Show("Information successfully changed, and new information is available ;D");


            EditAccounts ed = new EditAccounts();
            ed.Show();
        }


        //refreses the datagrid.
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource cs = new CollectionViewSource();
            da = new SqlDataAdapter();
            dt = new DataTable();


            SqlCommand cmd = dao.OpenCon().CreateCommand();
            cmd.CommandText = "uspAllAccounts";
            cmd.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = cmd;
            da.Fill(dt);
            cs.Source = dt.DefaultView;
            dgvEdit.ItemsSource = cs.View;

            dao.CloseCon();
        }

        private void btnRefresh_Click_1(object sender, RoutedEventArgs e)
        {

        }


        //this is to get the selection, when the user clicks on the datagrid, is gets the item in row 1,2 and 11 and converts it to string in order to display.
        //is good to mention that the index [0] is the account number, which is not enabled because the user is not allowed to modify account number.
        private void dgvEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dv = (DataRowView)dgvEdit.SelectedItem;

            if (dv != null)
            {
                txtfirstn.Text = dv.Row.ItemArray[1].ToString();
                txtsurn.Text = dv.Row.ItemArray[2].ToString();
                txtinitbaal.Text = dv.Row.ItemArray[11].ToString();
            }
        }

        private void dgvEdit_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
}
