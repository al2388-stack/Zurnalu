
// 1. ILogger interfeiss
public interface ILogger
{
    void Log(string message);
}

// 2. ILogReader interfeiss
public interface ILogReader
{
    List<string> GetMessages();
}

// 3. ConsoleLogger klase
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("[LOG] " + message);
    }
}

// 4. MemoryLogger klase
public class MemoryLogger : ILogger, ILogReader
{
    private readonly List<string> _messages = new List<string>();

    public void Log(string message)
    {
        _messages.Add(message);
    }

    public List<string> GetMessages()
    {
        return _messages;
    }
}

// 5. Calculator klase
public class Calculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        int result = a + b;
        _logger.Log($"{a} + {b} = {result}");
        return result;
    }
}

// Paskaidrojumi un teorētiskās atbildes:
/*
// Paskaidrojums:
// (a) Kāpēc Calculator balstās uz ILogger, nevis uz ConsoleLogger un kurš princips to prasa:
// Calculator balstās uz interfeisu ILogger (abstrakciju), nevis uz konkrētu klasi ConsoleLogger, lai nodrošinātu elastību un atslāņotu kodu (loģiskā atsaistīšana jeb "loose coupling"). Tas ļauj Calculator darboties ar jebkuru žurnālotāju (piemēram, MemoryLogger vai failu žurnālistu), nemainot pašas Calculator klases kodu. To pieprasa SOLID D princips – **Dependency Inversion Principle (Atkarību apvērsuma princips)**, kas nosaka, ka augstāka līmeņa moduļiem nav jābūt atkarīgiem no zemāka līmeņa moduļiem, bet gan abiem jābūt atkarīgiem no abstrakcijām.

// (b) Kāpēc lasīšana ir atsevišķā interfeisā ILogReader un kurš princips to prasa:
// Lasīšanas metode (GetMessages) ir atdalīta interfeisā ILogReader, jo ConsoleLogger veic tikai rakstīšanu un tam nav vajadzīga ziņu saglabāšana vai lasīšana atmiņā. Ja GetMessages būtu iekļauts iekš ILogger, ConsoleLogger būtu spiests implementēt nevajadzīgu metodi (tukšu vai ar kļūdas paziņojumu). To pieprasa SOLID I princips – **Interface Segregation Principle (Interfeisu segregācijas princips)**, kas nosaka, ka klientam (klasei) nedrīkst uzspiest metodiku, ko tas neizmanto; labāk veidot vairākus mazus, specifiskus interfeisus nekā vienu vispārīgu.
*/