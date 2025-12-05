namespace HomeWork.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string>Ingredients { get; set; }
    public double Price { get; set; }
}