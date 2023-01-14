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
    /// Interaction logic for SigninWindow.xaml
    /// </summary>
    public partial class SigninWindow : Window
    {
        string connectionString = @"Data Source=(local);Initial Catalog=CSDL_ChanNuoi;Integrated Security=True";
        public SigninWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Backbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow lw = new LoginWindow();
            lw.Show();
        }

        private void SignIn_Nextbtn_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Error");
            }
            else if (password.Text != confirm_password.Text)
            {
                MessageBox.Show("Confirm password do not match");
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Useradd", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@DisplayName", username.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@UserName", username.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Password", password.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@FullName", FullName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber", phonenumber.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@UserAdress", address.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Birthday", date_of_birth.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@IdRole", 2);
                    sqlcmd.ExecuteNonQuery();
                    clear();
                }
                this.Hide();
                LoginWindow lw = new LoginWindow();
                lw.Show();
            }
        }
        void clear()
        { 

            username.Text = username.Text = password.Text = FullName.Text = phonenumber.Text = address.Text = date_of_birth.Text = "";
        }

}
}
