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
        int[] monsterIndex = new int[5];
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

        DrawDisplay("", "");

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

    public void DrawDisplay(string choice1, string choice2)
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
    }
}
