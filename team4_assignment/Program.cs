﻿
using team4_assignment;

internal class Program
{ 
    static void Main(string[] args)
    {
        new GameManager();
        Entrance entrance = new Entrance();

        Character character = new Character();

        character.InputName();// 캐릭터 생성기능
        string userName = character.UserName;


    }
}
