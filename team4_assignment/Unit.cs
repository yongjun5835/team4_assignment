using System.Text;
using static GameManager;

class Unit
{
    protected string name = "";
    protected int maxHp;
    protected int hp;
    protected int maxMp;
    protected int mp;
    protected int atk;
    protected int def;
    protected int level;
    protected int exp;
    protected int gold;
    protected bool isDead = false;

    public string Name { get { return name; } set { name = value; } }
    public virtual int Hp { get { return hp; } set { hp = value; } }
    public int Mp { get { return mp; } set { mp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int MaxMp { get { return maxMp; } set { maxMp = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int Exp { get { return exp; } set { exp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }

    public int AttackUnit(Unit target, CorrectAtkType atkTypeDelegate )
    {
        StringBuilder txt = new StringBuilder($"{Name}의 공격");
        int damage = this.Atk /*- target.def*/;
        atkTypeDelegate(txt, ref damage);
        target.hp -= damage;
        Console.Write(txt);
        return damage;
    }

    public StringBuilder MagicalAttackBoss(Unit target, Skill skill)
    {
        StringBuilder txt = new StringBuilder($"공격");
        if (skill.SkillType == SkillType.Solo)
        {
            skill.UseSkill(this,txt);
        }
        else if (skill.SkillType == SkillType.Boss)
        {
            skill.UseSkill(this,target,txt);
        }

        return txt;
    }

    public StringBuilder MagicalAttackUnits(List<Monster> targets, Skill skill)
    {
        StringBuilder txt = new StringBuilder($"공격");
        if (skill.SkillType == SkillType.Solo)
        {
            skill.UseSkill(this,txt);
        }
        else if (skill.SkillType == SkillType.Taget)
        {
            skill.UseSkill(this, targets, txt);
        }
        else if (skill.SkillType == SkillType.Boss)
        {
            Console.Clear();
            Console.WriteLine("스킬타입이 보스인데 리스트로 target이 들어옴");
            Console.WriteLine();
        }

        return txt;
    }
}
