using Animal_;
using Carnivor
using Herbivore_;
using Meat_;
using Omnivore_;
using Plants_;
using System;
using System.Collections.Generic;
using TypeAnimal_;
using static Animal_.Animal;

public class Program
{

    public static void Main()
    {
        // Example data: size and animal instances
        Size size = new Size(1.2m, 0.6m, 0.8m);
        Carnivore wolf = new Carnivore("Wolf", 30, size, 10);
        Herbivore sheep = new Herbivore("Sheep", 100, size, 10);
        Omnivore bear = new Omnivore("Bear", 150, size, 10);
        Plants salad = new Plants(1, 100);
        Meat ham = new Meat(0.5m, 250);

        // Animals eating food
        wolf.Eat(ham, 2);
        sheep.Eat(salad, 3);
        bear.Eat(ham, 1);
        bear.Eat(salad, 3);

        // Animals running
        wolf.Run(200);
        sheep.Run(200);
        bear.Run(200);

        // Display total number of animals
        Console.Write($"Total animals number are: {Animal.Number}\n" + new string('_', 30) + "\n");

        // Test for incorrect animal type in Herbivore constructor
        Console.WriteLine(new Herbivore("Wolf", 15, size, 4));

        Random random = new Random();
        List<Animal> animals = new List<Animal>();

        // Generate random animals
        for (int i = 0; i < 10; i++)
        {
            TypeAnimal type = (TypeAnimal)random.Next(Enum.GetValues(typeof(TypeAnimal)).Length);
            decimal weight = (decimal)(random.NextDouble() * 100 + 1);
            Size size_ = new Size((decimal)(random.NextDouble() * 2 + 0.5), (decimal)(random.NextDouble() * 2 + 0.5), (decimal)(random.NextDouble() * 2 + 0.5));
            decimal speed = (decimal)(random.NextDouble() * 20 + 1);
            Animal animal = CreateAnimal(type, $"Animal number {i + 1}", weight, size_, speed);
            animals.Add(animal);
        }

        // Feed animals with random food
        foreach (var animal in animals)
        {
            if (animal is Carnivore)
            {
                Meat meat = new Meat((decimal)(random.NextDouble() * 5 + 0.1), (decimal)(random.NextDouble() * 0.05));
                animal.Eat(meat);
            }
            else if (animal is Herbivore)
            {
                Plants plants = new Plants((decimal)(random.NextDouble() * 5 + 0.1), (decimal)(random.NextDouble() * 0.05));
                animal.Eat(plants);
            }
            else if (animal is Omnivore)
            {
                if (random.Next(2) == 0)
                {
                    Meat meat = new Meat((decimal)(random.NextDouble() * 5 + 0.1), (decimal)(random.NextDouble() * 0.05));
                    animal.Eat(meat);
                }
                else
                {
                    Plants plants = new Plants((decimal)(random.NextDouble() * 5 + 0.1), (decimal)(random.NextDouble() * 0.05));
                    animal.Eat(plants);
                }
            }
        }

        // Count animals that eat food, meat, and plants
        int animalsEatFood = 0;
        int animalsEatMeat = 0;
        int animalsEatPlants = 0;

        foreach (var animal in animals)
        {
            if (animal.Stomach.Count > 0)
            {
                animalsEatFood++;
                foreach (var food in animal.Stomach)
                {
                    if (food is Meat)
                    {
                        animalsEatMeat++;
                    }
                    else if (food is Plants)
                    {
                        animalsEatPlants++;
                    }
                }
            }
        }

        // Display results
        Console.WriteLine($"Animals eat food: {animalsEatFood}");
        Console.WriteLine($"Animals eat meat: {animalsEatMeat}");
        Console.WriteLine($"Animals eat plants: {animalsEatPlants}\n" + new string('_', 30));

        // Print details of all animals
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
            Console.WriteLine();
        }
    }

    // Factory method to create an animal based on type
    public static Animal CreateAnimal(TypeAnimal type, string name, decimal weight, Size size, decimal speed)
    {
        return type switch
        {
            TypeAnimal.Wolf => new Carnivore(name, weight, size, speed),
            TypeAnimal.Bear => new Omnivore(name, weight, size, speed),
            TypeAnimal.Sheep => new Herbivore(name, weight, size, speed),
            TypeAnimal.Squirrel => new Herbivore(name, weight, size, speed),
            TypeAnimal.Cat => new Carnivore(name, weight, size, speed),
            TypeAnimal.Cow => new Herbivore(name, weight, size, speed),
            _ => throw new ArgumentException("Such an animal does not exist for us...")
        };
    }
}








