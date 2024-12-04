using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timescript : MonoBehaviour
{
    GameMaster master;
    TMP_Text text;
    void Start()
    {
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        text.text = ((int)((int)(master.time / 100)/60)).ToString("00") + " : " + ((int)(master.time/100)%60).ToString("00") + " : " + (master.time%100).ToString("00");
    }
}
