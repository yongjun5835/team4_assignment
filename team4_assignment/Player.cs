using System.Runtime;
using System.Text;

class Player : Unit
{
    private int[] maxExp = { 50, 100, 200, 300, 400, 500, 600, 700 }; // 레벨별 필요 경험치
    public Player()
    {
        hp = 100;
        maxHp = hp;
        atk = 10;
        def = 5;
        gold = 1500;
        mp = 500;
        maxMp = mp;
        level = 0;
        exp = 0;

        skills.Add(new FastSpin());
        skills.Add(new Rest());
    }

    private string job = "";
    private int gold = 0;

    public bool vsBoss = false;
    public bool vsBossSkillCombo = false;

    List<Skill> skills = new List<Skill>();

    public string Job { get { return job; } set { job = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public List<Skill> Skills { get { return Skills; } set { Skills = value; } }

    public void StatusUI()
    {
        while (true)
        {
            RenderStatusUI();

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

    void RenderStatusUI()
    {
        StringBuilder[] tmi = JobTMI($"{Job}");
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write("*-----------------------------------------------------------------------------------*");
        Console.SetCursorPosition(0, 11);
        Console.Write("*-----------------------------------------------------------------------------------*");
        for (int i = 1; i < 11; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(84, i);
            Console.Write("|");
        }
        Console.SetCursorPosition(3, 7);
        GameManager.GM.DrawText(3, 2, "이름 ","blue"); Console.Write($": {Name}");
        GameManager.GM.DrawText(3, 3, "직업 ","blue"); Console.Write($": {job}");
        GameManager.GM.DrawText(57, 2, $"<이력서>","green");
        GameManager.GM.DrawText(57, 3, $"Lv : {level+1}","white");
        GameManager.GM.DrawText(64, 3, $"({exp}".PadLeft(5,' ')+" / " + $"{maxExp[Level+1]})","white");
        GameManager.GM.DrawText(57, 4, $"체력   : {Hp} / {maxHp}","white");
        GameManager.GM.DrawText(57, 5, $"마나   : {Mp} / {MaxMp}", "white");
        GameManager.GM.DrawText(57, 6, $"공격력 : {Atk}", "white");
        GameManager.GM.DrawText(57, 7, $"방어력 : {Def}", "white");
        GameManager.GM.DrawText(57, 8, $"골드   : {Gold}", "white");

        GameManager.GM.DrawText(1, 5, "---------------------------------------------*", "white");
        GameManager.GM.DrawText(46, 6, "|", "white");
        GameManager.GM.DrawText(46, 7, "|", "white");
        GameManager.GM.DrawText(46, 8, "|", "white");
        GameManager.GM.DrawText(46, 9, "|", "white");
        GameManager.GM.DrawText(46, 10, "|", "white");

        if (Name.Length == 0)
        {
            GameManager.GM.DrawText(2, 6, $"소 개", "green");
        }
        else
        {
            GameManager.GM.DrawText(2, 6, $"{Name[0]}씨 :", "green");

        }

        GameManager.GM.DrawText(2, 7, $"{tmi[0]}", "white");
        GameManager.GM.DrawText(2, 8, $"{tmi[1]}", "white");
        GameManager.GM.DrawText(2, 9, $"{tmi[2]}", "white");

        Console.SetCursorPosition(2, 12);
    }

    public void CheckLevelup()
    {
        for (int i = level; i < maxExp.Length; i++) // maxExp 배열 사용
        {
            if (exp >= maxExp[i])
            {
                level++; // 레벨업
                atk += 1;
                def++;
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("-------------------------------------");        
                Console.SetCursorPosition(2, 7);
                Console.WriteLine($"레벨업!   {level + 1}레벨을 달성하셨습니다!");
                int totalExp = exp - maxExp[i];
                exp = totalExp;
                Console.SetCursorPosition(2, 8);
                Console.WriteLine($"다음 레벨까지 남은 경험치는 {maxExp[i+1]-exp}");
            }
            else
            {
                break;
            }
        }
    }

    StringBuilder[] JobTMI(string job)
    {
        StringBuilder[] tmi = new StringBuilder[3];

        tmi[0] = new StringBuilder();
        tmi[1] = new StringBuilder();
        tmi[2] = new StringBuilder();

        switch (job)
        {
            case "횟집 사장":
                tmi[0].Append("아따~ 오늘 매물들 상태가 왜 이런겨~");
                tmi[1].Append("김선장 배 띄우쇼");
                tmi[2].Append("직접 확 다 잡아 가야쓰것소..");
                break;
            case "전문 낚시꾼":
                tmi[0].Append("파고 퍼-펙트. 수온 퍼-펙트.");
                tmi[1].Append("바람 퍼-펙트.");
                tmi[2].Append("선장 출항.");
                break;
            case "해양 경찰":
                tmi[0].Append("출항하기 전에 점검 나왔습니다.");
                tmi[1].Append("신분증 제시하시고 구명 조끼 하세요.");
                tmi[2].Append("술 드시지 마시고 이제 출항하세요.");
                break;
            case "참치그룹 회장":
                tmi[0].Append("가족 건강과 행복, 아이들의 밝은 미래를 위해");
                tmi[1].Append("신뢰와 만족을 최우선으로 만들어 가겠습니다.");
                tmi[2].Append("                            ㅇㅇ산업 CEO 曰");
                break;
            default:

                break;
        }

        return tmi;
    }

}
