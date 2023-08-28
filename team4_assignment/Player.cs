using System.Reflection;
using System.Windows.Markup;

class Player : Unit
{
    public Player()
    {
        hp = 100;
        atk = 10;
        def = 5;
        gold = 1500;
        level = 1;
        exp = 0;
        
    }

    private string job = "";
    private int gold;
    private int exp;

    public string Job { get { return job; } set { job = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public int Level { get; set; }
    public int Exp { get; set; }


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
    public void CheckLevelup() //레벨업 체크
    {
        int[] maxExp = { 0, 10, 35, 65, 100 };//레벨별 필요 경험치

        for (int i = level + 1; i < maxExp.Length; i++)
        {
            if (exp >= maxExp[i])
            {
                level++; //레벨업
                atk += 0.5;
                def++;
            }
            else
            {
                break;
            }
        }
    }
}
