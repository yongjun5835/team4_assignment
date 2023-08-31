
using System;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using static GameManager;
using static System.Net.Mime.MediaTypeNames;

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

    // 테스트용
    public virtual StringBuilder UseSkill(Unit useUnit, List<Monster> taget, StringBuilder txt) { return null; }
    public virtual StringBuilder UseSkill(Unit useUnit, Unit taget, StringBuilder txt) { return null; }
    public virtual StringBuilder UseSkill(Unit useUnit, StringBuilder txt) { return null; }

}

class FastSpin : Skill
{
    CorrectAtkType AtkType;
    Random random = new Random();

    public FastSpin()
    {
        name = "빨리 감기";
        AtkType = GM.magicalDmg;
        skillType = SkillType.Taget;
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력 * {atkPercent})으로 1마리 랜덤으로 공격";
    }

    public override StringBuilder UseSkill(Unit useUnit, List<Monster> tagets, StringBuilder txt)
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
        int Damage = (int)(useUnit.Atk * atkPercent);
        AtkType(txt, ref Damage);
        txt.Insert(0, $"{tagets[randomNum].Name}은 ");
        txt.Replace("공격으로", $"{this.Name}로");
        tagets[randomNum].Hp -= Damage;
        return txt;
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

    public override StringBuilder UseSkill(Unit useUnit, StringBuilder txt)
    {
        useUnit.Hp += (int)(useUnit.Atk * atkPercent);

        txt.Clear();
        txt.Append($"{useUnit.Name}은 잠깐 휴식을 취합니다.");
        return txt;
    }
}

class WriggleWriggleSpin : Skill
{
    Random random = new Random();
    int AttckUnits = 2;
    CorrectAtkType AtkType;

    public WriggleWriggleSpin()
    {
        name = "요리조리 감기";
        skillType = SkillType.Taget;
        AtkType = GM.magicalDmg;
        requiredMp = 20;
        atkPercent = 1.5f;
        description = $"(공격력 * {atkPercent})으로 {AttckUnits}마리 랜덤으로 공격";
    }

    public override StringBuilder UseSkill(Unit useUnit, List<Monster> tagets, StringBuilder txt)
    {
        bool isAllDeath = false;
        StringBuilder savetxt = new StringBuilder();
        for (int i = 0; i < AttckUnits; i++)
        {
            StringBuilder temptxt = new StringBuilder(txt.ToString());
            int tempNum = 0;
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
                        txt.Clear();
                        txt.Append(savetxt);
                        return txt;
                    }
                }

            }
            int damage = (int)(useUnit.Atk * atkPercent);
            AtkType(temptxt, ref damage);
            temptxt.Insert(0, $"{tagets[randomNum].Name}은 ");
            temptxt.Replace("공격으로", $"{Name}로");
            savetxt.Append(temptxt + "\n");
            tagets[randomNum].Hp -= damage;
        }
        txt.Clear();
        txt.Append(savetxt);
        return txt;
    }

}

// 보스전 시작시 player의 bool vsBoss true으로 바꾸시고
// 끝나면 vsBoss false한 후 UseSkill() 다시 사용해주세요! 
class TheOldManAndTheSea : Skill
{
    public bool useChance = false;

    public TheOldManAndTheSea()
    {
        name = "도서정독";
        skillType = SkillType.Solo;
        requiredMp = 10;
        atkPercent = 1.0f;
        description = $"84일간 물고기 못 잡은 선배 이야기";
    }

    public override StringBuilder UseSkill(Unit useUnit, StringBuilder txt)
    {
        if (useUnit is Player == false)
            return txt;
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

        txt.Clear();
        txt.Append($"(이것저것 상승)선배님의 의지를 이어받았다.");
        return txt;

    }
}

class LookAtThisCan : Skill
{
    CorrectAtkType AtkType;

    public LookAtThisCan()
    {
        name = "캔 따기";
        AtkType = GM.magicalDmg;
        skillType = SkillType.Boss;
        requiredMp = 10;
        atkPercent = 2.0f;
        description = $"(공격력 * {atkPercent}) 저 안에 든 건 나의 가족?";
    }

    public override StringBuilder UseSkill(Unit useUnit, Unit taget, StringBuilder txt)
    {
        int damage = (int)(useUnit.Atk * atkPercent);
        AtkType(txt, ref damage);
        taget.Hp -= damage;
        txt.Replace("공격", Name);

        return txt;
    }
}

class TunaSliced : Skill
{
    CorrectAtkType AtkType;

    public TunaSliced()
    {
        name = "회 썰기";
        AtkType = GM.magicalDmg;
        skillType = SkillType.Boss;
        requiredMp = 10;
        atkPercent = 0.6f;
        description = $"(공격력 * {atkPercent} * 3) 참치 슬라이스!";
    }

    public override StringBuilder UseSkill(Unit useUnit, Unit taget, StringBuilder txt)
    {
        int attckNum = 3;
        int totalDmg = 0;

        for (int i = 0; i < attckNum; i++)
        {
            if (taget.IsDead == true)
            {
                break;
            }
            int damage = (int)(useUnit.Atk * atkPercent);
            AtkType(txt,ref damage);
            totalDmg += damage;
            taget.Hp -= damage;
        }
        txt.Clear();
        txt.Append($"{taget.Name}는 {Name}로 {totalDmg}의 피해를 입었다.");
        Program.player.vsBossSkillCombo = true;

        return txt;
    }
}

class Itadakimasu : Skill
{
    CorrectAtkType AtkType;

    public Itadakimasu()
    {
        AtkType = GM.magicalDmg;
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
            }
            else
            {
                description = $"HP 10을 회복한다.";
            }
            return description;
        }
    }


    public override StringBuilder UseSkill(Unit useUnit, Unit taget, StringBuilder txt)
    {
        if (Program.player.vsBossSkillCombo == true)
        {
            taget.Hp -= (int)(useUnit.Atk * atkPercent);
            useUnit.Hp += 60;
            Program.player.vsBossSkillCombo = false;
            txt.Clear();
            txt.Append($"(살점 주인 앞에서){useUnit.Name}은 회를 맛있게 먹었다.");
        }
        else
        {
            useUnit.Hp += 10;
            txt.Clear();
            txt.Append($"{useUnit.Name}은 체력을 10 회복하였다.");
        }

        return txt;
    }
}


class TempMagic : Skill
{
    CorrectAtkType AtkType;
    public TempMagic()
    {
        skillType = SkillType.Boss;
        AtkType = GM.magicalDmg;
        requiredMp = 10;
        atkPercent = 2.0f;
        name = "가짜 마법";
        description = $"2.0배수 ";
    }

    public override StringBuilder UseSkill(Unit useUnit, Unit taget, StringBuilder txt)
    {
        int Damage = (int)(useUnit.Atk * atkPercent);
        AtkType(txt, ref Damage);
        txt.Replace("공격", $"{name}");
        taget.Hp -= Damage;

        return txt;
    }

}