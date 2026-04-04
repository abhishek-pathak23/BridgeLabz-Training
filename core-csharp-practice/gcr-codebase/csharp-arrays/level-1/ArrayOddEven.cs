using System;

class ArrayOddEven{
    static void Main() {
        // Ask user to enter a natural number
        Console.Write("Enter a natural number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if(number < 1) {
            Console.WriteLine("Error: Not a natural number");
            return; // Exit the program if invalid
        }

        // Creating arrays to store odd and even numbers
        int[] odd = new int[number/2+1];  
        int[] even = new int[number/2+1]; 

        int oddIndex = 0, evenIndex = 0; 

        // Loop from 1 to number to separate odd and even numbers
        for(int i = 1; i <= number; i++){
            if(i % 2 == 0){
                even[evenIndex++] = i; 
            } else {
                odd[oddIndex++] = i; 
            }
        }

        // Display all odd numbers
        Console.WriteLine("Odd numbers:");
        for(int i = 0; i < oddIndex; i++){
            Console.Write(odd[i] + " ");
        }

        // Display all even numbers
        Console.WriteLine("\nEven numbers:");
        for(int i = 0; i < evenIndex; i++){
            Console.Write(even[i] + " ");
        }
    }
}
