using System;

class MultiTableSixToNine{
    static void Main(){
        Console.Write("Enter a number:");
        int num=Convert.ToInt32(Console.ReadLine()); //take inpt frm user
        int[] multiResult=new int[4]; 

        for(int i=6;i<=9;i++){
            multiResult[i-6]=num*i;//store the mltiplies
        }

        Console.WriteLine("Multiplication Table of "+num+" from 6 to 9:");
        for(int i=6;i<=9;i++){
            Console.WriteLine(num+" * "+i+" = "+multiResult[i-6]);
        }
    }
}
