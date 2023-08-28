using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Monster : Unit
{
    public Monster(int hp, int atk, string name,int level,int exp)
    {
        this.Hp = hp;
        this.Atk = atk;
        this.Name = name;
        this.Level = level;
        this.Exp = exp;
    }
    
    public void AttackPlayer()
    {
        Program.player.Hp -= this.atk;
    }
}