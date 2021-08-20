using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PDS.Xamarin.Generic;

//ref http://matatabi-ux.hateblo.jp/entry/2015/01/26/120000 Xamarin で ItemsControl っぽいコントロールを作りたい（１）
//ref http://matatabi-ux.hateblo.jp/entry/2015/01/28/120000 Xamarin で ItemsControl っぽいコントロールを作りたい（２）

/* usage
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:b="clr-namespace:XamarinControl.Behaviors;assembly=XamarinControl"
             xmlns:c="clr-namespace:XamarinControl.Controls;assembly=XamarinControl"
             xmlns:vm="clr-namespace:XamarinControl.ViewModels;assembly=XamarinControl"
             x:Class="XamarinControl.Views.TopPage">

  <ContentPage.BindingContext>
    <vm:TopPageViewModel/>
  </ContentPage.BindingContext>
  
  <c:ItemsControl ItemsSource ="{Binding Items}">
    <c:ItemsControl.ItemsPanel>
      <RelativeLayout/>
    </c:ItemsControl.ItemsPanel>
    <c:ItemsControl.ItemTemplate>
      <DataTemplate>
        <Grid Padding="20,10" 
              RelativeLayout.XConstraint="{Binding XConstraint}"
              RelativeLayout.YConstraint="{Binding YConstraint}">
          <Label Text="{Binding Content}"/>
        </Grid>
      </DataTemplate>
    </c:ItemsControl.ItemTemplate>
  </c:ItemsControl>
</ContentPage>
*/

namespace BomNuoc.Controls
{
    /// <summary>
    /// ItemsControl 風 View
    /// </summary>
    public class ItemsControl : ContentView
    {
        #region ItemsPanel

        /// <summary>
        /// ItemsPanel BindableProperty
        /// </summary>
        public static readonly BindableProperty ItemsPanelProperty = BindableProperty.Create(nameof(ItemsPanel), typeof(Layout<View>), typeof(ItemsControl),
            new StackLayout(), 
            BindingMode.OneWay, 
            null, 
            (bindable, oldValue, newValue) => OnItemsPanelChanged(bindable, (Layout<View>)oldValue, (Layout<View>)newValue));
        //public static readonly BindableProperty ItemsPanelProperty = BindableProperty.Create<ItemsControl, Layout<View>>(
        //    p => p.ItemsPanel,
        //    new StackLayout(),
        //    BindingMode.OneWay,
        //    null,
        //    OnItemsPanelChanged);

        /// <summary>
        /// ItemsPanel CLR プロパティ
        /// </summary>
        public Layout<View> ItemsPanel
        {
            get { return (Layout<View>)this.GetValue(ItemsPanelProperty); }
            set { this.SetValue(ItemsPanelProperty, value); }
        }

        /// <summary>
        /// ItemsPanel 変更イベントハンドラ
        /// </summary>
        /// <param name="bindable">BindableObject</param>
        /// <param name="oldValue">古い値</param>
        /// <param name="newValue">新しい値</param>
        private static void OnItemsPanelChanged(BindableObject bindable, Layout<View> oldValue, Layout<View> newValue)
        {
            var control = bindable as ItemsControl;
            if (control == null)
            {
                return;
            }

            if (oldValue != null)
            {
                oldValue.Children.Clear();
            }

            if (newValue == null)
            {
                return;
            }

            foreach (var item in control.ItemsSource)
            {
                var content = control.ItemTemplate.CreateContent();
                View view;
                var cell = content as ViewCell;
                if (cell != null)
                {
                    view = cell.View;
                }
                else
                {
                    view = (View)content;
                }

                view.BindingContext = item;
                control.ItemsPanel.Children.Add(view);
            }

            control.Content = newValue;
            control.UpdateChildrenLayout();
            control.InvalidateLayout();
        }

        #endregion //ItemsPanel


        #region ItemsSource

        /// <summary>
        /// ItemsSource BindableProperty
        /// </summary>
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(ItemsControl),
            new ObservableCollection<object>(),
            BindingMode.OneWay,
            null,
            (bindable, oldValue, newValue) => OnItemsSourceChanged(bindable, (IEnumerable)oldValue, (IEnumerable)newValue));
        //public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<ItemsControl, IEnumerable>(
        //    p => p.ItemsSource,
        //    new ObservableCollection<object>(),
        //    BindingMode.OneWay,
        //    null,
        //    OnItemsSourceChanged);

        /// <summary>
        /// ItemsSource CLR プロパティ
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// ItemsSource 変更イベントハンドラ
        /// </summary>
        /// <param name="bindable">BindableObject</param>
        /// <param name="oldValue">古い値</param>
        /// <param name="newValue">新しい値</param>
        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var control = bindable as ItemsControl;
            if (control == null)
            {
                return;
            }

            var oldCollection = oldValue as INotifyCollectionChanged;
            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= control.OnCollectionChanged;
            }

            if (newValue == null)
            {
                return;
            }
            
            control.ItemsPanel.Children.Clear();

            foreach (var item in newValue)
            {
                var content = control.ItemTemplate.CreateContent();
                View view;
                var cell = content as ViewCell;
                if (cell != null)
                {
                    view = cell.View;
                }
                else
                {
                    view = (View)content;
                }

                view.BindingContext = item;
                control.ItemsPanel.Children.Add(view);
            }

            var newCollection = newValue as INotifyCollectionChanged;
            if (newCollection != null)
            {
                newCollection.CollectionChanged += control.OnCollectionChanged;
            }

            control.UpdateChildrenLayout();
            control.InvalidateLayout();
            control.ItemsSourceUpdated?.Invoke(control, EventArgs.Empty);
        }

        public event EventHandler ItemsSourceUpdated;

        #endregion //ItemsSource

        #region ItemTemplate

        /// <summary>
        /// ItemTemplate BindableProperty
        /// </summary>
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ItemsControl),
            default(DataTemplate));
        //public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create<ItemsControl, DataTemplate>(
        //    p => p.ItemTemplate,
        //    default(DataTemplate));

        /// <summary>
        /// ItemTemplate CLR プロパティ
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)this.GetValue(ItemTemplateProperty); }
            set { this.SetValue(ItemTemplateProperty, value); }
        }

        #endregion //ItemTemplate

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ItemsControl()
        {
            this.Content = this.ItemsPanel;
        }

        /// <summary>
        /// Items の変更イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                this.ItemsPanel.Children.RemoveAt(e.OldStartingIndex);
                this.UpdateChildrenLayout();
                this.InvalidateLayout();
            }

            //var collection = this.ItemsSource as ObservableCollection<object>;
            if (e.NewItems == null)// || collection == null)
            {
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    this.ItemsPanel.Children.Clear();
                    this.UpdateChildrenLayout();
                    this.InvalidateLayout();

                    ItemsSourceUpdated?.Invoke(this, EventArgs.Empty);
                }
                return;
            }
            foreach (var item in e.NewItems)
            {
                var content = this.ItemTemplate.CreateContent();

                View view;
                var cell = content as ViewCell;
                if (cell != null)
                {
                    view = cell.View;
                }
                else
                {
                    view = (View)content;
                }

                view.BindingContext = item;
                this.ItemsPanel.Children.Insert(this.ItemsSource.IndexOf(item), view);
            }

            this.UpdateChildrenLayout();
            this.InvalidateLayout();

            ItemsSourceUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
