using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveob : MonoBehaviour
{
    GameMaster master;
    void Start()
    {
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
    }
    void Update()
    {
        transform.Translate(-master.speed*Time.deltaTime, 0, 0);
        if (transform.position.x < -30) Destroy(gameObject);
    }
}
