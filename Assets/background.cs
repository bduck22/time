using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    GameMaster master;
    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-master.speed * Time.deltaTime, 0, 0);
        if (transform.position.x <0) transform.position = new Vector3(63, transform.position.y, transform.position.z);
    }
}
