public class Obliczenia
{
    private double bokA;
    private double bokB;

    public static Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>
    {
        ['A'] = 1189,
        ['B'] = 1414,
        ['C'] = 1297
    };

    public Obliczenia(double bokA, double bokB)
    {
        BokA = bokA;
        BokB = bokB;
    }

    public double BokA
    {
        get { return bokA; }
        set
        {
            if (WalidacjaDlugosci(value))
                bokA = value;
            else
                throw new ArgumentException("Długość boku A musi być skończoną nieujemną liczbą.");
        }
    }

    public double BokB
    {
        get { return bokB; }
        set
        {
            if (WalidacjaDlugosci(value))
                bokB = value;
            else
                throw new ArgumentException("Długość boku B musi być skończoną nieujemną liczbą.");
        }
    }

    private bool WalidacjaDlugosci(double length)
    {
        return !double.IsNaN(length) && !double.IsInfinity(length) && length >= 0;
    }

    public static Obliczenia ArkuszPapieru(string format)
    {
        if (format.Length != 2)
            throw new ArgumentException("Nieprawidłowy format arkusza papieru.");

        char szereg = format[0];
        char indeksChar = format[1];
        if (!byte.TryParse(indeksChar.ToString(), out byte indeks))
            throw new ArgumentException("Nieprawidłowy format arkusza papieru.");

        decimal wysokośćBazowa;
        if (!wysokośćArkusza0.TryGetValue(szereg, out wysokośćBazowa))
            throw new ArgumentException("Nieprawidłowy format arkusza papieru.");

        double pierwiastekZDwóch = Math.Sqrt(2);

        double bokA = (double)(wysokośćBazowa / (decimal)Math.Pow(pierwiastekZDwóch, indeks));
        double bokB = bokA / pierwiastekZDwóch;

        return new Obliczenia(bokA, bokB);
    }

}
