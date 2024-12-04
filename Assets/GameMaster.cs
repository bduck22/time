using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] hudle;
    public float speed;
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        int type = Random.Range(1, 3);
        Instantiate(hudle[type - 1]);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(spawn());
    }
    void Update()
    {
        
    }
}
