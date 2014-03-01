using Informator.Presentation.Common;
using Informator.Presentation.Info_za_uplate;
using Informator.Presentation.Main;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Informator

{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Primer za navigaciju, sve putanje se nalaze u statickoj klasi navigacija, kao readonly svojstva...
            mainFrame.Navigate(Navigacija.pgMain);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape &&
                MessageBox.Show("Да ли сте сигурни да желите да затворите апликацију?", "Упозорење",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                Application.Current.Shutdown();
        }          
    }


}
