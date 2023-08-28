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
            Console.WriteLine("참치 사냥을 떠나는 것이에요\n");

            Console.WriteLine("1. 상태보기 2. 던전 입장 3. 인벤토리");
            int input = GameManager.GM.SelectOption(optionNum, false, "");
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
}
