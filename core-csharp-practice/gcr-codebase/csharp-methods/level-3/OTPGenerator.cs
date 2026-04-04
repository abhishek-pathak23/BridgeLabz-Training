using System;

class OTPGenerator
{
    // Generate single 6-digit OTP
    public static int GenerateOTP()
    {
        Random rand = new Random();
        return rand.Next(100000, 1000000);
    }

    // Check uniqueness in array
    public static bool AreUnique(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (array[i] == array[j]) return false;
        return true;
    }

    static void Main()
    {
        int[] otps = new int[10];
        for (int i = 0; i < 10; i++) otps[i] = GenerateOTP();

        Console.WriteLine("Generated OTPs: " + string.Join(", ", otps));
        Console.WriteLine("All OTPs Unique: " + AreUnique(otps));
    }
}
