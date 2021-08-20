using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Controls
{
   public  class TaggedButton : Button
    {
        #region Tag BindableProperty
        public static readonly BindableProperty TagProperty =
            BindableProperty.Create(
                nameof(Tag),
                typeof(object),
                typeof(TaggedButton),
                null,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((TaggedButton)bindable).Tag = newValue; }
            );

        public object Tag
        {
            get { return GetValue(TagProperty); }
            set
            {
                SetValue(TagProperty, value);
            }
        }
        #endregion

    }
}
