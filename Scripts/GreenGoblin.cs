using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGoblin : Enemy {

	public GreenGoblin() {
        maxHp = 300;
        currentHp = 300;
        attack = 10;
        defense = 10;
        magicDefense = 10;
        windResistance = 10;
        iceResistance = 10;
        thunderResistance = 10;
        accuracy = 10;
        speed = 10;
        evade = 10;
        experienceAwarded = 30;
    }
	
}
