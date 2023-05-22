using System.Windows;

namespace ChatApplication
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        private Window _window;

        #endregion

        #region Public Properties

        public string Test { get; set; } = "My string";


        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window) 
        {
            _window = window;
        }
        #endregion
    }
}
