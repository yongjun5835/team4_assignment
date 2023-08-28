
using System;
<<<<<<< HEAD
using System.Text;
=======
using System.Net;
>>>>>>> main
using System.Threading.Channels;

interface IPassive
{

}

enum SkillRange
{
    MySelf,
    Single,

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

<<<<<<< HEAD
    public virtual void Activate(Unit useUnit) { }
    public virtual void Activate(Unit useUnit, Unit taget) { }
    public virtual void Activate(Unit useUnit, Unit[] taget) { }
=======
    public virtual void UseSkill(Unit useUnit) { }
    public virtual void UseSkill(Unit useUnit, List<Monster> tagets) { }
<<<<<<< Updated upstream


>>>>>>> main
=======
>>>>>>> Stashed changes
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

<<<<<<< HEAD
    public override void Activate(Unit useUnit, Unit[] tagets)
=======
    public override void UseSkill(Unit useUnit, List<Monster> tagets)
>>>>>>> main
    {
        int num = random.Next(0, tagets.Count);
        tagets[num].Hp -= (int)(useUnit.Atk*atkPercent);
<<<<<<< HEAD
        Console.WriteLine($"공격 멘트!!.");
=======
>>>>>>> main
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

    public override void Activate(Unit useUnit)
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

<<<<<<< HEAD
    public override void Activate(Unit useUnit, Unit[] tagets)
=======
    public override void UseSkill(Unit useUnit, List<Monster> tagets)
>>>>>>> main
    {
        for (int i = 0; i < AttckUnits; i++) 
        {
            int num = random.Next(0, tagets.Count);
            tagets[num].Hp -= (int)(useUnit.Atk * atkPercent);
        }
        Thread.Sleep(1000);
    }
}

