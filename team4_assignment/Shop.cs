using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Shop
{
    Inventory shopInven = new Inventory();  // 상점
    Inventory.Item[] itemList = new Inventory.Item[5]; // 상점 인벤토리

    Inventory.Item[] playerInven; // 플레이어 인벤토리 

    public Shop()
    {
        shopInven.InventoryGetSet = itemList; // 클래스끼리 연결
        itemList[0] = new Inventory.Item("딱딱한 가쓰오부시", 10,0, "가쓰오부시다.", 0, 0, 0, 1000);
        itemList[1] = new Inventory.Item("대나무 낚시대", 20, 0, "풍류를 즐길 줄 아는 자의 낚싯대", 0, 0, 0, 2000);
        itemList[2] = new Inventory.Item("ㅇㅇ스커스 사시미", 30, 0, "중고가형 브랜드다.", 0, 0, 0, 3000);
        itemList[3] = new Inventory.Item("구명조끼", 0, 10, "나를 살려줄 든든한 친구", 0, 0, 0, 1000);
        itemList[4] = new Inventory.Item("아이스 박스", 0, 0, "살아서 다시 보길 바란다", 0, 50, 0, 500);
    }



    public void EnterShop()
    {
        Console.Clear();
        DrawShop(0, 0);
        DrawGoldUI(75, 0);
        DrawShopUI(75, 5);
        GameManager.GM.DrawText(83, 7, " _         .         _", "");
        GameManager.GM.DrawText(83, 8, "(_______.-' '-._______)", "");
        GameManager.GM.DrawText(83, 9, "", "");
        GameManager.GM.DrawText(83, 10, "      [0]메인으로", "");
        GameManager.GM.DrawText(83, 11, " _______       _______", "");
        GameManager.GM.DrawText(83, 12, "(_      '-. .-'      _)", "");
        GameManager.GM.DrawText(83, 13, "           '", "");

        GameManager.GM.DrawText(83, 15, " _         .         _", "");
        GameManager.GM.DrawText(83, 16, "(_______.-' '-._______)", "");
        GameManager.GM.DrawText(83, 17, "", "");
        GameManager.GM.DrawText(83, 18, "      [1]거래하기", "");
        GameManager.GM.DrawText(83, 19, " _______       _______", "");
        GameManager.GM.DrawText(83, 20, "(_      '-. .-'      _)", "");
        GameManager.GM.DrawText(83, 21, "           '", "");
        Choice1();
    }

    public void Choice1()
    {
        playerInven = Program.inventory.InventoryGetSet;
        bool isSelect = false;
        Console.SetCursorPosition(75, 25);
        Console.Write("                          ");
        Console.SetCursorPosition(75, 25);
        Console.Write("선택지를 입력해주세요.: ");

        while (isSelect == false)
        {
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
                    Trade();
                    isSelect = true;
                }
                else
                {
                    Console.SetCursorPosition(75, 25);
                    Console.Write("                                               ");
                    Console.SetCursorPosition(75, 25);
                    Console.Write("올바른 값을 입력해주세요.: ");
                }
            }
        }
    }

    public void Trade()
    {
        Console.Clear();
        GameManager.GM.DrawText(2, 7, " _         .         _", "");
        GameManager.GM.DrawText(2, 8, "(_______.-' '-._______)", "");
        GameManager.GM.DrawText(2, 9, "", "");
        GameManager.GM.DrawText(2, 10, "       거래 하기", "");
        GameManager.GM.DrawText(2, 11, " _______       _______", "");
        GameManager.GM.DrawText(2, 12, "(_      '-. .-'      _)", "");
        GameManager.GM.DrawText(2, 13, "           '", "");

        GameManager.GM.DrawText(28, 0, "    ___                                                                             ___", "");
        GameManager.GM.DrawText(28, 1, "   {   }                                                                           {   }", "");
        GameManager.GM.DrawText(28, 2, " ___)_(___                                                                       ___)_(___", "");
        GameManager.GM.DrawText(28, 3, "|         |---------------------------------------------------------------------|         |", "");
        GameManager.GM.DrawText(28, 4, "|         |                                                                     |  -      |", "");
        GameManager.GM.DrawText(28, 5, "|        -|                                                                     |-        |", "");
        GameManager.GM.DrawText(28, 6, "|      -  |                                                                     |         |", "");
        GameManager.GM.DrawText(28, 7, "|         |                                                                     |  -      |", "");
        GameManager.GM.DrawText(28, 8, "|        -|                                                                     |         |", "");
        GameManager.GM.DrawText(28, 9, "|     -   |                                                                     |-        |", "");
        GameManager.GM.DrawText(28, 10, "|         |                                                                     |         |", "");
        GameManager.GM.DrawText(28, 11, "|         |                                                                     |   -     |", "");
        GameManager.GM.DrawText(28, 12, "|        -|                                                                     |         |", "");
        GameManager.GM.DrawText(28, 13, "|         |                                                                     |-        |", "");
        GameManager.GM.DrawText(28, 14, "|      -  |                                                                     |         |", "");
        GameManager.GM.DrawText(28, 15, "|         |                                                                     |  -      |", "");
        GameManager.GM.DrawText(28, 16, "|        -|                                                                     |         |", "");
        GameManager.GM.DrawText(28, 17, "|     -   |                                                                     |-        |", "");
        GameManager.GM.DrawText(28, 18, "|         |                                                                     |  -      |", "");
        GameManager.GM.DrawText(28, 19, "|        -|                                                                     |-        |", "");
        GameManager.GM.DrawText(28, 20, "|         |                                                                     |         |", "");
        GameManager.GM.DrawText(28, 21, "|     -   |                                                                     |  -      |", "");
        GameManager.GM.DrawText(28, 22, "|_________|---------------------------------------------------------------------|_________|", "");
        GameManager.GM.DrawText(28, 23, "    ) (                                                                             ) (", "");
        GameManager.GM.DrawText(28, 24, "   {___}                                                                           {___}", "");

        Choice1();
    }

    public void DrawGoldUI(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("*-------------------------------------*");
        Console.SetCursorPosition(x, y + 4);
        Console.Write("*-------------------------------------*");
        for (int i = 1; i < 4; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write("|");
            Console.SetCursorPosition(x + 38, y + i);
            Console.Write("|");
        }
        GameManager.GM.DrawText(x + 2, y + 2, $"현재 소지금은 {Program.player.Gold}골드입니다.", "yellow");
    }

    public void DrawShopUI(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write("*-------------------------------------*");
        Console.SetCursorPosition(x, y + 18);
        Console.Write("*-------------------------------------*");
        for (int i = 1; i < 18; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write("|");
            Console.SetCursorPosition(x + 38, y + i);
            Console.Write("|");
        }
    }

    public void DrawShop(int x, int y)
    {
        Console.SetCursorPosition(x, y + 0);
        Console.Write("                    _____  _   _  _____ ______ ");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("                   /  ___|| | | ||  _  || ___ @");
        Console.SetCursorPosition(x, y + 2);
        Console.Write("                   @ `--. | |_| || | | || |_/ /");
        Console.SetCursorPosition(x, y + 3);
        Console.Write("                    `--. @|  _  || | | ||  __/ ");
        Console.SetCursorPosition(x, y + 4);
        Console.Write("                   /@__/ /| | | |@ @_/ /| | || ");
        Console.SetCursorPosition(x, y + 5);
        Console.Write("                   @____/ @_| |_/ @___/ @_| ||");
        Console.SetCursorPosition(x, y + 6);
        Console.Write("                   ||    Fishing   shop     ||");
        Console.SetCursorPosition(x, y + 7);
        Console.Write("   ________________||_______________________||_____________");
        Console.SetCursorPosition(x, y + 8);
        Console.Write("  |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_||");
        Console.SetCursorPosition(x, y + 9);
        Console.Write("  |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|| /|");
        Console.SetCursorPosition(x, y + 10);
        Console.Write("  |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_||/||");
        Console.SetCursorPosition(x, y + 11);
        Console.Write("  |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|||/|");
        Console.SetCursorPosition(x, y + 12);
        Console.Write("  |_|_|_|_|_|_|_|_|_|     _      _     |_|_|_|_|_|_|_|_|_|_|/||");
        Console.SetCursorPosition(x, y + 13);
        Console.Write("  |_|               |    (_)    (_)    |      __         |_|/||");
        Console.SetCursorPosition(x, y + 14);
        Console.Write("  |_|.              |__________________|     (^^)  .     |_||/|");
        Console.SetCursorPosition(x, y + 15);
        Console.Write("  |_|*`.            |_|      ||      |_|     _)(_  I`.   |_|/||");
        Console.SetCursorPosition(x, y + 16);
        Console.Write("  |_| S `.          |_|      ||      |_|    /    @/| ;   |_||/|");
        Console.SetCursorPosition(x, y + 17);
        Console.Write("  |_|`. A `.        |_|      ||      |_|   // )_@@/      |_|/||");
        Console.SetCursorPosition(x, y + 18);
        Console.Write("  |_|  `. L `.      |_|     [||]     |_|   @|.//_)       |_||/|");
        Console.SetCursorPosition(x, y + 19);
        Console.Write("  |_|    `. E `.    |_|      ||      |_|     // /        |_|/||");
        Console.SetCursorPosition(x, y + 20);
        Console.Write("  |_|______`__*_`___|_|      ||      |_|_____@@|_________|_||/|");
        Console.SetCursorPosition(x, y + 21);
        Console.Write("  |_|_|_|_|_|_|_|_|_|_|______||______|_|_|_|_|_|_|_|_|_|_|_|/||");
        Console.SetCursorPosition(x, y + 22);
        Console.Write("__|_|_|_|_|_|_|_|_|_|_|______||______|_|_|_|_|_|_|_|_|_|_|_||/________");
        Console.SetCursorPosition(x, y + 23);
        Console.Write(" /     /     /     /     /     /     /     /     /     /     /     /");
        Console.SetCursorPosition(x, y + 24);
        Console.Write("/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/");
        Console.SetCursorPosition(x, y + 25);
        Console.Write("_______________________________________________________________");
    }

    void SellItem(Inventory.Item sellitem)
    {

        Program.player.Gold += (int)(sellitem.Gold * 0.8f);

        sellitem = null;
    }

    void BuyItem(Inventory.Item buyItem)
    {
        Player player = Program.player; // 플레이어

        // 빈자리에 추가 
        for (int i = 0; i < playerInven.Length; i++)
        {
            if (playerInven[i] == null)
            {
                Program.player.Gold -= buyItem.Gold;
                playerInven[i] = buyItem;
                return;
            }
        }
        // 꽉찼으면

        Console.WriteLine("인벤토리가 꽉 찼습니다.");


    }
}
