using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace KarScraper
{
    public class SetPropertyAction : TriggerAction<FrameworkElement>
    {
        // PropertyName DependencyProperty.

        /// <summary>
        /// The property to be executed in response to the trigger.
        /// </summary>
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        public static readonly DependencyProperty PropertyNameProperty
            = DependencyProperty.Register("PropertyName", typeof(string),
            typeof(SetPropertyAction));


        // PropertyValue DependencyProperty.

        /// <summary>
        /// The value to set the property to.
        /// </summary>
        public object PropertyValue
        {
            get { return GetValue(PropertyValueProperty); }
            set { SetValue(PropertyValueProperty, value); }
        }

        public static readonly DependencyProperty PropertyValueProperty
            = DependencyProperty.Register("PropertyValue", typeof(object),
            typeof(SetPropertyAction));


        // TargetObject DependencyProperty.

        /// <summary>
        /// Specifies the object upon which to set the property.
        /// </summary>
        public object TargetObject
        {
            get { return GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        public static readonly DependencyProperty TargetObjectProperty
            = DependencyProperty.Register("TargetObject", typeof(object),
            typeof(SetPropertyAction));


        // Private Implementation.

        protected override void Invoke(object parameter)
        {
            object target = TargetObject ?? AssociatedObject;
            PropertyInfo propertyInfo = target.GetType().GetProperty(
                PropertyName,
                BindingFlags.Instance | BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.InvokeMethod);

            propertyInfo.SetValue(target, PropertyValue);

            //foreach (var item in ((AssociatedObject as Button).Parent as StackPanel).Children)
            //{
            //    if(item is Button buton)
            //    buton.Opacity =1;
            //}
            //(AssociatedObject as Button).Opacity = 0.5;

            //foreach (var item in ((target as FrameworkElement).Parent as Grid).Children)
            //{
            //    (item as FrameworkElement).Visibility = Visibility.Collapsed;               
            //}
        }
    }
}
