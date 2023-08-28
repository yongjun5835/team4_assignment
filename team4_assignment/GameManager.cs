using System;

class GameManager
{
    public static GameManager GM;
    public Player player;
    public GameManager()
    {
        GM = this;
    }

    /// <summary>
    /// 키 입력하면 숫자 값을 반환합니다.
    /// </summary>
    /// <param name="optionNum">옵션의 갯수, 다른 키 입력시 오류 로그</param>
    /// <param name="isUseNum0">0번키 사용 여부</param>
    /// <returns></returns>
    public int SelectOption(int optionNum, bool isUseNum0)
    {
        Console.WriteLine("\n원하시는 선택지를 입력해주세요.");
        if (!int.TryParse(Console.ReadLine(), out int key))
        {
            Console.WriteLine("입력 값을 다시 확인해주세요.");
            return -1;
        }
        else if (0 < key && key <= optionNum && isUseNum0 == false)
        {
            return key;
        }
        else if (0 <= key && key <= optionNum && isUseNum0 == true)
        {
            return key;
        }

        Console.WriteLine("입력 값을 다시 확인해주세요.");
        return -1;
    }
    /// <summary>
    /// 키 입력하면 숫자 값을 반환하고 텍스트 변경이 가능합니다.
    /// </summary>
    /// <param name="optionNum">옵션의 갯수, 다른 키 입력시 오류 로그</param>
    /// <param name="isUseNum0">0번키 사용 여부</param>
    /// <param name="text"> 입력 텍스트를 변경</param>
    /// <returns></returns>
    public int SelectOption(int optionNum, bool isUseNum0, string text)
    {
        Console.WriteLine(text);
        if (!int.TryParse(Console.ReadLine(), out int key))
        {
            Console.WriteLine("입력 값을 다시 확인해주세요.");
            return -1;
        }
        else if (0 < key && key <= optionNum && isUseNum0 == false)
        {
            Console.WriteLine(key);
            return key;
        }
        else if (0 <= key && key <= optionNum && isUseNum0 == true)
        {
            Console.WriteLine(key);
            return key;
        }

        Console.WriteLine("입력 값을 다시 확인해주세요.");
        return -1;
    }
}
