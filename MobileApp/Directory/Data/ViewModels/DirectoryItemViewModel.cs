using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TreeView
{
    /// <summary>
    /// A view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ?  this.FullPath : DirectorySturcture.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A list of all childredn in this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if this item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } } 
        
        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If UI tells us to close
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// <paramref name="fullPath"/> The full path of this item
        /// <paramref name="type"/> The type of item
        /// </summary>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand= new RelayCommand(Expand);
            
            //Create commands
            this.ExpandCommand = new RelayCommand(Expand);

            //Set path and type
            this.FullPath= fullPath;
            this.Type = type;

            //Setup the children as needed
            this.ClearChildren();
        }

        #endregion

        #region Helper Method
        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear items
            this.Children =  new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand arrow if we are not a file
            if(this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion

        /// <summary>
        /// Expands this directory and finds all children
        /// </summary>
        private void Expand()
        {
            //We cannot expand a file
            if (this.Type == DirectoryItemType.File)
                return;

            // Find all children
            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectorySturcture.GetDirectoryContents(this.FullPath).
                               Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
 