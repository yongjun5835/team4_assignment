namespace team4_assignment;

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
    protected bool isDead = false;

    public string Name { get { return name; } set { name = value; } }
    public virtual int Hp { get { return hp; } set { hp = value; } }
    public int Mp { get { return mp; } set { mp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MaxMp { get { return maxMp; } set { maxMp = value; } }
    public int Level { get { return level; } set { level = value; } }
    public int Exp { get { return exp; } set { exp = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }



    protected delegate void PhysicalDmg(ref int damage);
    protected PhysicalDmg physicalDmg;
    public Unit()
    {
        physicalDmg += DodgeEvent;
        physicalDmg += CriticalEvent;
    }

    public void AttckUnit(Unit target)
    {
    }

    void CriticalEvent(ref int damage)
    {
        if (damage == 0)
            return;

        int criticalPercent = 20;
        int randomNum = new Random().Next(0, 100);

        if (randomNum < criticalPercent)
        {
            damage = (int)(damage * 1.2f);
        }
    }

    public void DodgeEvent(ref int damage)
    {
        int dodgePercent = 50;
        int randomNum = new Random().Next(0, 100);
        if (randomNum < dodgePercent)
        {
            damage = 0;
        }
    }

    public void EquipItem(Item item, Player player)
    {
        item.isEquiped = true;
        player.Atk += item.Atk;
        player.Def += item.Def;

        if (item.CriticalModifier != 0)
        {
            player.physicalDmg += player.CriticalEvent;
        }

        if (item.DodgeModifier != 0)
        {
            player.physicalDmg += player.DodgeEvent;
        }
    }

    public void UnequipItem(Item item, Player player)
    {
        item.isEquiped = false;
        player.Atk -= item.Atk;
        player.Def -= item.Def;

        if (item.CriticalModifier != 0)
        {
            player.physicalDmg -= player.CriticalEvent;
        }

        if (item.DodgeModifier != 0)
        {
            player.physicalDmg -= player.DodgeEvent;
        }
    }
}
