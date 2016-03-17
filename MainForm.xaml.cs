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
    public partial class MainForm : PhoneApplicationPage
    {
        public static double totage, wt, temp;
        public static bool hepv, bcgv, dptv, polv;
        VibrateController vc = VibrateController.Default;
        public MainForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Windows.Markup.XamlParseException) { MessageBox.Show("Same Error"); }
        }
        private void a(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            name.Text = "";
        }

        private void a1(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            age.Text = "";

        }

        private void a2(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            weight.Text = "";
        }

        private void a3(object sender, System.Windows.RoutedEventArgs e)
        {
            fever.Text = "";
            // TODO: Add event handler implementation here.
        }



        private void calc_age(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            try
            {
                // TODO: Add event handler implementation here.
                char[] param = { '/' };
                string a = age.Text + "/";
                string[] words = a.Split(param);
                double day = Convert.ToDouble(words[0]) - Convert.ToInt32(DateTime.Today.Day.ToString());
                int mts = Convert.ToInt32(words[1]) - Convert.ToInt32(DateTime.Today.Month.ToString());
                int yrs = Convert.ToInt32(words[2]) - Convert.ToInt32(DateTime.Today.Year.ToString());
                totage = Convert.ToDouble(-1 * ((yrs * 12) + (mts) + (day / 30)));

                if (totage <= 12.0) { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("The Child is below 1 yrs of age. \nJust Confirming."); }
                else if (totage > 12.0 && totage <= 60.0) { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("The Child is above 1 yrs of age. \nJust Confirming."); }
                else { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("The Child is above 5 yrs of age. IMCI guidelines does not apply.\nProceed Anyways"); }
            }
            catch (System.FormatException)
            {
                vc.Start(TimeSpan.FromMilliseconds(100));
                MessageBox.Show("Incorrect Format");

            }
        }

        private void calc_wt(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            try { wt = Convert.ToDouble(weight.Text); }
            catch (System.FormatException) { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("Enter Numeric Value"); }
        }

        private void calc_temp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            try
            {
                temp = Convert.ToDouble(fever.Text);
                if (temp > 100.0 || temp < 97.5) { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("Are you sure " + name.Text + "'s temperature is " + Convert.ToString(temp) + " ?"); }
            }
            catch (System.FormatException) { vc.Start(TimeSpan.FromMilliseconds(100)); MessageBox.Show("Enter Numeric Value"); }
        }

        private void chk(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            hepv = Convert.ToBoolean(hep.IsChecked);
            dptv = Convert.ToBoolean(dpt.IsChecked);
            bcgv = Convert.ToBoolean(bcg.IsChecked);
            polv = Convert.ToBoolean(pol.IsChecked);
        }
    }
}