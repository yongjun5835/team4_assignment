using System;
namespace team4_assignment
{
    public class JobSetting
    {
        Entrance entrance = new Entrance();

        public JobSetting()
        {

        }

        public void ChoiceJob()
        {
            Console.Clear();
            Console.WriteLine("원하시는 직업을 선택하세요.\n");
            Console.WriteLine("1.궁수 2.전사 3.마법사 \n");

            int optionNum = 3;
            int input = GameManager.GM.SelectOption(optionNum, false, "");

            string jobName = "";
            int jobAtk = 0;
            int jobDef = 0;
            
            switch (input)
            {
                case 1:
                    jobName = "궁수";
                    jobAtk = 7;
                    jobDef = 7;
                    break;
                case 2:
                    jobName = "전사";
                    jobAtk = 10;
                    jobDef = 4;
                    break;
                case 3:
                    jobName = "마법사";
                    jobAtk = 5;
                    jobDef = 9;
                    break;
                default:
                    Console.WriteLine("입력 값을 다시 확인해주세요.");
                    ChoiceJob();
                    return;
            }
            Console.Clear();
            Console.WriteLine($"당신의 직업은 {jobName}입니다.");
            Console.WriteLine("1. 입장 하기 \n2. 직업 다시 고르기");

            Program.player.Job = jobName; // 직업 선택 시 player 상태보기에서 직업 이름이 입력됨.
            Program.player.Atk = jobAtk; 
            Program.player.Def = jobDef;

            int choiceInput = GameManager.GM.SelectOption(2, false);

            if (choiceInput == 1)
            {

                entrance.EntranceUI();
            }
            else if (choiceInput == 2)
            {
                ChoiceJob();
            }
            
        }        
    }
}

