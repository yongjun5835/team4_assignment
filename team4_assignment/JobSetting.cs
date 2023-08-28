using System;
namespace team4_assignment
{
	public class JobSetting
	{
		public JobSetting()
		{
			
		}


		public void ChoiceJob()
		{
            Console.WriteLine("원하시는 직업을 선택하세요.\n");
            Console.WriteLine("1.궁수 2.전사 3.마법사 \n");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"당신의 직업은 입니다.");
            Console.WriteLine("1. 입장 하기");
        }
			
	}
}

