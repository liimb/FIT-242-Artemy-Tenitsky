namespace Lab.StoreTask;

public class ProductMovement(int productId, int providerId, int quantity, bool isIncoming, decimal price, string date)
{
    public int ProductId { get; set; } = productId;
    public int ProviderId { get; set; } = providerId;
    public int Quantity { get; set; } = quantity;
    public bool IsIncoming { get; set; } = isIncoming;
    public decimal PricePerUnit { get; set; } = price;
    public string Date { get; set; } = date;
}
