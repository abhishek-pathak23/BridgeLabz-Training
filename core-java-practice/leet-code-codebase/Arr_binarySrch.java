public class Arr_binarySrch {
    // Binary search function
    public static int bin_search(int arr[], int key){
        int start = 0, end = arr.length - 1;

        while(start <= end){
            int mid = (start + end) / 2;
            if(arr[mid] == key){ // key found
                return mid;
            }
            if(arr[mid] < key){ // search right half
                start = mid + 1;
            }
            else{  // search left half
                end = mid - 1;
            }
        }
        return -1; // key not found
    }

    public static void main(String[] args) {
        int arr[] = {5, 8, 16, 19, 25, 60};
        bin_search(arr, 4); // search for 4 (not used)
        System.out.println(bin_search(arr, 8)); // search for 8 and print index
    }    
}
