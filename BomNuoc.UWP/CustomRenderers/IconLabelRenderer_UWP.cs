using System;
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using WApplication = Windows.UI.Xaml.Application;

[assembly: ExportRenderer(typeof(BomNuoc.Controls.IconLabel), typeof(BomNuoc.UWP.CustomRenderers.IconLabelRenderer_UWP))]

namespace BomNuoc.UWP.CustomRenderers
{
    public static class AlignmentExtensions
    {
        internal static Windows.UI.Xaml.TextAlignment ToNativeTextAlignment(this Xamarin.Forms.TextAlignment alignment)
        {
            switch (alignment)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    return Windows.UI.Xaml.TextAlignment.Center;
                case Xamarin.Forms.TextAlignment.End:
                    return Windows.UI.Xaml.TextAlignment.Right;
                default:
                    return Windows.UI.Xaml.TextAlignment.Left;
            }
        }

        internal static VerticalAlignment ToNativeVerticalAlignment(this Xamarin.Forms.TextAlignment alignment)
        {
            switch (alignment)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    return VerticalAlignment.Center;
                case Xamarin.Forms.TextAlignment.End:
                    return VerticalAlignment.Bottom;
                default:
                    return VerticalAlignment.Top;
            }
        }
    }
    public static class ConvertExtensions
    {
        public static Brush ToBrush(this Color color)
        {
            return new SolidColorBrush(color.ToWindowsColor());
        }

        public static Windows.UI.Color ToWindowsColor(this Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
    public static class FontExtensions
    {
        internal static bool IsDefault(this Xamarin.Forms.Span self)
        {
            // return self.FontFamily == null && self.FontSize == Device.GetNamedSize(NamedSize.Default, typeof(Label)) && self.FontAttributes == FontAttributes.None;
            return self.FontFamily == null && self.FontSize == Xamarin.Forms.Device.GetNamedSize(NamedSize.Default, typeof(Label)) && self.FontAttributes == FontAttributes.None;
        }
        internal static bool IsDefault(this Xamarin.Forms.Label self)
        {
            //return self.FontFamily == null && self.FontSize == Device.GetNamedSize(NamedSize.Default, typeof(Label)) && self.FontAttributes == FontAttributes.None;
            return self.FontFamily == null && self.FontSize == Xamarin.Forms.Device.GetNamedSize(NamedSize.Default, typeof(Label)) && self.FontAttributes == FontAttributes.None;
        }
    }
    public static class FormattedStringExtensions
    {
        public static Run ToRun(this Xamarin.Forms.Span span)
        {
            var run = new Run { Text = span.Text };

            if (span.ForegroundColor != Color.Default)
                run.Foreground = span.ForegroundColor.ToBrush();

            if (!span.IsDefault())
#pragma warning disable 618
                run.ApplyFont(span.Font);
#pragma warning restore 618

            return run;
        }
    }

    public class IconLabelRenderer_UWP : ViewRenderer<Label, Windows.UI.Xaml.Controls.Grid>
    {
        bool _fontApplied;
        bool _isInitiallyDefault;
        SizeRequest _perfectSize;
        bool _perfectSizeValid;

        private TextBlock _textBlock = null;
        private TextBlock _textBlockShadow = null;

        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            if (Element == null)
                return finalSize;
            double childHeight = Math.Max(0, Math.Min(Element.Height, _textBlock.DesiredSize.Height));
            var rect = new Rect();

            switch (Element.VerticalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    break;
                default:
                case Xamarin.Forms.TextAlignment.Center:
                    rect.Y = (int)((finalSize.Height - childHeight) / 2);
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    rect.Y = finalSize.Height - childHeight;
                    break;
            }
            rect.Height = childHeight;
            rect.Width = finalSize.Width;
            _textBlock.Arrange(rect);
            _textBlockShadow.Arrange(rect);
            return finalSize;
        }

        public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            if (!_perfectSizeValid)
            {
                _perfectSize = base.GetDesiredSize(double.PositiveInfinity, double.PositiveInfinity);
                _perfectSize.Minimum = new Xamarin.Forms.Size(Math.Min(10, _perfectSize.Request.Width), _perfectSize.Request.Height);
                _perfectSizeValid = true;
            }

            var widthFits = widthConstraint >= _perfectSize.Request.Width;
            var heightFits = heightConstraint >= _perfectSize.Request.Height;

            if (widthFits && heightFits)
                return _perfectSize;

            var result = base.GetDesiredSize(widthConstraint, heightConstraint);
            var tinyWidth = Math.Min(10, result.Request.Width);
            result.Minimum = new Xamarin.Forms.Size(tinyWidth, result.Request.Height);

            if (widthFits || Element.LineBreakMode == LineBreakMode.NoWrap)
                return result;

            bool containerIsNotInfinitelyWide = !double.IsInfinity(widthConstraint);

            if (containerIsNotInfinitelyWide)
            {
                bool textCouldHaveWrapped = Element.LineBreakMode == LineBreakMode.WordWrap || Element.LineBreakMode == LineBreakMode.CharacterWrap;
                bool textExceedsContainer = result.Request.Width > widthConstraint;

                if (textExceedsContainer || textCouldHaveWrapped)
                {
                    var expandedWidth = Math.Max(tinyWidth, widthConstraint);
                    result.Request = new Xamarin.Forms.Size(expandedWidth, result.Request.Height);
                }
            }

            return result;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (_textBlock == null)
                {
                    _textBlock = (new TextBlock());
                    _textBlockShadow = (new TextBlock());
                    _textBlockShadow.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(0x80, 0x99, 0x99, 0x99));
                }



                if (Control == null)
                {
                    var grid = new Windows.UI.Xaml.Controls.Grid();
                    grid.Children.Add(_textBlockShadow);
                    grid.Children.Add(_textBlock);
                    SetNativeControl(grid);
                }

                _isInitiallyDefault = Element.IsDefault();

                UpdateText(_textBlock, _textBlockShadow);
                UpdateColor(_textBlock);
                UpdateAlign(_textBlock, _textBlockShadow);
                UpdateFont(_textBlock, _textBlockShadow);
                UpdateLineBreakMode(_textBlock, _textBlockShadow);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Label.TextProperty.PropertyName || e.PropertyName == Label.FormattedTextProperty.PropertyName)
                UpdateText(_textBlock, _textBlockShadow);
            else if (e.PropertyName == Label.TextColorProperty.PropertyName)
                UpdateColor(_textBlock);
            else if (e.PropertyName == Label.HorizontalTextAlignmentProperty.PropertyName || e.PropertyName == Label.VerticalTextAlignmentProperty.PropertyName)
                UpdateAlign(_textBlock, _textBlockShadow);
            else if (e.PropertyName == Label.FontProperty.PropertyName)
                UpdateFont(_textBlock, _textBlockShadow);
            else if (e.PropertyName == Label.LineBreakModeProperty.PropertyName)
                UpdateLineBreakMode(_textBlock, _textBlockShadow);

            base.OnElementPropertyChanged(sender, e);
        }

        void UpdateAlign(TextBlock textBlock, TextBlock textBlockShadow)
        {
            _perfectSizeValid = false;

            if (textBlock == null)
                return;
            UpdateAlign(textBlockShadow, null);

            Label label = Element;
            if (label == null)
                return;

            textBlock.TextAlignment = label.HorizontalTextAlignment.ToNativeTextAlignment();
            textBlock.VerticalAlignment = label.VerticalTextAlignment.ToNativeVerticalAlignment();
        }

        void UpdateColor(TextBlock textBlock)
        {
            if (textBlock == null)
                return;

            Label label = Element;
            if (label != null && label.TextColor != Color.Default)
            {
                textBlock.Foreground = label.TextColor.ToBrush();
            }
            else
            {
                textBlock.ClearValue(TextBlock.ForegroundProperty);
            }
        }

        void UpdateFont(TextBlock textBlock, TextBlock textBlockShadow)
        {
            _perfectSizeValid = false;
            if (textBlockShadow != null)
            {
                //textBlockShadow.Margin = new Windows.UI.Xaml.Thickness(Core.Resource.Size.calc(2), Core.Resource.Size.calc(2), Core.Resource.Size.calc(-2), Core.Resource.Size.calc(-2));
                textBlockShadow.Margin = new Windows.UI.Xaml.Thickness(Resource.Size.calc(2), Resource.Size.calc(2), Resource.Size.calc(-2), Resource.Size.calc(-2));
            }
            if (textBlock == null)
                return;
            UpdateFont(textBlockShadow, null);

            Label label = Element;
            if (label == null || (label.IsDefault() && !_fontApplied))
                return;

#pragma warning disable 618
            Font fontToApply = label.IsDefault() && _isInitiallyDefault ? Font.SystemFontOfSize(NamedSize.Medium) : label.Font;
#pragma warning restore 618

            textBlock.ApplyFont(fontToApply);
            _fontApplied = true;
        }

        void UpdateLineBreakMode(TextBlock textBlock, TextBlock textBlockShadow)
        {
            _perfectSizeValid = false;

            if (textBlock == null)
                return;
            UpdateLineBreakMode(textBlockShadow, null);

            switch (Element.LineBreakMode)
            {
                case LineBreakMode.NoWrap:
                    textBlock.TextTrimming = TextTrimming.Clip;
                    textBlock.TextWrapping = TextWrapping.NoWrap;
                    break;
                case LineBreakMode.WordWrap:
                    textBlock.TextTrimming = TextTrimming.None;
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    break;
                case LineBreakMode.CharacterWrap:
                    textBlock.TextTrimming = TextTrimming.WordEllipsis;
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    break;
                case LineBreakMode.HeadTruncation:
                    textBlock.TextTrimming = TextTrimming.WordEllipsis;
                    textBlock.TextWrapping = TextWrapping.NoWrap;
                    break;
                case LineBreakMode.TailTruncation:
                    textBlock.TextTrimming = TextTrimming.CharacterEllipsis;
                    textBlock.TextWrapping = TextWrapping.NoWrap;
                    break;
                case LineBreakMode.MiddleTruncation:
                    textBlock.TextTrimming = TextTrimming.WordEllipsis;
                    textBlock.TextWrapping = TextWrapping.NoWrap;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void UpdateText(TextBlock textBlock, TextBlock textBlockShadow)
        {
            _perfectSizeValid = false;

            if (textBlock == null)
                return;
            UpdateText(textBlockShadow, null);

            Label label = Element;
            if (label != null)
            {
                FormattedString formatted = label.FormattedText;

                if (formatted == null)
                {
                    textBlock.Text = label.Text ?? string.Empty;
                }
                else
                {
                    textBlock.Inlines.Clear();

                    for (var i = 0; i < formatted.Spans.Count; i++)
                    {
                        if (formatted.Spans[i].Text != null)
                            textBlock.Inlines.Add(formatted.Spans[i].ToRun());
                    }
                }
            }
        }
    }
}
