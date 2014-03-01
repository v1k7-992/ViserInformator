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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Informator.Presentation.Common
{
    /// <summary>
    /// Interaction logic for TastaturaXAML.xaml
    /// </summary>
    public partial class TastaturaXAML : Window
    {
        TastaturaClass ts = new TastaturaClass();
        List<btnTasterTEMP> btnSlova = new List<btnTasterTEMP>(); 
        int br = 0;
        private static bool velika= false;
        private TextBox polje;
        public TastaturaXAML(TextBox polje1)
        {
            InitializeComponent();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth-200;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight / 2;
            this.Left = 100;
            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight/2;
            this.Background = Brushes.Black;
            this.polje = polje1;
            this.Loaded += kreirajTastaturu;
        }

        public TastaturaXAML()
        {
            // TODO: Complete member initialization
        }

        public void setFocusedTextBox(TextBox tb)
        {
            this.polje = tb;
        }

        private void kreirajTastaturu(object senderGl, EventArgs ev)
        {
            for (int i = 0; i < grdTast.RowDefinitions.Count - 1; i++)
            {
                var dugmeAt = grdTast.Children.Cast<Grid>().ElementAt(i);
                for (int j = 0; j < dugmeAt.ColumnDefinitions.Count; j++)
                {
                    if (i == 1 && j == 0 || i == 1 && j == 13 ||
                        i == 2 && j == 0 || i == 2 && j == 13 ||
                        i == 3 && j == 0 || i == 3 && j == 9)
                        continue;

                    btnTasterTEMP btn = new btnTasterTEMP();

                    btn.Margin = new Thickness(2);
                    btn.btnSlovo = ts.slova.ElementAt(br);
                    btnSlova.Add(btn);
                    switch (btn.btnSlovo)
                    {

                        case "←": btn.click += (sender, e) =>
                                { if (polje.Text.Length != 0) polje.Text = polje.Text.Remove(polje.Text.Length - 1); }; break;
                        case "↑": btn.click += (sender, e) =>
                        {
                            velika = !velika;
                            foreach (btnTasterTEMP pom in btnSlova)
                            {
                                if (velika) pom.btnSlovo = pom.btnSlovo.ToUpper();
                                else pom.btnSlovo = pom.btnSlovo.ToLower();
                            }
                        }; break;

                        case "⏎":
                            {
                                //todo kada se sredi wcf
                                break;
                            }
                        default:
                            btn.click += (sender, e) => { polje.Text += ((sender as btnTasterTEMP).btnSlovo); }; break;

                    }//swwitch
                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, 0);
                    dugmeAt.Children.Add(btn);
                    br++;
                }
            }
        }
       }//class
}//namespace

 
    



