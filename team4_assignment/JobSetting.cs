using System;
namespace team4_assignment
{
    public class JobSetting
    {
        Entrance entrance = new Entrance();


        public JobSetting()
        {

        }

        private class JobInfo
        {
            public string Name { get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int Gold { get; set; }
        }

        private JobInfo[] jobInfos = new JobInfo[] // 직업 종류와 능력치
        {
            new JobInfo { Name = "횟집 사장", Atk =7 , Def = 7, Gold = 1500 },
            new JobInfo { Name = "전문 낚시꾼", Atk = 10, Def = 4, Gold = 1500},
            new JobInfo { Name = "해양 경찰", Atk = 5, Def = 9, Gold = 1500 },
            new JobInfo { Name = "참치그룹 회장", Atk = 1, Def = 2, Gold = 2000}
        };

        public void ChoiceJob()
        {
            Console.Clear();
            Console.WriteLine("원하시는 직업을 선택하세요.\n");

            for (int i = 0; i < jobInfos.Length; i++) //직업 수 만큼 앞 보기 숫자가 늘어나며 선택지 증가. 
            {
                Console.WriteLine($"{i + 1}. {jobInfos[i].Name} ( 공격력 : {jobInfos[i].Atk} , 방어력 : {jobInfos[i].Def} , 소지 금화 : {jobInfos[i].Gold} G)");
            }

            int optionNum = jobInfos.Length;
            int input = GameManager.GM.SelectOption(optionNum, false, "");

            if (input >= 1 && input <= jobInfos.Length)
            {
                string jobName = jobInfos[input - 1].Name;
                int jobAtk = jobInfos[input - 1].Atk;
                int jobDef = jobInfos[input - 1].Def;
                int jobGold = jobInfos[input - 1].Gold;

                Console.Clear();
                Console.WriteLine($"당신이 선택한 직업은 {jobName}입니다.\n");
                Console.WriteLine("1. 확인 \n2. 다시 선택");

                Program.player.Job = jobName; // 직업 선택 시 player 상태보기에서 직업 이름이 입력됨.
                Program.player.Atk = jobAtk;
                Program.player.Def = jobDef;
                Program.player.Gold = jobGold;

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
            else
            {
                Console.WriteLine("입력 값을 다시 확인해주세요.");
                ChoiceJob();
            }
        }
    }

}