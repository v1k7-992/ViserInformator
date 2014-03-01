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
using System.Windows.Media.Animation;
using Informator.Presentation.Common;
using Informator.Presentation.Adresar;

namespace Informator.Presentation.Adresar
{
    /// <summary>
    /// Interaction logic for AdresarItem.xaml
    /// </summary>
    public partial class AdresarItem : UserControl
    {
        Osoba o;
        Details det;
        public AdresarItem(Osoba o)
        {
            this.o = o;
            this.MouseLeftButtonDown += (oo, ee) => 
            { 
                det = new Details(o);
                det.Loaded += SlajdULevo;
                Animate.SlideDown(Adresar.pgAdresar.tastatura);
                det.Focusable = true;
                det.Focus();
                det.ShowDialog();
            };
            InitializeComponent();
        }

        private void SlajdULevo(object sender, RoutedEventArgs e)
        {
            Animate.SlideLeft(det);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ime.Text = o.zvanje + "  " + o.imeprezime;
            kab.Text = o.kabinet.ToString();
            mail.Text = o.mail;
        }
    }
}
