using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace DiscountCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<SaleItem> saleItemList = new ObservableCollection<SaleItem>();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            PercentSlider.Value = 15;

            SaleItemsListBox.ItemsSource = saleItemList;
        }

        private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SalePriceTextBlock.Text = CalculatePrice();
        }

        private void PercentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (string.IsNullOrEmpty(PriceTextBox.Text.Trim()))
                return;

            SalePriceTextBlock.Text = CalculatePrice();
        }

        private string CalculatePrice()
        {
            double price = 0;

            if (!double.TryParse(PriceTextBox.Text.Replace("$", "").Replace(",", ""), out price))
                return "$0";

            double salePrice = price - (price * (Math.Floor(PercentSlider.Value) / 100));

            return string.Format("{0:c}", salePrice);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SaleItem si = new SaleItem();
            si.OriginalPrice = decimal.Parse(PriceTextBox.Text);
            si.PercentOff = decimal.Parse(SalePercentTextBlock.Text.Replace("%", ""));
            si.SalePrice = decimal.Parse(SalePriceTextBlock.Text.Replace("$", ""));

            saleItemList.Add(si);
        }
    }
}