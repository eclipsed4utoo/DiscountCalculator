using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DiscountCalculator
{
    public class SaleItem
    {
        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PercentOff { get; set; }
    }
}
