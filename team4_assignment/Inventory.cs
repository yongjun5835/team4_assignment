class Inventory

{


    Item[] inventory;

    public Inventory()
    {
        inventory = new Item[10];

        inventory[0] = new Item(name: "무쇠 갑옷", atk: 0, def: 5, desc: "아주 오래 된 무쇠 갑옷이다.", hp: 0, qu: 0);
        inventory[1] = new Item(name: "낡은 검", atk: 10, def: 0, desc: "낡은 검이다.", hp: 0, qu: 0);
        inventory[2] = new Item(name: "Hp포션", atk: 0, def: 0, desc: "Hp를 30회복한다.", hp: 30, qu: 3);

    }
    class Item
    {
        public string Name;
        public int Atk;
        public int Def;
        public string Desc;
        public int Hp;
        public int Quantity;

        public Item(string name, int atk, int def, string desc, int hp, int qu)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Desc = desc;
            Hp = hp;
            Quantity = qu;
        }
    }


    public void DisplayInventory()
    {
        Console.Clear();
        Console.WriteLine("[인벤토리]");
        Console.WriteLine();
        Console.WriteLine("1. 장비아이템"); //장비
        Console.WriteLine("2. 소비아이템"); //물약 
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
        Console.WriteLine($" {inventory[0].Name,-8}| 방어력 : {inventory[0].Def,-3} | {inventory[0].Desc}");
        Console.WriteLine($" {inventory[1].Name,-8}| 공격력 : {inventory[1].Atk,-3} | {inventory[1].Desc}");
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
        Console.WriteLine($" {inventory[0].Name,-8}| 방어력 : {inventory[0].Def,-3} | {inventory[0].Desc}");
        Console.WriteLine($" {inventory[1].Name,-8}| 공격력 : {inventory[1].Atk,-3} | {inventory[1].Desc}");
        Console.WriteLine();
        Console.WriteLine("0. 뒤로가기");

        int optionNum = 1;
        int input = GameManager.GM.SelectOption(optionNum, false, "");
        switch (input)
        {
            case 1:
                InventoryEquipManagement();
                break;
        }
    }




    public void InventoryConsumption() // 물약
    {
        Console.Clear();

        Console.WriteLine("[인벤토리_소비아이템]");
        Console.WriteLine();
        Console.WriteLine($" 1. {inventory[2].Name,-5} | {inventory[2].Desc} | 남은 갯수 : {inventory[2].Quantity}");
        Console.WriteLine();
        Console.WriteLine("1. 사용하기");
        Console.WriteLine("0. 뒤로가기");
        //1번 입력시 갯수 - hp30회복시키기


        int optionNum = 1;
        int input = GameManager.GM.SelectOption(optionNum, false, "");
        switch (input)
        {
            case 1:
                InventoryEquipManagement();
                break;
        }
    }

}