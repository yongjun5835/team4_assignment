﻿
using System;
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

    public virtual void UseSkill(Unit useUnit) { }
    public virtual void UseSkill(Unit useUnit, Unit taget) { }
    public virtual void UseSkill(Unit useUnit, Unit[] taget) { }


}

class FastSpin : Skill
{
    public FastSpin()
    {
        name = "빨리 감기!!";
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력*{atkPercent})으로 한 마리의 물고기를 공격합니다.";
    }

    public override void UseSkill(Unit useUnit, Unit taget)
    {
        taget.Hp -= (int)(useUnit.Atk*atkPercent);
    } 
}

class Rest : Skill
{
    public Rest()
    {
        name = "휴식";
        requiredMp = 5;
        atkPercent = 1.2f;

        description = $"(사용자의 체력을 (공격력*{atkPercent})만큼 회복합니다)";
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
        description = $"(공격력*{atkPercent})로 {AttckUnits} 마리의 물고기를 랜덤으로 공격합니다.";
    }

    public override void UseSkill(Unit useUnit, Unit[] tagets)
    {
        for (int i = 0; i < AttckUnits; i++) 
        {
            int num = random.Next(0, tagets.Length);
            tagets[num].Hp -= (int)(useUnit.Atk * atkPercent);
            Console.WriteLine($"{tagets[num].Name}은(는) {(int)(useUnit.Atk * atkPercent)}만큼의 대미지를 받았습니다.");
        }
        Thread.Sleep(1000);
    }
}
