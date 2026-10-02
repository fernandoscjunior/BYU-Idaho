public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        //First things first lets make the array we will return
        var result = new double[length];

        //Second lets make a for loop to append the multiples to our array, it will iterate "length" number of times 
        // (it is the same size of the array and the length user has determined)
        for (int i = 1; i <= length; i++)
        {
            result[i-1] = i * number; 

            ///To add the multiplied number to the right index in 'result' we remove 1 so if i=1 index=0. We cant start i at 0 because it will give us one more result (being zero) and that would be more than the array accepts
        }
        
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// data    {1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// new_data{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //First thing: simplify "data"s size. and create the new list that will be assimiliated to "data".
        int size = data.Count;
        List<int> new_data = new();

        //Second: Slice the "data" List into two separate Lists, then remove all that was added in the first slide so we can easily just switch places and have the final result.
        var sliceOne = data.GetRange(0, size - amount);
		data.RemoveRange(0, size - amount);
        var sliceTwo = data.GetRange(0, amount);

        //Adding slices to a new list
		new_data.AddRange(sliceTwo);
		new_data.AddRange(sliceOne);

        data.Clear();
        data.AddRange(new_data);
    }
    // After finishing the assigment I saw this solution tothe fact that if you have an amount bigger than size it gives an error:
    //Just add this before slicing:   amount %= size;
}
