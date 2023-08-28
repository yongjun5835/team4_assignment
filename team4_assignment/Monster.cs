using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Monster : Unit
{
    public Monster(int hp, int atk, string name)
    {
        this.Hp = hp;
        this.Atk = atk;
        this.Name = name;
    }
    
    public void AttackPlayer()
    {
        Program.player.Hp -= this.atk;
    }
}