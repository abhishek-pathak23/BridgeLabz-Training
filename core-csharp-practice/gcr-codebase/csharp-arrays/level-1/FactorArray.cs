using System;

class FactorArray{
    static void Main() {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = new int[10]; //initialize the array
        int count = 0;

        for(int i = 1; i <= number; i++){
            if(number % i == 0){
                if(count == factors.Length){
                    int[] temp = new int[factors.Length * 2];
                    for(int j = 0; j < factors.Length; j++) temp[j] = factors[j];
                    factors = temp;
                }
                factors[count++] = i;//store the factor
            }
        }

        Console.WriteLine("Factors of " + number + ":");
        for(int i = 0; i < count; i++){
            Console.Write(factors[i] + " ");
        }
    }
}
