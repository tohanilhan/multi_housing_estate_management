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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        public Window5()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
        }

        private void Assign_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string querry2 = "insert into Resident (SSN,Name,Surname,Rent_price,Apt_no,Building_no) values (@Ssn,@Name,@Surname,@rent,@apt,@build)";
                SqlCommand cmd = new SqlCommand(querry2, sqlConn);
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@Ssn", rssn.Text);
                cmd.Parameters.AddWithValue("@Name", rname.Text);
                cmd.Parameters.AddWithValue("@Surname", rsurname.Text);
                cmd.Parameters.AddWithValue("@apt", resapt.Text);
                cmd.Parameters.AddWithValue("@build", resbuild.Text);
                cmd.Parameters.AddWithValue("@rent", resrent.Text);

                cmd.ExecuteScalar();
                MessageBox.Show("Resident succesfully added!");
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
            Window nw = new Window2();
            nw.Show();
            this.Close();
        }
    }
}
