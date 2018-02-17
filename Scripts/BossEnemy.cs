using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy {

	public BossEnemy()
    {
        maxHp = 3000;
        currentHp = 3000;
        attack = 15;
        defense = 15;
        magicAttack = 15;
        magicDefense = 20;
        windResistance = 20;
        iceResistance = 20;
        thunderResistance = 20;
        accuracy = 50;
        speed = 20;
        evade = 30;
        experienceAwarded = 4000;
    }
}
