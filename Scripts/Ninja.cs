using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : PartyCharacter {

    public Ninja()
    {
        maxHp = 1000;
        currentHp = 1000;
        attack = 10;
        defense = 10;
        magicAttack = 10;
        magicDefense = 10;
        windResistance = 10;
        iceResistance = 10;
        thunderResistance = 10;
        accuracy = 10;
        speed = 12;
        evade = 12;
        position = new Vector3(3.63f, -1.99f, 0);
    }

    public void LevelUp()
    {
        base.LevelUP();
        maxHp += 100;
        attack += 1;
        defense += 1;
        magicAttack += 1;
        magicDefense += 1;
        accuracy += 1;
        speed += 2;
        evade += 2;
    }

}
