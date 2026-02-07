using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonControls : MonoBehaviour
{
    public void ToMainGame()
    {
        SceneManager.LoadScene("1_Main_Game");
    }

    public void ToStartMenu()
    {
        SceneManager.LoadScene("0_Start_Screen");
    }
}
