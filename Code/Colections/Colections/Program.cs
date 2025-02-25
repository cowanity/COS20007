internal class Program
{
    private static void Main(string[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        Solution solution = new();


        if (solution.TwoSum(nums, target).Length == 2)
        {
            Console.WriteLine($"Indices of the two numbers: {((int[]?)solution.TwoSum(nums, target))[0]}, {((int[]?)solution.TwoSum(nums, target))[1]}"); // Output: "Indices of the two numbers: 0, 1"
        }
        else
        {
            Console.WriteLine("No solution found.");
        }
    }
}

internal class Solution
{
    internal int[] TwoSum(int[] nums, int target)
    {
        throw new NotImplementedException();
    }
}