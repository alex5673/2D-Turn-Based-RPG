using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusScreen : MonoBehaviour {

    public void ToStatusScreen()
    {
        SceneManager.LoadScene("StatusScreen");
    }
}
