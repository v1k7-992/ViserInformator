using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Threading;
using Informator.Presentation.Predmeti;
using Informator.Presentation.Adresar;
using Informator.Presentation.Common;
using System.Windows.Threading;

namespace Informator.Presentation.Main
{
    public partial class pgMain : Page 
    {
        public pgMain()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            Animate.GridAnimateEntrance(gdMain);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblClock.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnPredmeti_Click(object sender, RoutedEventArgs e)
        {
            pgPredmeti p = new pgPredmeti();
            this.NavigationService.Navigate(p);
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Info_za_uplate.pgInfo_za_uplate p = new Info_za_uplate.pgInfo_za_uplate();            
            this.NavigationService.Navigate(p);
        }

        private void btnAdresar_Click(object sender, RoutedEventArgs e)
        {
            Adresar.pgAdresar p = new Adresar.pgAdresar();
            this.NavigationService.Navigate(p);
        }

        private void btnNastava_Click(object sender, RoutedEventArgs e)
        {
            Nastava_i_vezbe.pgNastava_i_vezbe p = new Nastava_i_vezbe.pgNastava_i_vezbe();
            this.NavigationService.Navigate(p);
        }
        private void btnKnjiga_Click(object sender, RoutedEventArgs e)
        {
            Knjiga_utisaka.pgKnjiga_utisaka p = new Knjiga_utisaka.pgKnjiga_utisaka();
            this.NavigationService.Navigate(p);
        } 
    }
}
