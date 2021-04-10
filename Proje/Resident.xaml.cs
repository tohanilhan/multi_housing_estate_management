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
    /// Window2.xaml etkileşim mantığı
    /// </summary>
    public partial class Window2 : Window
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        private void bindDatagrid()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Resident";
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Resident");
            da.Fill(dt);
            rgrid.SelectedValuePath = "SSN";
            rgrid.ItemsSource = dt.DefaultView;
        }
        public Window2()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            bindDatagrid();
        }

        private void Addresident(object sender, RoutedEventArgs e)
        {
            Window addres = new Window5();
            addres.Show();
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry3 = "delete from Resident where SSN =@ssnr";
                SqlCommand sqlCommand = new SqlCommand(querry3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ssnr", rgrid.SelectedValue);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Resident succesfully deleted.");
                rgrid.Items.Refresh();
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
            Window refr = new Window2();
            refr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window menu = new MainWindow();
            menu.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select Name, Surname, Rent_price, Apt_no, Building_no from Resident where SSN =@Ssn", sqlcon);
            sqlcmd.Parameters.AddWithValue("@Ssn", int.Parse(trssn.Text));
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                trname.Text = dr.GetValue(0).ToString();
                trsurname.Text = dr.GetValue(1).ToString();
                trrent.Text = dr.GetValue(2).ToString();
                trapt.Text = dr.GetValue(3).ToString();
                trbuild.Text = dr.GetValue(4).ToString();

            }
            sqlConnection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string query3 = "update Resident set Rent_price=@rent,Name=@name,Surname=@surname,Apt_no=@aptno,Building_no=@buildno where SSN=@ssnr";
                SqlCommand sqlCommand = new SqlCommand(query3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", trname.Text);
                sqlCommand.Parameters.AddWithValue("@surname", trsurname.Text);
                sqlCommand.Parameters.AddWithValue("@ssnr", trssn.Text);
                sqlCommand.Parameters.AddWithValue("@rent", trrent.Text);
                sqlCommand.Parameters.AddWithValue("@aptno", trapt.Text);
                sqlCommand.Parameters.AddWithValue("@buildno", trbuild.Text);
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
            Window refr = new Window2();
            refr.Show();
            this.Close();
        }
    }
}
