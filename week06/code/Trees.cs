public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: when first exceeds last, we've processed all elements in this range
        if (first > last)
        {
            return;
        }

        // Calculate the middle index
        int mid = (first + last) / 2;

        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[mid]);

        // Recursively process the left half (elements before middle)
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively process the right half (elements after middle)
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}