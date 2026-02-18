public class Pair<K, V>
{
    private K key;
    private V value;

    public K Key
    {
        get { return key; }
        set { key = value; }
    }

    public V Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public Pair(K key, V value)
    {
        this.key = key;
        this.value = value;
    }

    public override string ToString()
    {
        return $"Key: {key}, Value: {value}";
    }
}
