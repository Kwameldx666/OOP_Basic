using Animal_;
using Food_;
using Plants_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Omnivore_
{
    // Class for omnivorous animals
    public class Omnivore : Animal
    {
        public Omnivore(string name, decimal weight, Size size, decimal speed)
            : base(name, weight, size, speed) { }

        public override double Energy()
        {
            if (Stomach.Count == 0)
                return 0.0;

            double totalEnergy = 0;
            double averageWeightFood = 0;
            double weightCoef = 0.5; // default for Omnivore

            foreach (var food in Stomach)
            {
                totalEnergy += (double)food.Energy;
                averageWeightFood += (double)food.Weight;
                if (food is Plants)
                    weightCoef = 0.5;
                else
                    weightCoef = -0.5;
            }

            return 0.35 + weightCoef * (averageWeightFood / Stomach.Count) + totalEnergy;
        }

        public override void Eat(Food food, int count)
        {
            if (food.Weight <= Weight / 8)
            {
                for (int i = 0; i < count; i++)
                {
                    Stomach.Add(food);
                }
                Console.WriteLine($"\tType: {GetType().Name}\n{Name} eats {food}\n" + new string('_', 30));
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
                Stomach.Add(food);
                Console.WriteLine($"\tType: {GetType().Name}\n{Name} eats {food}\n" + new string('_', 30));
            }
            else
            {
                Console.Write("\r\nAn animal can't eat that much\n" + new string('_', 30) + "\n");
            }
        }
    }

}
