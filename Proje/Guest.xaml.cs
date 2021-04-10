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
    /// Guest.xaml etkileşim mantığı
    /// </summary>
    public partial class Guest : Window
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        private void bindDatagrid()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Guest";
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Guest");
            da.Fill(dt);
            ggrid.SelectedValuePath = "Ssn_guest";

            ggrid.ItemsSource = dt.DefaultView;
        }
        public Guest()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            bindDatagrid();
            
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry3 = "delete from Guest where Ssn_guest=@ssng";
                SqlCommand sqlCommand = new SqlCommand(querry3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ssng", ggrid.SelectedValue);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Worker succesfully deleted.");
                ggrid.Items.Refresh();
            }
            catch (Exception ex2)
            {

                MessageBox.Show(ex2.Message);
            }
            finally
            {
                sqlConnection.Close();

            }
            Window re = new Guest();
            re.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select Name, Surname, Visit_reason, Time from Guest where Ssn_guest =@Ssn_guest", sqlcon);
            sqlcmd.Parameters.AddWithValue("@Ssn_guest", int.Parse(tgssn.Text));
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                tgname.Text = dr.GetValue(0).ToString();
                tgsurname.Text = dr.GetValue(1).ToString();
                tgreason.Text = dr.GetValue(2).ToString();
                tgtime.Text = dr.GetValue(3).ToString();
                
            }
            sqlConnection.Close();
        }

        private void Addworkerbtn(object sender, RoutedEventArgs e)
        {
            Window addguest = new Window4();
            addguest.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window back = new MainWindow();
            back.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query3 = "update Guest set Name=@name,Surname=@surname,Visit_reason=@reason, Time=@time where Ssn_guest=@ssng";
                SqlCommand sqlCommand = new SqlCommand(query3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", tgname.Text);
                sqlCommand.Parameters.AddWithValue("@surname", tgsurname.Text);
                sqlCommand.Parameters.AddWithValue("@ssng", tgssn.Text);
                sqlCommand.Parameters.AddWithValue("@reason", tgreason.Text);
                sqlCommand.Parameters.AddWithValue("@time", tgtime.Text);

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
            Window refr = new Guest();
            refr.Show();
            this.Close();
        }
    }
    }

