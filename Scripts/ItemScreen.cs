using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemScreen : MonoBehaviour {

    public void ToItemScreen()
    {
        SceneManager.LoadScene("ItemScreen");
    }
}
