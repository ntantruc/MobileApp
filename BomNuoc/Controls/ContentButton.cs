using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BomNuoc.Controls
{
    [ContentProperty("Overlay")]
    public class ContentButton : ContentView
    {

        private Color oldBackground = Color.White;
        public void SetDisable()
        {
            this.IsEnabled = false;
            oldBackground = this.BackgroundColor;
            this.BackgroundColor = Color.Gray;
        }
        public void SetEnable()
        {
            this.BackgroundColor = oldBackground;
            this.IsEnabled = true;
        }

        protected View BaseGrid;
        protected ContentView OverlayContent;
        protected ContentView GridContent;
        protected Button BackgroundButton;
        protected Button BaseButton;
        public ContentButton()
        {
            CreateView();
        }
        public View Overlay
        {
            get { return OverlayContent.Content; }
            set
            {
                //if (!BaseGrid.Children.Contains(value))
                OverlayContent.Content = value;
            }
        }

        private void CreateView()
        {
            BackgroundButton = new Button { BackgroundColor = Color.Transparent, BorderRadius = Device.OnPlatform<int>(0, 1, 0, 0), TextColor = Color.Transparent, FontAttributes = FontAttributes.None, BorderColor = Color.Transparent, BorderWidth = 0, HeightRequest = -1 };
            OverlayContent = new ContentView { };
            GridContent = new ContentView { BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            BaseButton = new Button { BackgroundColor = Color.Transparent, BorderRadius = Device.OnPlatform<int>(0, 1, 0, 0), TextColor = Color.Transparent, FontAttributes = FontAttributes.None, BorderColor = Color.Transparent, BorderWidth = 0, HeightRequest = -1 };
            if (GridMode == false)
            {
                var baseGrid = new AbsoluteLayout { BackgroundColor = Color.Transparent, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
                AbsoluteLayout.SetLayoutFlags(BackgroundButton, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(BackgroundButton, new Rectangle(0, 0, 1, 1));
                baseGrid.Children.Add(BackgroundButton);
                AbsoluteLayout.SetLayoutFlags(OverlayContent, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                //AbsoluteLayout.SetLayoutFlags(OverlayContent, AbsoluteLayoutFlags.All);
                //AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(0, 0, 1, 1));
                //AbsoluteLayout.SetLayoutFlags(OverlayContent, AbsoluteLayoutFlags.All);
                //AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(0.5, 0.5, 0.99, 0.99));
                //AbsoluteLayout.SetLayoutFlags(OverlayContent, AbsoluteLayoutFlags.All);
                //AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(0.5, 0.5, 1.1, 1.1));
                baseGrid.Children.Add(OverlayContent);
                AbsoluteLayout.SetLayoutFlags(BaseButton, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(BaseButton, new Rectangle(0, 0, 1, 1));
                baseGrid.Children.Add(BaseButton);
                BaseGrid = baseGrid;
            }
            else
            {
                var baseGrid = new Grid { RowSpacing = 0, ColumnSpacing = 0, BackgroundColor = Color.Transparent, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
                baseGrid.Children.Add(BackgroundButton);
                GridContent.Content = OverlayContent;
                baseGrid.Children.Add(GridContent);
                baseGrid.Children.Add(BaseButton);
                BaseGrid = baseGrid;
            }
            BaseButton.Clicked += BaseButton_Clicked;
            base.Content = BaseGrid;
        }

        ~ContentButton()
        {
            BaseButton.Clicked -= BaseButton_Clicked;
        }

        public event EventHandler Clicked;

        #region BackgroundColor BindableProperty
        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(
                nameof(BackgroundColor),
                typeof(Color),
                typeof(ContentButton),
                Color.Transparent,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).BackgroundColor = (Color)newValue; }
            );

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set
            {
                SetValue(BackgroundColorProperty, value);
                BackgroundButton.BackgroundColor = value;
            }
        }
        #endregion

        #region BorderColor BindableProperty
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(ContentButton),
                Color.Transparent,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).BorderColor = (Color)newValue; }
            );

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
                BaseButton.BorderColor = value;
            }
        }
        #endregion

        #region BorderWidth BindableProperty
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(
                nameof(BorderWidth),
                typeof(double),
                typeof(ContentButton),
                0.0,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).BorderWidth = (double)newValue; }
            );

        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set
            {
                SetValue(BorderWidthProperty, value);
                BaseButton.BorderWidth = value;
                BackgroundButton.BorderWidth = Math.Max(0.0, value - 1.0);
            }
        }
        #endregion

        #region BorderRadius BindableProperty
        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create(
                nameof(BorderRadius),
                typeof(int),
                typeof(ContentButton),
                Device.OnPlatform<int>(0, 1, 0, 0),
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).BorderRadius = (int)newValue; }
            );

        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set
            {
                if (Device.RuntimePlatform == Device.Android && value == 0) value = 1;
                SetValue(BorderRadiusProperty, value);
                BaseButton.BorderRadius = value;
                BackgroundButton.BorderRadius = value;
            }
        }
        #endregion

        #region Tag BindableProperty
        public static readonly BindableProperty TagProperty =
            BindableProperty.Create(
                nameof(Tag),
                typeof(object),
                typeof(ContentButton),
                null,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).Tag = newValue; }
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

        #region GridMode BindableProperty
        public static readonly BindableProperty GridModeProperty =
            BindableProperty.Create(
                nameof(GridMode),
                typeof(bool),
                typeof(ContentButton),
                false,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).GridMode = (bool)newValue; }
            );

        public bool GridMode
        {
            get { return (bool)GetValue(GridModeProperty); }
            set
            {
                SetValue(GridModeProperty, value);
                CreateView();
            }
        }
        #endregion


        #region Padding BindableProperty
        public new static readonly BindableProperty PaddingProperty =
            BindableProperty.Create(
                nameof(Padding),
                typeof(Thickness),
                typeof(ContentButton),
                new Thickness(0),
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).Padding = (Thickness)newValue; }
            );

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set
            {
                SetValue(PaddingProperty, value);
                OverlayContent.Margin = value;
            }
        }
        #endregion



        #region HorizontalContentOptions BindableProperty
        public static readonly BindableProperty HorizontalContentOptionsProperty =
            BindableProperty.Create(
                nameof(HorizontalContentOptions),
                typeof(LayoutOptions),
                typeof(ContentButton),
                LayoutOptions.Center,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).HorizontalContentOptions = (LayoutOptions)newValue; }
            );

        public LayoutOptions HorizontalContentOptions
        {
            get { return (LayoutOptions)GetValue(HorizontalContentOptionsProperty); }
            set
            {
                SetValue(HorizontalContentOptionsProperty, value);
                var current = AbsoluteLayout.GetLayoutBounds(OverlayContent);
                double x = 0.0, y = current.Top, w = 0.0, h = current.Height;
                if (value.Alignment == LayoutAlignment.Start || value.Alignment == LayoutAlignment.Fill) { x = 0.0; }
                else if (value.Alignment == LayoutAlignment.Center) { x = 0.5; }
                else if (value.Alignment == LayoutAlignment.End) { x = 1; }
                if (value.Expands == true) { x = 0.0; w = 1.0; }
                else { w = AbsoluteLayout.AutoSize; }
                AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(x, y, w, h));
                GridContent.HorizontalOptions = value;
            }
        }
        #endregion

        #region VerticalContentOptions BindableProperty
        public static readonly BindableProperty VerticalContentOptionsProperty =
            BindableProperty.Create(
                nameof(VerticalContentOptions),
                typeof(LayoutOptions),
                typeof(ContentButton),
                LayoutOptions.Center,
                BindingMode.Default,
                null,
                (bindable, oldValue, newValue) => { ((ContentButton)bindable).VerticalContentOptions = (LayoutOptions)newValue; }
            );

        public LayoutOptions VerticalContentOptions
        {
            get { return (LayoutOptions)GetValue(VerticalContentOptionsProperty); }
            set
            {
                SetValue(VerticalContentOptionsProperty, value);
                var current = AbsoluteLayout.GetLayoutBounds(OverlayContent);
                double x = current.Left, y = 0.0, w = current.Width, h = 0.0;
                if (value.Alignment == LayoutAlignment.Start || value.Alignment == LayoutAlignment.Fill) { y = 0.0; }
                else if (value.Alignment == LayoutAlignment.Center) { y = 0.5; }
                else if (value.Alignment == LayoutAlignment.End) { y = 1; }
                if (value.Expands == true) { y = 0.0; h = 1.0; }
                else { h = AbsoluteLayout.AutoSize; }
                AbsoluteLayout.SetLayoutBounds(OverlayContent, new Rectangle(x, y, w, h));
                GridContent.VerticalOptions = value;
            }
        }
        #endregion

        private void BaseButton_Clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
