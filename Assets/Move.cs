using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed = 1.0f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.left *  speed * Time.deltaTime);
    }
}
