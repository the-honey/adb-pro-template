namespace api.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;

        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}