using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Tilemove : MonoBehaviour
{
    GameMaster master;
    void Start()
    {
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
    }
    void Update()
    {
        transform.Translate(-master.speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -33) transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
