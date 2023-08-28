class Unit
{
    protected string name = "";
    protected int maxHp = 0;
    protected int hp = 0;
    protected int atk = 0;
    protected int def = 0;
    protected int maxMp = 0 ;
    protected int mp = 0;

    public string Name { get { return name; } set { name = value; } }
    public int Hp { get { return hp; } set { hp = value; } }
    public int Atk { get { return atk; } set { atk = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MaxMp { get { return maxMp; } set { maxMp = value; } }
    public int Mp { get { return mp; } set { mp = value; } }

}
