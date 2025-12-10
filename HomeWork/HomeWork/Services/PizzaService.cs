using HomeWork.Helpers;
using HomeWork.Models;

namespace HomeWork.Services;

public class PizzaService
{
    private string path="Data/Products.json";
    private List<Product> _pizzas;

    public PizzaService()
    {
        _pizzas=JsonHelper<Product>.Read(path);
    }
}