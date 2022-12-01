using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public KeyCode startKey, optionsKey;

    public AudioSource music;

    public bool startPlaying;
    public bool isPlaying;
    public bool inOptions;

    public BeatController beatCont;
    public PersonajeController pjCont;
    public static GameManager instance;

    public GameObject normalEffect, goodEffect, perfectEffect, missEffect, valeria, vicente, inicio, inGame, opciones, resultados, gameOver;

    public Sprite S, A, B, C;

    public Image imagenRango;

    public int currentScore;
    public int scorePerNote;
    public int scorePerGoodNote;
    public int scorePerPerfectNote;
    public int vida;
    public int duracion;
    public int notasMaX;
    public float notasReal;
    public float porcentaje;
    public int currentCombo;
    public int perfects;
    public int goods;
    public int normals;
    public int misses;
    public string rango;

    public Slider vidaSlider;
    public Slider duracionSlider;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI perfText, goodText, normalText, missText;
    
    // Start is called before the first frame update
    private void Awake()
    {
        inOptions = false;
        startPlaying = false;
        isPlaying = false;
        rango = null;
        notasMaX = 0;
        notasReal = 0;
        perfects = 0;
        goods = 0;
        normals = 0;
        misses = 0;
        currentCombo = 0;
        porcentaje = 100;
        currentScore = 0;
        duracionSlider.maxValue = music.clip.length;
        duracionSlider.value = 0;
        instance = this;
        vida = 100;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        multiplierTracker = 0;
        
    }
    public void SetPlayer()
    {
        if(DataManager.instance.personaje == 1)
        {
            vicente.SetActive(true);
            valeria.SetActive(false);
        }
        if (DataManager.instance.personaje == 2)
        {
            vicente.SetActive(false);
            valeria.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        duracionSlider.value = music.time;
        vidaSlider.value = vida;
        if(vida > 100)
        {
            vida = 100;
        }
        if (vida <= 0)
        {
            GameOver();
        }
        if(!startPlaying)
        {
            if(Input.GetKeyDown(startKey))
            {
                Comenzar();
            }
        }
        if(isPlaying)
        {
            if(Input.GetKeyDown("escape"))
            {
                if (inOptions)
                {
                    opciones.SetActive(false);
                    beatCont.hasStarted = true;
                    pjCont.active = true;
                    music.UnPause();
                    inOptions = false;
                }
                else if(!inOptions)
                {
                    opciones.SetActive(true);
                    music.Pause();
                    beatCont.hasStarted = false;
                    pjCont.active = false;
                    inOptions = true;
                }
            }
        }
        if( Mathf.Abs(music.time - music.clip.length) <= 0.1f)
        {
            AjustPorcentaje();
        }
    }
    public void GameOver()
    {
        beatCont.hasStarted = false;
        pjCont.active = false;
        music.Stop();
        isPlaying = false;
        gameOver.SetActive(true);
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        notasMaX++;
        notasReal += 0.8f;
        vida += 5;
        normals++;
        Instantiate(normalEffect, normalEffect.transform.position, normalEffect.transform.rotation);
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        notasMaX++;
        notasReal += 0.9f;
        vida += 10;
        goods++;
        Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation);
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        notasMaX++;
        notasReal++;
        vida += 15;
        perfects++;
        Instantiate(perfectEffect, perfectEffect.transform.position, perfectEffect.transform.rotation);
        NoteHit();
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        currentCombo++;
        porcentaje = Mathf.RoundToInt((notasReal / notasMaX) * 100);
        multiText.text = "Multiplier: " + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        comboText.text = "Combo: " + currentCombo;
    }

    public void NoteMissed()
    {
        Debug.Log("Hit Missed");
        Instantiate(missEffect, missEffect.transform.position, missEffect.transform.rotation);
        vida -= 20;
        currentCombo = 0;
        currentMultiplier = 1;
        multiplierTracker = 0;
        notasMaX++;
        misses++;
        porcentaje = Mathf.RoundToInt((notasReal / notasMaX) * 100);
        multiText.text = "Multiplier: " + currentMultiplier;
        comboText.text = "Combo: " + currentCombo;
    }

    public void AjustPorcentaje()
    {
        if(95 < porcentaje)
        {
            rango = "S";
            imagenRango.sprite = S;
        }
        else if(85 < porcentaje)
        {
            rango = "A";
            imagenRango.sprite = A;
        }
        else if (75 < porcentaje)
        {
            rango = "B";
            imagenRango.sprite = B;
        }
        else
        {
            rango = "C";
            imagenRango.sprite = C;
        }
        CancionTermina();
    }

    public void GuardarRango()
    {
        if(SceneManager.GetActiveScene().name == "Cancion1")
        {
            DataManager.instance.Rango1(rango);
        }
        if (SceneManager.GetActiveScene().name == "Cancion2")
        {
            DataManager.instance.Rango2(rango);
        }
        if (SceneManager.GetActiveScene().name == "Cancion3")
        {
            DataManager.instance.Rango3(rango);
        }
    }

    public void ResetEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BotonRendirse()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void CancionTermina()
    {
        inGame.SetActive(false);
        isPlaying = false;
        pjCont.active = false;
        perfText.text = perfects.ToString();
        goodText.text = goods.ToString();
        normalText.text = normals.ToString();
        missText.text = misses.ToString();
        resultados.SetActive(true);
    }

    public void Comenzar()
    {
        inicio.SetActive(false);
        inGame.SetActive(true);
        startPlaying = true;
        beatCont.hasStarted = true;
        pjCont.active = true;
        music.Play();
    }

    public void CargarCancion1()
    {
        SceneManager.LoadScene("Cancion1");
    }
    public void CargarCancion2()
    {
        SceneManager.LoadScene("Cancion2");
    }
    public void CargarCancion3()
    {
        SceneManager.LoadScene("Cancion3");
    }

    public void CargarFinal()
    {
        if((DataManager.instance.rango1 == "S" || DataManager.instance.rango1 == "A") && (DataManager.instance.rango2 == "S" || DataManager.instance.rango2 == "A") && (DataManager.instance.rango3 == "S" || DataManager.instance.rango3 == "A"))
        {
            SceneManager.LoadScene("Final1");
        }
        else
        {
            SceneManager.LoadScene("Final2");
        }
    }
}
