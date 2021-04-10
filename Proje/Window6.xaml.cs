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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        public Window6()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
        }

        private void Assign_Click_1(object sender, RoutedEventArgs e)
        {
            try
                {
                    string querry2 = "insert into Worker (Ssn_worker,Name,Surname) values (@Ssn_worker,@Name,@Surname)";
                    SqlCommand cmd = new SqlCommand(querry2, sqlConn);
                    sqlConn.Open();
                    cmd.Parameters.AddWithValue("@Ssn_worker", facowssn.Text);
                    cmd.Parameters.AddWithValue("@Name", facowname.Text);
                    cmd.Parameters.AddWithValue("@Surname", facowsurname.Text);
                    cmd.ExecuteScalar();
                    MessageBox.Show("Worker succesfully added!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConn.Close();
                }
                try
                    {
                string querry2 = "insert into Facility (F_name,F_type,OwnerSSN,Rent_money) values (@fname,@ftype,@fowner,@frent)";
                SqlCommand cmd = new SqlCommand(querry2, sqlConn);
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@fname", facname.Text);
                cmd.Parameters.AddWithValue("@ftype", factype.Text);
                cmd.Parameters.AddWithValue("@fowner", facowssn.Text);
                cmd.Parameters.AddWithValue("@frent", facrent.Text);
                cmd.Parameters.AddWithValue("@Time", facname.Text);
                cmd.ExecuteScalar();
                MessageBox.Show("Facility succesfully added!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window news = new Facility();
            news.Show();
            this.Close();
        }
    }
}
