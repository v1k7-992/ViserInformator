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

namespace Informator.Presentation.Vesti
{
    /// <summary>
    /// Interaction logic for VestiShowItem.xaml
    /// </summary>
    public partial class VestiShowItem : UserControl
    {
        public VestiItem vest{get; set;}
        public VestiShowItem(VestiItem vestProsledjena)
        {
            InitializeComponent();
            this.vest=vestProsledjena;
            this.Naslov.Text = vest.naslovVesti;
            this.Datum.Content = vest.datumPostavljanja.ToString("d");
            this.Predmet.Content = vest.predmet;
        }
    }
}
