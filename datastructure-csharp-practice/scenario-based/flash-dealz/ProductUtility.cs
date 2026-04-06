namespace FlashDealz;

public class ProductUtility : IProductSorter
{
    public void SortProducts(Product[] products, int count)
    {
        QuickSort(products, 0, count - 1);
    }

    private void QuickSort(Product[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    private int Partition(Product[] arr, int low, int high)
    {
        int pivot = arr[high].Discount;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j].Discount > pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    private void Swap(Product[] arr, int i, int j)
    {
        Product temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
