class Player : Unit
{
    public Player()
    {
        hp = 100;
        atk = 10;
        def = 5;
        gold = 1500;
    }

    private string job = "";
    private int gold;

    public string Job { get { return job; } set { job = value; } }
    public int Gold { get { return gold; } set { gold = value; } }

    public void StatusUI()
    {
        Console.Clear();
        Console.WriteLine($"이름 : {Name}");
        Console.WriteLine($"직업 : {Job}");
        Console.WriteLine($"공격력 : {Atk}");
        Console.WriteLine($"방어력 : {Def}");
        Console.WriteLine($"금화 : {Gold}");
        Console.WriteLine("\n1. 나가기");
        int inputKey = GameManager.GM.SelectOption(1, false);
        switch (inputKey)
        {
            case 1:
                return;
            default:
                break;
        }
    }
}
