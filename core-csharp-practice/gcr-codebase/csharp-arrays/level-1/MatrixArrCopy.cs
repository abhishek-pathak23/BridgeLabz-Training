using System;

class MatrixArrCopy{
    static void Main() {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];//2D ar
        int[] array = new int[rows * cols];//1D arr to copy elements

        //taking the input  for matrix
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                Console.Write($"Enter element [{i},{j}]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        //copy to 1D arr
        int k = 0;
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                array[k++] = matrix[i, j];
            }
        }

        //print the  1D array
        Console.WriteLine("1D array elements:");
        for(int i = 0; i < array.Length; i++){
            Console.Write(array[i] + " ");
        }
    }
}
