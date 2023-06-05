using System.Windows;
using System.Windows.Input;

namespace ChatApplication
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        private Window _Window;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int _OuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _WindowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the rezise border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMargineSize); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMargineSize
        {
            get 
            {
                return _Window.WindowState == WindowState.Minimized ? 0 : _OuterMarginSize;
            }
            set
            {
                _OuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMargineSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _Window.WindowState == WindowState.Maximized ? 0 : _WindowRadius;
            }
            set
            {
                _WindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title of bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title of bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        #endregion

        #region Command
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window) 
        {
            _Window = window;

            // Listen out for the window resizing
            _Window.StateChanged += (sender, e) =>
            {
               // Fire off events for all properties that are affected by resize
               OnPropertyChanged(nameof(ResizeBorderThickness));
               OnPropertyChanged(nameof(OuterMargineSize));
               OnPropertyChanged(nameof(OuterMarginSizeThickness));
               OnPropertyChanged(nameof(WindowRadius));
               OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }
        #endregion
    }
}
