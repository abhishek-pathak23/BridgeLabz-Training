public class decimal_binary {

    // convert decimal to binary
    public static int decTobin(int decNum){
        int binNum = 0;
        int pow = 0;
        while(decNum > 0){
            int rem = decNum % 2; // get remainder
            decNum /= 2;           // divide by 2
            binNum = binNum + rem * (int)Math.pow(10, pow); // add to binary number
            pow++;         
        }
        return binNum; // return binary
    }

    public static void main(String[] args) {
        System.out.println("binary is: " + decTobin(15)); // print binary of 15
    }
}
