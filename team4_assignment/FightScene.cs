using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class FightScene
{
    List<Monster> monsters = new List<Monster>();
    Random rand = new Random();
    int stageLevel;
    int[] monsterIndex = new int[5];

    public FightScene()
    {
        stageLevel = 1;
        CreateMonster(15, 5, "송사리");
        CreateMonster(10, 9, "꺽지");
        CreateMonster(25, 8, "블루길");
        CreateMonster(40, 15, "농어");
        CreateMonster(70, 25, "참치");
    }

    public void CreateMonster(int hp, int atk, string name)
    {
        Monster monster = new Monster(hp, atk, name);
        monsters.Add(monster);
    }

    public void StartPhase()
    {
        for (int i = 0; i < 5; i++)
        {
            if (stageLevel == 1)
            {
                monsterIndex[i] = rand.Next(0, 3);
            }
            else if (stageLevel == 2)
            {
                monsterIndex[i] = rand.Next(0, 4);
            }
            else if (stageLevel == 3)
            {
                monsterIndex[i] = rand.Next(0, 5);
            }
        }

        DrawDisplay("도망가기", "맞서 싸우기", "생선과 친해지기", "생선과 대화하기");
        ShowChoice();
    }

    public void ShowChoice()
    {
        bool isSelect = false;
        Console.SetCursorPosition(0, 28);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();

            if (key == "0")
            {
                Program.entrance.EntranceUI();
                isSelect = true;
            }
            else if (key == "1")
            {
                PlayerPhase();
                isSelect = true;
            }
            else if (key == "2")
            {
                PlayerPhase();
                isSelect = true;
            }
            else if (key == "3")
            {
                PlayerPhase();
                isSelect = true;
            }
            else
            {
                Console.SetCursorPosition(0, 28);
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 28);
                Console.Write("올바른 값을 입력해주세요.: ");
            }
        }
    }

    public void PlayerPhase()
    {

    }

    public void MonsterPhase()
    {

    }

    public void Result()
    {

    }

    public void DrawDisplay(string choice1, string choice2, string choice3, string choice4)
    {
        Console.Clear();

        Console.SetCursorPosition(0, 0);
        Console.Write("*-----------------------------------------------------------------------------------*");
        Console.SetCursorPosition(0, 25);
        Console.Write("*-----------------------------------------------------------------------------------*");
        for (int i = 1; i <25; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(84, i);
            Console.Write("|");
        }

        Console.SetCursorPosition(3, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"스파르타 던전 {stageLevel}층 | 생선을 처치하고 더 높은 층으로 가세요!");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.Write("-----------------------------------------------------------------------------------");

        for (int i = 3; i < 12; i++)
        {
            Console.SetCursorPosition(60, i);
            Console.Write("|");
        }
        Console.SetCursorPosition(66, 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("플레이어 스탯");
        Console.ResetColor();
        Console.SetCursorPosition(61, 4);
        Console.Write("-----------------------");
        Console.SetCursorPosition(66, 6);
        Console.Write($"HP: {Program.player.Hp}");
        Console.SetCursorPosition(66, 7);
        Console.Write($"MP: {Program.player.Mp}");
        Console.SetCursorPosition(66, 8);
        Console.Write($"ATK: {Program.player.Atk}");
        Console.SetCursorPosition(66, 9);
        Console.Write($"DEF: {Program.player.Def}");
        Console.SetCursorPosition(1, 12);
        Console.Write("-----------------------------------------------------------------------------------");

        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.SetCursorPosition(2, 16);
        Console.Write("생");
        Console.SetCursorPosition(2, 18);
        Console.Write("선");
        Console.ResetColor();
        for (int i = 13; i < 23; i++)
        {
            Console.SetCursorPosition(4, i);
            Console.Write("|");
        }

        for (int i = 13; i < 23; i++)
        {
            Console.SetCursorPosition(20, i);
            Console.Write("|");
        }
        if (stageLevel >= 1)
        {
            Console.SetCursorPosition(10, 15);
            Console.Write($"{monsters[monsterIndex[0]].Name}");
            Console.SetCursorPosition(10, 17);
            Console.Write($"HP: {monsters[monsterIndex[0]].Hp}");
            Console.SetCursorPosition(10, 18);
            Console.Write($"ATK: {monsters[monsterIndex[0]].Atk}");
            if (monsters[monsterIndex[0]].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(9, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(9, 20);
                Console.Write($"[잡았다!]");
                Console.ResetColor();
            }
        }

        for (int i = 13; i < 23; i++)
        {
            Console.SetCursorPosition(36, i);
            Console.Write("|");
        }
        if (stageLevel >= 1)
        {
            Console.SetCursorPosition(26, 15);
            Console.Write($"{monsters[monsterIndex[1]].Name}");
            Console.SetCursorPosition(26, 17);
            Console.Write($"HP: {monsters[monsterIndex[1]].Hp}");
            Console.SetCursorPosition(26, 18);
            Console.Write($"ATK: {monsters[monsterIndex[1]].Atk}");
            if (monsters[monsterIndex[1]].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(25, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(25, 20);
                Console.Write($"[잡았다!]");
                Console.ResetColor();
            }
        }

        for (int i = 13; i < 23; i++)
        {
            Console.SetCursorPosition(52, i);
            Console.Write("|");
        }
        if (stageLevel >= 1)
        {
            Console.SetCursorPosition(42, 15);
            Console.Write($"{monsters[monsterIndex[2]].Name}");
            Console.SetCursorPosition(42, 17);
            Console.Write($"HP: {monsters[monsterIndex[2]].Hp}");
            Console.SetCursorPosition(42, 18);
            Console.Write($"ATK: {monsters[monsterIndex[2]].Atk}");
            if (monsters[monsterIndex[2]].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(41, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(51, 20);
                Console.Write($"[잡았다!]");
                Console.ResetColor();
            }
        }

        for (int i = 13; i < 23; i++)
        {
            Console.SetCursorPosition(68, i);
            Console.Write("|");
        }
        if (stageLevel >= 2)
        {
            Console.SetCursorPosition(58, 15);
            Console.Write($"{monsters[monsterIndex[3]].Name}");
            Console.SetCursorPosition(58, 17);
            Console.Write($"HP: {monsters[monsterIndex[3]].Hp}");
            Console.SetCursorPosition(58, 18);
            Console.Write($"ATK: {monsters[monsterIndex[3]].Atk}");
            if (monsters[monsterIndex[3]].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(57, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(57, 20);
                Console.Write($"[잡았다!]");
                Console.ResetColor();
            }
        }

        if (stageLevel >= 3)
        {
            Console.SetCursorPosition(74, 15);
            Console.Write($"{monsters[monsterIndex[4]].Name}");
            Console.SetCursorPosition(74, 17);
            Console.Write($"HP: {monsters[monsterIndex[4]].Hp}");
            Console.SetCursorPosition(74, 18);
            Console.Write($"ATK: {monsters[monsterIndex[4]].Atk}");
            if (monsters[monsterIndex[4]].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(73, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(73, 20);
                Console.Write($"[잡았다!]");
                Console.ResetColor();
            }
        }

        Console.SetCursorPosition(1, 23);
        Console.Write("-----------------------------------------------------------------------------------");
        Console.SetCursorPosition(2, 24);
        Console.Write($"0. {choice1} | 1. {choice2} | 2. {choice3} | 3. {choice4} |");
    }
}
