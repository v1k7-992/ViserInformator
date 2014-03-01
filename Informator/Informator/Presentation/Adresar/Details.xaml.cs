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

namespace Informator.Presentation.Adresar
{
    /// <summary>
    /// Interaction logic for details.xaml
    /// </summary>
    public partial class Details : Window
    {
        private Osoba o;
        public Details(Osoba o)
        {
            InitializeComponent();
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth/2;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth/2;
            this.Top = 0;
            this.Background = Brushes.White;
            this.o = o;
            listBox1.Items.Add(o.imeprezime);
            listBox1.Items.Add(o.kabinet);
            listBox1.Items.Add(o.konsultacije);
            listBox1.Items.Add(o.mail);
            listBox1.Items.Add(o.predmeti);
            listBox1.Items.Add(o.zvanje);
        }
        public void setVrednosti(Osoba o)
        {
            listBox1.Items.Add(o.imeprezime);
            listBox1.Items.Add(o.kabinet);
            listBox1.Items.Add(o.konsultacije);
            listBox1.Items.Add(o.mail);
            listBox1.Items.Add(o.predmeti);
            listBox1.Items.Add(o.zvanje);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int start_time = 500;
            DoubleAnimation da = new DoubleAnimation(0, System.Windows.SystemParameters.PrimaryScreenWidth, TimeSpan.FromMilliseconds(start_time));
            DoubleAnimation daa = new DoubleAnimation(1, 0.3, TimeSpan.FromMilliseconds(start_time));
            ExponentialEase easing = new ExponentialEase();
            easing.EasingMode = EasingMode.EaseIn;
            easing.Exponent = 5;
            da.EasingFunction = easing;
            daa.EasingFunction = easing;
            da.Completed += (oo, ee) => { this.Close(); };
            TranslateTransform tt = new TranslateTransform();
            this.RenderTransformOrigin = new Point(System.Windows.SystemParameters.PrimaryScreenWidth, 0);
            this.RenderTransform = tt;
            tt.BeginAnimation(TranslateTransform.XProperty, da);
            this.BeginAnimation(OpacityProperty, daa);
        }
    }
}
