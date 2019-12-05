﻿using System;
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
using ThemeParkTycoonGame.Core;

namespace ThemeParkTycoonGame.Fancy.Controls
{
    /// <summary>
    /// Interaction logic for GuestinfoWindow.xaml
    /// </summary>
    public partial class GuestinfoWindow : Window
    {
        Core.Guest guest;
        Core.Wallet wallet;

        public const string DEFAULT_PAYMENT_REASON = "Paid to an unknown entity";

        public delegate void BalanceChangedEvent(object sender, BalanceChangedEventArgs e);
        public event BalanceChangedEvent BalanceChanged;
        public GuestinfoWindow(Core.Guest selectedGuest)
        {
            InitializeComponent();

            this.guest = selectedGuest;

            this.guest.Wallet.BalanceChanged += (s, ev) =>
            {
                RefreshFinances();
            };


            RefreshFinances();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // balanceLabel.Content = guest.Wallet.Balance;


        }

        private void RefreshFinances()
        {
            // clear the panel
            financialHistory.Items.Clear();



            foreach (TransactionLog log in this.guest.Wallet.History.ToList())
            {

                //ListViewItem temp = new ListViewItem();


                guest.Wallet.History.Add(log);
                financialHistory.Items.Add(log);

            }

        }
    }
}
