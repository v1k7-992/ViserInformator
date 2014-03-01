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

namespace Informator.Presentation.Common
{
    public partial class ctrIzborSmera : UserControl
    {
        private List<string> _vrednosti = new List<string> { "RT", "NRT ", "EPO", "ASUV", "AVT" };
        private string selectedText;
        private UIElement element;
        bool inFocus;
        double start;
        
        public ctrIzborSmera()
        {
            InitializeComponent();

            gdValues.Visibility = Visibility.Hidden;

            this.PopunjavanjeVrednosti();

            gdValues.MouseMove += gdValues_MouseMove;
            lblSelectedValue.MouseDown += lblSelectedValue_MouseDown;
            lblSelectedValue.Content = this._vrednosti[0];
            gdValues.MouseUp += gdValues_MouseUp;
        }

        void gdValues_MouseUp(object sender, MouseButtonEventArgs e)
        {
            gdValues.ReleaseMouseCapture();
            inFocus = false;
            lblSelectedValue.Content = selectedText;

            double end = lblSelectedValue.PointToScreen(new Point(0, 0)).Y;

            DoubleAnimation da = new DoubleAnimation(start, Grid.GetRow(element)*100, new Duration(TimeSpan.FromMilliseconds(250)));
            da.DecelerationRatio = 0.7;
            TranslateTransform rt = new TranslateTransform();
            gdValues.RenderTransform = rt;
            da.Completed += (object o, EventArgs ea) => 
            { 
                lblSelectedValue.Visibility = Visibility.Visible;
                gdValues.Visibility = Visibility.Hidden;
            };
            rt.BeginAnimation(TranslateTransform.YProperty, da);
        }

        void lblSelectedValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inFocus = true;
            gdValues.Visibility = Visibility.Visible;
            gdValues.CaptureMouse();
            lblSelectedValue.Visibility = Visibility.Hidden;
            
        }

        void gdValues_MouseMove(object sender, MouseEventArgs e)
        {
            if (inFocus)
            {
                TranslateTransform rt = new TranslateTransform();
                rt.Y = e.GetPosition(this).Y - 400;
                gdValues.RenderTransform = rt;
                start = rt.Y;
                foreach (var c in gdValues.Children)
                {
                    double lblTop = lblSelectedValue.PointToScreen(new Point(0, 0)).Y;

                    if ((c as UIElement).PointToScreen(new Point(0, 0)).Y >= lblTop - 20 && (c as UIElement).PointToScreen(new Point(0, 0)).Y <= lblTop + 20)
                    {
                        (c as Label).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF005DFF"));
                        selectedText = (c as Label).Content.ToString();
                        (c as Label).BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF005DFF"));
                        element = (c as UIElement);
                    }
                    else
                    {
                        (c as Label).BorderBrush = new SolidColorBrush(Colors.White);
                        (c as Label).Background = new SolidColorBrush(Colors.Transparent);
                    }
                }
            }
        }

        private void PopunjavanjeVrednosti()
        {
            for (int i = 0; i < _vrednosti.Count; i++)
            {
                gdValues.RowDefinitions.Add(new RowDefinition());
                Label lblVrednost = new Label();
                lblVrednost.Content = _vrednosti[i];
                lblVrednost.FontSize = 40;
                lblVrednost.Height = 90;
                lblVrednost.Margin = new Thickness(5);
                lblVrednost.FontFamily = new FontFamily("Calibri");
                lblVrednost.Foreground = new SolidColorBrush(Colors.White);
                lblVrednost.BorderBrush = new SolidColorBrush(Colors.White);
                lblVrednost.BorderThickness = new Thickness(3);
                lblVrednost.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                lblVrednost.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
                Grid.SetColumn(lblVrednost, 0);
                Grid.SetRow(lblVrednost, i);
                gdValues.Children.Add(lblVrednost);
            }
        }
        }
    }
