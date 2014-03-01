using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;
using System.Globalization;
using Informator.Presentation.Common;
using System.Windows.Media.Animation;

namespace Informator.Presentation.Knjiga_utisaka
{
    /// <summary>
    /// Interaction logic for pgKnjiga_utisaka.xaml
    /// </summary>
    public partial class pgKnjiga_utisaka : Page
    {
        TastaturaXAML tastatura;
        public pgKnjiga_utisaka()
        {
            InitializeComponent();
            txtIme.GotFocus += (oo, ee) => 
            {
                tastatura = new TastaturaXAML(txtIme);
                tastatura.Loaded += (o, e) => { Animate.SlideUp(tastatura); };
                tastatura.Show();
            };
            txtIme.LostFocus += (oo, ee) => 
            {
                Animate.SlideDown(tastatura);
            };
            txtKomentar.GotFocus += (oo, ee) => 
            {
                tastatura = new TastaturaXAML(txtKomentar);
                tastatura.Loaded += (o, e) => { Animate.SlideUp(tastatura); };
                tastatura.Show();
            };
            txtKomentar.LostFocus += (oo, ee) => 
            {
                Animate.SlideDown(tastatura);
            };
            Animate.SlideUp(this);
            Animate.GridAnimateEntrance(gdKu);
            Animate.GridAnimateEntrance(gdtmp);
        }

        private void btnPosalji_Click(object sender, RoutedEventArgs e)
        {
           
            //Sledeca verzija mora da ima konektivnost sa bazom
            if (txtIme.Text != "")
            {
                if (txtKomentar.Text != "")
                {
                    StackPanel panel = new StackPanel();

                    panel.Margin = new Thickness(10, 3, 10, 10);

                    TextBlock komentar = new TextBlock();
                    komentar.Text = txtKomentar.Text;
                    komentar.FontSize = 20;
                    komentar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    komentar.TextWrapping = TextWrapping.Wrap;

                    CultureInfo c = new CultureInfo(0x0C1A);
                    TextBlock autor = new TextBlock();
                    autor.FontSize = 15;
                    autor.Foreground = new SolidColorBrush(Color.FromRgb(215, 255, 255));
                    autor.HorizontalAlignment = HorizontalAlignment.Right;
                    
                    autor.Text="Аутор: "+txtIme.Text+", Написано: "+DateTime.Now.Date.ToString("D", c);


                    Border border = new Border();
                    border.BorderThickness = new Thickness(0, 0, 0, 1);
                    border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    panel.Children.Add(komentar);
                    panel.Children.Add(autor);
                    panel.Children.Add(border);
                    //pnlKomentari.Children.Add(panel);
                    //pnlKomentari.RowDefinitions.Add(new RowDefinition());
                   
                    Animate.AddChildSP(panel, pnlKomentari, 200);
                    txtIme.Text = "";
                    txtKomentar.Text = "";  
                }else
                    MessageBox.Show("Морате унети своји коментар!");
            }
            else
                MessageBox.Show("Морате унети своје име!");
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            Animate.SlideDown(this);
            //this.NavigationService.GoBack();
        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            txtIme.Text = "";
            txtKomentar.Text = "";
        }
    }
}
