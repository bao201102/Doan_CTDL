namespace baithi
{
    public class Transport
    {
        private string id;
        private string name;
        private float price;
        public string getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public float getPrice()
        {
            return price;
        }
        public Transport(string id, string name, float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
