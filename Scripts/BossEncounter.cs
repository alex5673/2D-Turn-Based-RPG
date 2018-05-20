using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
using System.IO;

public class BossEncounter : MonoBehaviour {

    //public GameObject bossSprite;

    private string bossActive;

	// Use this for initialization
	void Start () {
        bossActive = "";
        ReadBossEnemyFile();
        
        if(bossActive == "true")
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision occured");
        WriteToBossFile();
        SceneManager.LoadScene("GrassBattleScreen");
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision occured");
        SceneManager.LoadScene("GrassBattleScreen");
    }
    */

    public void ReadBossEnemyFile()
    { 
        string fileName = "BossEnemy.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + fileName);

        try
        {
            bossActive = reader.ReadLine();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
        }
    }

    public void WriteToBossFile()
    {
        string fileName = "BossEnemy.txt";

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);

        try
        {
            writer.WriteLine("false");
            writer.WriteLine("true");
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            writer.Close();
        }

        //AssetDatabase.Refresh();
    }
}
