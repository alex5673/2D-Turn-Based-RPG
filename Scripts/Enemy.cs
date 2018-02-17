using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    protected int experienceAwarded;
    protected int timesDefeated;

	public Enemy() {
        experienceAwarded = 0;
        timesDefeated = 0;
	}
	
	public int GetExperienceAwarded()
    {
        return experienceAwarded;
    }

    public int GetTimesDefeated()
    {
        return timesDefeated;
    }

    public void SetExperienceAwarded(int expAwarded)
    {
        experienceAwarded = expAwarded;
    }

    public void SetTimesDefeated(int amountDefeated)
    {
        timesDefeated = amountDefeated;
    }
}
