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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=TOHANSQL;Initial Catalog=PROJECT_Db;Integrated Security=True");
        public Window4()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Proje.Properties.Settings.PROJECT_DbConnectionString"].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
        }

        private void Assign_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {   
                string querry2 = "insert into Guest (Ssn_guest,Name,Surname,Visit_reason,Time) values (@Ssn_guest,@Name,@Surname,@Reason,@Time)";
                SqlCommand cmd = new SqlCommand(querry2, sqlConn);
                sqlConn.Open();
                cmd.Parameters.AddWithValue("@Ssn_guest", guestssn.Text);
                cmd.Parameters.AddWithValue("@Name", guestname.Text);
                cmd.Parameters.AddWithValue("@Surname", guestsurname.Text);
                cmd.Parameters.AddWithValue("@Reason", guestvisit.Text);
                cmd.Parameters.AddWithValue("@Time", guesttime.SelectedDate);
                cmd.ExecuteScalar();
                MessageBox.Show("Guest succesfully added!");
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
            Window nw = new Guest();
            nw.Show();
            this.Close();
        }
    }
}
