using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUi : MonoBehaviour
{
    public TextMeshProUGUI speed; 
    public GameMaster gmaster;

    void Start()
    {
        if (speed != null && gmaster != null)
        {
            speed.text = "Speed: " + gmaster.speed.ToString();
        }
        else
        {
            Debug.Log("Speed Script or GameMaster hasn't connected");
        }
    }

    void Update()
    {
        if (gmaster != null)
        {
            speed.text = "Speed: " + gmaster.speed.ToString();
        }
    }
}
