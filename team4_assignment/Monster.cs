using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Monster : Unit
{
    public Monster(int type)
    {
        int[] monsterHp = { 10, 20, 30, 40, 50, 500 };
        int[] monsterAtk = { 5, 10, 15, 20, 25, 95 };
        int[] monsterExp = { 5, 10, 15, 20, 25, 95 };
        string[] monsterName = { "송사리", "꺽지", "블루길", "농어", "참치", "자이언트참치" };

        this.hp = monsterHp[type];
        this.atk = monsterAtk[type];
        this.exp = monsterExp[type];
        this.name = monsterName[type];
    }
    public override int Hp 
    { 
        get { return hp; } 
        set 
        { 
            hp = value; 
            if (hp <= 0)
            {
                hp = 0;
                isDead = true;
            }
        } 
    }

    public void AttackPlayer()
    {
        Program.player.Hp -= this.atk;
    }
}