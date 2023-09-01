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
            new JobInfo { Name = "횟집 사장", Atk = 10 , Def = 10, Gold = 1500 },
            new JobInfo { Name = "전문 낚시꾼", Atk = 13, Def = 7, Gold = 1500},
            new JobInfo { Name = "해양 경찰", Atk = 8, Def = 12, Gold = 1500 },
            new JobInfo { Name = "참치그룹 회장", Atk = 4, Def = 6, Gold = 2500}
        };

        public void ChoiceJob()
        {
            string JobBG1 = "        _ ^ _ ";
            string JobBG2 = "       '_\\V/o` ";
            string JobBG3 = "       ' oX`'`                            ";
            string JobBG4 = "          X             -TUNA♥!";
            string JobBG5 = "          X                                              ~ .";
            string JobBG6 = "          X            ^                                   |\\";
            string JobBG7 = "          X        \\O/)  `                                 |_\\";
            string JobBG8 = "          X.a##a.   M      `                             __|__\\";
            string JobBG9 = "       .aa########a.>>       `                           \\   /";
            string JobBG10 = "~~~~~~~~~~~~~~~~~~~~~~~~ ~~~~~ ~ ~~~~~~~~~ ~~~~~~~~~~~~~~~~~~~~~~~";
            string JobBG11 = "            _\\_   o             ¿      .";
            string JobBG12 = ">('>     \\\\/  *\\ .               ____//(_____//    ";
            string JobBG13 =  "         //\\___=                 >'____))__v--\\     >('>";
        

            string line = ("---------------------------------------------------------------------------------");

            int optionNum = jobInfos.Length;
            int input = 0;
            while (input < 1 || input > optionNum)
            {
                Console.Clear();
                GameManager.GM.MakeUI();
                GameManager.GM.DrawText(27, 2, "원하시는 직업을 선택하세요.", "white");
                GameManager.GM.DrawText(2, 4, ($"{line}\n"), "white");
                GameManager.GM.DrawText(2, 5, ($"\n"), "white");

                for (int i = 0; i < jobInfos.Length; i++) //직업 수 만큼 앞 보기 숫자가 늘어나며 선택지 증가. 
                {
                    Console.WriteLine($"\t{i + 1}. {jobInfos[i].Name} ( 공격력 : {jobInfos[i].Atk} , 방어력 : {jobInfos[i].Def} , 소지 금화 : {jobInfos[i].Gold} G)");
                }
                GameManager.GM.DrawText(2, 11, ($"{line}"), "white");

                GameManager.GM.DrawText(6, 12, ($"{JobBG1}"), "");
                GameManager.GM.DrawText(6, 13, ($"{JobBG2}"), "");
                GameManager.GM.DrawText(6, 14, ($"{JobBG3}"), "");
                GameManager.GM.DrawText(6, 15, ($"{JobBG4}"), "");
                GameManager.GM.DrawText(6, 16, ($"{JobBG5}"), "");
                GameManager.GM.DrawText(6, 17, ($"{JobBG6}"), "");
                GameManager.GM.DrawText(6, 18, ($"{JobBG7}"), "");
                GameManager.GM.DrawText(6, 19, ($"{JobBG8}"), "");
                GameManager.GM.DrawText(6, 20, ($"{JobBG9}"), "");
                GameManager.GM.DrawText(6, 21, ($"{JobBG10}"), "blue");
                GameManager.GM.DrawText(6, 22, ($"{JobBG11}"), "");
                GameManager.GM.DrawText(6, 23, ($"{JobBG12}"), "");
                GameManager.GM.DrawText(6, 24, ($"{JobBG13}"), "");
                GameManager.GM.DrawText(2, 26, "  ", " ");
                GameManager.GM.DrawText(0, 27, "원하시는 선택지를 입력해주세요.\n", "");





                //Console.WriteLine("원하시는 직업을 선택하세요.\n");



                if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > optionNum)
                {
                    Console.WriteLine("입력 값을 다시 확인해주세요.");
                }
            }   
                    string jobName = jobInfos[input - 1].Name;
                    int jobAtk = jobInfos[input - 1].Atk;
                    int jobDef = jobInfos[input - 1].Def;
                    int jobGold = jobInfos[input - 1].Gold;

                    //Console.Clear();
                    //Console.WriteLine($"당신이 선택한 직업은 {jobName} 입니다.\n");
                    //Console.WriteLine("1. 확인 \n2. 다시 선택");
                    Console.Clear();
                    GameManager.GM.MakeUI();
                    GameManager.GM.DrawText(23, 12, ($"당신이 선택한 직업은 {jobName} 입니다."), "yellow");
                    GameManager.GM.DrawText(2, 22, ($"{line}\n"), "white");
                    GameManager.GM.DrawText(2, 23, "1. 확인 2. 다시 선택", "");
                    GameManager.GM.DrawText(2, 26, " ", "");

                    Program.player.Job = jobName; // 직업 선택 시 player 상태보기에서 직업 이름이 입력됨. (이하 공격력, 방어력, 골드 변동).
                    Program.player.Atk = jobAtk;
                    Program.player.Def = jobDef;
                    Program.player.Gold = jobGold;

                    bool isSelect = false;
                    while (isSelect == false)
                    {
                        int inputNum = 2;
                        int choiceInput = GameManager.GM.SelectOption(inputNum, false);
                        switch (choiceInput)
                        {
                            case 1:
                                entrance.EntranceUI();
                                isSelect = true;
                                break;
                            case 2:
                                ChoiceJob();
                                isSelect = true;
                                break;
                            default:
                                break;

                        }
                    }
        }
    }
}
    