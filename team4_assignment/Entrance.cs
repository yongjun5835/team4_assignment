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
            //GameManager.GM.MakeUI();
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
            //GameManager.GM.MakeUI();
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
        //GameManager.GM.MakeUI();
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

    void RenderMainImg()
    {
        Queue<string> imgArr = new Queue<string>();
        string A01 = "                                                           |>>>";
        string A02 = "                   _                      _                |";
        string A03 = "    ____________ .' '.    _____/----/-\\ .' './========\\   / \\";
        string A04 = "   //// ////// /V_.-._\\  |.-.-.|===| _ |-----| u    u |  /___\\";
        string A05 = "  // /// // ///==\\ u |.  || | ||===||||| |T| |   ||   | .| u |_ _ _ _ _ _";
        string A06 = " ///////-\\////====\\==|:::::::::::::::::::::::::::::::::::|u u| U U U U U";
        string A07 = " |----/\\u |--|++++|..|'''''''''''::::::::::::::''''''''''|+++|+-+-+-+-+-+";
        string A08 = " |u u|u | |u ||||||..|              '::::::::'           |===|>=== _ _ ==";
        string A09 = " |===|  |u|==|++++|==|              .::::::::.           | T |....| V |..";
        string A10 = " |u u|u | |u ||HH||         \\|/    .::::::::::.";
        string A11 = " |===|_.|u|_.|+HH+|_              .::::::::::::.              _";
        string A12 = "                __(_)___         .::::::::::::::.         ___(_)__";
        string A13 = "---------------/  / \\  /|       .:::::;;;:::;;:::.       |\\  / \\  \\-------";
        string A14 = "______________/_______/ |      .::::::;;:::::;;:::.      | \\_______\\________";
        string A15 = "|       |     [===  =] /|     .:::::;;;::::::;;;:::.     |\\ [==  = ]   |";
        string A16 = "|_______|_____[ = == ]/ |    .:::::;;;:::::::;;;::::.    | \\[ ===  ]___|____";
        string A17 = "     |       |[  === ] /|   .:::::;;;::::::::;;;:::::.   |\\ [=  ===] |";
        string A18 = "_____|_______|[== = =]/ |  .:::::;;;::::::::::;;;:::::.  | \\[ ==  =]_|______";
        string A19 = " |       |    [ == = ] /| .::::::;;:::::::::::;;;::::::. |\\ [== == ]      |";
        string A20 = "_|_______|____[=  == ]/ |.::::::;;:::::::::::::;;;::::::.| \\[  === ]______|_";
        string A21 = "   |       |  [ === =] /.::::::;;::::::::::::::;;;:::::::.\\ [===  =]   |";
        string A22 = "___|_______|__[ == ==]/.::::::;;;:::::::::::::::;;;:::::::.\\[=  == ]___|_____\n";

        imgArr.Enqueue(A01);
        imgArr.Enqueue(A02);
        imgArr.Enqueue(A03);
        imgArr.Enqueue(A04);
        imgArr.Enqueue(A05);
        imgArr.Enqueue(A06);
        imgArr.Enqueue(A07);
        imgArr.Enqueue(A08);
        imgArr.Enqueue(A09);
        imgArr.Enqueue(A10);
        imgArr.Enqueue(A11);
        imgArr.Enqueue(A12);
        imgArr.Enqueue(A13);
        imgArr.Enqueue(A14);
        imgArr.Enqueue(A15);
        imgArr.Enqueue(A16);
        imgArr.Enqueue(A17);
        imgArr.Enqueue(A18);
        imgArr.Enqueue(A19);
        imgArr.Enqueue(A20);
        imgArr.Enqueue(A21);
        imgArr.Enqueue(A22);
        int count = imgArr.Count;
        for (int i = 0; i < count; i++)
        {
            Console.SetCursorPosition(4, i+3);
            Console.Write(imgArr.Dequeue());
        }
        
    }
}
