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

    public Slider vidaSlider;
    public Slider duracionSlider;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(music.time);
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
        vida += 5;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        vida += 10;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        vida += 15;
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
        multiText.text = "Multiplier: " + currentMultiplier;
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        Debug.Log("Hit Missed");
        vida -= 15;
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: " + currentMultiplier;
    }
}
