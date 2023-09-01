using System;
namespace team4_assignment
{
	public class Character
	{
        
        JobSetting jobSetting = new JobSetting();
        public string UserName { get; set; }
        string BG1 = ("                                        |");
        string BG2 = ("                                      \\ _ /");
        string BG3 = ("                                    -= (_) =-");
        string BG4 = ("                                      /   \\");
        string BG5 = ("                                        | ");

        string BGa = ("    .\\/.                                  ");
        string BGb = (".\\\\//o\\\\                      ,\\/.                      ,~~");
        string BGc = ("//o\\\\|,\\/.   ,.,.,   ,\\/.  ,\\//o\\\\                     |\\");
        string BGd = ("  |  |//o\\  /###/#\\  //o\\  /o\\\\|                      /| \\");
        string BGe = ("^^|^^|^~|^^^|' '|:|^^^|^^^^^|^^|^^^\"\"\"\"\"\"\"\"(\"~~~~~~~~/_|__\\~~~~~~~~~~");
        string BGf = (" .|'' . |  '''\"\"'\"''. |`===`|''  '\"\" \"\" \" (\" ~~~~ ~ ~======~~  ~~ ~");
        string BGg = (" ^^ ^^   ^^^ ^ ^^^ ^^^^ ^^^ ^^ ^^ \"\" \"\"\"( \" ~~~~~~ ~~~~~  ~~~ ~");

        public Character()
		{

        }

		public void InputName()
		{
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(27, 2, "~참치 사냥을 떠나는 것이에요~", "white");
            GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
            GameManager.GM.DrawText(30, 5, ($"{BG1}"), "yellow");
            GameManager.GM.DrawText(30, 6, ($"{BG2}"), "yellow");
            GameManager.GM.DrawText(30, 7, ($"{BG3}"), "yellow");
            GameManager.GM.DrawText(30, 8, ($"{BG4}"), "yellow");
            GameManager.GM.DrawText(30, 9, ($"{BG5}"), "yellow");
            GameManager.GM.DrawText(26, 12, "원하시는 이름을 설정해 주세요!", "white");
            GameManager.GM.DrawText(7, 15, ($"{BGa}"), "blue");
            GameManager.GM.DrawText(7, 16, ($"{BGb}"), "blue");
            GameManager.GM.DrawText(7, 17, ($"{BGc}"), "blue");
            GameManager.GM.DrawText(7, 18, ($"{BGd}"), "blue");
            GameManager.GM.DrawText(7, 19, ($"{BGe}"), "blue");
            GameManager.GM.DrawText(7, 20, ($"{BGf}"), "blue");
            GameManager.GM.DrawText(7, 21, ($"{BGg}"), "blue");
            GameManager.GM.DrawText(2, 22, "---------------------------------------------------------------------------------\n", "white");
            GameManager.GM.DrawText(35, 24, "  "," " );


            string userName = Console.ReadLine(); // 사용자가 설정하려는 이름을 입력받는 부분
            Program.player.Name = userName;

            Console.Clear();
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(26, 12, ($"당신의 이름은 {userName}입니다!"), "yellow");
            GameManager.GM.DrawText(2, 22, "---------------------------------------------------------------------------------\n", "white");
            GameManager.GM.DrawText(2, 23, "1. 확인 2. 이름 변경", "white");
            GameManager.GM.DrawText(2, 26, " ", "");
            GameManager.GM.DrawText(0, 27, "원하시는 선택지를 입력해주세요.\n", "");


            bool isSelect = false;
            while (isSelect == false)
            {
                int optionNum = 2;
                int input = GameManager.GM.SelectOption(optionNum, false, "");
                switch (input)
                {
                    case 1:
                        isSelect = true;
                        jobSetting.ChoiceJob();//직업 선택화면 
                        break;

                    case 2:
                        isSelect = true;
                        ChangeName(); // 입력한 이름을 변경할 때 이동 
                        break;

                    default:
                        break;
                }
            }
        }

        public void ChangeName() // 이름을 재설정 할 때. 
        {
            Console.Clear();
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(27, 2, "~참치 사냥을 떠나는 것이에요~", "white");
            GameManager.GM.DrawText(2, 4, "---------------------------------------------------------------------------------", "white");
            GameManager.GM.DrawText(30, 5, ($"{BG1}"), "yellow");
            GameManager.GM.DrawText(30, 6, ($"{BG2}"), "yellow");
            GameManager.GM.DrawText(30, 7, ($"{BG3}"), "yellow");
            GameManager.GM.DrawText(30, 8, ($"{BG4}"), "yellow");
            GameManager.GM.DrawText(30, 9, ($"{BG5}"), "yellow");
            GameManager.GM.DrawText(26, 12, "변경 할 이름을 설정해 주세요.", "red");
            GameManager.GM.DrawText(7, 15, ($"{BGa}"), "blue");
            GameManager.GM.DrawText(7, 16, ($"{BGb}"), "blue");
            GameManager.GM.DrawText(7, 17, ($"{BGc}"), "blue");
            GameManager.GM.DrawText(7, 18, ($"{BGd}"), "blue");
            GameManager.GM.DrawText(7, 19, ($"{BGe}"), "blue");
            GameManager.GM.DrawText(7, 20, ($"{BGf}"), "blue");
            GameManager.GM.DrawText(7, 21, ($"{BGg}"), "blue");
            GameManager.GM.DrawText(2, 22, "---------------------------------------------------------------------------------\n", "white");
            GameManager.GM.DrawText(35, 24, "  ", " ");

            string userName = Console.ReadLine();
            Program.player.Name = userName;

            Console.Clear();
            GameManager.GM.MakeUI();
            GameManager.GM.DrawText(26, 12, ($"당신의 이름은 {userName}입니다!"), "yellow");
            GameManager.GM.DrawText(2, 22, "---------------------------------------------------------------------------------\n", "white");
            GameManager.GM.DrawText(2, 23, "1. 확인 2. 이름 변경", "white");
            GameManager.GM.DrawText(2, 26, " ", "");

            bool isSelect = false;
            while (isSelect == false)
            {
                int optionNum = 2;
                int input = GameManager.GM.SelectOption(optionNum, false, "");
                switch (input)
                {
                    case 1:
                        isSelect = true;
                        jobSetting.ChoiceJob();//직업 선택화면 
                        break;

                    case 2:
                        isSelect = true;
                        ChangeName(); // 입력한 이름을 변경할 때 이동 
                        break;

                    default:
                        break;
                }
            }

        }

    }

	
}

