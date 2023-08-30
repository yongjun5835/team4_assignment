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
        int optionNum = 3;
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("참치 사냥을 떠나는 것이에요\n");

            Console.WriteLine("1. 상태보기 2. 던전 입장 3. 인벤토리");

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

            }
        }
    }
}
