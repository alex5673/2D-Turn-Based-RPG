using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenuStats : MonoBehaviour {

    public GameObject mainCharacter1LvlText;
    public GameObject mainCharacter2LvlText;
    public GameObject mainCharacter3LvlText;
    public GameObject mainCharacter1HPText;
    public GameObject mainCharacter2HPText;
    public GameObject mainCharacter3HPText;
    public GameObject mainCharacter3MPText;

    private string character1Lvl;
    private string character2Lvl;
    private string character3Lvl;
    private string character1HP;
    private string character2HP;
    private string character3HP;
    private string character3MP;
    
    void Start()
    {
        character1Lvl = "";
        character2Lvl = "";
        character3Lvl = "";
        character1HP = "";
        character2HP = "";
        character3HP = "";
        character3MP = "";

        ReadCharacterStats();


        mainCharacter1LvlText.GetComponent<Text>().text = "Lvl: " + character1Lvl;
        mainCharacter2LvlText.GetComponent<Text>().text = "Lvl: " + character2Lvl;
        mainCharacter3LvlText.GetComponent<Text>().text = "Lvl: " + character3Lvl;
        mainCharacter1HPText.GetComponent<Text>().text = "HP: " + character1HP;
        mainCharacter2HPText.GetComponent<Text>().text = "HP: " + character2HP;
        mainCharacter3HPText.GetComponent<Text>().text = "HP: " + character3HP;
        mainCharacter3MPText.GetComponent<Text>().text = "MP: " + character3MP;
    }

    public void ReadCharacterStats()
    {
        string fileName = "Character1Stats.txt";
        string fileName2 = "Character2Stats.txt";
        string fileName3 = "Character3Stats.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + fileName);
        StreamReader reader2 = new StreamReader(Application.persistentDataPath + "/" + fileName2);
        StreamReader reader3 = new StreamReader(Application.persistentDataPath + "/" + fileName3);

        try
        {
            character1Lvl = reader.ReadLine();
            character2Lvl = reader2.ReadLine();
            character3Lvl = reader3.ReadLine();

            reader.ReadLine();
            reader2.ReadLine();
            reader3.ReadLine();

            reader.ReadLine();
            reader2.ReadLine();
            reader3.ReadLine();

            character1HP = reader.ReadLine();
            character2HP = reader2.ReadLine();
            character3HP = reader3.ReadLine();

            character3MP = reader3.ReadLine();
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
