using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    protected int level;
    protected int maxHp;
    protected int maxMp;
    protected int currentHp;
    protected int currentMp;
    protected int attack;
    protected int defense;
    protected int magicAttack;
    protected int magicDefense;
    protected int windResistance;
    protected int iceResistance;
    protected int thunderResistance;
    protected int accuracy;
    protected int speed;
    protected int evade;
    protected Vector3 position;

	public Character() {
        level = 1;
        maxHp = 0;
        maxMp = 0;
        currentHp = 0;
        currentMp = 0;
        attack = 0;
        defense = 0;
        magicAttack = 0;
        magicDefense = 0;
        windResistance = 0;
        iceResistance = 0;
        thunderResistance = 0;
        accuracy = 0;
        speed = 0;
        evade = 0;
        position = new Vector3(0, 0, 0);
	}
	
    public int GetLevel()
    {
        return level;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public int GetMaxMp()
    {
        return maxMp;
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    public int GetCurrentMp()
    {
        return currentMp;
    }

    public int GetAttack()
    {
        return attack;
    }

    public int GetDefense()
    {
        return defense;
    }

    public int GetMagicAttack()
    {
        return magicAttack;
    }

    public int GetMagicDefense()
    {
        return magicDefense;
    }

    public int GetWindResistance()
    {
        return windResistance;
    }

    public int GetIceResistance()
    {
        return iceResistance;
    }

    public int GetThunderResistance()
    {
        return thunderResistance;
    }

    public int GetAccuracy()
    {
        return accuracy;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetEvade()
    {
        return evade;
    }

    public Vector3 GetPosition()
    {
        return position;
    }

    public void SetLevel(int lvl)
    {
        level = lvl;
        if(level > 99)
        {
            level = 99;
        }
    }

    public void SetMaxHp(int maxHealthPoints)
    {
        maxHp = maxHealthPoints;
        if (maxHp > 9999)
        {
            maxHp = 9999;
        }
    }

    public void SetMaxMp(int maxMagicPoints)
    {
        maxMp = maxMagicPoints;
        if (maxMp > 999)
        {
            maxMp = 999;
        }
    }

    public void SetCurrentHp(int currentHealthPoints)
    {
        currentHp = currentHealthPoints;
    }

    public void SetCurrentMp(int currentMagicPoints)
    {
        currentMp = currentMagicPoints;
    }

    public void SetAttack(int att)
    {
        attack = att;
        if (attack > 99)
        {
            attack = 99;
        }
    }

    public void SetDefense(int def)
    {
        defense = def;
        if (defense > 99)
        {
            defense = 99;
        }
    }

    public void SetMagicAttack(int magAtt)
    {
        magicAttack = magAtt;
        if (magicAttack > 99)
        {
            magicAttack = 99;
        }
    }

    public void SetMagicDefense(int magDef)
    {
        magicDefense = magDef;
        if (magicDefense > 99)
        {
            magicDefense = 99;
        }
    }

    public void SetAccuracy(int acc)
    {
        accuracy = acc;
        if (accuracy > 99)
        {
            accuracy = 99;
        }
    }

    public void SetSpeed(int spd)
    {
        speed = spd;
        if (speed > 99)
        {
            speed = 99;
        }
    }

    public void SetEvade(int evad)
    {
        evade = evad;
        if (evade > 99)
        {
            evade = 99;
        }
    }

    public void SetPosition(Vector3 pos)
    {
        position = pos;
    }
}
