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
using Informator.Presentation.Common;
using System.Windows.Media.Animation;

namespace Informator.Presentation.Adresar
{
    /// <summary>
    /// Interaction logic for pgAdresar.xaml
    /// </summary>
    
    public partial class pgAdresar : Page
    {
        List<Osoba> listaO = new List<Osoba>();
        public static TastaturaXAML tastatura;
        public pgAdresar()
        {
            InitializeComponent();
            dodaj();
            this.Loaded += (oo, ee) => { Animate.SlideUp(this); };
            tbPretraga.GotFocus += (oo, ee) => { tastatura = new TastaturaXAML(tbPretraga); tastatura.Loaded += (o, e) => { Animate.SlideUp(tastatura); }; tastatura.Show(); };
            tbPretraga.LostFocus += (oo, ee) => { Animate.SlideDown(tastatura); };
            tbPretraga.TextChanged += tbPretraga_TextChanged;
            Animate.GridAnimateEntrance(header);
            Animate.GridAnimateEntrance(footer);
        }

        void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmp = listaO.Where(x => x.imeprezime.ToLower().Contains(tbPretraga.Text.ToLower())).ToList();
            AdresarItem a;
            foreach (var temp in lista.Children.Cast<UIElement>())
            {
                Animate.RemoveChildAnimate(temp, lista);
            }
                for (int i = 0; i < tmp.Count; i++)
                {
                    a = new AdresarItem(tmp[i]);
                    lista.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    Grid.SetColumn(a, 0);
                    Grid.SetRow(a, i);
                    Animate.AddChildAnimate(a, lista, i * 50);
                }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            Animate.SlideDown(this);
            //this.NavigationService.GoBack();
        }

        private void dodaj()
        {
            listaO.Add(new Osoba() { imeprezime = "Пера Петровић", zvanje = "Profesor", kabinet = 112, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Мика Микић", zvanje = "Asistent", kabinet = 113, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Милан Тртица", zvanje = "Demonstrator", kabinet = 114, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Никола Шећеровски", zvanje = "Profesor", kabinet = 114, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Душан Чоко", zvanje = "Demonstrator", kabinet = 115, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Предраг Тасић", zvanje = "Profesor", kabinet = 116, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Виктор Балковић", zvanje = "Profesor", kabinet = 117, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Мирко Ступар", zvanje = "Asistent", kabinet = 118, mail = "trtprt@gmail.com" });
            listaO.Add(new Osoba() { imeprezime = "Ана Милетић", zvanje = "Profesor", kabinet = 119, mail = "trtprt@gmail.com" });
            AdresarItem a;
            lista.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < listaO.Count; i++)
            {
                a = new AdresarItem(listaO[i]);
                lista.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                Grid.SetColumn(a, 0);
                Grid.SetRow(a, i);
                Animate.AddChildAnimate(a, lista, i * 50);
            }
        }
    }
}
