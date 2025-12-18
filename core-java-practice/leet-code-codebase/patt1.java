public class patt1 {
    public static void main(String args[])
    {
        for(int i = 1; i <= 5; i++) // rows
        {
            for(int j = 1; j <= i; j++) // columns in each row
            {
                System.out.print("*"); // print star
            }
            System.out.println(); // move to next line
        }
    }
}
