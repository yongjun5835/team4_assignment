﻿class Player : Unit
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
        string line = ("---------------------------------------------------------------------------------");

        while (true)
        {
            Console.Clear();
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(36, 2, "[MY INFO]", "white");
            GameManager.GM.DrawText(2, 4, ($"{line}"), "white");
            GameManager.GM.DrawText(2, 6, ($"이  름 : {Name}"), "white");
            GameManager.GM.DrawText(2, 7, ($"직  업 : {Job}"), "white");
            GameManager.GM.DrawText(2, 8, ($"레  벨 : {level + 1}    경험치 :{exp}/{maxExp[level]}"), "white");
            GameManager.GM.DrawText(2, 9, ($"체  력 : {Hp} / {maxHp}"), "white");
            GameManager.GM.DrawText(2, 10, ($"마  나 : {mp} / {maxMp}"), "white");
            GameManager.GM.DrawText(2, 11,($"공격력 : {Atk}"), "white");
            GameManager.GM.DrawText(2, 12,($"방어력 : {Def}"), "white");
            GameManager.GM.DrawText(2, 13,($"금  화 : {Gold} G"), "white");
            GameManager.GM.DrawText(2, 22, ($"{line}"), "white");
            GameManager.GM.DrawText(2, 23, ("1.나가기"), "white");
            GameManager.GM.DrawText(0, 26, " ", "");




            //Console.WriteLine($"이름 : {Name}");
            //Console.WriteLine($"직업 : {Job}");
            //Console.WriteLine($"레벨 : {level + 1}    경험치 :{exp}/{maxExp[level]}");
            //Console.WriteLine($"체력 : {Hp} / {maxHp}");
            //Console.WriteLine($"마나 : {mp} / {maxMp}");
            //Console.WriteLine($"공격력 : {Atk}");
            //Console.WriteLine($"방어력 : {Def}");
            //Console.WriteLine($"금화 : {Gold}");
            //Console.WriteLine("\n1. 나가기");
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
    
    public void CheckLevelup()
    {
        for (int i = level; i < maxExp.Length; i++) // maxExp 배열 사용
        {
            if (exp >= maxExp[i])
            {
                level++; // 레벨업
                atk += 1;
                def++;
                Console.SetCursorPosition(2, 8);
                Console.WriteLine($"레벨업!   {level+1}레벨을 달성하셨습니다!");

                int totalExp = exp - maxExp[i];
                exp = totalExp;
                Console.SetCursorPosition(2, 9);
                Console.WriteLine($"다음 레벨까지 남은 경험치는 {maxExp[i+1]-exp}");
            }
            else
            {
                break;
            }
        }
    }

}
