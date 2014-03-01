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
    /// <summary>
    /// Interaction logic for btnTasterTEMP.xaml
    /// </summary>
    public partial class btnTasterTEMP : UserControl
    {

        public event EventHandler click; 

        public btnTasterTEMP()
        {
            InitializeComponent();
            this.gdMainTast.MouseDown += new MouseButtonEventHandler(gdMainTast_MouseDown);
        }
        void animirajPromenu()
        {
            SolidColorBrush promena = new SolidColorBrush();
            promena.Color = Colors.Blue;

            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Color.FromRgb(48,48,48);
            myColorAnimation.To = Colors.LightGray;
            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            myColorAnimation.AutoReverse = true;

            // Apply the animation to the brush's Color property.
            promena.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            gdMainTast.Background = promena;
        }
        
        void gdMainTast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (click != null)
                click(this, null);
          animirajPromenu();
        }

        public string btnSlovo
        {
            get { return this.Slovo.Content.ToString(); }
            set { this.Slovo.Content = value; }
        }
    }
}
