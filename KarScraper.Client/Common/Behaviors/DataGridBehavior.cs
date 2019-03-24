using FbScraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace KarScraper.Common.Behaviors
{
    public class DataGridBehavior
    {
        public static DependencyProperty StaticLpColumnProperty =
      DependencyProperty.RegisterAttached("StaticLpColumn",
                                          typeof(bool),
                                          typeof(DataGridBehavior),
                                          new FrameworkPropertyMetadata(false, OnDisplayRowNumberChanged));
        public static bool GetStaticLpColumn(DependencyObject target)
        {
            return (bool)target.GetValue(StaticLpColumnProperty);
        }
        public static void SetStaticLpColumn(DependencyObject target, bool value)
        {
            target.SetValue(StaticLpColumnProperty, value);
        }


        private static void OnDisplayRowNumberChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = target as DataGrid;
            if ((bool)e.NewValue == true)
            {
                ItemsChangedEventHandler itemsChangedHandler = null;
                itemsChangedHandler = (object sender, ItemsChangedEventArgs ea) =>
                {
                    if (GetStaticLpColumn(dataGrid) == false)
                    {
                        dataGrid.ItemContainerGenerator.ItemsChanged -= itemsChangedHandler;
                        return;
                    }
                    int a = 1;
                    foreach (var item in dataGrid.Items)
                    {
                        dynamic it = item;
                        it.Lp = a++;                       
                    }
 
                };
                dataGrid.ItemContainerGenerator.ItemsChanged += itemsChangedHandler;
            }
        }
    }
}
