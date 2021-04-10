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
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        

        private void bindDatagrid()
        {
            SqlConnection sqlConnection = new SqlConnection(); 
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Worker";
            cmd.Connection = sqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Worker");
            da.Fill(dt);
            wgrid.SelectedValuePath = "Ssn_worker";

            wgrid.ItemsSource = dt.DefaultView;
        }

        public Window1()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
      
            twname.Clear();
            twsurname.Clear();
            twssn.Clear();
            twsalary.Clear();
            bindDatagrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query3 = "update Worker set Salary=@salary,Name=@name,Surname=@surname where Ssn_worker=@ssnw";
                SqlCommand sqlCommand = new SqlCommand(query3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", twname.Text);
                sqlCommand.Parameters.AddWithValue("@surname", twsurname.Text);
                sqlCommand.Parameters.AddWithValue("@ssnw", twssn.Text);
                sqlCommand.Parameters.AddWithValue("@salary", twsalary.Text);
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
            Window refr = new Window1();
            refr.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry3 = "delete from Worker where Ssn_worker=@ssnw";
                SqlCommand sqlCommand = new SqlCommand(querry3, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ssnw", wgrid.SelectedValue);
                sqlCommand.ExecuteScalar();
                MessageBox.Show("Worker succesfully deleted.");
                wgrid.Items.Refresh();
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
            Window refr = new Window1();
            refr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window menu = new MainWindow();
            menu.Show();
            this.Close();
        }
        private void Addworkerbtn(object sender, RoutedEventArgs e)
        {

            Window window = new Window3();
            window.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Select Name, Surname, Salary from Worker where Ssn_worker =@Ssn_worker", sqlcon);
            sqlcmd.Parameters.AddWithValue("@Ssn_worker", int.Parse(twssn.Text));
             
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {   
                twname.Text = dr.GetValue(0).ToString();
                twsurname.Text = dr.GetValue(1).ToString();
                twsalary.Text = dr.GetValue(2).ToString();
            }
            
            sqlConnection.Close();

        }
    }
    }

