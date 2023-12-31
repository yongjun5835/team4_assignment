﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class StageSelectScene
{
    public void StageSelect()
    {

        string dungeon1 = ":::::::::  :::    ::: ::::    :::  ::::::::  ::::::::::  ::::::::  ::::    ::: ";
        string dungeon2 = ":+:    :+: :+:    :+: :+:+:   :+: :+:    :+: :+:        :+:    :+: :+:+:   :+: ";
        string dungeon3 = "+:+    +:+ +:+    +:+ :+:+:+  +:+ +:+        +:+        +:+    +:+ :+:+:+  +:+ ";
        string dungeon4 = "+#+    +:+ +#+    +:+ +#+ +:+ +#+ :#:        +#++:++#   +#+    +:+ +#+ +:+ +#+ ";
        string dungeon5 = "+#+    +#+ +#+    +#+ +#+  +#+#+# +#+   +#+# +#+        +#+    +#+ +#+  +#+#+# ";
        string dungeon6 = "#+#    #+# #+#    #+# #+#   #+#+# #+#    #+# #+#        #+#    #+# #+#   #+#+# ";
        string dungeon7 = "#########   ########  ###    ####  ########  ##########  ########  ###    #### ";

        Entrance entrance = new Entrance();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{dungeon1}\n{dungeon2}\n{dungeon3}\n{dungeon4}\n{dungeon5}\n{dungeon6}\n{dungeon7}\n\n\n");
        Console.ResetColor();
        Console.WriteLine("---------------------------------------------------------------------------------\n");
        string canEnter2 = (Program.fightScene.clearLevel >= 1) ? "[입장가능]" : "[입장불가]";
        string canEnter3 = (Program.fightScene.clearLevel >= 2) ? "[입장가능]" : "[입장불가]";

        Console.WriteLine("[입장가능] 1. 세 마리의 생선과 전투를 합니다!");
        Console.WriteLine($"{canEnter2} 2. 네 마리의 생선과 전투를 합니다!");
        Console.WriteLine($"{canEnter3} 3. 다섯 마리의 생선과 전투를 합니다!");
        Console.WriteLine("");
        Console.ForegroundColor = (Program.fightScene.clearLevel >= 2) ? ConsoleColor.Blue : ConsoleColor.Red;
        Console.Write($"{canEnter3}[보스]");
        Console.ResetColor();
        Console.Write(" 4. 자이언트참치 잡으러 가기");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------------------------------------------\n");
        Console.WriteLine("0. 뒤로가기");

        bool isSelect = false;
        Console.SetCursorPosition(0, 26);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();
            if (key == "0")
            {
                entrance.EntranceUI();
              
            }
            else if (key == "1")
            {
                Program.fightScene.stageLevel = 1;
                Program.fightScene.Restart();
                Program.fightScene.StartPhase();
                isSelect = true;
            }
            else if (key == "2" && Program.fightScene.clearLevel >= 1)
            {
                Program.fightScene.stageLevel = 2;
                Program.fightScene.Restart();
                Program.fightScene.StartPhase();
                isSelect = true;
            }
            else if (key == "3" && Program.fightScene.clearLevel >= 2)
            {
                Program.fightScene.stageLevel = 3;
                Program.fightScene.Restart();
                Program.fightScene.StartPhase();
                isSelect = true;
            }
            else if (key == "4" && Program.fightScene.clearLevel >= 2)
            {
                Program.bossScene.StartPhase();
                isSelect = true;
            }
            else
            {
                Console.SetCursorPosition(0, 28);
                Console.Write("                                               ");
                Console.SetCursorPosition(0, 28);
                Console.Write("올바른 값을 입력해주세요.: ");
            }
        }
    }
}