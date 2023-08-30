using System;

class Entrance
{
    Player player;
    Inventory inventory;

    public Entrance()
    {
        DefaultSetting();
        inventory = new Inventory();
    }

    public void DefaultSetting()
    {
        player = Program.player;
    }

    public void EntranceUI()
    {
        int optionNum = 4;
        while (true)
        {
            Console.Clear();
            GameManager.GM.MakeUI();
            Console.Write("\n\n");
            Console.WriteLine("참치 사냥을 떠나는 것이에요\n");

            Console.WriteLine("1. 상태보기 2. 던전 입장 3. 인벤토리 4. 여관");

            if (Program.player.Hp <= 0)
            {
                Console.WriteLine("당신은 체력이 없어 던전에 입장할 수 없습니다!");
            }

            int input = GameManager.GM.SelectOption(optionNum, false, "");
            switch (input)
            {
                case 1:
                    player.StatusUI();
                    break;
                case 2:
                    Console.WriteLine("던전 입장");
                    if (Program.player.Hp > 0)
                    {
                        Program.stageSelectScene.StageSelect();
                    }
                    else
                    {
                        continue;
                    }
                    break;
                case 3:
                    inventory.DisplayInventory();
                    break;
                case 4:
                    Inn();
                    break;

            }
        }
    }

    void Inn()
    {
        int optionNum = 2;
        int cheatCode = 0;

        while (true)
        {
            Console.Clear();
            GameManager.GM.MakeUI();
            Console.Write("\n\n아늑하고 따뜻한 이곳은 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'여관'\n");
            Console.ResetColor();

            Console.WriteLine("1. 내일을 맞이하기 (500 G)  2. 돌아가기");
            int input = GameManager.GM.SelectOption(optionNum, false);
            switch (input)
            {
                case 1:
                    if (Program.player.Gold < 500)
                    {
                        Console.WriteLine("\n골드가 부족합니다.");
                        Thread.Sleep(2000);
                        break;
                    }
                    if (Program.player.Hp == Program.player.MaxHp)
                    {
                        Console.WriteLine("\n아직 피곤하지 않다.");
                        Thread.Sleep(2000);
                        break;
                    }
                    player.Hp = player.MaxHp;
                    player.Gold -= 500;
                    SleepAni();
                    break;
                case 2:
                    return;
                case -1:
                    cheatCode--;
                    break;
                default:
                    break;

            }
            if (cheatCode == -10)
                GameManager.GM.PlayerCheat();
        }
    }

    void SleepAni()
    {
        Console.CursorVisible = false;
        string text = "푸~푸르르푸~푸린푸우린~";
        Console.Clear();
        GameManager.GM.MakeUI();
        Console.ForegroundColor= ConsoleColor.Cyan;
        for (int i = 0; i < text.Length; i++)
        {
            int space = (84-30)/text.Length;
            int updown = 0;
            if (i%3==0)
            {
                updown = -1;
            }
            Console.SetCursorPosition(42-(text.Length/2*space)+(i*space), 12+updown);
            Console.Write(text[i]);
            Thread.Sleep(400);
        }
        Console.ResetColor();
        Console.SetCursorPosition(30,15);
        Console.Write("체력이 모두 회복되었ㄷ...zZ");
        Thread.Sleep(1500);
        Console.SetCursorPosition(26, 17);
        GameManager.GM.PressAnyKey();
        Console.CursorVisible = true;
    }
}
