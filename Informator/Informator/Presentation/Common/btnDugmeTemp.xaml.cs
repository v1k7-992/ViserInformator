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

namespace Informator.Presentation.Common
{
    public partial class btnDugmeTemp : UserControl
    {
        public event EventHandler click;

        public btnDugmeTemp()
        {
            InitializeComponent();

            this.gdMain.MouseDown += gdMain_MouseDown;
        }

        void gdMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (click != null)
            {
                DoubleAnimation da = new DoubleAnimation(1.0, 0.95, TimeSpan.FromMilliseconds(50));
                da.AutoReverse = true;
                ScaleTransform rt = new ScaleTransform();
                this.RenderTransformOrigin = new Point(0.5, 0.5);
                this.RenderTransform = rt;
                rt.BeginAnimation(ScaleTransform.ScaleXProperty, da);
                rt.BeginAnimation(ScaleTransform.ScaleYProperty, da);
                click(this, null);
            }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("btnImage", typeof(ImageSource), typeof(btnDugmeTemp));

        public static readonly DependencyProperty textProperty =
            DependencyProperty.Register("btnText", typeof(string), typeof(btnDugmeTemp));


        public ImageSource btnImage 
        {
            get { return this.Image.Source; }
            set { this.Image.Source = value; }
        }

        public string btnText 
        {
            get { return this.Text.Content.ToString(); }
            set { this.Text.Content = value; }
        }

        public Brush btnBackColor
        {
            get { return this.gdMain.Background; }
            set { this.gdMain.Background = value; }
        }

    }
}
