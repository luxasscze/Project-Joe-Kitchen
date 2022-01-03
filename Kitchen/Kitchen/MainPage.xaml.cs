using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Kitchen.SQL;
using System.Data.SqlClient;
using static Kitchen.GlobalVar;


namespace Kitchen
{
    public partial class MainPage : ContentPage
    {
        public IList<Order> Orders { get; set; }
        public bool IsUpdating { get; set; }

        public int ActiveOrders { get; set; }
        public int OrdersInProgress { get; set; }
        public int OrdersTotal { get; set; }
        public string SelectedStatus { get; set; }

        public int AmountAll { get; set; }
        public int AmountNewOrder { get; set; }
        public int AmountInTheKitchen { get; set; }
        public int AmountReadyForDelivery { get; set; }
        public int AmountOnTheWay { get; set; }
        public int AmountFinished { get; set; }




        
        
        public MainPage()
        {
            InitializeComponent();
            noOrdersFrame.IsVisible = false;
            statusSelectFrame.IsVisible = false;
            
        }

        public async void OnLoginClicked(object sender, EventArgs e)
        {
            if(CheckLogin(emailText.Text, passwordText.Text))
            {

                noOrdersFrame.IsVisible = true;
                statusSelectFrame.IsVisible = true;
                captionText.HorizontalOptions = LayoutOptions.StartAndExpand;
                captionText.FontSize = 18;                
                loginFrame.IsVisible = false;
                ordersFrame.Opacity = 0;
                ordersFrame.IsVisible = true;
                IsUpdating = true;
                StartUpdating();
                await ordersFrame.FadeTo(1, 1000);
                

            }
            else
            {
                
                await DisplayAlert("LOGIN", "LOGIN FAILED", "OK");
            }
        }

        public async void OnOrderTapped(object sender, ItemTappedEventArgs e)
        {
            Order selectedOrder = e.Item as Order;            
            await Navigation.PushModalAsync(new OrderDetail(selectedOrder.OrderId));

        }

        public void OnAllClicked(object sender, EventArgs e)
        {
            SelectedStatus = "All";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.GreenYellow;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.Black;

            newOrdersButton.BackgroundColor = Color.Transparent;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.GreenYellow;

            inTheKitchenButton.BackgroundColor = Color.Transparent;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.GreenYellow;

            readyForDeliveryButton.BackgroundColor = Color.Transparent;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.GreenYellow;

            onTheWayButton.BackgroundColor = Color.Transparent;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.GreenYellow;

            finishedButton.BackgroundColor = Color.Transparent;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.GreenYellow;
        }

        public void OnNewOrdersClicked(object sender, EventArgs e)
        {
            SelectedStatus = "NewOrder";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.Transparent;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.GreenYellow;

            newOrdersButton.BackgroundColor = Color.GreenYellow;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.Black;

            inTheKitchenButton.BackgroundColor = Color.Transparent;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.GreenYellow;

            readyForDeliveryButton.BackgroundColor = Color.Transparent;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.GreenYellow;

            onTheWayButton.BackgroundColor = Color.Transparent;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.GreenYellow;

            finishedButton.BackgroundColor = Color.Transparent;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.GreenYellow;
        }

        public void OnInTheKitchenClicked(object sender, EventArgs e)
        {
            SelectedStatus = "InTheKitchen";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.Transparent;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.GreenYellow;

            newOrdersButton.BackgroundColor = Color.Transparent;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.GreenYellow;

            inTheKitchenButton.BackgroundColor = Color.GreenYellow;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.Black;

            readyForDeliveryButton.BackgroundColor = Color.Transparent;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.GreenYellow;

            onTheWayButton.BackgroundColor = Color.Transparent;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.GreenYellow;

            finishedButton.BackgroundColor = Color.Transparent;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.GreenYellow;
        }

        public void OnReadyForDeliveryClicked(object sender, EventArgs e)
        {
            SelectedStatus = "ReadyForDelivery";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.Transparent;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.GreenYellow;

            newOrdersButton.BackgroundColor = Color.Transparent;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.GreenYellow;

            inTheKitchenButton.BackgroundColor = Color.Transparent;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.GreenYellow;

            readyForDeliveryButton.BackgroundColor = Color.GreenYellow;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.Black;

            onTheWayButton.BackgroundColor = Color.Transparent;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.GreenYellow;

            finishedButton.BackgroundColor = Color.Transparent;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.GreenYellow;
        }

        public void OnOnTheWayClicked(object sender, EventArgs e)
        {
            SelectedStatus = "OnTheWay";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.Transparent;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.GreenYellow;

            newOrdersButton.BackgroundColor = Color.Transparent;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.GreenYellow;

            inTheKitchenButton.BackgroundColor = Color.Transparent;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.GreenYellow;

            readyForDeliveryButton.BackgroundColor = Color.Transparent;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.GreenYellow;

            onTheWayButton.BackgroundColor = Color.GreenYellow;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.Black;

            finishedButton.BackgroundColor = Color.Transparent;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.GreenYellow;
        }

        public void OnFinishedClicked(object sender, EventArgs e)
        {
            SelectedStatus = "Finished";
            GetOrders(SelectedStatus);
            allButton.BackgroundColor = Color.Transparent;
            allButton.BorderColor = Color.GreenYellow;
            allButton.TextColor = Color.GreenYellow;

            newOrdersButton.BackgroundColor = Color.Transparent;
            newOrdersButton.BorderColor = Color.GreenYellow;
            newOrdersButton.TextColor = Color.GreenYellow;

            inTheKitchenButton.BackgroundColor = Color.Transparent;
            inTheKitchenButton.BorderColor = Color.GreenYellow;
            inTheKitchenButton.TextColor = Color.GreenYellow;

            readyForDeliveryButton.BackgroundColor = Color.Transparent;
            readyForDeliveryButton.BorderColor = Color.GreenYellow;
            readyForDeliveryButton.TextColor = Color.GreenYellow;

            onTheWayButton.BackgroundColor = Color.Transparent;
            onTheWayButton.BorderColor = Color.GreenYellow;
            onTheWayButton.TextColor = Color.GreenYellow;

            finishedButton.BackgroundColor = Color.GreenYellow;
            finishedButton.BorderColor = Color.GreenYellow;
            finishedButton.TextColor = Color.Black;
        }

        public void StartUpdating()
        {

            GetOrders(SelectedStatus);
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                GetOrders(SelectedStatus);

                if (IsUpdating)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            //IsUpdating = true;
        }

        public void GetOrders(string status)
        {
            string commString;
            if(status == "NewOrder")
            {
                commString = "SELECT * FROM Orders WHERE IsActive='True' AND Status='NewOrder' ORDER BY Id DESC";
            }
            else if(status == "InTheKitchen")
            {
                commString = "SELECT * FROM Orders WHERE IsActive='True' AND Status='InTheKitchen' ORDER BY Id DESC";
            }
            else if(status == "ReadyForDelivery")
            {
                commString = "SELECT * FROM Orders WHERE IsActive='True' AND Status='ReadyForDelivery' ORDER BY Id DESC";
            }
            else if(status == "OnTheWay")
            {
                commString = "SELECT * FROM Orders WHERE IsActive='True' AND Status='OnTheWay' ORDER BY Id DESC";
            }
            else if(status == "Finished")
            {
                commString = "SELECT * FROM Orders WHERE IsActive='True' AND Status='Finished' ORDER BY Id DESC";
            }
            else
            {
                commString = "SELECT * FROM Orders WHERE IsActive = 'True' ORDER BY Id DESC";
            }
            ordersList.BindingContext = null;
            Orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                
                    SqlCommand cmd = new SqlCommand
                    {

                        CommandText = commString,
                        Connection = connection
                    };


                    SqlDataReader reader = cmd.ExecuteReader();
                

                Orders.Clear();

                while(reader.Read())
                {
                    Orders.Add(new Order
                    {
                        OrderId = int.Parse(reader["Id"].ToString()),
                        Created = DateTime.Parse(reader["Created"].ToString()),
                        Customer = reader["Customer"].ToString(),
                        TotalAmount = decimal.Parse(reader["TotalAmount"].ToString()),
                        IsActive = bool.Parse(reader["IsActive"].ToString()),
                        Items = reader["Items"].ToString().Split(';'),
                        DeliveryFee = decimal.Parse(reader["DeliveryFee"].ToString()),
                        Status = reader["Status"].ToString(),
                        StatusChanged = reader["StatusChanged"].ToString(),
                        Eta = reader["Eta"].ToString(),
                        Staff = reader["Staff"].ToString(),
                        Score = int.Parse(reader["Score"].ToString())


                    });
                }

                connection.Close();

                for(int i = 0; i < Orders.Count; i++)
                {
                    if(Orders[i].Status == "NewOrder")
                    {
                        Orders[i].OrderColor = "YellowGreen";
                        Orders[i].OrderTextOneColor = "YellowGreen";
                        Orders[i].OrderTextTwoColor = "Black";
                        Orders[i].OrderIdColor = "DarkGreen";
                        Orders[i].OrderImage = "NewOrder.png";
                        
                    }
                    else if(Orders[i].Status == "InTheKitchen")
                    {
                        Orders[i].OrderColor = "Cyan";
                        Orders[i].OrderTextOneColor = "Cyan";
                        Orders[i].OrderTextTwoColor = "Black";
                        Orders[i].OrderIdColor = "CadetBlue";
                        Orders[i].OrderImage = "InTheKitchen.png";
                        
                    }
                    else if(Orders[i].Status == "ReadyForDelivery")
                    {
                        Orders[i].OrderColor = "Plum";
                        Orders[i].OrderTextOneColor = "Plum";
                        Orders[i].OrderTextTwoColor = "Black";
                        Orders[i].OrderIdColor = "Purple";
                        Orders[i].OrderImage = "ReadyForDelivery.png";
                    }
                    else if(Orders[i].Status == "OnTheWay")
                    {
                        Orders[i].OrderColor = "Purple";
                        Orders[i].OrderTextOneColor = "Purple";
                        Orders[i].OrderTextTwoColor = "Plum";
                        Orders[i].OrderIdColor = "Plum";
                        Orders[i].OrderImage = "OnTheWay.png";
                    }
                    else if(Orders[i].Status == "Finished")
                    {
                        Orders[i].OrderColor = "Orange";
                        Orders[i].OrderTextOneColor = "Orange";
                        Orders[i].OrderTextTwoColor = "Black";
                        Orders[i].OrderIdColor = "OrangeRed";
                        Orders[i].OrderImage = "Finished.png";
                    }
                    else if(Orders[i].Status == "Declined")
                    {
                        Orders[i].OrderColor = "Maroon";
                        Orders[i].OrderTextOneColor = "Cyan";
                        Orders[i].OrderTextTwoColor = "Black";
                        Orders[i].OrderIdColor = "DarkBlue";
                    }
                    else
                    {
                        Orders[i].OrderColor = "Black";
                        Orders[i].OrderTextOneColor = "Cyan";
                        Orders[i].OrderTextTwoColor = "DarkBlue";
                        Orders[i].OrderIdColor = "DarkBlue";
                    }

                    ActiveOrders = Orders.Count(item => item.Status == "NewOrder");
                    OrdersInProgress = Orders.Count(Item => Item.Status == "InTheKitchen");
                    OrdersTotal = Orders.Count;

                    AmountAll = Orders.Count;
                    AmountNewOrder = Orders.Count(Item => Item.Status == "NewOrder");
                    AmountInTheKitchen = Orders.Count(Item => Item.Status == "InTheKitchen");
                    AmountReadyForDelivery = Orders.Count(Item => Item.Status == "ReadyForDelivery");
                    AmountOnTheWay = Orders.Count(Item => Item.Status == "OnTheWay");
                    AmountFinished = Orders.Count(Item => Item.Status == "Finished");
                    captionText.Text = "User: " + emailText.Text + "\t\t\t\t\t\t\t\t  AWAITING ORDERS: " + ActiveOrders + " | ORDERS IN PROGRESS: " + OrdersInProgress + " | TOTAL ORDERS TODAY: " + OrdersTotal;
                    allButton.Text = "ALL (" + AmountAll + ")";
                    newOrdersButton.Text = "NEW ORDERS (" + AmountNewOrder + ")";
                    inTheKitchenButton.Text = "IN THE KITCHEN (" + AmountInTheKitchen + ")";
                    readyForDeliveryButton.Text = "READY FOR DELIVERY (" + AmountReadyForDelivery + ")";
                    onTheWayButton.Text = "ON THE WAY (" + AmountOnTheWay + ")";
                    finishedButton.Text = "FINISHED (" + AmountFinished + ")";
                }

                if(Orders.Count == 0)
                {
                    
                    ordersFrame.IsVisible = false;                  
                    
                    noOrdersFrame.IsVisible = true;
                    noOrderText.Text = "NO ORDERS!";
                }
                else
                {
                    
                    noOrdersFrame.IsVisible = false;                    
                    ordersFrame.IsVisible = true;
                    
                }

                BindingContext = this;
                ordersList.BindingContext = this;

            }
            //ordersList.ForceReload();
        }
    }
}
