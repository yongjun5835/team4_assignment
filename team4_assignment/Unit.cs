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


    public delegate void AttackTypeDele(ref int damage) ;
    public AttackTypeDele physicalDmg;
    public AttackTypeDele magicalDmg;

    public Unit()
    {
        physicalDmg += DmgRange;
        physicalDmg += DodgeEvent;
        physicalDmg += DmgCriticalEvent;
        magicalDmg += DmgRange;
        magicalDmg += DmgCriticalEvent;
    }

    public void AttckUnit(Unit target, AttackTypeDele atkTypeDelegate )
    {
        int damage = this.Atk /*- target.def*/;
        atkTypeDelegate(ref damage);
        target.hp -= damage;

    }

    #region 공격 델리게이트 전용 함수
    void DmgRange(ref int damage)
    {
        float dmgRange = ((float)new Random().Next(90,111))/100;
        float temp = damage * dmgRange;
        damage = (int)Math.Round(temp,0);
    }

    void DmgCriticalEvent(ref int damage)
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

    void DodgeEvent(ref int damage)
    {
        int dodgePercent = 50;
        int randomNum = new Random().Next(0, 100);
        if (randomNum < dodgePercent)
        {
            damage = 0;
        }
    }
    #endregion
}
