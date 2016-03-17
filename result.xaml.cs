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
    public partial class result : PhoneApplicationPage
    {
        public static string treatment = "";
        public static int a = 0, b = 0, c = 0, d = 0, e = 0;
        VibrateController vc = VibrateController.Default;
        public result()
        {
            InitializeComponent();
        }
        private void LongClick()
        {
            vc.Start(TimeSpan.FromMilliseconds(500));
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (m_Shield.MainForm.wt < 10) { general.Text = "UnderWeight\n"; }
            if (!m_Shield.MainForm.bcgv) { treatment += "\nGive BCG Vaccination\n"; }
            if (!m_Shield.MainForm.dptv) { treatment += "\nGive DPT Vaccination\n"; }
            if (!m_Shield.MainForm.polv) { treatment += "\nGive Polio Vaccination\n"; }
            if (!m_Shield.MainForm.hepv) { treatment += "\nGive Hepatitis Vaccination\n"; }
            if ((m_Shield.assessment.yes || m_Shield.assessment.vomit || m_Shield.assessment.conv || m_Shield.assessment.activity || m_Shield.assessment.curr || m_Shield.assessment.str || m_Shield.assessment.ind))
            {
                LongClick();
                UIToolkit.setTimeout(1000, () => { LongClick(); });
                UIToolkit.setTimeout(2000, () => { LongClick(); });

                general.Text += "\nSevere Pneumonia or Very Severe Disease\n";
                treatment += "\n\nGive First Dose of an appropriate antibiotic.\nRefer urgently to hospital.\n";

            }
            else if (m_Shield.assessment.breathrate > 40)
            {
                general.Text += "\nPneumonia\n";
                treatment += "\n\nGive oral antibiotic for 3 days.\nIf wheezing give an inhaled bronchodilator for 5days.\nSoothe the throat andrelieve the cough with a safe remedy.\nFollow-up in 2 days.\n";
            }
            else
            {
                if (m_Shield.assessment.co)
                {
                    general.Text += "\nCough or Cold\n";
                    treatment += "\n\nIf wheezing give an inhaled bronchodilator for 5days.\nSoothe the throat andrelieve the cough with a safe remedy.\nFollow-up in 5 days if not improving.\n";
                }
                else { general.Text += "\nNo Cough or Cold\n"; }
            }




            if (m_Shield.assessment.leth)
            {
                a += 1;
                b += 1;
            }
            if (m_Shield.assessment.eye) { a += 1; b += 1; }
            if (m_Shield.assessment.inabl) { a += 1; }

            if (m_Shield.assessment.slow) { a += 1; }

            if (a > 2)
            {
                LongClick();
                UIToolkit.setTimeout(1000, () => { LongClick(); });
                UIToolkit.setTimeout(2000, () => { LongClick(); });
                general.Text += "\nSevere Dehydration\n";
                treatment += "\n\nRefer urgently to hospital.\nGive frequent sips of ORS on the way.\nContinue breastfeeding.\nIf cholera in locality,give antibiotic for cholera.\n";
            }
            else if (b > 0)
            {
                general.Text += "\nSome Dehydration\n";
                treatment += "\n\nGive fluid,zinc supplements and food for dehydration.\nFollow-up in 5 days if not improving.\n";
            }
            else
            {
                general.Text += "\nNo Dehydration\n";
                treatment += "\n\nGive fluid,zinc supplements and food for dehydration.\nFollow-up in 5 days if not improving.\n";
            }

            if (m_Shield.assessment.di && m_Shield.assessment.len < 14 && !(m_Shield.assessment.bloo))
            {
                if (a > 1 || b > 1)
                {
                    general.Text += "\nSevere Persistent Diarrhoea\n";
                    treatment += "\n\nGive fluid,zinc supplements and food for dehydration.\nRefer urgently to hospital.\nGive frequent sips of ORS on the way.\n";
                }
                else
                {
                    general.Text += "\nPersistent Diarrhoea\n";
                    treatment += "\n\nMultivitamins and Minerals for 15 days.\nSpecific feeding.\nFollow-up in 5 days.\n";
                }
            }
            if (m_Shield.assessment.di && m_Shield.assessment.len < 14 && (m_Shield.assessment.bloo))
            {
                general.Text += "\nDysentry\n";
                treatment += "\n\nGive ciprofloxacin for 3 days.\nFollow up in 2 days.\n";
            }
        }
        private void sub(object sender, EventArgs e)
        {
            vc.Start(TimeSpan.FromMilliseconds(100));
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/m-Shield/pages/treatment.xaml", UriKind.Relative));
        }
        private void sub1(object sender, EventArgs e)
        {
            vc.Start(TimeSpan.FromMilliseconds(100));
            PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/counsel.xaml", UriKind.Relative));
        }
    }
}
