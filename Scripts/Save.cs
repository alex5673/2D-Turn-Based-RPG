using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour {

    public void WriteToCharaterPosFile()
    {
        string fileName = "PlayersMapPosition.txt";

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);

        try
        {
            writer.WriteLine("" + transform.position.x);
            writer.WriteLine("" + transform.position.y);
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
