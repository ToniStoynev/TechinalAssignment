using Zoo.Animals;

namespace Zoo;

public class Zoo
{
    private static readonly Random _random = new Random();
    private readonly List<Animal> _animals = new();
    public Zoo()
    {
        InitializeAnimals();
    }

    public void SimulateHunger()
    {
        foreach (var animal in _animals)
        {
            animal.HealthPoints -= _random.Next(0, 20);
            if (animal is Elephant elephant && !elephant.CanWalk)
            {
                animal.IsAlive = false;
            }
        }
    }

    public void SimulateFeeding()
    {
        int monkeyFood = _random.Next(5, 25);
        int lionFood = _random.Next(5, 25);
        int elephantFood = _random.Next(5, 25);

        foreach (var animal in _animals)
        {
            switch (animal)
            {
                case Monkey monkey:
                    monkey.HealthPoints += monkeyFood;
                    break;
                case Lion lion:
                    lion.HealthPoints += lionFood;
                    break;
                case Elephant elephant:
                    elephant.HealthPoints += elephantFood;
                    break;
            }
        }
    }

    public int GetAliveAnimalsCount()
        => _animals
            .Where(a => a.IsAlive)
            .Count();

    private void InitializeAnimals()
    {
        for (int i = 0; i < 5; i++)
        {
            _animals.Add(new Monkey());
            _animals.Add(new Lion());
            _animals.Add(new Elephant());
        }
    }
}
