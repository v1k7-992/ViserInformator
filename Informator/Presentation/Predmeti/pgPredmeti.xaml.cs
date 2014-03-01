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

namespace Informator.Presentation.Predmeti
{
    /// <summary>
    /// Interaction logic for Predmeti.xaml
    /// </summary>
    public partial class pgPredmeti : Page
    {
      public  String pNaziv;
        String pSemestar;
       public int pGodina = 1;
       
        String pStudije;

        Boolean IsClick = false;
           
        
        
        Frame f;
        public pgPredmeti()
        {
            InitializeComponent();
            //Animate.GridAnimateEntrance2(IzborSmera);
          
        }



        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnNazad_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            pgPredmetiIzbor pg = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(pg);


        }
    }
}
