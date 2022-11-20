using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menudeinicio : MonoBehaviour
{
     public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
     public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

}
