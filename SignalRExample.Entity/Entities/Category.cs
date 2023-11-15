namespace SignalRExample.Entity.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
