using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] hudle;
    public float speed;
    public GameObject text_pre;
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        Instantiate(text_pre,new Vector3(20, -5.648f, (int)Random.Range(1, 3)), transform.rotation);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(spawn());
    }
    void Update()
    {
        
    }
}
