using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

internal class FightScene
{
    List<Monster> monsters = new List<Monster>();
    Random rand = new Random();
    public int stageLevel;
    public int clearLevel = 0;
    FastSpin fastSpin = new FastSpin();
    WriggleWriggleSpin wriggleWriggleSpin = new WriggleWriggleSpin();
    Rest rest = new Rest();
    TempMagic tempMagic = new TempMagic();

    StringBuilder skillTxtHelper;

    public FightScene()
    {
        int type1 = rand.Next(0, 3);
        CreateMonster(type1);
        int type2 = rand.Next(0, 3);
        CreateMonster(type2);
        int type3 = rand.Next(0, 3);
        CreateMonster(type3);
        int type4 = rand.Next(2, 4);
        CreateMonster(type4);
        int type5 = rand.Next(3, 5);
        CreateMonster(type5);
        if (stageLevel <= 2)
        {
            monsters[3].Hp = 0;
        }
        if (stageLevel <= 3)
        {
            monsters[4].Hp = 0;
        }
    }

    public void Restart()
    {
        monsters.RemoveAt(4);
        monsters.RemoveAt(3);
        monsters.RemoveAt(2);
        monsters.RemoveAt(1);
        monsters.RemoveAt(0);

        int type1 = rand.Next(0, 3);
        CreateMonster(type1);
        int type2 = rand.Next(0, 3);
        CreateMonster(type2);
        int type3 = rand.Next(0, 3);
        CreateMonster(type3);
        int type4 = rand.Next(2, 4);
        CreateMonster(type4);
        int type5 = rand.Next(3, 5);
        CreateMonster(type5);
        if (stageLevel < 2)
        {
            monsters[3].Hp = 0;
        }
        if (stageLevel < 3)
        {
            monsters[4].Hp = 0;
        }
    }

    public void CreateMonster(int type)
    {
        Monster monster = new Monster(type);
        monsters.Add(monster);
    }

    public void StartPhase()
    {
        DrawDisplay("도망가기", "맞서 싸우기", "생선과 친해지기", "생선과 대화하기");

        InfoClear();
        Console.SetCursorPosition(2, 4);
        Console.Write($"'{monsters[0].Name}'이(가) 출현했습니다!");
        Console.SetCursorPosition(2, 5);
        Console.Write($"'{monsters[1].Name}'이(가) 출현했습니다!");
        Console.SetCursorPosition(2, 6);
        Console.Write($"'{monsters[2].Name}'이(가) 출현했습니다!");
        if (stageLevel >= 2)
        {
            Console.SetCursorPosition(2, 7);
            Console.Write($"'{monsters[3].Name}'이(가) 출현했습니다!");
        }
        if (stageLevel >= 3)
        {
            Console.SetCursorPosition(2, 8);
            Console.Write($"'{monsters[4].Name}'이(가) 출현했습니다!");
        }

        ShowChoice1();
    }

    public void PlayerPhase()
    {
        DrawDisplay("취소하기", fastSpin.Name, wriggleWriggleSpin.Name, rest.Name);

        InfoClear();
        Console.SetCursorPosition(2, 4);
        Console.Write($"{fastSpin.Name}   | {fastSpin.Description}");
        Console.SetCursorPosition(2, 5);
        Console.Write($"{wriggleWriggleSpin.Name} | {wriggleWriggleSpin.Description}");
        Console.SetCursorPosition(2, 6);
        Console.Write($"{rest.Name}          | {rest.Description}");

        ShowChoice2();
    }

    public void SkillPhase()
    {

        DrawDisplay("다음 페이즈로", "X", "X", "X");

        InfoClear();

        StringBuilder subText = new StringBuilder();
        StringBuilder tempText = new StringBuilder(skillTxtHelper.ToString());
        for (int i = 5; i < tempText.Length; i++)
        {
            if (tempText[i] == '\n')
            {
                skillTxtHelper.Remove(i, skillTxtHelper.Length-i);
                tempText.Remove(0,i+1);
                subText = tempText;
                break;
            }
        }
        Console.SetCursorPosition(2, 4);
        Console.Write(skillTxtHelper); // << 스킬 텍스트
        Console.SetCursorPosition(2, 5);
        Console.Write(subText); // << 스킬 텍스트


        if (monsters[0].Hp <= 0 &&
            monsters[1].Hp <= 0 &&
            monsters[2].Hp <= 0 &&
            monsters[3].Hp <= 0 &&
            monsters[4].Hp <= 0)
        {
            Console.SetCursorPosition(2, 5);
            Console.Write("당신은 모든 생선들을 잡았습니다!");
        }

        ShowChoice3();
    }

    public void MonsterPhase()
    {
        DrawDisplay("다음 페이즈로", "X", "X", "X");
        InfoClear();
        if (monsters[0].Hp > 0)
        {
            Console.SetCursorPosition(2, 4);
            monsters[0].AttackUnit(Program.player, GameManager.GM.physicalDmg);
            //Console.Write($"{monsters[0].Name}의 공격으로 {currentDmg}의 피해를 입었습니다!");
        }
        if (monsters[1].Hp > 0)
        {
            Console.SetCursorPosition(2, 5);
            monsters[1].AttackUnit(Program.player, GameManager.GM.physicalDmg);
            //Console.Write($"{monsters[1].Name}의 공격으로 {currentDmg}의 피해를 입었습니다!");
        }
        if (monsters[2].Hp > 0)
        {
            Console.SetCursorPosition(2, 6);
            monsters[2].AttackUnit(Program.player, GameManager.GM.physicalDmg);
            //Console.Write($"{monsters[2].Name}의 공격으로 {currentDmg}의 피해를 입었습니다!");
        }
        if (monsters[3].Hp > 0 && stageLevel >= 2)
        {
            Console.SetCursorPosition(2, 7);
            monsters[3].AttackUnit(Program.player, GameManager.GM.physicalDmg);
            ////Console.Write($"{monsters[3].Name}의 공격으로 {currentDmg}의 피해를 입었습니다!");
        }
        if (monsters[4].Hp > 0 && stageLevel >= 3)
        {
            Console.SetCursorPosition(2, 8);
            monsters[4].AttackUnit(Program.player, GameManager.GM.physicalDmg);
            //Console.Write($"{monsters[4].Name}의 공격으로 {currentDmg}의 피해를 입었습니다!");
        }

        if (Program.player.Hp <= 0)
        {
            Console.SetCursorPosition(2, 9);
            Console.Write("더 이상 싸울 체력이 없습니다!");
        }

        Console.SetCursorPosition(63, 6);
        Console.Write("                ");
        Console.SetCursorPosition(63, 7);
        Console.Write("                ");
        Console.SetCursorPosition(63, 8);
        Console.Write("                ");
        Console.SetCursorPosition(63, 9);
        Console.Write("                ");
        Console.SetCursorPosition(66, 6);
        Console.Write($"HP: {Program.player.Hp}");
        Console.SetCursorPosition(66, 7);
        Console.Write($"MP: {Program.player.Mp}");
        Console.SetCursorPosition(66, 8);
        Console.Write($"ATK: {Program.player.Atk}");
        Console.SetCursorPosition(66, 9);
        Console.Write($"DEF: {Program.player.Def}");

        ShowChoice4();
    }
    public void DropPotion()
    {
        Random random = new Random();

        //포션 드롭 확률 설정 50 %
        int dropChance = 50;
        if (random.Next(0, 100) < dropChance)
        {
            int potionIndex = 0; //  포션의 인덱스 설정
            int potionAmount = 1;
            Program.inventory.AddQuantity(potionIndex, potionAmount);
        }
        else
        {
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("");
        }
    }

        public void Result()//결과창
    {
        DrawDisplay("메인으로", "X", "X", "X");

        InfoClear();
        Console.SetCursorPosition(2, 4);
        int totalExp = 0;
        int totalGold = 0;

        foreach (var monster in monsters)
        {
            if (monster.IsDead)
            {
                totalExp += monster.Exp;
                totalGold += monster.Gold;
            }
        }
        if (totalExp > 0)
        {
            Program.player.Exp += totalExp;
            Program.player.Gold += totalGold;

            Console.SetCursorPosition(2, 5);
            Console.WriteLine($"골드 {totalGold}를 획득했습니다!");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine($"총 소지하신 골드는 {Program.player.Gold}원 입니다.");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine($"경험치 {totalExp}를 획득했습니다");

            Program.player.CheckLevelup();
            DropPotion();
        }

        ShowChoice5();
    }

    public void InfoClear()
    {
        Console.SetCursorPosition(2, 4);
        Console.Write("                                                         ");
        Console.SetCursorPosition(2, 5);
        Console.Write("                                                         ");
        Console.SetCursorPosition(2, 6);
        Console.Write("                                                         ");
        Console.SetCursorPosition(2, 7);
        Console.Write("                                                         ");
        Console.SetCursorPosition(2, 8);
        Console.Write("                                                         ");
        Console.SetCursorPosition(2, 9);
        Console.Write("                                                         ");
    }

    public void ShowChoice1()
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
                Program.fightScene.PlayerPhase();
                isSelect = true;
            }
            else if (key == "2")
            {
                InfoClear();
                Console.SetCursorPosition(2, 4);
                Console.Write($"'{monsters[0].Name}'이(가) 당신의 요청을 거절했습니다!");
                Console.SetCursorPosition(2, 5);
                Console.Write($"'{monsters[1].Name}'이(가) 당신의 요청을 거절했습니다!");
                Console.SetCursorPosition(2, 6);
                Console.Write($"'{monsters[2].Name}'이(가) 당신의 요청을 거절했습니다!");
                if (stageLevel >= 2)
                {
                    Console.SetCursorPosition(2, 7);
                    Console.Write($"'{monsters[3].Name}'이(가) 당신의 요청을 거절했습니다!");
                }
                if (stageLevel >= 3)
                {
                    Console.SetCursorPosition(2, 8);
                    Console.Write($"'{monsters[4].Name}'이(가) 당신의 요청을 거절했습니다!");
                }
                Console.SetCursorPosition(0, 28);
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 28);
                Console.Write("선택지를 입력해주세요.: ");
            }
            else if (key == "3")
            {
                InfoClear();
                Console.SetCursorPosition(2, 4);
                Console.Write($"'{monsters[0].Name}': 보글보글보글(널 가만두지 않겠다!)");
                Console.SetCursorPosition(2, 5);
                Console.Write($"'{monsters[1].Name}': 보글보글보글(널 가만두지 않겠다!)");
                Console.SetCursorPosition(2, 6);
                Console.Write($"'{monsters[2].Name}': 보글보글보글(널 가만두지 않겠다!)");
                if (stageLevel >= 2)
                {
                    Console.SetCursorPosition(2, 7);
                    Console.Write($"'{monsters[3].Name}': 보글보글보글(널 가만두지 않겠다!)");
                }
                if (stageLevel >= 3)
                {
                    Console.SetCursorPosition(2, 8);
                    Console.Write($"'{monsters[4].Name}': 보글보글보글(널 가만두지 않겠다!)");
                }
                Console.SetCursorPosition(0, 28);
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 28);
                Console.Write("선택지를 입력해주세요.: ");
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
    // 마법 사용 구간
    public void ShowChoice2()
    {
        bool isSelect = false;
        skillTxtHelper = new StringBuilder();
        Console.SetCursorPosition(0, 28);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();
            if (key == "0")
            {
                Program.fightScene.StartPhase();
                isSelect = true;
            }
            else if (key == "1")
            {
                skillTxtHelper = Program.player.MagicalAttackUnits(monsters,fastSpin);
                Program.player.Mp -= fastSpin.RequiredMp;
                Program.fightScene.SkillPhase();
                isSelect = true;
            }
            else if (key == "2")
            {
                skillTxtHelper = Program.player.MagicalAttackUnits(monsters, wriggleWriggleSpin);
                Program.player.Mp -= wriggleWriggleSpin.RequiredMp;
                Program.fightScene.SkillPhase();
                isSelect = true;
            }
            else if (key == "3")
            {
                skillTxtHelper = Program.player.MagicalAttackUnits(monsters, rest);
                Program.player.Mp -= rest.RequiredMp;
                Program.fightScene.SkillPhase();
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

    public void ShowChoice3()
    {
        bool isSelect = false;
        Console.SetCursorPosition(0, 28);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();

            if (key == "0")
            {
                if (monsters[0].Hp <= 0 &&
                    monsters[1].Hp <= 0 &&
                    monsters[2].Hp <= 0 &&
                    monsters[3].Hp <= 0 &&
                    monsters[4].Hp <= 0)
                {
                    if (clearLevel == 0 && stageLevel == 1)
                    {
                        clearLevel = 1;
                    }
                    else if (clearLevel == 1 && stageLevel == 2)
                    {
                        clearLevel = 2;
                    }
                    Program.fightScene.Result();
                }
                else
                {
                    Program.fightScene.MonsterPhase();
                }
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

    public void ShowChoice4()
    {
        bool isSelect = false;
        Console.SetCursorPosition(0, 28);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();

            if (key == "0")
            {
                if (Program.player.Hp > 0)
                {
                    Program.fightScene.PlayerPhase();
                }
                else
                {
                    Program.entrance.EntranceUI();
                }
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

    public void ShowChoice5()
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
            else
            {
                Console.SetCursorPosition(0, 28);
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 28);
                Console.Write("올바른 값을 입력해주세요.: ");
            }
        }
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
            Console.Write($"{monsters[0].Name}");
            Console.SetCursorPosition(10, 17);
            Console.Write($"HP: {monsters[0].Hp}");
            Console.SetCursorPosition(10, 18);
            Console.Write($"ATK: {monsters[0].Atk}");
            if (monsters[0].Hp > 0)
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
            Console.Write($"{monsters[1].Name}");
            Console.SetCursorPosition(26, 17);
            Console.Write($"HP: {monsters[1].Hp}");
            Console.SetCursorPosition(26, 18);
            Console.Write($"ATK: {monsters[1].Atk}");
            if (monsters[1].Hp > 0)
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
            Console.Write($"{monsters[2].Name}");
            Console.SetCursorPosition(42, 17);
            Console.Write($"HP: {monsters[2].Hp}");
            Console.SetCursorPosition(42, 18);
            Console.Write($"ATK: {monsters[2].Atk}");
            if (monsters[2].Hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(41, 20);
                Console.Write($"[전투중]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(41, 20);
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
            Console.Write($"{monsters[3].Name}");
            Console.SetCursorPosition(58, 17);
            Console.Write($"HP: {monsters[3].Hp}");
            Console.SetCursorPosition(58, 18);
            Console.Write($"ATK: {monsters[3].Atk}");
            if (monsters[3].Hp > 0)
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
            Console.Write($"{monsters[4].Name}");
            Console.SetCursorPosition(74, 17);
            Console.Write($"HP: {monsters[4].Hp}");
            Console.SetCursorPosition(74, 18);
            Console.Write($"ATK: {monsters[4].Atk}");
            if (monsters[4].Hp > 0)
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
