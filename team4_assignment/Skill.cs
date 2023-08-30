
using System;
using System.Net;
using System.Threading.Channels;
using System.Xml.Linq;

enum SkillType
{
    Solo,
    Taget,
    Boss
}

class Skill
{
    protected string name = "";
    protected string description = "";
    protected SkillType skillType;
    protected int requiredMp;
    protected float atkPercent;

    public int RequiredMp { get { return requiredMp; } set { requiredMp = value; } }
    public virtual string Name { get { return name; } set { name = value; } }
    public virtual string Description { get { return description; } set { description = value; } }
    public SkillType SkillType { get { return skillType; } set { skillType = value; } }


    public virtual void UseSkill(Unit useUnit) { }
    public virtual void UseSkill(Unit useUnit, Unit taget) { }
    public virtual void UseSkill(Unit useUnit, List<Monster> tagets) { }
}

class FastSpin : Skill
{
    Random random = new Random();

    public FastSpin()
    {
        name = "빨리 감기!!";
        skillType = SkillType.Taget;
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력 * {atkPercent})로 1마리 랜덤으로 공격";
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

        tagets[randomNum].Hp -= (int)(useUnit.Atk * atkPercent);
    }
}

class Rest : Skill
{
    public Rest()
    {
        name = "휴식";
        skillType = SkillType.Solo;
        requiredMp = 5;
        atkPercent = 1.2f;

        description = $"사용자의 체력을 (공격력 * {atkPercent})만큼 회복";
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
        skillType = SkillType.Taget;
        requiredMp = 20;
        atkPercent = 1.5f;
        description = $"(공격력 * {atkPercent})로 {AttckUnits}마리 랜덤으로 공격";
    }

    public override void UseSkill(Unit useUnit, List<Monster> tagets)
    {
        bool isAllDeath = false;
        for (int i = 0; i < AttckUnits; i++)
        {
            int randomNum = 0;
            while (isAllDeath == false)
            {
                randomNum = random.Next(0, tagets.Count);
                if (tagets[randomNum].IsDead == false)
                {
                    break;
                }
                for (int num = 0; num < tagets.Count; num++)
                {
                    if (tagets[num].Hp > 0)
                    {
                        break;
                    }
                    if (num == tagets.Count - 1)
                    {
                        isAllDeath = true;
                        break;
                    }
                }

            }
            tagets[randomNum].Hp -= (int)(useUnit.Atk * atkPercent);
        }
        Thread.Sleep(1000);
    }
}

// 보스전 시작시 player의 bool vsBoss true으로 바꾸시고
// 끝나면 vsBoss false한 후 UseSkill() 다시 사용해주세요! 
class TheOldManAndTheSea : Skill
{
    bool useChance = false;

    public TheOldManAndTheSea()
    {
        name = "도서정독";
        skillType = SkillType.Solo;
        requiredMp = 10;
        atkPercent = 1.0f;
        description = $"84일간 물고기 못 잡은 선배 이야기";
    }

    public override void UseSkill(Unit useUnit)
    {
        if (useUnit is Player == false)
            return;
        if (((Player)useUnit).vsBoss == true && useChance == false)
        {
            useChance = true;
            useUnit.Atk += 10;
            useUnit.Def += 5;
            useUnit.Hp += useUnit.MaxMp;
        }
        else if (((Player)useUnit).vsBoss == false && useChance == true)
        {
            useChance = false;
            useUnit.Atk -= 10;
            useUnit.Def -= 5;
        }

    }
} 

class LookAtThisCan : Skill
{
    Random random = new Random();

    public LookAtThisCan()
    {
        name = "캔 따기";
        skillType = SkillType.Boss;
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력 * {atkPercent}) 저 안에 든 건 나의 가족?";
    }

    public override void UseSkill(Unit useUnit, Unit taget)
    {
        taget.Hp -= (int)(useUnit.Atk * atkPercent);
    }
}

class TunaSliced : Skill
{

    public TunaSliced()
    {
        name = "회 썰기";
        skillType = SkillType.Boss;
        requiredMp = 10;
        atkPercent = 0.4f;
        description = $"(공격력 * {atkPercent} * 3) 참치 슬라이스!";
    }

    public override void UseSkill(Unit useUnit, Unit taget)
    {
        int attckNum = 3;

        for (int i = 0; i < attckNum; i++)
        {
            if (taget.IsDead == true)
            {
                break;
            }
            taget.Hp -= (int)(useUnit.Atk * atkPercent);
        }
        Program.player.vsBossSkillCombo = true;
    }
}

class Itadakimasu : Skill
{

    public Itadakimasu()
    {
        skillType = SkillType.Boss;
        requiredMp = 10;
        atkPercent = 2.0f;
        name = "간식타임";
        description = $"HP 10을 회복한다.";
    }
    public override string Name 
    { 
        get 
        { 
            if (Program.player.vsBossSkillCombo == true)
            {
                name = "꺼__억";
            }
            else
            {
                name = "간식시간";
            }
            return name; 
        } 
    }

    public override string Description
    {
        get
        {
            if (Program.player.vsBossSkillCombo == true)
            {
                description = $"(HP 60 회복, 공격력 * {atkPercent}) 눈 앞에서 살점";
            }else
            {
                description = $"HP 10을 회복한다.";
            }
            return description;
        }
    }


    public override void UseSkill(Unit useUnit, Unit taget)
    {
        if (Program.player.vsBossSkillCombo == true)
        {
            taget.Hp -= (int)(useUnit.Atk * atkPercent);
            useUnit.Hp += 60;
            Program.player.vsBossSkillCombo = false;

        }
        else
        {
            useUnit.Hp += 10;
        }
    }
}



