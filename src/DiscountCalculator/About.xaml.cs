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
using Microsoft.Phone.Tasks;

namespace DiscountCalculator
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void SendEmail()
        {
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "Shopping Discount Calculator - Version " + VersionNumber.Text;
            email.To = "sdcsupport@eclipsed4utoo.com";
            email.Show();
        }

        private void EmailSupportHyperlink_Click(object sender, RoutedEventArgs e)
        {
            SendEmail();
        }
    }
}