﻿
using team4_assignment;

internal class Program
{ 
    static void Main(string[] args)
    {
        new GameManager();
        Character character = new Character();
        character.InputName();// 캐릭터 생성기능
        string userName = character.UserName;

    }

    public static FightScene fightScene = new FightScene();
    public static Player player = new Player();
    public static Entrance entrance = new Entrance();
    public static StageSelectScene stageSelectScene = new StageSelectScene();
    public static BossScene bossScene = new BossScene();
    public static Shop shop = new Shop();
    public static Inventory inventory = new Inventory(); 
}
