using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc
{
    public static class ViewExtensions
    {
        public static T Bind<T>(this T view, BindableProperty property, string path) where T : View
        {
            view.SetBinding(property, path);
            return view;
        }

        public static T Bind<T>(this T view, BindableProperty property, Binding binding) where T : View
        {
            view.SetBinding(property, binding);
            return view;
        }

        public static T SetGridRow<T>(this T view, int value) where T : View
        {
            Grid.SetRow(view, value);
            return view;
        }
        public static T SetGridColumn<T>(this T view, int value) where T : View
        {
            Grid.SetColumn(view, value);
            return view;
        }
        //Xamarinのバージョン上げたら死んだ
        //public static T AddTrigger<T>(this T view, string path, object value, BindableProperty setterProperty, object setterValue) where T : View
        //{
        //    var trigger = new DataTrigger(typeof(T))
        //    {
        //        Binding = new Binding(path),
        //        Value = value
        //    };
        //    trigger.Setters.Add(new Setter()
        //    {
        //        Property = setterProperty,
        //        Value = setterValue
        //    });
        //    view.Triggers.Add(trigger);
        //    return view;
        //}
    }
    public static class GridExtensions
    {
        public static Grid AddChild(this Grid view, View child)
        {
            view.Children.Add(child);
            return view;
        }
        public static Grid RemoveChild(this Grid view, View child)
        {
            view.Children.Remove(child);
            return view;
        }
    }
    public static class StackLayoutExtensions
    {
        public static StackLayout AddChild(this StackLayout view, View child)
        {
            view.Children.Add(child);
            return view;
        }
        public static StackLayout RemoveChild(this StackLayout view, View child)
        {
            view.Children.Remove(child);
            return view;
        }
    }
    public static class ContentViewExtensions
    {
        public static ContentView AddChild(this ContentView view, View child)
        {
            view.Content = child;
            return view;
        }
    }
    public static class ButtonExtensions
    {
        public static T AddCommand<T>(this T view, Action execute) where T : Button
        {
            view.SetBinding(Button.CommandParameterProperty, new Binding { Source = view });
            view.SetBinding(Button.CommandProperty, new Binding { Source = new Command(execute) });
            return view;
        }
        public static T AddCommand<T>(this T view, Action<object> execute) where T : Button
        {
            view.SetBinding(Button.CommandParameterProperty, new Binding { Source = view });
            view.SetBinding(Button.CommandProperty, new Binding { Source = new Command(execute) });
            return view;
        }
    }
}
