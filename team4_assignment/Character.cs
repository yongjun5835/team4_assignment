using System;
namespace team4_assignment
{
	public class Character
	{
        
        JobSetting jobSetting = new JobSetting();
        public string UserName { get; set; }
        
        public Character()
		{

        }

		public void InputName()
		{
            Console.Clear();
            Console.WriteLine("참치 사냥을 떠나는 것이에요\n");
            Console.WriteLine("원하시는 이름을 설정해 주세요.\n");

            string userName = Console.ReadLine(); // 사용자가 설정하려는 이름을 입력받는 부분
            Program.player.Name = userName;
            
            Console.Clear();
			Console.WriteLine($"당신의 이름은 {userName}입니다.\n");
            Console.WriteLine("1. 확인 \n2. 이름 변경");

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
            Console.WriteLine("참치 사냥을 떠나는 것이에요\n");
            Console.WriteLine("변경 할 이름을 설정해 주세요.\n");

            string userName = Console.ReadLine();
            Program.player.Name = userName;

            Console.Clear();
            Console.WriteLine($"당신의 이름은 {userName}입니다.");
            Console.WriteLine("1. 확인  \n2. 이름 변경");

            int optionNum = 2;
            int input = GameManager.GM.SelectOption(optionNum, false, "");
            switch (input)
            {
                case 1:
                    jobSetting.ChoiceJob();
                    break;

                case 2:
                    ChangeName();
                    break;
            }
           
           
        }


    }

	
}

