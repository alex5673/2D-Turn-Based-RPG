using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy {

	public Rat() {
        maxHp = 200;
        currentHp = 200;
        attack = 8;
        defense = 8;
        magicDefense = 10;
        windResistance = 10;
        iceResistance = 10;
        thunderResistance = 10;
        accuracy = 10;
        speed = 11;
        evade = 12;
        experienceAwarded = 40;
    }
	
}
