using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(3, 5) will result in: {3, 6, 9, 12, 15}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step Plan:
        // 1. Create an array of doubles with a size equal to 'length'.
        // 2. Loop through each index of the array from 0 to length - 1.
        // 3. For each index i, calculate number * (i + 1) to get the ith multiple.
        // 4. Assign this value to the current index of the array.
        // 5. After filling all values, return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotates the 'data' list to the right by 'amount' positions.
    /// For example: {1,2,3,4,5,6,7,8,9} rotated by 3 becomes {7,8,9,1,2,3,4,5,6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step Plan:
        // 1. Determine the number of elements in the list (use data.Count).
        // 2. Get the last 'amount' elements using GetRange(count - amount, amount).
        // 3. Remove those elements from the end using RemoveRange.
        // 4. Insert those elements at the start of the list using InsertRange(0, ...).
        // 5. The list will now be rotated to the right by 'amount'.

        int count = data.Count;

        List<int> tail = data.GetRange(count - amount, amount);
        data.RemoveRange(count - amount, amount);
        data.InsertRange(0, tail);
    }
}
