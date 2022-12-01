using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public KeyCode startKey;

    public AudioSource music;

    public bool startPlaying;

    public BeatController beatCont;
    public PersonajeController pjCont;
    public static GameManager instance;

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

    public Slider vidaSlider;
    public Slider duracionSlider;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;
    public TextMeshProUGUI comboText;

    // Start is called before the first frame update
    void Start()
    {
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
                startPlaying = true;
                beatCont.hasStarted = true;
                pjCont.active = true;
                music.Play();
            }
        }
    }
    public void GameOver()
    {
        beatCont.hasStarted = false;
        pjCont.active = false;
        music.Stop();
    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        notasMaX++;
        notasReal += 0.8f;
        vida += 5;
        normals++;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        notasMaX++;
        notasReal += 0.9f;
        vida += 10;
        goods++;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        notasMaX++;
        notasReal++;
        vida += 15;
        perfects++;
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
        if(porcentaje == 100)
        {

        }
        else if(89 < porcentaje)
        {

        }
        else if (79 < porcentaje)
        {

        }
        else
        {

        }
    }
}
