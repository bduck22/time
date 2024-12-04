using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] hudle;
    public float speed;
    public float time;
    void Start()
    {
        time = 0;
        StartCoroutine(spawn());
        StartCoroutine(Time());
    }
    IEnumerator spawn()
    {
        int type = Random.Range(1, 3);
        Instantiate(hudle[type - 1]);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(spawn());
    }
    IEnumerator Time()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        time += 1f;
        yield return StartCoroutine(Time());
    }
    void Update()
    {
        
    }
}
