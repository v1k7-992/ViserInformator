using Informator.Presentation.Common;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Informator.Presentation.Info_za_uplate
{

    public partial class pgInfo_za_uplate : Page
    {
        int i = 0;
        //List<InformatorServis.Predmeti> predmeti;
        //InformatorServis.PredmetiClient cl = new InformatorServis.PredmetiClient();

        public pgInfo_za_uplate()
        {
            InitializeComponent();

            //Pozivanje servisne operacije asinhrono
            //cl.ListaPredmetaAsync();
            //cl.ListaPredmetaCompleted += cl_ListaPredmetaCompleted;

            //------------------------Primer----------------------------
            //---Dodavanje dugmica dinamicki, ako nekom bude potrebno---
            //for (int i = 0; i < gdRight.ColumnDefinitions.Count; i++)
            //{
            //    for (int j = 0; j < gdRight.RowDefinitions.Count; j++)
            //    {
            //        Rectangle btn = new Rectangle();
            //        btn.Fill = new SolidColorBrush(Colors.Azure);
            //        btn.Margin = new Thickness(5);
            //        Grid.SetColumn(btn, i);
            //        Grid.SetRow(btn, j);
            //        gdRight.Children.Add(btn);
            //    }
            //}

            //--------------------------Dodavanje elementa pomocu metode----------------
            for (int i = 0; i < 16; i++)
            {
                var btn = new btnDugmeTemp { Margin = new Thickness(5), btnBackColor = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(i * 10), Convert.ToByte(255 / (i + 1)), Convert.ToByte(i + 20))), btnText = i.ToString() };
                btn.click += btn_click;
              //  Animate.AddChildAnimate(btn, gdRight, i * 50);
            }

            //-------------------------Dodavanje animacije celom grid layout-u----------------
            //Animate.GridAnimateEntrance(gdRight);
        }

        void btn_click(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as btnDugmeTemp).btnText);
        }

        //Metoda sa rezultatom "upita"
        //void cl_ListaPredmetaCompleted(object sender, InformatorServis.ListaPredmetaCompletedEventArgs e)
        //{
        //    predmeti = e.Result.ToList();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            var btn = new btnDugmeTemp { Margin = new Thickness(5) };
            (btn as btnDugmeTemp).btnText = "Dugme" + i;
            BitmapImage bmi = new BitmapImage(new Uri("/Resources/cek.png", UriKind.Relative));
            (btn as btnDugmeTemp).btnImage = bmi;
            //Grid.SetColumn(btn, 3);
            //Grid.SetRow(btn, 3);
            //gdRight.Children.Add(btn);
            //Animate.AddChildAnimate(btn, gdRight, 50);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           // Animate.RemoveFirstAnimate(gdRight, 100);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          //  var c = gdRight.Children.Cast<UIElement>().ElementAt(6);
           // Animate.RemoveSpecficChild(c, gdRight);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           /// var c = gdRight.Children.Cast<UIElement>().Take(6).ToArray();
           // Animate.RemoveRangeOfChildren(c, gdRight);
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


    }
}
