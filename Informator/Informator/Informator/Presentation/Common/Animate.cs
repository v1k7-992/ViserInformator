using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Informator.Presentation.Common;
using Informator.Presentation.Info_za_uplate;

namespace Informator.Presentation.Common
{
    public static class Animate
    {
        public static void AddChild(UIElement child, Grid grid)
        {
            int first_free_col = 0;
            int first_free_row = 0;

            var c = grid.Children.Cast<UIElement>().LastOrDefault();

            if (c != null)
            {
                first_free_col = Grid.GetColumn(c);
                first_free_row = Grid.GetRow(c);

                if (first_free_col == (grid.ColumnDefinitions.Count - 1)
                    && first_free_row == (grid.RowDefinitions.Count - 1))
                    throw new Exception("Nema slobodnih mesta");
                if (first_free_row == (grid.RowDefinitions.Count - 1))
                {
                    first_free_row = 0;
                    first_free_col++;
                }
                else { first_free_row++; }
            }

            Grid.SetColumn(child, first_free_col);
            Grid.SetRow(child, first_free_row);

            if (!grid.Children.Contains(child))
                grid.Children.Add(child);
        }

        public static void AddChildAnimate(UIElement child, Grid grid, int start_time)
        {
            AddChild(child, grid);

            child.Opacity = 0.0;

            DoubleAnimation an = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(200));
            an.BeginTime = TimeSpan.FromMilliseconds(start_time += 80);

            child.BeginAnimation(btnDugmeTemp.OpacityProperty, an);

            DoubleAnimation da = new DoubleAnimation(50, 0, new Duration(TimeSpan.FromMilliseconds(200)));
            da.BeginTime = TimeSpan.FromMilliseconds(start_time);
            da.DecelerationRatio = 0.7;
            TranslateTransform rt = new TranslateTransform();
            child.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.XProperty, da);
        }

        public static void GridAnimateEntrance(Grid grid)
        {
            int start_time = 0;

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                var rows = grid.Children.Cast<UIElement>().Where(x => Grid.GetColumn(x) == i).ToList();
                foreach (var child in rows)
                {
                    child.Opacity = 0.0;
                    DoubleAnimation an = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(200));
                    an.BeginTime = TimeSpan.FromMilliseconds(start_time += 100);

                    child.BeginAnimation(btnDugmeTemp.OpacityProperty, an);

                    DoubleAnimation da = new DoubleAnimation(50, 0, new Duration(TimeSpan.FromMilliseconds(200)));
                    da.BeginTime = TimeSpan.FromMilliseconds(start_time);
                    da.DecelerationRatio = 0.7;
                    TranslateTransform rt = new TranslateTransform();
                    child.RenderTransform = rt;
                    rt.BeginAnimation(TranslateTransform.XProperty, da);
                }
            }
        }

        public static void RemoveChildAnimate(UIElement child, Grid grid)
        {
            int row, column;
            double columnwidth, rowheight;

            List<UIElement> tmp = new List<UIElement>();

            DoubleAnimation an = new DoubleAnimation(1.0, 0, TimeSpan.FromMilliseconds(100));
            //an.BeginTime = TimeSpan.FromMilliseconds(start_time);
            child.BeginAnimation(btnDugmeTemp.OpacityProperty, an);

            row = Grid.GetRow(child);
            column = Grid.GetColumn(child);

            columnwidth = grid.ColumnDefinitions.ElementAt(column).Width.Value;
            rowheight = grid.RowDefinitions.ElementAt(row).Height.Value;

            DoubleAnimation da = new DoubleAnimation(1.0, 0, TimeSpan.FromMilliseconds(100));
            //da.BeginTime = TimeSpan.FromMilliseconds(start_time);
            da.Completed += (object sender, EventArgs e) => { grid.Children.Remove(child); };

            ScaleTransform rt = new ScaleTransform();
            child.RenderTransformOrigin = new Point(0.5, 0.5);
            child.RenderTransform = rt;
            rt.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            rt.BeginAnimation(ScaleTransform.ScaleYProperty, da);

        }

        public static void RemoveFirstAnimate(Grid grid, int start_time)
        {
            var d = grid.Children.Cast<UIElement>().ElementAt(0);

            Animate.RemoveChildAnimate(d, grid);
            var tmp = new List<UIElement>();
            tmp.AddRange(grid.Children.Cast<UIElement>().ToArray());
            grid.Children.Clear();
            foreach (var c in tmp)
            {
                c.Opacity = 0.5;
                Animate.AddChild(c, grid);
                if (Grid.GetRow(c) > 0)
                    Animate.MoveUp(c, grid, start_time += 50);
                if (Grid.GetRow(c) == 0 && Grid.GetColumn(c) > 0)
                    Animate.MoveDiagonally(c, grid, start_time);
                c.Opacity = 1.0;
            }
        }

        public static void RemoveSpecficChild(UIElement child, Grid grid)
        {
            int start_time = 100;
            int indeks = grid.Children.IndexOf(child);
            Animate.RemoveChildAnimate(child, grid);

            var tmp = new List<UIElement>();
            var tmp1 = new List<UIElement>();

            tmp.AddRange(grid.Children.Cast<UIElement>().Skip(indeks).ToArray());
            tmp1.AddRange(grid.Children.Cast<UIElement>().Take(indeks).ToArray());
            grid.Children.Clear();

            for (int k = 0; k < indeks; k++)
                grid.Children.Add(tmp1[k]);

            foreach (var c in tmp)
            {
                Animate.AddChild(c, grid);
                if (Grid.GetRow(c) > 0)
                    Animate.MoveUp(c, grid, start_time += 50);
                if (Grid.GetRow(c) == 0 && Grid.GetColumn(c) > 0)
                    Animate.MoveDiagonally(c, grid, start_time);
            }
        }

        public static void RemoveRangeOfChildren(UIElement[] children, Grid grid)
        {
            //80% radi kako treba
            foreach (var c in children)
            {
                Animate.RemoveChildAnimate(c, grid);
            }

            int start_time = 100;

            List<UIElement> tmp = null;
            List<UIElement> tmp1 = null;

            if (grid.Children.IndexOf(children[0]) == 0)
            {
                tmp = new List<UIElement>();
                tmp.AddRange(grid.Children.Cast<UIElement>().Skip(children.Count()).ToArray());
                grid.Children.Clear();
            }
            else
            {
                tmp = new List<UIElement>();
                tmp1 = new List<UIElement>();
                tmp1.AddRange(grid.Children.Cast<UIElement>().Take(grid.Children.IndexOf(children[0])).ToArray());
                tmp.AddRange(grid.Children.Cast<UIElement>().Skip(children.Count()).ToArray());
            }

            grid.Children.Clear();

            if (tmp1 != null)
            {
                for (int k = 0; k < children.Count(); k++)
                {
                    grid.Children.Add(tmp1[k]);
                }
            }

            foreach (var c in tmp)
            {
                c.Opacity = 0.5;
                Animate.AddChild(c, grid);
                if (Grid.GetRow(c) > 0)
                    Animate.MoveUp(c, grid, start_time += 50);
                if (Grid.GetRow(c) == 0 && Grid.GetColumn(c) > 0)
                    Animate.MoveDiagonally(c, grid, start_time);
                c.Opacity = 1.0;
            }
        }

        private static void MoveDiagonally(UIElement child, Grid grid, int start_time)
        {
            double move_x, move_y;

            move_x = -grid.ColumnDefinitions.First().ActualWidth;

            move_y = grid.RowDefinitions.First().ActualHeight * (grid.RowDefinitions.Count - 1);

            DoubleAnimation ax = new DoubleAnimation(0, move_x, new Duration(TimeSpan.FromMilliseconds(400)));
            ax.BeginTime = TimeSpan.FromMilliseconds(start_time);
            DoubleAnimation ay = new DoubleAnimation(0, move_y, new Duration(TimeSpan.FromMilliseconds(400)));
            ay.BeginTime = TimeSpan.FromMilliseconds(start_time);
            TranslateTransform rt = new TranslateTransform();
            child.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.XProperty, ax);
            rt.BeginAnimation(TranslateTransform.YProperty, ay);
        }

        private static void MoveUp(UIElement child, Grid grid, int start_time)
        {
            double move_y = -grid.RowDefinitions.First().ActualHeight;

            DoubleAnimation ay = new DoubleAnimation(0, move_y, new Duration(TimeSpan.FromMilliseconds(200)));
            ay.BeginTime = TimeSpan.FromMilliseconds(start_time);

            TranslateTransform rt = new TranslateTransform();
            child.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.YProperty, ay);
        }

        private static void MoveDown(UIElement child, Grid grid, int start_time)
        {
            double move_y = grid.RowDefinitions.First().ActualHeight;

            DoubleAnimation ay = new DoubleAnimation(0, move_y, new Duration(TimeSpan.FromMilliseconds(200)));
            ay.BeginTime = TimeSpan.FromMilliseconds(start_time);

            TranslateTransform rt = new TranslateTransform();
            child.RenderTransform = rt;
            rt.BeginAnimation(TranslateTransform.YProperty, ay);
        }

        // za izbor predmeta 
        public static void GridAnimateEntrance2(Grid grid)
        {
            int start_time = 0;

            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                var rows = grid.Children.Cast<UIElement>().Where(x => Grid.GetRow(x) == i).ToList();
                foreach (var child in rows)
                {
                    child.Opacity = 0.0;
                    DoubleAnimation an = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(200));
                    an.BeginTime = TimeSpan.FromMilliseconds(start_time += 100);

                    child.BeginAnimation(btnDugmeTemp.OpacityProperty, an);

                    DoubleAnimation da = new DoubleAnimation(80, 0, new Duration(TimeSpan.FromMilliseconds(100)));
                    da.BeginTime = TimeSpan.FromMilliseconds(start_time);
                    da.DecelerationRatio = 0.7;
                    TranslateTransform rt = new TranslateTransform();
                    child.RenderTransform = rt;
                    rt.BeginAnimation(TranslateTransform.XProperty, da);
                }
            }
        }
    }
}