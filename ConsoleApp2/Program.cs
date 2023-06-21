using System;
using System.Collections.Generic;

// Основной абстрактный класс пиццы
public abstract class Pizza
{
    public string Size { get; protected set; }
    public string Sauce { get; protected set; }
    public string Cheese { get; protected set; }
    public List<string> AdditionalIngredients { get; protected set; }

    public Pizza(string size, string sauce, string cheese, List<string> additionalIngredients)
    {
        Size = size;
        Sauce = sauce;
        Cheese = cheese;
        AdditionalIngredients = additionalIngredients;
    }

    public abstract decimal CalculatePrice();

    public override string ToString()
    {
        string pizzaDescription = $"Size: {Size}\nSauce: {Sauce}\nCheese: {Cheese}\nAdditional Ingredients:";
        foreach (string ingredient in AdditionalIngredients)
        {
            pizzaDescription += $"\n- {ingredient}";
        }
        return pizzaDescription;
    }
}

// Конкретная пицца итальянского стиля
public class ItalianPizza : Pizza
{
    public ItalianPizza(string size, string sauce, string cheese, List<string> additionalIngredients)
        : base(size, sauce, cheese, additionalIngredients)
    {
    }

    public override decimal CalculatePrice()
    {
        decimal basePrice = 10m; // Базовая цена для итальянской пиццы
        decimal ingredientPrice = 0;
        foreach (string ingredient in AdditionalIngredients)
        {
            ingredientPrice += GetIngredientPrice(ingredient);
        }
        return basePrice + ingredientPrice;
    }

    private decimal GetIngredientPrice(string ingredient)
    {
        decimal ingredientPrice = 0;
        switch (ingredient)
        {
            case "bacon":
                ingredientPrice = 2.5m;
                break;
            case "salami":
                ingredientPrice = 1.8m;
                break;
            case "mushrooms":
                ingredientPrice = 1.2m;
                break;
            case "olives":
                ingredientPrice = 0.8m;
                break;
                // Добавьте остальные ингредиенты и их стоимость
        }
        return ingredientPrice;
    }
}

// Конкретная пицца сицилийского стиля
public class SicilianPizza : Pizza
{
    public SicilianPizza(string size, string sauce, string cheese, List<string> additionalIngredients)
        : base(size, sauce, cheese, additionalIngredients)
    {
    }

    public override decimal CalculatePrice()
    {
        decimal basePrice = 12m; // Базовая цена для сицилийской пиццы
        decimal ingredientPrice = 0;
        foreach (string ingredient in AdditionalIngredients)
        {
            ingredientPrice += GetIngredientPrice(ingredient);
        }
        return basePrice + ingredientPrice;
    }

    private decimal GetIngredientPrice(string ingredient)
    {
        decimal ingredientPrice = 0;
        switch (ingredient)
        {
            case "pepperoni":
                ingredientPrice = 2.2m;
                break;
            case "ham":
                ingredientPrice = 1.5m;
                break;
            case "onions":
                ingredientPrice = 0.9m;
                break;
            case "bell peppers":
                ingredientPrice = 1.1m;
                break;
                // Добавьте остальные ингредиенты и их стоимость
        }
        return ingredientPrice;
    }
}

// Фабрика для создания основных составляющих пиццы
public abstract class PizzaFactory
{
    public abstract Pizza CreatePizza(string size, List<string> additionalIngredients);
}

// Конкретная фабрика для итальянской пиццы
public class ItalianPizzaFactory : PizzaFactory
{
    public override Pizza CreatePizza(string size, List<string> additionalIngredients)
    {
        string sauce = "tomato";
        string cheese = "Mozzarella";
        return new ItalianPizza(size, sauce, cheese, additionalIngredients);
    }
}

// Конкретная фабрика для сицилийской пиццы
public class SicilianPizzaFactory : PizzaFactory
{
    public override Pizza CreatePizza(string size, List<string> additionalIngredients)
    {
        string sauce = "barbecue";
        string cheese = "Ricotta";
        return new SicilianPizza(size, sauce, cheese, additionalIngredients);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Создание пиццы с помощью фабрики
        PizzaFactory factory = new ItalianPizzaFactory();
        List<string> ingredients = new List<string> { "bacon", "mushrooms", "olives" };
        Pizza pizza = factory.CreatePizza("standard", ingredients);

        // Подсчет стоимости и вывод описания
        decimal price = pizza.CalculatePrice();
        string description = pizza.ToString();

        Console.WriteLine(description);
        Console.WriteLine($"Price: {price}");

        // Создание пиццы другого региона
        factory = new SicilianPizzaFactory();
        ingredients = new List<string> { "pepperoni", "ham", "onions" };
        pizza = factory.CreatePizza("XXL", ingredients);

        price = pizza.CalculatePrice();
        description = pizza.ToString();

        Console.WriteLine(description);
        Console.WriteLine($"Price: {price}");

        Console.ReadLine();
    }
}
