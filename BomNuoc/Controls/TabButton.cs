using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BomNuoc.Controls
{
    public class TabButton : TaggedButton
    {
        public TabButton()
        {
            this.Clicked += TabButton_Clicked;
        }

        private void TabButton_Clicked(object sender, EventArgs e)
        {
            IsSelected = true;
        }

        #region SelectedColor BindableProperty
        public static readonly BindableProperty SelectedColorProperty =
            BindableProperty.Create(
                nameof(SelectedColor),
                typeof(Color),
                typeof(TabButton),
                Color.Cyan,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((TabButton)bindable).SelectedColor = (Color)newValue; }
            );

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set
            {
                SetValue(SelectedColorProperty, value);
            }
        }
        #endregion

        #region IsSelected BindableProperty
        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(
                nameof(IsSelected),
                typeof(bool),
                typeof(TabButton),
                false,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((TabButton)bindable).UpdateColor(); }
            );

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);                
            }
        }
        #endregion

        ~TabButton()
        {
            this.Clicked -= TabButton_Clicked;
        }

        private Color DefaultBackgroundColor { get; set; } = Color.Default;

        private void UpdateColor()
        {
            if (IsSelected)
            {
                this.DefaultBackgroundColor = this.BackgroundColor;
                this.BackgroundColor = SelectedColor;
                foreach (var b in FindParentTabButtons())
                {
                    if (b != this)
                    {
                        b.IsSelected = false;
                    }
                }
            }
            else
            {
                if (this.BackgroundColor == SelectedColor)
                {
                    this.BackgroundColor = DefaultBackgroundColor;
                }
            }
        }

        private List<TabButton> FindParentTabButtons()
        {
            var ret = new List<TabButton>();
            if (Parent != null)
            {
                if (Parent.GetType() == typeof(StackLayout))
                {
                    ret.AddRange(((StackLayout)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
                else if (Parent.GetType() == typeof(Grid))
                {
                    ret.AddRange(((Grid)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
                else if (Parent.GetType() == typeof(AbsoluteLayout))
                {
                    ret.AddRange(((AbsoluteLayout)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
                else if (Parent.GetType() == typeof(RelativeLayout))
                {
                    ret.AddRange(((RelativeLayout)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
                else if (Parent.GetType() == typeof(WrapLayout))
                {
                    ret.AddRange(((WrapLayout)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
                else if (Parent.GetType() == typeof(WrapLayoutOld))
                {
                    ret.AddRange(((WrapLayoutOld)Parent).Children.Where(d => d.GetType() == typeof(TabButton)).Select(d => (TabButton)d));
                }
            }
            return ret;
        }

    }
}
