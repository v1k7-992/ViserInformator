using System;
using Informator.Presentation.Common;
using Informator.Presentation.Predmeti;
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
    /// Interaction logic for pgPredmetiIzbor.xaml
    /// </summary>
    public partial class pgPredmetiIzbor : Page
    {
 
        int pGodina = 1;
        string Smer;
        string CeoSmer;

        public pgPredmetiIzbor(int Godina, String Naziv)
        {
            Smer = Naziv;
            pGodina = Godina;
            InitializeComponent();
            naslov();
           
            lblSmer.Content = "Предмети за " + Godina.ToString() + ". Годину " + Smer + "-a";
            DodavanjeDugnica();
        }

       public void DodavanjeDugnica()
        {
            
            int brojac = 0;

            for (int i = 2; i <= 27; i++)
            {
             
                var btnP = new btnIzborPredmeta { Margin = new Thickness(1, 1, 1, 1) };
               
                btnP.Height = 52;
                btnP.Opacity = 0.7;
                btnP.FontSize = 23;
                btnP.Foreground = new SolidColorBrush(Colors.White);

                if (i <= 14)
                {
                    if (i % 2 == 0)
                    {
                        brojac++;
                        Grid.SetColumn(btnP, 0);
                        Grid.SetRow(btnP, brojac);
                        btnP.Text.Content = "Предмети " + brojac;
                    }
                    else
                    {
                        btnP.Text.Content = "Професори " + brojac;
                        Grid.SetColumn(btnP, 1);
                        Grid.SetRow(btnP, brojac);

                    }

                }

                if (brojac >= 7)
                {

                    if (i % 2 == 0)
                    {
                        brojac++;
                        Grid.SetColumn(btnP, 0);
                        Grid.SetRow(btnP, brojac);
                        btnP.Text.Content = "Предмети " + brojac;

                    }
                    else
                    {
                        btnP.Text.Content = "Професори "  + brojac;
                        Grid.SetColumn(btnP, 1);
                        Grid.SetRow(btnP, brojac);

                    }

                }
                GridDugmici.Children.Add(btnP);
                
                Animate.GridAnimateEntrance2(GridDugmici);
            }
           }
        
       private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


       public void naslov ()
       {
            switch (Smer)
            {
                case "Нрт":
                    lblNaslov.Content = "Нове Рачунарске Технологије";
                        break;
                case "Рт":
                        lblNaslov.Content = "Рачунарска Техника";
                        break;
                case "Авт":
                        lblNaslov.Content = "Аудио и Видео Технологије";
                        break;
                case "Елите":
                        lblNaslov.Content = "Електроника и Телекомуникације";
                        break;
                case "Асув":
                        lblNaslov.Content = "Аутоматика и Системи Управљања Возилима";
                        break;
                case "Нет":
                        lblNaslov.Content = "Нове Енергетске Технологије";
                        break;
                case "Еп":
                        lblNaslov.Content = "Електронско Пословање";
                        break;

            }
           
       }
        }



    }








        

    
