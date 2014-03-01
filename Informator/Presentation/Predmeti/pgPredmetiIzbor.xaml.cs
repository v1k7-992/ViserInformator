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
    /// Interaction logic for pgPredmetiIzbor.xaml
    /// </summary>
    public partial class pgPredmetiIzbor : Page
    {
        int pGodina = 1;
        string Smer;
        string CeoSmer;
        string izabranipredmet;

        public pgPredmetiIzbor(int Godina, string Naziv)
        {   
            InitializeComponent();
            Smer = Naziv;
            pGodina = Godina;

            naslov();
           
            Kreiraj();
       

        }
        public void Kreiraj()
        {
            lblSmer.Content = Smer + ". " + pGodina + " Година";
            int brojac = 0;
            Label labels = new Label();

            labels.Content = "Други Семестар";
            labels.Foreground = new SolidColorBrush(Colors.White);
            labels.FontSize = 22;
            // Dodavanje Predmeta 
            for (int i = 2; i <= 15; i++)
            {

                var btnP = new btnIzborPredmeta { Margin = new Thickness(1, 1, 1, 1) };
                btnP.Predmet.Content = "Сигурност информационих система " + i;
                btnP.Profesor.Content = "Др Зоран Бањац";
                btnP.btnPredmeti.Click += new RoutedEventHandler(btn_Click);


                btnP.ESPB.Content = "6 ЕСПБ ";
                btnP.Height = 58;
                btnP.Opacity = 0.7;
                btnP.FontSize = 23;
                btnP.Foreground = new SolidColorBrush(Colors.White);

                if (i <= 7) // prvi semestar
                {

                    Grid.SetRow(btnP, brojac + i);
                    Animate.AddChildAnimate(btnP, GridDugmici, i * 50);
                }

                else if (i == 8) // kraj semestra 
                {
                    Grid.SetRow(labels, 8);
                    Animate.AddChildAnimate(labels, GridDugmici, i * 50);


                }

                else if (i > 8) // drugi semestar 
                {
                    brojac++;
                    Grid.SetRow(btnP, 8 + brojac);
                    Animate.AddChildAnimate(btnP, GridDugmici, i * 50);
                }


            }
        } // Dodaje predmete 


        void btn_Click(object sender, RoutedEventArgs e)
        {

            izabranipredmet = ((Button)(sender)).Content.ToString();



            IzabraniPredmet p = new IzabraniPredmet(izabranipredmet);
            this.NavigationService.Navigate(p);


        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void naslov()
        {
            switch (Smer)
            {
                case "Нрт":
                    lblNaslov.Content = "Нове Рачунарске Технологије";
                    lblRukovodilac.Content = "Руководилац студијског програма: др Верица Васиљевић";
                    lblSekretar.Content = "Секретар студијског програма: инж. Мирко Ступар";
                    break;
                case "Рт":
                    lblNaslov.Content = "Рачунарска Техника";
                    lblRukovodilac.Content = "Руководилац студијског програма: др Зоран Бањац";
                    lblSekretar.Content = "Секретар студијског програма: инж. Дивна Мићић";
                    break;
                case "Авт":
                    lblNaslov.Content = "Аудио и Видео Технологије";
                    lblRukovodilac.Content = "Руководилац студијског програма: мр Јадранка Ајчевић";
                    lblSekretar.Content = "Секретар студијског програма: дипл. инг. Владимир Церић";
                    break;
                case "Елите":
                    lblNaslov.Content = "Електроника и Телекомуникације";
                    lblRukovodilac.Content = "Руководилац студијског програма: др Славица Маринковић";
                    lblSekretar.Content = "Секретар студијског програма: инж. Ненад Толић";
                    break;
                case "Асув":
                    lblNaslov.Content = "Аутоматика и Системи Управљања Возилима";
                    lblRukovodilac.Content = "Руководилац студијског програма: мр Јадранка Ајчевић";
                    lblSekretar.Content = "Секретар студијског програма: дипл. инг. Владимир Церић";
                    break;
                case "Нет":
                    lblNaslov.Content = "Нове Енергетске Технологије";
                    lblRukovodilac.Content = "Руководилац студијског програма: мр Александра Грујић";
                    lblSekretar.Content = "Секретар студијског програма: дипл. инг. Милан Ивезић";
                    break;
                case "Еп":
                    lblNaslov.Content = "Електронско Пословање";
                    lblRukovodilac.Content = "Руководилац студијског програма: др Предраг Сталетић";
                    lblSekretar.Content = "Секретар студијског програма: дипл. инг. Александар Симовић";
                    break;

            }

        } // Dodaje naslove 
    }
}
