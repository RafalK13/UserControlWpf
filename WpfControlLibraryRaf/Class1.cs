using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfControlLibraryRaf
{
    public class MyPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Size childSize = new Size(availableSize.Width, double.PositiveInfinity);

            foreach (UIElement elem in InternalChildren)
                elem.Measure(childSize);

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size childSize;

            int n = 0;
            double top = 0.0;
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                childSize = new Size(finalSize.Width, InternalChildren[i].DesiredSize.Height);
                Rect r = new Rect(new Point(n, top), childSize);
                InternalChildren[i].Arrange(r);
                top += childSize.Height;
                n += 13;
            }

            return finalSize;
        }
    }
}
