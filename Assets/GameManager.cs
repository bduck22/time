using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;

    public void PauseGameForSeconds(float seconds)
    {
        if (!isPaused)
        {
            StartCoroutine(PauseCoroutine(seconds));
        }
    }

    private IEnumerator PauseCoroutine(float seconds)
    {
        isPaused = true;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;
        isPaused = false;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
