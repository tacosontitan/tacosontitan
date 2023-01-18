namespace Sandbox.Modules;

/// <summary>
/// Represents the Hamming distance (the number of differences between two values).
/// </summary>
internal sealed class HammingDistance : Module
{
    public HammingDistance() :
        base("hamming", "Hamming Distance", "Calculates the number of different bits between two integers.")
    { }
    protected override async Task Work()
    {
        if (!TryRequestInput("Please supply a 32-bit integer value for x: ", out int x))
            return;
        if (!TryRequestInput("Please supply a 32-bit integer value for y: ", out int y))
            return;

        await CalculateHammingDistance(x, y);
    }
    /// <summary>
    /// Calculate Hamming distance between two specified integers by applying an exclusive logical OR and counting the bits that were different.
    /// </summary>
    /// <param name="x">The left operand.</param>
    /// <param name="y">The right operand.</param>
    private async Task CalculateHammingDistance(int x, int y)
    {
        // The exclusive logical OR will return true only if one operand is true while the other is not.
        //      true  ^ false = true
        //      false ^ true  = true
        //      true  ^ true  = false
        //      false & false = false
        // To see this impact, let's say x = 1 and y = 4:
        //        0001
        //      ^ 0100
        //      ------
        //        0101
        int xor = x ^ y;
        int bitCount = CountBits(xor);
        await WriteSuccess($"The Hamming distance for {x} and {y} is {bitCount}.");
    }
    /// <summary>
    /// Count the number of bits in a specified integer value by repeatedly removing the rightmost bits until none remain.
    /// </summary>
    /// <param name="value">The value to count bits in.</param>
    /// <returns>Returns the number of set bits in the specified value.</returns>
    private int CountBits(int value)
    {
        int count = 0;
        while (value != 0)
        {
            // Here, we take advantage of the binary properties of value - 1.
            // Let's say that value = 23 (00010111).
            // value - 1 will flip the rightmost bit 22 = 00010110.
            //                                       21 = 00010101.
            //                                       20 = 00010100.
            // At this point, you can likely see where the AND operator fits in.
            // By applying the bitwise AND operator, the bits that aren't present in both operands are removed.
            // So let's remove bits until we get to zero, starting with a value of 23:
            //      00010111 & 00010110 = 00010110 :: 23 & 22 = 22
            //      00010110 & 00010101 = 00010100 :: 22 & 21 = 20
            //      00010100 & 00010011 = 00010000 :: 20 & 19 = 16
            //      00010000 & 00001111 = 00000000 :: 16 & 15 =  0
            // This process applies this in a condensed form of value &= value - 1 while counting the number of passes required to reach zero.
            value &= value - 1;
            count++;
        }

        return count;
    }
}