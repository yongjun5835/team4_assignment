class Inventory

{


    Item[] inventory;
    Item[] inventoryPotion;

    public Inventory()
    {
        inventory = new Item[10];

        inventory[0] = new Item(name: "무쇠 갑옷", atk: 0, def: 5, desc: "아주 오래 된 무쇠 갑옷이다.", hp: 0, qu: 0);
        inventory[1] = new Item(name: "낡은 검", atk: 10, def: 0, desc: "낡은 검이다.", hp: 0, qu: 0);


        inventoryPotion = new Item[5];

        inventoryPotion[0] = new Item(name: "Hp포션", atk: 0, def: 0, desc: "Hp를 30회복한다.", hp: 30, qu: 3);
    }

    static void Equipitem(Item item)
    {
        item.isEquiped = true;
    }
    static void Unequopitem(Item item)
    {
        item.isEquiped = false;
    }

    class Item
    {
        public string Name;
        public int Atk;
        public int Def;
        public string Desc;
        public int Hp;
        public int Quantity;

        public bool isEquiped;

        public Item(string name, int atk, int def, string desc, int hp, int qu)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Desc = desc;
            Hp = hp;
            Quantity = qu;
            isEquiped = false;
        }

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

            Console.WriteLine($" {inventory[i].Name,-8}| 방어력 : {inventory[i].Def,-3} | {inventory[i].Desc}");
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
                InventoryEquipManagement();
                break;
        }
    }

    public void InventoryEquipManagement() //장착관리
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

            Console.WriteLine($" {inventory[i].Name,-8}| 방어력 : {inventory[i].Def,-3} | {inventory[i].Desc}");
        }
        Console.WriteLine();
        Console.WriteLine("0. 뒤로가기");

        //장착
        string input = Console.ReadLine();
        if(int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                InventoryEquip();
            }
            else if(x >= 0 && x<= 5)
            {
                Item item = inventory[x -1];
                if (item.isEquiped)
                {
                    Unequopitem(item);
                }
                else
                {
                    Equipitem(item);
                }
                InventoryEquipManagement();
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
        //1번 입력시 갯수 - hp30회복시키기


    }

}