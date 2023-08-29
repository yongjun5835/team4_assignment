using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace team4_assignment;

internal class StageSelectScene
{
    public void StageSelect()
    {
        Console.Clear();

        string canEnter2 = (Program.fightScene.clearLevel >= 1) ? "[입장가능]" : "[입장불가]";
        string canEnter3 = (Program.fightScene.clearLevel >= 2) ? "[입장가능]" : "[입장불가]";

        Console.WriteLine("[입장가능] 1. 세 마리의 생선과 전투를 합니다!");
        Console.WriteLine($"{canEnter2} 2. 네 마리의 생선과 전투를 합니다!");
        Console.WriteLine($"{canEnter3} 3. 다섯 마리의 생선과 전투를 합니다!");
        Console.WriteLine("");

        bool isSelect = false;
        Console.SetCursorPosition(0, 28);
        Console.Write("선택지를 입력해주세요.: ");
        while (isSelect == false)
        {
            string key = Console.ReadLine();

            if (key == "1")
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