namespace ParcelTracker.Node
{
    public class ParcelNode
    {
        // Represents a delivery stage
        public string Stage { get; }

        // Points to the next stage in the chain
        public ParcelNode? Next { get; set; }

        public ParcelNode(string stage)
        {
            Stage = stage;
            Next = null;
        }
    }
}
