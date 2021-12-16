public class Map
{
    private float x;
    private float y;
    private string name;
    private int id;
    private string city;
    private string district;
    public float getX()
    {
        return x;
    }
    public float getY()
    {
        return y;
    }
    public string getName()
    {
        return name;
    }
    public int getId()
    {
        return id;
    }
    public string getCity()
    {
        return city;
    }
    public string getDistrict()
    {
        return district;
    }
    public Map(float x, float y, string name, int id, string district, string city)
    {
        this.x = x;
        this.y = y;
        this.name = name;
        this.id = id;
        this.city = city;
        this.district = district;
    }
    public override string ToString()
    {
        return name + " ((" + x + "; " + y + "), " + district + ", " + city + ")";
    }
}