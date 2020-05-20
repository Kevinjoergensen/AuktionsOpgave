using AuktionsOpgave.Models;
using AuktionsOpgave.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class Overview : Page
    {
    private int buyer;
    public List<Item> Items;
    private AuctionContext db;
        public Overview(int buyerid)
        {
            db = new AuctionContext();
            Items = db.Items.Where(i => i.Seller.Id != buyerid).ToList();
            this.buyer = buyerid;
            InitializeComponent();
            Auctions();
        }

        public void Auctions()
        {
            List<ItemData> ItemDatas = new List<ItemData>();
            foreach (Item it in Items)
            {
                ItemData ItemD = new ItemData(it, buyer);
                ItemDatas.Add(ItemD);
            }
            this.DataContext = ItemDatas;
        }

        

            private void btnBid_Click(object sender, RoutedEventArgs e)
        {
            ItemData Ditem = (ItemData)DataItems.SelectedItem;
            Item item = Ditem.Item;
            if (item.Expire > DateTime.Now)
            {
            this.NavigationService.Content = new Bidding(item,buyer);
            } else
            {
                statusBar.Content = "This auction has ended";
            }


        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Auctions();
        }
    }
    class ItemData
    {
        private AuctionContext db = new AuctionContext();
        public Item Item { get; set; }
        public string Status { get; set; }
        public string TimeLeft { get; set; }
        public ItemData(Item item, int buyerid)
        {
            this.Item = item;
            if (Item.Expire.CompareTo(DateTime.Now) < 0 && Item.Buyer != null)
            {
                if (Item.Buyer.Id == buyerid)
                {
                Status = "Congratulations. Auction won.";
                } else
                {
                    Status = "Auction won by " + Item.Buyer.Name + ".";
                }
            }
            else if (Item.Expire.CompareTo(DateTime.Now) > 0)
            {
                Status = "Auction is ongoing.";
            }
            else if (Item.Expire.CompareTo(DateTime.Now) < 0 && Item.Buyer == null)
            {  
                    Status = "Auction has ended. No bidders."; 
            }
            DateTime daysLeft = Item.Expire;
            DateTime startDate = DateTime.Now;

            //Calculate countdown timer.
            TimeSpan t = daysLeft - startDate;
            if(t.Seconds > 0)
            {
            this.TimeLeft = string.Format("{0} Days, {1} Hours, {2} Minutes left", t.Days, t.Hours, t.Minutes);
            } else
            {
                TimeLeft = "";
            }
            
        }
    }
}
