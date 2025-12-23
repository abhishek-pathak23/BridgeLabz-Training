using System;

class MultiplicationTableNum{
    static void Main(){
        Console.Write("Enter a number: ");
        int number=Convert.ToInt32(Console.ReadLine()); //take input from user 

        int[] table=new int[10]; //store the results

        for(int i=1;i<=10;i++){
            table[i-1]=number*i; //calculate the  multiplication
        }

        Console.WriteLine("Multiplication Table of "+number+":");
        for(int i=1;i<=10;i++){
            Console.WriteLine(number+" * "+i+" = "+table[i-1]);        }
    }
}
