using Food_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_
{

    // Abstract base class for animals
    public abstract class Animal
    {


        public static int Number { get; private set; } // Total number of animals created
        public string Name { get; set; }
        protected decimal Weight { get; }
        protected Size AnimalSize { get; }
        protected decimal Speed { get; }
        public List<Food> Stomach { get; } // List of food items in the animal's stomach

        // Structure to represent the size of an animal
        public struct Size
        {
            public decimal Length { get; }
            public decimal Width { get; }
            public decimal Height { get; }

            public Size(decimal length, decimal width, decimal height)
            {
                Length = length;
                Width = width;
                Height = height;
            }

            public override string ToString()
            {
                return $"Length: {Length}, Width: {Width}, Height: {Height}";
            }
        }


        protected Animal(string name, decimal weight, Size size, decimal speed)
        {
            Name = name;
            Weight = weight;
            AnimalSize = size;
            Speed = speed;
            Stomach = new List<Food>();
            Number++;
        }

        public override string ToString()
        {
            return $"Animal type: {GetType().Name}\n" +
                   $"Name: {Name}\n" +
                   $"Weight: {Weight} kg\n" +
                   $"Size: {AnimalSize}\n" +
                   $"Speed: {Speed} m/s\n" + new string('_', 30);
        }

        // Abstract methods to be implemented by derived classes
        public abstract void Eat(Food food, int count);
        public abstract void Eat(Food food);

        // Method to simulate running
        public void Run(decimal distance)
        {
            double energy = Energy();
            if (energy <= 0)
            {
                Console.Write("Need more energy to run an animal\n" + new string('_', 30));
            }
            else
            {
                double time = (double)(distance / (Speed / (decimal)energy));
                Console.WriteLine(
                    $"Run: {Name}\n" +
                    $"Distance: {distance}\n" +
                    $"It takes: {time} seconds\n" + new string('_', 30));
            }
        }

        // Abstract method to get the energy level
        public abstract double Energy();
    }

}
