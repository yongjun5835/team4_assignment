using System;
namespace team4_assignment;
class Inventory
{


    Player player = new Player();
    Item[] inventory;
    Item[] inventoryPotion;

    public Inventory()
    {
        inventory = new Item[10];

        inventory[0] = new Item(name: "무쇠 갑옷", atk: 0, def: 5, desc: "아주 오래 된 갑옷이다.", hp: 0, qu: 0, critModifier: 0, dodgeModifier: 0);
        inventory[1] = new Item(name: "낡은 검", atk: 10, def: 0, desc: "낡은 검이다.", hp: 0, qu: 0, critModifier: 0, dodgeModifier: 0);


        inventoryPotion = new Item[5];

        inventoryPotion[0] = new Item(name: "Hp포션", atk: 0, def: 0, desc: "Hp를 30회복한다.", hp: 30, qu: 3, critModifier: 0, dodgeModifier: 0) ;
    }

    static void EquipItem(Item item, Player player)
    {
        item.isEquiped = true;
        player.Atk += item.Atk; 
    }

    static void UnequopItem(Item item, Player player)
    {
        item.isEquiped = false;
        player.Atk -= item.Atk; 
    }

    public void DisplayInventory()
    {
        Console.Clear();
        Console.WriteLine("[인벤토리]");
        Console.WriteLine();
        Console.WriteLine("1. 장비아이템"); //장비
        Console.WriteLine("2. 회복아이템"); //물약 
        Console.WriteLine();
        Console.WriteLine("0. 뒤로가기");

        int optionNum = 2;
        int input = GameManager.GM.SelectOption(optionNum, false, "");
        switch (input)
        {
            case 1:
                InventoryEquip();
                break;
            case 2:
                InventoryConsumption();
                break;
        }
    }

    public void InventoryEquip() //장착아이템 목록
    {
        Console.Clear();
        Console.WriteLine("[인벤토리_장비아이템]");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine();
        // 아이템
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                break;

            if (inventory[i].isEquiped)
                Console.Write("[E]");

            Console.WriteLine($" {inventory[i].Name,-8} | 공격력 {inventory[i].Atk, -3} | 방어력{inventory[i].Def,-3} | {inventory[i].Desc}");
        }
        Console.WriteLine();
        Console.WriteLine("1. 장착관리");
        Console.WriteLine("0. 뒤로가기");

        int optionNum = 2
            ;
        int input = GameManager.GM.SelectOption(optionNum, false, "");
        switch (input)
        {
            case 1:
                InventoryEquipManagement(player);
                break;
        }
    }

    public void InventoryEquipManagement(Player player)
    {
        Console.Clear();
        Console.WriteLine("[인벤토리_장비아이템]");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine();

        // 아이템
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                break;

            Console.Write(i + 1 + "");
            if (inventory[i].isEquiped)
                Console.Write("[E]");

            Console.WriteLine($" {inventory[i].Name,-8} | 공격력 {inventory[i].Atk,-3} | 방어력 : {inventory[i].Def,-3} | {inventory[i].Desc}");
        }
        Console.WriteLine();
        Console.WriteLine("0. 뒤로가기");

        int optionNum = inventory.Length + 1; 
        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                InventoryEquip();
            }
            else if (x >= 1 && x <= optionNum)
            {
                Item item = inventory[x - 1];
                if (item.isEquiped)
                {
                    UnequopItem(item, player);
                }
                else
                {
                    EquipItem(item, player);
                }
                InventoryEquipManagement(player);
            }
        }
    }




    public void InventoryConsumption() // 물약
    {
        Console.Clear();

        Console.WriteLine("[인벤토리_회복아이템]");
        Console.WriteLine();
        for (int i = 0; i < inventoryPotion.Length; i++)
        {
            if (inventoryPotion[i] == null)
                break;

            Console.Write(i + 1 + "");
            Console.WriteLine($" {inventoryPotion[0].Name,-5} | {inventoryPotion[0].Desc,-3}  (남은 갯수 : {inventoryPotion[0].Quantity})");
        }
        Console.WriteLine();
        Console.WriteLine("1. 사용하기");
        Console.WriteLine("0. 뒤로가기");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 1)
            {
                InventoryConsumption();
            }
        }
        //1번 입력시 갯수 - hp30회복시키기


    }

}