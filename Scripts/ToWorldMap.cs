using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWorldMap : MonoBehaviour {

    public void WorldMapButton()
    {
        SceneManager.LoadScene("WorldMap");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("WorldMap");
    }

}
