using AuktionsOpgave.Models;
using AuktionsOpgave.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Bidding.xaml
    /// </summary>
    public partial class Bidding : Page
    {
        private AuctionContext db;
        private Item Currentitem;
        private Person buyer;
        public Bidding(Item item, int buyerid)
        {
            InitializeComponent();
            db = new AuctionContext();
            Currentitem = item;
            buyer = db.People.Where(p => p.Id.Equals(buyerid)).First();
            this.DataContext = Currentitem;
        }

        private void btnBid_Click(object sender, RoutedEventArgs e)
        {
            int bid;
            bool status = int.TryParse(biddingValue.Text, out bid);
            if (status && bid > Currentitem.Price)
            {
                var result = db.Items.Where(i => i.Id.Equals(Currentitem.Id)).First();
                result.Price = bid;
                result.Buyer = buyer;
                db.SaveChanges();
                this.NavigationService.Content = new Overview(buyer.Id);
            } else
            {
                biddingValue.Clear();
                statusBar.Content = "Can't bid below the current price. Place a bid that is higher.";

            }
        }
       

        private void goBack(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();

        }
    }
}
