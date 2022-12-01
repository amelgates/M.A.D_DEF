using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string rango1, rango2, rango3;

    public int personaje;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Vicente()
    {
        personaje = 1;
    }

    public void Valeria()
    {
        personaje = 2;
    }

    public void Rango1(string s)
    {
        rango1 = s;
    }

    public void Rango2(string s)
    {
        rango1 = s;
    }
    public void Rango3(string s)
    {
        rango1 = s;
    }
}
