using AuktionsOpgave.Storage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SellerApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private AuctionContext db;
        public Login()
        {
            InitializeComponent();
            db = new AuctionContext();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buyer = db.People.Where(b => b.Email.Equals(email.Text) && b.Password.Equals(password.Text)).FirstOrDefault();
            if (buyer != null)
            {                
                this.NavigationService.Content = new Overview(buyer.Id);

            } else
            {
                if (password.Text == "" && email.Text == "")
                {
                    statusBar.Content = "Please enter your email and password";
                } else if (email.Text == "")
                {
                    statusBar.Content = "Please enter your email";
                } else if (password.Text == "")
                {
                    statusBar.Content = "Please enter your password";
                } else
                {
                    statusBar.Content = "User not found. Try again.";
                    email.Clear();
                    password.Clear();
                }
            }
        }
    }
}
