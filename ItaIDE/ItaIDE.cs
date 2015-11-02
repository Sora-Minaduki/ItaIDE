using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.Text.Editor;

namespace ItaIDE
{
    class ItaIDE
    {
        private Image _image;
        private BitmapImage _bitmap;
        private IWpfTextView _view;
        private IAdornmentLayer _adornmentLayer;
        private Config config = Config.Instance;

        public ItaIDE(IWpfTextView view)
        {
            _view = view;

            _image = new Image();
            _image.Opacity = config.Opacity;

            // Set the position. The default is right.
            if (config.Position == "center")
            {
                _image.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else if (config.Position == "left")
            {
                _image.HorizontalAlignment = HorizontalAlignment.Left;
            }
            else if (config.Position == "right")
            {
                _image.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (config.Position == "stretch")
            {
                _image.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
            else
            {
                _image.HorizontalAlignment = HorizontalAlignment.Right;
            }

            // Set the stretch method. The default is uniform. 
            if (config.Stretch == "fill")
            {
                _image.Stretch = Stretch.Fill;
            }
            else if (config.Stretch == "none")
            {
                _image.Stretch = Stretch.None;
            }
            else if (config.Stretch == "uniform")
            {
                _image.Stretch = Stretch.Uniform;
            }
            else if (config.Stretch == "uniformtofill")
            {
                _image.Stretch = Stretch.UniformToFill;
            }
            else
            {
                _image.Stretch = Stretch.Uniform;
            }

            _image.StretchDirection = StretchDirection.Both;
            _image.MinHeight = 300.0;

            _bitmap = new BitmapImage(new Uri(config.Path));

            _image.Source = _bitmap;

            _adornmentLayer = view.GetAdornmentLayer("ItaIDE");

            _view.ViewportHeightChanged += delegate { this.onSizeChange(); };
            _view.ViewportWidthChanged += delegate { this.onSizeChange(); };
        }

        public void onSizeChange()
        {
            _adornmentLayer.RemoveAllAdornments();

            Canvas.SetLeft(_image, _view.ViewportLeft);
            Canvas.SetTop(_image, _view.ViewportTop);
            _image.Height = _view.ViewportHeight;
            _image.Width = _view.ViewportWidth;

            _adornmentLayer.AddAdornment(AdornmentPositioningBehavior.ViewportRelative, null, null, _image, null);
        }
    }
}
