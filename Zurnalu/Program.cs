var calc1 = new  Calculator(new ConsoleLogger());

calc1.Add(2, 3);


var memory = new MemoryLogger();

var calc2 = new Calculator(memory);

calc2.Add(10, 5);

calc2.Add(1, 1);


foreach (string line in memory.GetMessages())

{

    Console.WriteLine(line);

}
