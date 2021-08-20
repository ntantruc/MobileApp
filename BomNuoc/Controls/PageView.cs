using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Controls
{
    public class PageView : ContentView
    {
        #region ViewPage BindableProperty
        public static readonly BindableProperty ViewPageProperty =
            BindableProperty.Create(
                nameof(ViewPage),
                typeof(ContentPage),
                typeof(PageView),
                null,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((PageView)bindable).ViewPage = (ContentPage)newValue; }
            );

        public ContentPage ViewPage
        {
            get { return (ContentPage)GetValue(ViewPageProperty); }
            set
            {
                var current = ViewPage;
                if (current != null) ((IPageController)current).SendDisappearing();
                SetValue(ViewPageProperty, value);
                if (value != null)
                {
                    this.Content = value.Content;
                    ((IPageController)value).SendAppearing();
                }
                else
                {
                    this.Content = null;
                }
            }
        }
        #endregion

        public void SendAppearing()
        {
            (ViewPage as IPageController)?.SendAppearing();
        }

        public void SendDisappearing()
        {
            (ViewPage as IPageController)?.SendDisappearing();
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
        }
        public PageView()
        {

        }
    }
}
