class Player : Unit
{
    public Player()
    {
        hp = 100;
        maxHp = hp;
        atk = 10;
        def = 5;
        gold = 1500;
        mp = 50;
        maxMp = mp;

        skills.Add(new FastSpin());
        skills.Add(new Rest());
    }

    private string job = "";
    private int gold;
    List<Skill> skills = new List<Skill>();

    public string Job { get { return job; } set { job = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public List<Skill> Skills { get { return Skills; } set { Skills = value; } }

    public void StatusUI()
    {
        Console.Clear();
        Console.WriteLine($"이름 : {Name}");
        Console.WriteLine($"직업 : {Job}");
        Console.WriteLine($"체력 : {Hp} / {maxHp}");
        Console.WriteLine($"마나 : {mp} / {maxMp}");
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

    public void UseSkill(Skill skill)
    {
        if (Mp < skill.RequiredMp)
        {
            Console.WriteLine("\n마나가 부족합니다.");
            Thread.Sleep(1000);
            return;
        }
        Mp -= skill.RequiredMp;
        skill.Activate(this);
    }
}
