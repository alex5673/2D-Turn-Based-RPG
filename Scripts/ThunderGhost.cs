using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderGhost : Enemy {

	public ThunderGhost() {
        maxHp = 150;
        currentHp = 150;
        attack = 1;
        defense = 99;
        magicAttack = 10;
        magicDefense = 1;
        windResistance = 1;
        iceResistance = 1;
        thunderResistance = 99;
        accuracy = 10;
        speed = 7;
        evade = 10;
        experienceAwarded = 50;
    }

}
