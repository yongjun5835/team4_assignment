using System;
using System.Text;

class GameManager
{
    public static GameManager GM;



    public GameManager()
    {
        GM = this;
        SettingDele();
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

    // 추가적인 키입력을 원할 때
    public void PressAnyKey()
    {
        Console.WriteLine("계속하시려면 아무 키나 눌려주세요.");
        Console.ReadKey();
    }

    // 용준님이 만든 UI 틀
    //public void MakeUI()
    //{
    //    Console.Clear();
    //    Console.SetCursorPosition(0, 0);
    //    Console.Write("*-----------------------------------------------------------------------------------*");
    //    Console.SetCursorPosition(0, 25);
    //    Console.Write("*-----------------------------------------------------------------------------------*");
    //    for (int i = 1; i < 25; i++)
    //    {
    //        Console.SetCursorPosition(0, i);
    //        Console.Write("|");
    //        Console.SetCursorPosition(84, i);
    //        Console.Write("|");
    //    }
    //    Console.WriteLine();
    //}

    // 대미지 보정용 코드, 직접적인 공격은 안 함
    #region 공격 델리게이트 전용 함수
    public delegate void CorrectAtkType(StringBuilder txt, ref int damage);
    public CorrectAtkType physicalDmg;
    public CorrectAtkType magicalDmg;

    void SettingDele()
    {
        physicalDmg += DmgRange;
        physicalDmg += DodgeEvent;
        physicalDmg += DmgCriticalEvent;
        magicalDmg += DmgRange;
        magicalDmg += DmgCriticalEvent;
    }

    void DmgRange(StringBuilder txt, ref int damage)
    {
        float dmgRange = ((float)new Random().Next(90, 111)) / 100;
        float temp = damage * dmgRange;
        damage = (int)Math.Round(temp, 0);
    }

    void DmgCriticalEvent(StringBuilder txt, ref int damage)
    {
        if (damage == 0)
            return;

        int criticalPercent = 20;
        int randomNum = new Random().Next(0, 100);

        if (randomNum < criticalPercent)
        {
            damage = (int)(damage * 1.2f);
            txt.Replace("공격", "치명적인 공격");
        }
        txt.Append($"으로 {damage}의 피해를 입었습니다!");
    }

    void DodgeEvent(StringBuilder txt, ref int damage)
    {
        int dodgePercent = 50;
        int randomNum = new Random().Next(0, 100);
        if (randomNum < dodgePercent)
        {
            damage = 0;
            txt.Append("을 회피하였습니다.");
        }
    }

    public void PlayerCheat()
    {
        Program.player.Atk += 100;
        Program.player.Def += 50;
        Program.player.MaxHp += 5000;
        Program.player.Hp += 5000;
        Program.player.Gold += 5000;
        Console.WriteLine("치트 사용됨");
        Thread.Sleep(1000);
    }
    #endregion

}
