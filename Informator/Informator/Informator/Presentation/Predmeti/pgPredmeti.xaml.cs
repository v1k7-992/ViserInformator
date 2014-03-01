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
            Animate.GridAnimateEntrance2(IzborSmera);
          
        }

     

        private void BtnNrt_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Нрт";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina,pNaziv);
            this.NavigationService.Navigate(p);
        }

        private void btnDruga_Click(object sender, RoutedEventArgs e)
        {
            lblGodina.Content = "Друга Година Студија";

            pGodina = 2;
            btnDruga.Background.Opacity = 0.3;
            btnPrva.Background.Opacity = 1;
            btnTreca.Background.Opacity = 1;
            btnSpec.Background.Opacity = 1;

        }

        private void btnPrva_Click(object sender, RoutedEventArgs e)
        {
            lblGodina.Content = "Прва Година Студија";
            pGodina = 1;
           btnPrva.Background.Opacity = 0.3;
            btnDruga.Background.Opacity = 1;
            btnSpec.Background.Opacity = 1;
            btnTreca.Background.Opacity = 1;
        }

        private void btnTreca_Click(object sender, RoutedEventArgs e)
        {
            lblGodina.Content = "Трећа Година Студија";
            pGodina = 3;
            btnTreca.Background.Opacity = 0.3;
            btnPrva.Background.Opacity = 1;
            btnDruga.Background.Opacity = 1;
            btnSpec.Background.Opacity = 1;
        }

        private void btnSpec_Click(object sender, RoutedEventArgs e)
        {
            lblGodina.Content = "Специјалистичке Студије";
            // pgSpecijalisticke p = new pgSpecijalisticke();
            // this.NavigationService.Navigate(p);
        }

        private void btnElite_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Елите";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }

        private void btnAsuv_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Асув";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }

 

        private void btnRt_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Рт";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }

        private void btnAvt_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Авт";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }

        private void btnEnt_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Нет";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }

      

        private void btnЕp_Click(object sender, RoutedEventArgs e)
        {
            pNaziv = "Eп";
            pgPredmetiIzbor p = new pgPredmetiIzbor(pGodina, pNaziv);
            this.NavigationService.Navigate(p);
        }


        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnNazad_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
