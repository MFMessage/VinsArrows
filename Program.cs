Arrow arrow = GetArrow();
Console.WriteLine($" That arrow costs {arrow.GetCost()} gold.");

Arrow GetArrow()
{
    ArrowHead arrowhead = SetHead();
    Fletching fletching = SetFletch();
    float shaft = SetShaft();

    return new Arrow(arrowhead, shaft, fletching);
}

float AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        Console.Write(text);
        if (float.TryParse(Console.ReadLine(), out float result) && min <= result && max >= result)
            return result;
        else continue;
    }
}

float SetShaft()
{
    float shaftLength = AskForNumberInRange("How long would you like the arrow shaft to be? (between 60 and 100 cm)", 60, 100);
    return shaftLength;
}

Fletching SetFletch()
{
    while (true)
    {
        Console.Write("Choose a fletching feather type (Plastic, Turkey, or Goose)");
        string fletchChoice = Console.ReadLine();

        if (fletchChoice != null)
            fletchChoice = fletchChoice.ToLower().Trim();

        if (fletchChoice == "plastic")
            return Fletching.Plastic;
        else if (fletchChoice == "turkey")
            return Fletching.Turkey;
        else if (fletchChoice == "goose")
            return Fletching.Goose;
        else
        {
            Console.WriteLine("Invalid choice, try again.");
            continue;
        }
    }
}

ArrowHead SetHead()
{
    while (true)
    {
        Console.Write("Choose an arrowhead type (Steel, Wood, or Obsidian)");
        string headChoice = Console.ReadLine();

            headChoice = headChoice.ToLower().Trim();
            return headChoice switch
            {
                "steel" => ArrowHead.Steel,
                "wood" => ArrowHead.Wood, // WTF IS HAPPENING HERE HOW DO I MAKE IT SO IT WILL ASK AGAIN IF THE CHOICE IS INVALID???
                "obsidian" => ArrowHead.Obsidian,
                _ => ArrowHead.invalid
            };
    }
}

class Arrow
{
    private ArrowHead _arrowhead;
    private float _shaft;
    private Fletching _fletching;

    public Arrow(ArrowHead arrowHead, float shaft, Fletching fletching)
    {
        _arrowhead = arrowHead;
        _fletching = fletching;
        _shaft = shaft;
    }

    public ArrowHead GetHead() => _arrowhead;
    public float Shaft
    {
        get { return _shaft; }
        set { _shaft = value = AskForNumberInRange("How long would you like the arrow shaft to be? (between 60 and 100 cm)", 60, 100); }
    }
    public Fletching GetFletching() => _fletching;

    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            ArrowHead.Steel => 10,
            ArrowHead.Wood => 3,
            ArrowHead.Obsidian => 5
        };
        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.Turkey => 5,
            Fletching.Goose => 3
        };
        float shaftCost = 0.05f * _shaft;

        return arrowheadCost + fletchingCost + shaftCost;
    }
    float AskForNumberInRange(string text, int min, int max)
    {
        while (true)
        {
            Console.Write(text);
            if (float.TryParse(Console.ReadLine(), out float result) && min <= result && max >= result)
                return result;
            else continue;
        }
    }
}
enum ArrowHead
{
    Steel, Wood, Obsidian, invalid
}

enum Fletching
{
    Plastic, Turkey, Goose, invalid
}
