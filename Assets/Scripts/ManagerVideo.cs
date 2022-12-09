using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ManagerVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void OnEnable()
    {
        videoPlayer.loopPointReached += loopPointReached;
    }

    void loopPointReached(VideoPlayer v)
    {
        SceneManager.LoadScene("Game");
    }
}
