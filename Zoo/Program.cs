var zoo = new Zoo.Zoo();

for (int day = 1; day <= 100; day++)
{
    zoo.SimulateHunger();
    zoo.SimulateFeeding();

    int count = zoo.GetAliveAnimalsCount();
    Console.WriteLine($"Day {day}: {count} animals still alive.");
}

Console.ReadLine();