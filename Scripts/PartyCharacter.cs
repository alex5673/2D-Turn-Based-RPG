using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCharacter : Character {

    protected int experiencePoints;
    protected int experienceNeeded;

	public PartyCharacter() {
        experiencePoints = 0;
        experienceNeeded = 90;
	}

    public virtual void LevelUP()
    {
        level++;
        experiencePoints -= experienceNeeded;
        experienceNeeded *= 2;
    }

    public int GetExperiencePoints()
    {
        return experiencePoints;
    }

    public int GetExperienceNeeded()
    {
        return experienceNeeded;
    }

    public void SetExperiencePoints(int expPoints)
    {
        experiencePoints = expPoints;
    }

    public void SetExperienceNeeded(int expNeeded)
    {
        experienceNeeded = expNeeded;
    }
}
