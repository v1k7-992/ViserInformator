using System;
using System.Threading;
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

namespace Informator.Presentation
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {

        private Thread clock_thread;
        CultureInfo cultureinfo = new System.Globalization.CultureInfo("sr-Cyrl-CS");

        public Main()
        {
            InitializeComponent();
        }
                

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #region Dogadjaji kontrola

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape &&
                MessageBox.Show("Да ли сте сигурни да желите да затворите апликацију?", "Упозорење",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clock_thread = new Thread(new ThreadStart(clockTick));
            clock_thread.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clock_thread.Abort();
        }

        #endregion

        private void clockTick()
        {
            while (true)
            {
                var vreme = DateTime.Now;
                lblClock.Dispatcher.Invoke(new Action(() => lblClock.Text = vreme.ToString(" dd/MMMM/yyyy HH:mm", cultureinfo)));
                Thread.Sleep(100);
            }
        }
    }
}
