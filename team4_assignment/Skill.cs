
using System;
using System.Net;
using System.Threading.Channels;

interface IPassive
{

}

class Skill
{
    protected string name = "";
    protected string description = "";
    protected int requiredMp;
    protected float atkPercent;

    public int RequiredMp {get { return requiredMp;}set { requiredMp = value; } }
    public string Name {get { return name;}set { name = value; } }
    public string Description { get { return description; } set { description = value; } }

    public virtual void UseSkill(Unit useUnit) { }
    public virtual void UseSkill(Unit useUnit, List<Monster> tagets) { }

}

class FastSpin : Skill
{
    Random random = new Random();

    public FastSpin()
    {
        name = "빨리 감기!!";
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력*{atkPercent})로 한 마리 랜덤으로 공격";
    }

    public override void UseSkill(Unit useUnit, List<Monster> tagets)
    {
        int randomNum;
        while (true)
        {
            randomNum = random.Next(0, tagets.Count);
            if (tagets[randomNum].IsDead == false)
            {
                break;
            }
        }

        tagets[randomNum].Hp -= (int)(useUnit.Atk*atkPercent);
    }
}

class Rest : Skill
{
    public Rest()
    {
        name = "휴식";
        requiredMp = 5;
        atkPercent = 1.2f;

        description = $"사용자의 체력을 (공격력*{atkPercent})만큼 회복";
    }

    public override void UseSkill(Unit useUnit)
    {
        useUnit.Hp += (int)(useUnit.Atk * atkPercent);

        Console.WriteLine($"{useUnit.Name}은(는) 잠깐 휴식합니다. \n체력 {(int)(useUnit.Atk * atkPercent)} 회복!!.");
    }
}

class WriggleWriggleSpin : Skill
{
    Random random = new Random();
    int AttckUnits = 2;

    public WriggleWriggleSpin()
    {
        name = "요리조리 감기";
        requiredMp = 20;
        atkPercent = 1.5f;
        description = $"(공격력*{atkPercent})로 {AttckUnits} 마리 랜덤으로 공격";
    }

    public override void UseSkill(Unit useUnit, List<Monster> tagets)
    {
        for (int i = 0; i < AttckUnits; i++) 
        {
            int randomNum;
            while (true)
            {
                randomNum = random.Next(0, tagets.Count);
                if (tagets[randomNum].IsDead == false)
                {
                    Console.WriteLine("죽지 않았다");
                    Console.ReadLine();
                    break;
                }
            }
            tagets[randomNum].Hp -= (int)(useUnit.Atk * atkPercent)+100;
        }
        Thread.Sleep(1000);
    }
}

