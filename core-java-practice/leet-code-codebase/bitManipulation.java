import java.util.Scanner;

public class bitManipulation {

    // check if number is even or odd
    public static void evenOdd_byBit(int num){
        if((num & 1) == 0){
            System.out.print("Number is Even");
        }
        else{
            System.out.print("Number is Odd");
        }
    }

    // get ith bit of number
    public static int get_ithBit(int num, int i){
        if((num & 1 << i) == 0){
            return 0;
        }
        else{
            return 1;
        }
    }

    // set ith bit to 1
    public static int set_ithBit(int num, int i){
        return num | 1 << i;
    }

    // clear ith bit to 0
    public static int clear_ithBit(int num, int i){
        return num & ~(1 << i);
    }

    // update ith bit to newBit (0 or 1)
    public static int update_ithBit(int num, int i, int newBit){
        num = num & ~(1 << i); // clear ith bit first
        return num | (newBit << i); // then set new bit
    }

    public static void main(String args[]){
        Scanner sc = new Scanner(System.in);
        int num = sc.nextInt();
        // evenOdd_byBit(num);
        // System.out.println(get_ithBit(num, 3));
        // System.out.println(set_ithBit(num, 6)); 
        // System.out.println(clear_ithBit(num, 0));
        System.out.println(update_ithBit(10, 2, 1)); // change 2nd bit of 10 to 1
    }
}
