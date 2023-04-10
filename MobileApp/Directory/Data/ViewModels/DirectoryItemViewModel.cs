using System.Collections.ObjectModel;

namespace TreeView
{
    /// <summary>
    /// A view model for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
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

    }
}
