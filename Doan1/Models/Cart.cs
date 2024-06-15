namespace Doan1.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Book product, int quantity)
        {
            CartLine? line = Lines.Where(p => p.Product.BookID == product.BookID).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Book product) => Lines.RemoveAll(l => l.Product.BookID == product.BookID);
        public decimal ComputeTotalValue() => Lines.Sum(e => (e.Product.Price - e.Product.PriceSale) * e.Quantity);
        public void Clear() => Lines.Clear();
        /*public void Update(int id, int quantity)
        {
            CartLine? line = Lines.Where(p => p.Product.BookID == id).FirstOrDefault();
            if (line != null)
            {
                line.Quantity = quantity;
            }
        }*/
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Book Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
