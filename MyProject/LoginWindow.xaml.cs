using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source=(local);Initial Catalog=CSDL_ChanNuoi;Integrated Security=True");
            {
                try
                {
                    if(sql.State == ConnectionState.Closed)
                    {
                        sql.Open();
                    }
                    String querry = "SELECT COUNT (1) FROM Userlogin WHERE username = @UserName AND password = @Password";
                    SqlCommand sqlCmd = new SqlCommand(querry, sql);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@UserName", username.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", password.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Incorrect");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Signup_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SigninWindow sw = new SigninWindow();
            sw.Show();
        }
    }
}
