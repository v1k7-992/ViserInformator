using System;
using Informator.Presentation.Common;
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

namespace Informator.Presentation.Vesti
{
    /// <summary>
    /// Interaction logic for pgVesti.xaml
    /// </summary>
    public partial class pgVesti : Page
    {
        public pgVesti()
        {
            InitializeComponent();
           
            this.Loaded += pgVesti_Loaded;
            OsnovneMask.MouseDown+=scrollDown_event;
        }

        private void scrollDown_event(object sender, MouseButtonEventArgs e)
        {

            ScrollViewer temp = sender as ScrollViewer;

            temp.CaptureMouse();
            var point = e.GetPosition(temp);
            temp.ScrollToVerticalOffset(point.Y+temp.VerticalOffset + 10);
            MessageBox.Show(temp.VerticalOffset.ToString());
            MessageBox.Show(point.Y.ToString());
        }

        void pgVesti_Loaded(object sender, RoutedEventArgs e)
        {
            
            for(int i=0; i<10; i++){
                VestiShowItem temp = new VestiShowItem(new VestiItem());
                if (temp.vest.tip == TipVesti.OPSTE)
                {

                }
                else if (temp.vest.tip == TipVesti.ISTAKNUTO)
                {

                }
                else { }
                Animate.AddChildSP(new VestiShowItem(new VestiItem()), Osnovne, i*100);
            }


        }

    }
}
