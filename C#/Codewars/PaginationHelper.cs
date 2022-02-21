// https://www.codewars.com/kata/515bb423de843ea99400000a/train/csharp

namespace Codewars
{
    using System.Collections.Generic;

    public class PagnationHelper<T>
    {
        private IList<T> _items;
        private int _itemsPerPage;
        private int _pageCount;

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            _items = collection;
            _itemsPerPage = itemsPerPage;

            _pageCount = collection.Count / itemsPerPage;
            if (collection.Count % itemsPerPage > 0)
            {
                _pageCount++;
            }
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount => _items.Count;

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount => _pageCount;

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= _pageCount)
            {
                return -1;
            }

            // If we're on the last page, then page could have less than _pageCount items
            if (pageIndex == _pageCount - 1)
            {
                return _items.Count % _itemsPerPage;
            }

            return _itemsPerPage;
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= _items.Count)
            {
                return -1;
            }

            return itemIndex / _itemsPerPage;
        }
    }
}
