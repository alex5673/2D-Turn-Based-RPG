using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StatusScreenStats : MonoBehaviour {

    public GameObject mainCharacter1Sprite;
    public GameObject mainCharacter2Sprite;
    public GameObject mainCharacter3Sprite;

    public GameObject previousButton;
    public GameObject nextButton;

    public GameObject characterNameText;
    public GameObject hpText;
    public GameObject mptext;
    public GameObject levelText;
    public GameObject experienceText;
    public GameObject attackText;
    public GameObject defenseText;
    public GameObject magicAttackText;
    public GameObject magicDefenseText;
    public GameObject windResistanceText;
    public GameObject iceResistanceText;
    public GameObject thunderResistanceText;
    public GameObject accuracyText;
    public GameObject speedText;
    public GameObject evadeText;

    private string character1Name;
    private string character1HP;
    private string character1MP;
    private string character1Lvl;
    private string character1CurrentExperience;
    private string character1ExperienceNeeded;
    private string character1Attack;
    private string character1Defense;
    private string character1MagicAttack;
    private string character1MagicDefense;
    private string character1WindResistance;
    private string character1IceResistance;
    private string character1ThunderResistance;
    private string character1Accuracy;
    private string character1Speed;
    private string character1Evade;

    private string character2Name;
    private string character2HP;
    private string character2MP;
    private string character2Lvl;
    private string character2CurrentExperience;
    private string character2ExperienceNeeded;
    private string character2Attack;
    private string character2Defense;
    private string character2MagicAttack;
    private string character2MagicDefense;
    private string character2WindResistance;
    private string character2IceResistance;
    private string character2ThunderResistance;
    private string character2Accuracy;
    private string character2Speed;
    private string character2Evade;

    private string character3Name;
    private string character3HP;
    private string character3MP;
    private string character3Lvl;
    private string character3CurrentExperience;
    private string character3ExperienceNeeded;
    private string character3Attack;
    private string character3Defense;
    private string character3MagicAttack;
    private string character3MagicDefense;
    private string character3WindResistance;
    private string character3IceResistance;
    private string character3ThunderResistance;
    private string character3Accuracy;
    private string character3Speed;
    private string character3Evade;

    private bool mainCharacter1Stats;
    private bool mainCharacter2Stats;
    private bool mainCharacter3Stats;

    // Use this for initialization
    void Start () {
        character1Name = "Main Character 1";
        character1HP = "";
        character1MP = "0";
        character1Lvl = "";
        character1CurrentExperience = "";
        character1ExperienceNeeded = "";
        character1Attack = "";
        character1Defense = "";
        character1MagicAttack = "";
        character1MagicDefense = "";
        character1WindResistance = "";
        character1IceResistance = "";
        character1ThunderResistance = "";
        character1Accuracy = "";
        character1Speed = "";
        character1Evade = "";

        character2Name = "Main Character 2";
        character2HP = "";
        character2MP = "0";
        character2CurrentExperience = "";
        character2ExperienceNeeded = "";
        character2Attack = "";
        character2Defense = "";
        character2MagicAttack = "";
        character2MagicDefense = "";
        character2WindResistance = "";
        character2IceResistance = "";
        character2ThunderResistance = "";
        character2Accuracy = "";
        character2Speed = "";
        character2Evade = "";

        character3Name = "Main Character 3";
        character3HP = "";
        character3MP = "";
        character3CurrentExperience = "";
        character3ExperienceNeeded = "";
        character3Attack = "";
        character3Defense = "";
        character3MagicAttack = "";
        character3MagicDefense = "";
        character3WindResistance = "";
        character3IceResistance = "";
        character3ThunderResistance = "";
        character3Accuracy = "";
        character3Speed = "";
        character3Evade = "";

        mainCharacter1Stats = true;
        mainCharacter2Stats = false;
        mainCharacter3Stats = false;

        mainCharacter1Sprite.SetActive(true);
        mainCharacter2Sprite.SetActive(false);
        mainCharacter3Sprite.SetActive(false);

        previousButton.SetActive(false);
        nextButton.SetActive(true);

        ReadCharacterStats();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(mainCharacter1Stats == true)
        {
            characterNameText.GetComponent<Text>().text = character1Name;
            hpText.GetComponent<Text>().text = "HP: " + character1HP;
            mptext.GetComponent<Text>().text = "MP: " + character1MP;
            levelText.GetComponent<Text>().text = "Lvl: " + character1Lvl;
            experienceText.GetComponent<Text>().text = "Exp: " + character1CurrentExperience + "/" + character1ExperienceNeeded;
            attackText.GetComponent<Text>().text = "Attack: " + character1Attack;
            defenseText.GetComponent<Text>().text = "Defense: " + character1Defense;
            magicAttackText.GetComponent<Text>().text = "Magic Attack: " + character1MagicAttack;
            magicDefenseText.GetComponent<Text>().text = "Magic Defense: " + character1MagicDefense;
            windResistanceText.GetComponent<Text>().text = "Wind Resistance: " + character1WindResistance;
            iceResistanceText.GetComponent<Text>().text = "Ice Resistance: " + character1IceResistance;
            thunderResistanceText.GetComponent<Text>().text = "Thunder Resistance: " + character1ThunderResistance;
            accuracyText.GetComponent<Text>().text = "Accuracy: " + character1Accuracy;
            speedText.GetComponent<Text>().text = "Speed: " + character1Speed;
            evadeText.GetComponent<Text>().text = "Evade: " + character1Evade;
        }
        else if(mainCharacter2Stats == true)
        {
            characterNameText.GetComponent<Text>().text = character2Name;
            hpText.GetComponent<Text>().text = "HP: " + character2HP;
            mptext.GetComponent<Text>().text = "MP: " + character2MP;
            levelText.GetComponent<Text>().text = "Lvl: " + character2Lvl;
            experienceText.GetComponent<Text>().text = "Exp: " + character2CurrentExperience + "/" + character2ExperienceNeeded;
            attackText.GetComponent<Text>().text = "Attack: " + character2Attack;
            defenseText.GetComponent<Text>().text = "Defense: " + character2Defense;
            magicAttackText.GetComponent<Text>().text = "Magic Attack: " + character2MagicAttack;
            magicDefenseText.GetComponent<Text>().text = "Magic Defense: " + character2MagicDefense;
            windResistanceText.GetComponent<Text>().text = "Wind Resistance: " + character2WindResistance;
            iceResistanceText.GetComponent<Text>().text = "Ice Resistance: " + character2IceResistance;
            thunderResistanceText.GetComponent<Text>().text = "Thunder Resistance: " + character2ThunderResistance;
            accuracyText.GetComponent<Text>().text = "Accuracy: " + character2Accuracy;
            speedText.GetComponent<Text>().text = "Speed: " + character2Speed;
            evadeText.GetComponent<Text>().text = "Evade: " + character2Evade;
        }
        else if(mainCharacter3Stats == true)
        {
            characterNameText.GetComponent<Text>().text = character3Name;
            hpText.GetComponent<Text>().text = "HP: " + character3HP;
            mptext.GetComponent<Text>().text = "MP: " + character3MP;
            levelText.GetComponent<Text>().text = "Lvl: " + character3Lvl;
            experienceText.GetComponent<Text>().text = "Exp: " + character3CurrentExperience + "/" + character3ExperienceNeeded;
            attackText.GetComponent<Text>().text = "Attack: " + character3Attack;
            defenseText.GetComponent<Text>().text = "Defense: " + character3Defense;
            magicAttackText.GetComponent<Text>().text = "Magic Attack: " + character3MagicAttack;
            magicDefenseText.GetComponent<Text>().text = "Magic Defense: " + character3MagicDefense;
            windResistanceText.GetComponent<Text>().text = "Wind Resistance: " + character3WindResistance;
            iceResistanceText.GetComponent<Text>().text = "Ice Resistance: " + character3IceResistance;
            thunderResistanceText.GetComponent<Text>().text = "Thunder Resistance: " + character3ThunderResistance;
            accuracyText.GetComponent<Text>().text = "Accuracy: " + character3Accuracy;
            speedText.GetComponent<Text>().text = "Speed: " + character3Speed;
            evadeText.GetComponent<Text>().text = "Evade: " + character3Evade;
        }
	}

    public void Next()
    {
        if(mainCharacter1Stats == true)
        {
            mainCharacter1Stats = false;
            mainCharacter2Stats = true;
            mainCharacter1Sprite.SetActive(false);
            mainCharacter2Sprite.SetActive(true);
            previousButton.SetActive(true);
        }
        else if(mainCharacter2Stats == true)
        {
            mainCharacter2Stats = false;
            mainCharacter3Stats = true;
            mainCharacter2Sprite.SetActive(false);
            mainCharacter3Sprite.SetActive(true);
            nextButton.SetActive(false);
        }
    }

    public void Previous()
    {
        if(mainCharacter3Stats == true)
        {
            mainCharacter3Stats = false;
            mainCharacter2Stats = true;
            mainCharacter3Sprite.SetActive(false);
            mainCharacter2Sprite.SetActive(true);
            nextButton.SetActive(true);
        }
        else if(mainCharacter2Stats == true)
        {
            mainCharacter2Stats = false;
            mainCharacter1Stats = true;
            mainCharacter2Sprite.SetActive(false);
            mainCharacter1Sprite.SetActive(true);
            previousButton.SetActive(false);
        }
    }

    public void ReadCharacterStats()
    {
        string fileName = "Character1Stats.txt";
        string fileName2 = "Character2Stats.txt";
        string fileName3 = "Character3Stats.txt";

        StreamReader reader = new StreamReader(fileName);
        StreamReader reader2 = new StreamReader(fileName2);
        StreamReader reader3 = new StreamReader(fileName3);

        try
        {
            character1Lvl = reader.ReadLine();
            character2Lvl = reader2.ReadLine();
            character3Lvl = reader3.ReadLine();

            character1CurrentExperience = reader.ReadLine();
            character2CurrentExperience = reader2.ReadLine();
            character3CurrentExperience = reader3.ReadLine();

            character1ExperienceNeeded = reader.ReadLine();
            character2ExperienceNeeded = reader2.ReadLine();
            character3ExperienceNeeded = reader3.ReadLine();

            character1HP = reader.ReadLine();
            character2HP = reader2.ReadLine();
            character3HP = reader3.ReadLine();

            character3MP = reader3.ReadLine();

            character1Attack = reader.ReadLine();
            character2Attack = reader2.ReadLine();
            character3Attack = reader3.ReadLine();

            character1Defense = reader.ReadLine();
            character2Defense = reader2.ReadLine();
            character3Defense = reader3.ReadLine();

            character1MagicAttack = reader.ReadLine();
            character2MagicAttack = reader2.ReadLine();
            character3MagicAttack = reader3.ReadLine();

            character1MagicDefense = reader.ReadLine();
            character2MagicDefense = reader2.ReadLine();
            character3MagicDefense = reader3.ReadLine();

            character1WindResistance = reader.ReadLine();
            character2WindResistance = reader2.ReadLine();
            character3WindResistance = reader3.ReadLine();

            character1IceResistance = reader.ReadLine();
            character2IceResistance = reader2.ReadLine();
            character3IceResistance = reader3.ReadLine();

            character1ThunderResistance = reader.ReadLine();
            character2ThunderResistance = reader2.ReadLine();
            character3ThunderResistance = reader3.ReadLine();

            character1Accuracy = reader.ReadLine();
            character2Accuracy = reader2.ReadLine();
            character3Accuracy = reader3.ReadLine();

            character1Speed = reader.ReadLine();
            character2Speed = reader2.ReadLine();
            character3Speed = reader3.ReadLine();

            character1Evade = reader.ReadLine();
            character2Evade = reader2.ReadLine();
            character3Evade = reader3.ReadLine();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
            reader2.Close();
            reader3.Close();
        }
    }
}
