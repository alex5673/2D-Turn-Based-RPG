using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PartyCharacter {

	public Warrior() {
        maxHp = 1200;
        currentHp = 1200;
        attack = 12;
        defense = 12;
        magicAttack = 10;
        magicDefense = 10;
        windResistance = 10;
        iceResistance = 10;
        thunderResistance = 10;
        accuracy = 10;
        speed = 10;
        evade = 10;
        position = new Vector3(3.42f, -0.39f, 0);
	}

    public void LevelUp()
    {
        base.LevelUP();
        maxHp += 200;
        attack += 2;
        defense += 2;
        magicAttack += 1;
        magicDefense += 1;
        accuracy += 1;
        speed += 1;
        evade += 1;
    }
	
}
