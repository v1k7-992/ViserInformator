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

namespace Informator.Presentation.Predmeti
{
    /// <summary>
    /// Interaction logic for IzabraniPredmet.xaml
    /// </summary>
    public partial class IzabraniPredmet : Page
    {
        string izabranipredmet;
        public IzabraniPredmet(string IzbPredmet)
        {
            Predmeti pr = new Predmeti();
            izabranipredmet = IzbPredmet;
            InitializeComponent();

            izabranipredmet = IzbPredmet.Replace("System.Windows.Controls.Label: ",string.Empty);
            lblPredmet.Content = izabranipredmet;
            int b = 0;
            ishodtxt.Text += "\n";
            ishodtxt.Text= "Теоријска настава:";
            ishodtxt.Text += "\n";
            for (int i = 0; i <= pr.sadrzajPredmetaNiz.Length - 2; i++ )
            {
                b++;

                if (pr.sadrzajPredmetaNiz[i].Substring(0, 19) == " Практична настава:")
                {
                    ishodtxt.Text += "\n";
                    ishodtxt.Text += "Практична настава:";
                    ishodtxt.Text += "\n";
                    b = 0;
                    Grid.SetColumn(ishodtxt, 1);
                }
                else
                {
                     ishodtxt.Text += b.ToString() + ". " + pr.sadrzajPredmetaNiz[i] + "\n";
                    //ishodtxt.TextWrapping = TextWrapping.Wrap;
                    Grid.SetRow(ishodtxt, 3);
                    Grid.SetColumn(ishodtxt, 0);
                }
            }

            
            

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
