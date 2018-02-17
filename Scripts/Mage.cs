using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PartyCharacter {

	public Mage() {
        maxHp = 800;
        maxMp = 60;
        currentHp = 800;
        currentMp = 60;
        attack = 1;
        defense = 10;
        magicAttack = 12;
        magicDefense = 12;
        windResistance = 10;
        iceResistance = 10;
        thunderResistance = 10;
        accuracy = 10;
        speed = 8;
        evade = 10;
        position = new Vector3(7.13f, -1.36f, 0);
    }
	
	public void LevelUp()
    {
        base.LevelUP();
        maxHp += 50;
        maxMp += 30;
        attack += 1;
        defense += 1;
        magicAttack += 2;
        magicDefense += 2;
        accuracy += 1;
        speed += 1;
        evade += 1;
    }
}
