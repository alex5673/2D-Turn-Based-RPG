using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicScreen : MonoBehaviour {

    public void ToMagicScreen()
    {
        SceneManager.LoadScene("MagicScreen");
    }
}
