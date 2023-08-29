namespace team4_assignment
{
    class Item


    {
        public int CriticalModifier { get; private set; }
        public int DodgeModifier { get; private set; }


        public string Name;
        public int Atk;
        public int Def;
        public string Desc;
        public int Hp;
        public int Quantity;
        public bool isEquiped;

        public Item(string name, int atk, int def, string desc, int hp, int qu, int critModifier, int dodgeModifier)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Desc = desc;
            Hp = hp;
            Quantity = qu;
            isEquiped = false;
            CriticalModifier = critModifier; 
            DodgeModifier = dodgeModifier; 
        }
    }
}

