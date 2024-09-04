using Animal_;
using Food_;
using Meat_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Carnivore_
{
    public class Carnivore : Animal
    {
        public Carnivore(string name, decimal weight, Size size, decimal speed)
            : base(name, weight, size, speed) { }

        public override double Energy()
        {
            if (Stomach.Count == 0)
                return 0.0;

            double totalEnergy = 0;
            double totalWeight = 0;

            foreach (var food in Stomach)
            {
                totalWeight += (double)food.Weight;
                totalEnergy += (double)food.Energy;
            }

            return 0.2 - 1.0 / 5 * (totalWeight / Stomach.Count) + totalEnergy;
        }

        public override void Eat(Food food, int count)
        {
            if (food.Weight <= Weight / 8)
            {
                if (food is Meat)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Stomach.Add(food);
                    }
                    Console.WriteLine($"\tType: {GetType().Name}\n{Name} eats {food}\n" + new string('_', 30));
                }
                else
                {
                    Console.Write("This animal eats only meat");
                }
            }
            else
            {
                Console.Write("\r\nAn animal can't eat that much\n" + new string('_', 30) + "\n");
            }
        }

        public override void Eat(Food food)
        {
            if (food.Weight <= Weight / 8)
            {
                if (food is Meat)
                {
                    Stomach.Add(food);
                    Console.WriteLine($"\tType: {GetType().Name}\n{Name} eats {food}\n" + new string('_', 30));
                }
                else
                {
                    Console.Write("This animal eats only meat");
                }
            }
            else
            {
                Console.Write("\r\nAn animal can't eat that much\n" + new string('_', 30) + "\n");
            }
        }
    }

}
