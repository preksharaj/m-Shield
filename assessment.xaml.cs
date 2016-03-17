using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Devices;
using System.Threading;

namespace m_Shield
{
    public partial class assessment : PhoneApplicationPage
    {
        public static int breathrate, len;
        public static bool yes, no, vomit, doesnt_vom, conv, dont_conv, activity, curr, ind, str, co, leth, di, bloo, eye, inabl, thirst, slow;
        VibrateController vc = VibrateController.Default;
        public assessment()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            vc.Start(TimeSpan.FromMilliseconds(100));
            NavigationService.Navigate(new Uri("/m-Shield/pages/result.xaml", UriKind.Relative));
        }

        private void chk(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            yes = (bool)(yes_feed.IsChecked);
            no = (bool)no_feed.IsChecked;
            vomit = (bool)vomits.IsChecked;
            doesnt_vom = (bool)doesnt_vomit.IsChecked;
            conv = (bool)convulsion.IsChecked;
            dont_conv = !((bool)convulsion.IsChecked);
            activity = (bool)inactive.IsChecked;
            co = Convert.ToBoolean(cough.IsChecked);
            str = (bool)stridor.IsChecked;
            ind = (bool)indrawing.IsChecked;
            leth = (bool)lethargy.IsChecked;
            di = (bool)dia.IsChecked;
            bloo = (bool)blood.IsChecked;
            eye = (bool)eyes.IsChecked;
            inabl = (bool)inable.IsChecked;
            thirst = (bool)thirsty.IsChecked;
            slow = (bool)very_slow.IsChecked;
        }

        private void sub(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                // TODO: Add event handler implementation here.
                breathrate = Convert.ToInt32(breath.Text);
                len = Convert.ToInt32(leng.Text);
            }
            catch (System.FormatException)
            { MessageBox.Show("Incorrect or Incomplete Submission.\n\nProceed Anyway."); }
        }

        private void clr(object sender, System.Windows.RoutedEventArgs e)
        {
            leng.Text = "";
            // TODO: Add event handler implementation here.
        }

        private void clr1(object sender, System.Windows.RoutedEventArgs e)
        {
            breath.Text = "";// TODO: Add event handler implementation here.
        }

        private void clr2(object sender, System.Windows.RoutedEventArgs e)
        {
            day.Text = "";// TODO: Add event handler implementation here.
        }


    }
}