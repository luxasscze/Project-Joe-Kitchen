using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kitchen.SQL;
using static Kitchen.GlobalVar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kitchen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetail : ContentPage
    {
        
        public IList<Item> Items { get; set; }

        public OrderDetail(int orderId)
        {
            InitializeComponent();
            ReadOrder(orderId);            
            orderIdText.Text = "ORDER #" + orderId.ToString();
            orderStatusText.Text = _Order[0].Status;
            orderChangedText.Text = "Last change: " + _Order[0].StatusChanged.ToString();
            
            Items = new List<Item>();
            
            for (int i = 0; i < _Order[0].Items.Length / 3; i++)
            {
                Items.Add(new Item { ItemName = _Order[0].Items[i * 3], ItemQuantity = int.Parse(_Order[0].Items[i * 3 + 1]), ItemPrice = (decimal.Parse(_Order[0].Items[i * 3 + 2]) * int.Parse(_Order[0].Items[i * 3 + 1])) });
            }

            BindingContext = this;

            if(_Order[0].Status == "NewOrder")
            {
                startCookingButton.IsEnabled = true;
                declineButton.IsEnabled = true;
                readyForDeliveryButton.IsEnabled = false;

                startCookingButton.Opacity = 1;
                declineButton.Opacity = 1;
                readyForDeliveryButton.Opacity = 0.3;
                statusImage.Source = "NewOrder.png";
               
            }
            else if(_Order[0].Status == "InTheKitchen")
            {
                startCookingButton.IsEnabled = false;
                declineButton.IsEnabled = false;
                readyForDeliveryButton.IsEnabled = true;

                startCookingButton.Opacity = 0.3;
                declineButton.Opacity = 0.3;
                readyForDeliveryButton.Opacity = 1;
                statusImage.Source = "InTheKitchen.png";

            }
            else if(_Order[0].Status == "ReadyForDelivery")
            {
                startCookingButton.IsEnabled = false;
                declineButton.IsEnabled = false;
                readyForDeliveryButton.IsEnabled = false;

                startCookingButton.Opacity = 0.3;
                declineButton.Opacity = 0.3;
                readyForDeliveryButton.Opacity = 0.3;
                statusImage.Source = "ReadyForDelivery.png";

            }
            else if(_Order[0].Status == "OnTheWay")
            {
                startCookingButton.IsEnabled = false;
                declineButton.IsEnabled = false;
                readyForDeliveryButton.IsEnabled = false;

                startCookingButton.Opacity = 0.3;
                declineButton.Opacity = 0.3;
                readyForDeliveryButton.Opacity = 0.3;
                statusImage.Source = "OnTheWay.png";

            }
            else if(_Order[0].Status == "Finished")
            {
                startCookingButton.IsEnabled = false;
                declineButton.IsEnabled = false;
                readyForDeliveryButton.IsEnabled = false;

                startCookingButton.Opacity = 0.3;
                declineButton.Opacity = 0.3;
                readyForDeliveryButton.Opacity = 0.3;
                statusImage.Source = "Finished.png";

            }
        }

        public async void OnCloseClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public void OnStartCookingClicked(object sender, EventArgs e)
        {
            foodFrame.IsVisible = false;
            minutesFrame.IsVisible = true;

            startCookingButton.IsVisible = false;
            declineButton.IsVisible = false;
            readyForDeliveryButton.IsVisible = false;
            closeButton.IsVisible = false;

           

        }

        public async void On10Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(30).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void On20Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(40).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void On30Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(50).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void On40Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(60).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void On50Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(70).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void On60Clicked(object sender, EventArgs e)
        {
            _Order[0].Status = "InTheKitchen";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            _Order[0].Eta = DateTime.Now.AddMinutes(80).ToString("HH:mm");



            orderStatusText.Text = "InTheKitchen";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "InTheKitchen.png";

            UpdateOrder(_Order[0]);

            minutesFrame.IsVisible = false;
            foodFrame.IsVisible = true;

            startCookingButton.IsVisible = true;
            declineButton.IsVisible = true;
            readyForDeliveryButton.IsVisible = true;

            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = true;
            closeButton.IsVisible = true;


            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(1, 600)
                );
        }

        public async void OnDeclineClicked(object sender, EventArgs e)
        {
            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = false;

            _Order[0].Status = "Declined";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            

            orderStatusText.Text = "Declined";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            UpdateOrder(_Order[0]);

            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(0.3, 600)
                );
        }

        public async void OnReadyForDeliveryClicked(object sender, EventArgs e)
        {
            startCookingButton.IsEnabled = false;
            declineButton.IsEnabled = false;
            readyForDeliveryButton.IsEnabled = false;

            _Order[0].Status = "ReadyForDelivery";
            _Order[0].StatusChanged = DateTime.Now.ToString("HH:mm:ss");
            

            orderStatusText.Text = "ReadyForDelivery";
            orderChangedText.Text = "Changed: " + _Order[0].StatusChanged;
            statusImage.Source = "ReadyForDelivery.png";
            UpdateOrder(_Order[0]);

            await Task.WhenAll(
                startCookingButton.FadeTo(0.3, 600),
                declineButton.FadeTo(0.3, 600),
                readyForDeliveryButton.FadeTo(0.3, 600)
                );
        }
    }
}