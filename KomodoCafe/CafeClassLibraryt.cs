using System;
using System.Collections.Generic;
using System.Linq;

namespace KomodoCafe
{
public class MenuItem
{
    public int MealID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public decimal Price { get; set; }

    public MenuItem(int mealID, string name, string description, string ingredients, decimal price)
    {
        MealID = mealID;
        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;
    }
}
}

