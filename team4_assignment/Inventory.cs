﻿using System;
using System.Numerics;

class Inventory

{

    public Player Player;
    Item[] inventory;
    Item[] inventoryPotion;
    private int ItemCount;


    public Item[] InventoryGetSet { get { return inventory; }set { inventory = value; } }






    public Inventory()
    {
        inventory = new Item[10];

        inventory[0] = new Item(name: "|     앞치마    ", atk: 0, def: 20, desc: "방어력을 올려준다고? 오케이~", hp: 0,mp:0, qu: 0, gold: 500);;
        inventory[1] = new Item(name: "| 주방에 있던 칼", atk: 80, def: 0, desc: "물고기랑 싸우려면 일단 들고가자..", hp: 0, mp: 0, qu: 0, gold: 1000);


        inventoryPotion = new Item[5];

        inventoryPotion[0] = new Item(name: "Hp포션", atk: 0, def: 0, desc: "Hp를 30회복한다.", hp: 30, mp: 0, qu: 3, gold: 100);
        inventoryPotion[1] = new Item(name: "Mp포션", atk: 0, def: 0, desc: "Mp를 30회복한다.", hp: 0, mp: 30, qu: 3, gold: 100);
    }

    static void Equipitem(Item item)

    {
        Player player = new Player();

        item.isEquiped = true;

            
            Program.player.Atk += item.Atk;
            Program.player.Def += item.Def;
    }
    static void Unequopitem(Item item)
    {
        item.isEquiped = false;

        Player player = new Player(); 
        Program.player.Atk -= item.Atk;
        Program.player.Def -= item.Def;
    }
    public void AddQuantity1(int index, int amount)//HP포션
    {


        inventoryPotion[index].Quantity += amount;
        Console.SetCursorPosition(2, 11);
        Console.WriteLine("Hp포션이 드랍 되었습니다!");

    }
    public void AddQuantity2(int index, int amount) //MP포션
    {
        inventoryPotion[index].Quantity += amount;
        Console.SetCursorPosition(2, 11);
        Console.WriteLine("Mp포션이 드랍 되었습니다!");
    }
    public void DropItem()//스테이지 아이템 드랍
    {
        Random random = new Random();
        int itemType = 1;

        if (random.Next(1, 10) == itemType)
        {
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("-------------------------------------");
            Item droppedItem = new Item(name: "아무짝에도 쓸모없는 비늘", atk: 0, def: 1, desc: "장식용인가..", hp: 0, mp: 0, qu: 1, gold:10);

            
            bool isAlreadyOwned = inventory.Any(item => item != null && item.Name == droppedItem.Name);//중복드랍 체크
            if (!isAlreadyOwned)
            {
                Console.SetCursorPosition(2, 10);
                Console.WriteLine($"몬스터가 아이템을 떨어뜨렸습니다: {droppedItem.Name}");

                AddItem(droppedItem);
            }



        }
    }
    public void AddItem(Item item)//아이템 추가
    {
        for (int index = 0; index < inventory.Length; index++)
        {
            if (inventory[index] == null) // 비여있는 슬롯 체크
            {
                inventory[index] = item;
                ItemCount++;
                return;
            }
        }
    }
    public class Item
    {

        private int quantity;
        public string Name;
        public int Atk;
        public int Def;
        public string Desc;
        public int Hp;
        public int Quantity { get { return quantity; }set{ quantity = value; } }
        public int Mp;
        int gold; //
        public int Gold { get { return gold; } set { gold = value; } } //

        public bool isEquiped;

        public Item(string name, int atk, int def, string desc, int hp, int mp,int qu,int gold)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Desc = desc;
            Hp = hp;
            Mp = mp;
            Quantity = qu;
            this.gold = gold; // 
            isEquiped = false;
        }

    }


    public void DisplayInventory()
    {
        Console.Clear();
        GameManager.GM.MakeUI();
        GameManager.GM.DrawText(35, 2, "[인벤토리]", "white");
        GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
        GameManager.GM.DrawText(2, 6, "1. 장비아이템", "white");
        GameManager.GM.DrawText(2, 7, "2. 회복아이템", "white");
        GameManager.GM.DrawText(2, 22, "---------------------------------------------------------------------------------\n", "white");
        GameManager.GM.DrawText(2, 23, "0. 뒤로가기", "white");
        GameManager.GM.DrawText(2, 26, " ", "");
        GameManager.GM.DrawText(0, 27, "원하시는 선택지를 입력해주세요.\n", "");

        //Console.Clear();
        //Console.WriteLine("[인벤토리]");
        //Console.WriteLine();
        //Console.WriteLine("1. 장비아이템"); //장비
        //Console.WriteLine("2. 회복아이템"); //물약 
        //Console.WriteLine();
        //Console.WriteLine("0. 뒤로가기");
        while (true)
        {
            int optionNum = 2;
            int input = GameManager.GM.SelectOption(optionNum, true, "");
            switch (input)
            {
                case 0:
                    Program.entrance.EntranceUI();
                    break;
                case 1:
                    InventoryEquip();
                    break;
                case 2:
                    InventoryConsumption();
                    break;
                default:
                    break;
            }
        }
    }

    public void InventoryEquip() //장착아이템 목록
    {
        while (true)
        {
            Console.Clear();
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(30, 2, "[인벤토리 - 장비아이템]", "white");
            GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
            GameManager.GM.DrawText(2, 6, "[아이템 목록]\n\n", "white");
     
            //Console.Clear();
            //Console.WriteLine("[인벤토리_장비아이템]");
            //Console.WriteLine();
            //Console.WriteLine("[아이템 목록]");
            //Console.WriteLine();
            // 아이템
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                    break;

                if (inventory[i].isEquiped)
                    Console.Write("|" + "\u001b[31m[E]\u001b[0m");

                Console.WriteLine($"{inventory[i].Name,-8} | 공격력 : {inventory[i].Atk,-3}| 방어력 : {inventory[i].Def,-3}|{inventory[i].Desc}");
            }

            GameManager.GM.DrawText(2, 20, "---------------------------------------------------------------------------------\n", "white");
            GameManager.GM.DrawText(2, 22, "1. 장착관리", "white");
            GameManager.GM.DrawText(2, 23, "0. 뒤로가기", "white");
            GameManager.GM.DrawText(2, 26, " ", "");

            //Console.WriteLine();
            //Console.WriteLine("1. 장착관리");
            //Console.WriteLine("0. 뒤로가기");

            int optionNum = 1;
            int input = GameManager.GM.SelectOption(optionNum, true);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                case 1:
                    InventoryEquipManagement();
                    break;
                default:
                    break;
               

            }
        }
    }

    public void InventoryEquipManagement() //장착관리
    {
        Console.Clear();
        GameManager.GM.MakeUI();
        GameManager.GM.DrawText(25, 2, "[인벤토리 - 장비아이템_장착관리]", "white");
        GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
        GameManager.GM.DrawText(2, 6, "[아이템 목록]\n\n", "white");
        //Console.Clear();
        //Console.WriteLine("[인벤토리_장비아이템]");
        //Console.WriteLine();
        //Console.WriteLine("[아이템 목록]");
        //Console.WriteLine();

        // 아이템
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                break;

            Console.Write(i + 1 + ". ");
            if (inventory[i].isEquiped)
                Console.Write("|"+"\u001b[31m[E]\u001b[0m");

            Console.WriteLine($"{inventory[i].Name,-8} | 공격력 : {inventory[i].Atk,-3}| 방어력 : {inventory[i].Def,-3}|{inventory[i].Desc}");

        }

        GameManager.GM.DrawText(2, 20, "---------------------------------------------------------------------------------\n", "white");
        GameManager.GM.DrawText(2, 22, "(아이템 번호 입력 - 장착, 재입력 - 해제)", "blue");
        GameManager.GM.DrawText(2, 23, "0. 뒤로가기", "white");
        GameManager.GM.DrawText(2, 26, " ", "");
        GameManager.GM.DrawText(0, 27, "원하시는 선택지를 입력해주세요.\n", "");
        //Console.WriteLine();
        //Console.WriteLine("0. 뒤로가기");
        //Console.WriteLine();


        //장착
        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                InventoryEquip();
            }
            else if (x >= 1 && x <= inventory.Length)
            {
                Item item = inventory[x - 1];
                if (item == null)
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    InventoryEquipManagement();
                }
                else
                {
                    if (item.isEquiped)
                    {
                        Unequopitem(item);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("아이템이 해제되었습니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Equipitem(item);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("아이템이 장착되었습니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                    }
                    InventoryEquipManagement();
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1300);
            }
        }
    }
    public void InventoryConsumption() // 물약
    {

        Console.Clear();
        GameManager.GM.MakeUI();
        GameManager.GM.DrawText(30, 2, "[인벤토리 - 회복아이템]", "white");
        GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
        GameManager.GM.DrawText(2, 6, "[아이템 목록]\n\n", "white");
        //Console.Clear();

        //Console.WriteLine("[인벤토리_회복아이템]");
        //Console.WriteLine();
        for (int i = 0; i < inventoryPotion.Length; i++)
        {
            if (inventoryPotion[i] == null)
                break;

            Console.Write("| "+ (i + 1) + ".");
            Console.WriteLine($"   {inventoryPotion[i].Name,-5}  |  {inventoryPotion[i].Desc,-3}  |  ( 남은 갯수 : \u001b[32m{inventoryPotion[i].Quantity}\u001b[0m )");
        }
        GameManager.GM.DrawText(2, 23, "0. 뒤로가기", "white");
        GameManager.GM.DrawText(2, 26, " ", "");
        GameManager.GM.DrawText(0, 27, "원하시는 선택지를 입력해주세요.\n", "");
        //Console.WriteLine();
        //Console.WriteLine("0. 뒤로가기");

        //포션 사용!
        string input = Console.ReadLine();
        if (int.TryParse(input, out int x))
        {
            if (x == 0)
            {
                DisplayInventory();
            }
            else if (x == 1)
            {
                if (inventoryPotion[0].Quantity > 0)
                {
                    int healAmount = inventoryPotion[0].Hp;

                    // 현재 체력 + 회복량이 최대 체력(MaxHp)를 넘지 않도록 처리
                    int maxHealAmount = Program.player.MaxHp - Program.player.Hp;
                    if (healAmount > maxHealAmount)
                    {
                        healAmount = maxHealAmount;
                    }

                    // 체력 회복 및 물약 수량 감소
                    Program.player.Hp += healAmount;
                    inventoryPotion[0].Quantity--;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("물약을 사용하셨습니다.");
                    Console.ResetColor();
                    Thread.Sleep(1300);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("남은 물약이 없습니다.");
                    Console.ResetColor();
                    Thread.Sleep(1300);
                }

            }
            else if (x == 2)
            {
                if (inventoryPotion[1].Quantity > 0)
                {
                    int healAmount = inventoryPotion[1].Mp;

                    // 현재 체력 + 회복량이 최대 체력(MaxHp)를 넘지 않도록 처리
                    int maxHealAmount = Program.player.MaxMp - Program.player.Mp;
                    if (healAmount > maxHealAmount)
                    {
                        healAmount = maxHealAmount;
                    }

                    // 체력 회복 및 물약 수량 감소
                    Program.player.Mp += healAmount;
                    inventoryPotion[1].Quantity--;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("물약을 사용하셨습니다.");
                    Console.ResetColor();
                    Thread.Sleep(1300);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("남은 물약이 없습니다.");
                    Console.ResetColor();
                    Thread.Sleep(1300);
                }

            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1300);
            }
            InventoryConsumption();
        }
    }
}