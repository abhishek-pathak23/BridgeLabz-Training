namespace FlashDealz;

public class Product
{
    public int Id { get; private set; }
    public int Discount { get; private set; }

    public Product(int id, int discount)
    {
        Id = id;
        Discount = discount;
    }
}
