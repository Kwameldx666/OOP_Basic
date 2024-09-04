# OOP_Basic

Этот проект демонстрирует базовые принципы объектно-ориентированного программирования (ООП) на языке C#. В проекте реализованы классы, представляющие животных и их взаимодействие с различными типами пищи.

## Структура проекта

Проект включает следующие файлы:

- **Animal.cs**: Основной абстрактный класс `Animal`, представляющий общие свойства и методы для всех животных.
- **Carnivore.cs**: Класс `Carnivore`, представляющий плотоядных животных, наследуется от `Animal`.
- **Herbivore.cs**: Класс `Herbivore`, представляющий травоядных животных, наследуется от `Animal`.
- **Omnivore.cs**: Класс `Omnivore`, представляющий всеядных животных, наследуется от `Animal`.
- **Meat.cs**: Класс `Meat`, представляющий мясо как тип пищи.
- **Plants.cs**: Класс `Plants`, представляющий растения как тип пищи.
- **TypeAnimal.cs**: Перечисление `TypeAnimal`, представляющее типы животных.
- **Program.cs**: Основной файл программы, содержащий примеры использования классов и методы для создания и взаимодействия объектов.

## Основные классы и методы

### Animal
- **Свойства**:
  - `string Name` - Имя животного.
  - `decimal Weight` - Вес животного.
  - `Size Size` - Размер животного.
  - `decimal Speed` - Скорость животного.
  - `List<Food> Stomach` - Список еды, съеденной животным.
  
- **Методы**:
  - `Eat(Food food, decimal amount)` - Метод для потребления еды.
  - `Run(decimal distance)` - Метод для симуляции бега на определенное расстояние.

### Carnivore
Класс `Carnivore` наследуется от `Animal` и представляет плотоядных животных.

### Herbivore
Класс `Herbivore` наследуется от `Animal` и представляет травоядных животных.

### Omnivore
Класс `Omnivore` наследуется от `Animal` и представляет всеядных животных.

### Meat и Plants
Классы `Meat` и `Plants` представляют мясо и растения соответственно, как типы пищи.

## Использование

Пример использования классов и методов:

```csharp
public static void Main()
{
    Size size = new Size(1.2m, 0.6m, 0.8m);
    Carnivore wolf = new Carnivore("Wolf", 30, size, 10);
    Herbivore sheep = new Herbivore("Sheep", 100, size, 10);
    Omnivore bear = new Omnivore("Bear", 150, size, 10);
    Plants salad = new Plants(1, 100);
    Meat ham = new Meat(0.5m, 250);

    // Животные едят пищу
    wolf.Eat(ham, 2);
    sheep.Eat(salad, 3);
    bear.Eat(ham, 1);
    bear.Eat(salad, 3);

    // Животные бегут
    wolf.Run(200);
    sheep.Run(200);
    bear.Run(200);

    // Вывод общего количества животных
    Console.Write($"Total animals number are: {Animal.Number}\n" + new string('_', 30) + "\n");

    // Тест на некорректный тип животного в конструкторе Herbivore
    Console.WriteLine(new Herbivore("Wolf", 15, size, 4));
}
