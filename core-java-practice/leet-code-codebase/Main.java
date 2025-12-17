// Class named computer that demonstrates method overloading
class computer {

    // Method to add two integers
    public int add(int n1, int n2) {
        return n1 + n2; // Returns the sum of two numbers
    }

    // Overloaded method to add three integers
    public int add(int n1, int n2, int n3) {
        return n1 + n2 + n3; // Returns the sum of three numbers
    }
}

// Main class
public class method_overloading {

    // Main method: entry point of the program
    public static void main(String[] args) {

        // Creating an object of the computer class
        computer obj = new computer();

        // Calling the add method with two arguments
        int result = obj.add(3, 8);

        // Printing the result to the console
        System.out.println(result);
    }
}
