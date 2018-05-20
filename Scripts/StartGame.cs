using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
using System.IO;

public class StartGame : MonoBehaviour {

	public void NewGame()
    {

        string fileName = "Character1Stats.txt";
        string fileName2 = "Character2Stats.txt";
        string fileName3 = "Character3Stats.txt";
        string fileName4 = "BossEnemy.txt";
        string fileName5 = "PlayersMapPosition.txt";
        string fileName6 = "NewGame.txt";

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName).Dispose();
        }

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName2))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName2).Dispose();
        }

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName3))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName3).Dispose();
        }

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName4))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName4).Dispose();
        }

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName5))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName5).Dispose();
        }

        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName6))
        {
            File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName6).Dispose();
        }

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName, false);
        StreamWriter writer2 = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName2, false);
        StreamWriter writer3 = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName3, false);
        StreamWriter writer4 = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName4, false);
        StreamWriter writer5 = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName5, false);
        StreamWriter writer6 = new StreamWriter(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName6, false);

        try
        {
            writer4.WriteLine("false");
            writer4.WriteLine("false");

            writer5.WriteLine("1.55");
            writer5.WriteLine("0");

            writer.WriteLine("1");
            writer2.WriteLine("1");
            writer3.WriteLine("1");

            writer.WriteLine("0");
            writer2.WriteLine("0");
            writer3.WriteLine("0");

            writer.WriteLine("90");
            writer2.WriteLine("90");
            writer2.WriteLine("90");

            writer.WriteLine("1200");
            writer2.WriteLine("1000");
            writer3.WriteLine("800");

            writer3.WriteLine("60");

            writer.WriteLine("12");
            writer2.WriteLine("10");
            writer3.WriteLine("1");

            writer.WriteLine("12");
            writer2.WriteLine("10");
            writer3.WriteLine("10");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("12");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("12");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("10");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("10");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("10");

            writer.WriteLine("10");
            writer2.WriteLine("10");
            writer3.WriteLine("10");

            writer.WriteLine("10");
            writer2.WriteLine("12");
            writer3.WriteLine("8");

            writer.WriteLine("10");
            writer2.WriteLine("12");
            writer3.WriteLine("8");

            writer6.WriteLine("true");

            writer.Flush();
            writer2.Flush();
            writer3.Flush();
            writer4.Flush();
            writer5.Flush();
            writer6.Flush();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            writer.Close();
            writer2.Close();
            writer3.Close();
            writer4.Close();
            writer5.Close();
            writer6.Close();
        }

        //AssetDatabase.Refresh();

        SceneManager.LoadScene("WorldMap");
    }

    public void LoadGame()
    {
 
        string gameFileExists = "";

        string fileName = "NewGame.txt";

        if (!File.Exists(Application.dataPath + Path.DirectorySeparatorChar + fileName))
        {
            File.Create(Application.dataPath + Path.DirectorySeparatorChar + fileName).Dispose();
        }

        StreamReader reader = new StreamReader(Application.persistentDataPath + Path.DirectorySeparatorChar + fileName);

        try
        {
            gameFileExists = reader.ReadLine();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
        }

        if (gameFileExists == "true")
        {
            SceneManager.LoadScene("WorldMap");
        }
        
    }
}
