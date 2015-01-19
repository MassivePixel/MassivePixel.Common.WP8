using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MassivePixel.Common.WP8
{
    public static class VisualTreeHelperExtensions
    {
        public static IEnumerable<T> GetChildren<T>(this DependencyObject o)
            where T : DependencyObject
        {
            if (o == null)
                throw new ArgumentNullException("o");

            for (int index = 0, total = VisualTreeHelper.GetChildrenCount(o);
                index < total;
                index++)
            {
                var child = VisualTreeHelper.GetChild(o, index);
                if (child is T)
                    yield return (T)child;

                foreach (var grandchild in child.GetChildren<T>())
                    yield return grandchild;
            }
        }
    }
}
