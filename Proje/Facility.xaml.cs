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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Proje
{
    /// <summary>
    /// Facility.xaml etkileşim mantığı
    /// </summary>
    public partial class Facility : Window
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");

        private void bindDatagrid()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select F_name,F_type,Rent_money,OwnerSSN,r.Name from Facility c, Worker r where r.Ssn_worker=c.OwnerSSN";
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Facility");
            da.Fill(dt);
            fgrid.SelectedValuePath = "F_name";

            fgrid.ItemsSource = dt.DefaultView;
        }
        public Facility()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            bindDatagrid();
            
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window menu = new MainWindow();
            menu.Show();
            this.Close();
        }

        private void Addfacilitybtn(object sender, RoutedEventArgs e)
        {
            Window at = new Window6();
            at.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query3 = "update Facility set F_name=@fname,OwnerSSN=@ownerssn,F_type=@ftype,Rent_money=@rent where F_name=@fname";
                SqlCommand sqlCommand = new SqlCommand(query3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@fname", fname.Text);
                sqlCommand.Parameters.AddWithValue("@ownerssn", fowner.Text);
                sqlCommand.Parameters.AddWithValue("@ftype", ftype.Text);
                sqlCommand.Parameters.AddWithValue("@rent", frent.Text);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Succesfully updated.");
            }
            catch (Exception ex4)
            {

                MessageBox.Show(ex4.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            /*For refreshing the window*/
            Window refr = new Facility();
            refr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select F_type, Rent_money, OwnerSSN from Facility where F_name =@fname", sqlcon);
            sqlcmd.Parameters.AddWithValue("@fname",(fname.Text));
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                ftype.Text = dr.GetValue(0).ToString();
                frent.Text = dr.GetValue(1).ToString();
                fowner.Text = dr.GetValue(2).ToString();
            }
            sqlConnection.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow(); ;
            window.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry3 = "delete from Facility where F_name=@fname";
                SqlCommand sqlCommand = new SqlCommand(querry3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@fname", fgrid.SelectedValue);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Facility succesfully deleted.");
                fgrid.Items.Refresh();
            }
            catch (Exception ex2)
            {

                MessageBox.Show(ex2.Message);
            }
            finally
            {
                sqlConnection.Close();

            }
            /*For refreshing the window*/
            Window refr = new Facility();
            refr.Show();
            this.Close();
        }

        
    }
}
