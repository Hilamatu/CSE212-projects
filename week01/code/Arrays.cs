public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    /// Declare a fixed array to store the results
    /// For loop that will run for the length of the array
    /// For each iteration it will multiply the nummber by index+1
    /// Return the array
    public static double[] MultiplesOf(double number = 7, int length = 7)
    {
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    /// Create the list of numbers to be rotated
    /// Use a loop to iterate through the list using the amount to determine where to start
    /// remove the numbers to the right of the amount and store them in a temorary list
    /// add the temporary list to the front of the original list
    public static List<int> data = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static void RotateListRight(List<int> data, int amount = 5)
    {
            List<int> temp = data.GetRange(data.Count - amount, amount);
            data.RemoveRange(data.Count - amount, amount);
            data.InsertRange(0, temp);

    }
}
