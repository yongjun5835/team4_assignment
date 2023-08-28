class Unit
{
    protected string name = "";
    protected int maxHp;
    protected int hp;
    protected int maxMp;
    protected int mp;
    protected int atk;
    protected int def;

    public string Name { get { return name; } set { name = value; } }
    public int Hp { get { return hp; } set { hp = value; } }
    public int Mp { get { return mp; } set { mp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MaxMp { get { return maxMp; } set { maxMp = value; } }

    public void AttckUnit(Unit target)
    {
    }
}
