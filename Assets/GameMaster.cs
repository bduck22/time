using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int speed;
    public GameObject text_pre;
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        Instantiate(text_pre).transform.position= new Vector2(20, -5.648f);
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(spawn());
    }
    void Update()
    {
        
    }
}
