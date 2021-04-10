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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        public Window3()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window nwindow = new Window1();
            nwindow.Show();
            this.Close();
        }

        private void Assign_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry2 = "insert into Worker (Ssn_worker,Name,Surname,Salary) values(@Ssn_worker,@name,@surname,@salary)";
                SqlCommand cmd = new SqlCommand(querry2, sqlConn);
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@name", workername.Text);
                cmd.Parameters.AddWithValue("@surname", workersurname.Text);
                cmd.Parameters.AddWithValue("@salary", workersalary.Text);
                cmd.Parameters.AddWithValue("@ssn_worker", workerssn.Text);
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


        }
    }
}
