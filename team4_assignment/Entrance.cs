using System;

class Entrance
{
    Player player;
    Inventory inventory;

    public Entrance()
    {
        if (GameManager.GM.player == null)
        {
            Console.WriteLine("플레이어가 null 입니다.");
            Console.ReadLine();
        }

        DefaultSetting();
        inventory = new Inventory();
    }

    public void DefaultSetting()
    {
        player = Program.player;
    }

    public void EntranceUI()
    {
        int optionNum = 3;
        while (true) 
        {
            Console.Clear();
            EntranceImage();

            Console.WriteLine("1. 상태보기 2. 던전 입장 3. 인벤토리");
            int input = GameManager.GM.SelectOption(optionNum, false);
            switch (input)
            {
                case 1:
                    player.StatusUI();
                    break;
                case 2:
                    Console.WriteLine("던전 입장");
                    Program.fightScene.StartPhase();
                    break;
                case 3:
                    inventory.DisplayInventory();
                    break;

            }
        }
    }

    public void EntranceImage()
    {
        int leftNum = 15;
        Console.SetCursorPosition(0, 0);
        Console.Write("*-----------------------------------------------------------------------------------*");
        Console.SetCursorPosition(0, 25);
        Console.Write("*-----------------------------------------------------------------------------------*");
        for (int i = 1; i < 25; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            Console.SetCursorPosition(84, i);
            Console.Write("|");
        }
        Console.SetCursorPosition(3, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"지금부터 참치 사냥을 떠나는 것이에요.");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.Write("-----------------------------------------------------------------------------------");
        Console.SetCursorPosition(leftNum, 24);
        Console.Write("    \\/;:   \'--' `---`           `\\//-\\///");
        Console.SetCursorPosition(leftNum, 23);
        Console.Write("      |;:  |\\ /' /\\_\\_        ~. _ ~   -   //-");
        Console.SetCursorPosition(leftNum, 22);
        Console.Write("      |;:  |  \\ / `\\       //.  -    ^   ~");
        Console.SetCursorPosition(leftNum, 21);
        Console.Write("      |;:  |(____.-'     '.   ~   -    `    ~");
        Console.SetCursorPosition(leftNum, 20);
        Console.Write("      |;:  |/^}__..-,@   .~`    ~    `o ~");
        Console.SetCursorPosition(leftNum, 19);
        Console.Write("      |;   |_`\\_      /  ,\\\\.~`  `-._ -  ^ ");
        Console.SetCursorPosition(leftNum, 18);
        Console.Write("      |,   |_          /     `-._ ..--~`_");
        Console.SetCursorPosition(leftNum, 17);
        Console.Write("      |    |            /`-._           _\\/");
        Console.SetCursorPosition(leftNum, 16);
        Console.Write("    `\\%%.'  /`%&'");
        Console.SetCursorPosition(leftNum, 15);
        Console.Write("  % %& %& %&% &%%");
        Console.SetCursorPosition(leftNum, 14);
        Console.Write(" '%&% %&% %&&%&%%'%");
        Console.SetCursorPosition(leftNum, 13);
        Console.Write("&& %&% %&%& %&% %&%'");
        Console.SetCursorPosition(leftNum, 12);
        Console.Write("&%&% %&% % %& &% %%&");
        Console.SetCursorPosition(leftNum, 11);
        Console.Write("%%& %&%& %&%&% %&%%&");
        Console.SetCursorPosition(leftNum, 10);
        Console.Write(" &%&% %&%& %& &%& %");
        Console.SetCursorPosition(leftNum, 9);
        Console.Write(" % &%% %&% &% %&%&,");
        Console.SetCursorPosition(leftNum, 8);
        Console.Write("  %& %&% &%&% % &%");
        Console.SetCursorPosition(leftNum, 7);
        Console.Write("   ,%&%& %&%& %&");
        Console.SetCursorPosition(leftNum, 6);
        Console.Write("     ,%&& %&& %");

        Console.SetCursorPosition(0, 27);
    }
}
