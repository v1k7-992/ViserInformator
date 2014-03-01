using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Informator.Presentation.Common
{
    public class StoryboardTranslate
    {
        public event EventHandler completed;

        public List<SbItem> Children = new List<SbItem>();

        public void Begin()
        {
            Children.Last().animation.Completed += animation_Completed;
           
            foreach (var c in Children)
            {
                c.transform.BeginAnimation(c.dp, c.animation);
            }
        }

        void animation_Completed(object sender, EventArgs e)
        {
            if (completed != null)
                completed(this, null);
        }
    }

    public class SbItem
    {
        public TranslateTransform transform { get; set; }
        public DependencyProperty dp { get; set; }
        public AnimationTimeline animation { get; set; }

        public SbItem(TranslateTransform transform, DependencyProperty dp, AnimationTimeline animation)
        {
            this.transform = transform;
            this.dp = dp;
            this.animation = animation;
        }
    }
}
