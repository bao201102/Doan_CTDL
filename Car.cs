namespace baithi {
    public class Car {
        private string id;
        private string name;
        private float speed;
        private float price;
        public string getId() {
            return id;
        }
        public string getName() {
            return name;
        }
        public float getSpeed() {
            return speed;
        }
        public float getPrice() {
            return price;
        }
        public Car(string id, string name, float speed, float price) {
            this.id = id;
            this.name = name;
            this.speed = speed;
            this.price = price;
        }
    }
}
