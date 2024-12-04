using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.PlayerSettings;

public class jump : MonoBehaviour
{
    bool onejump;
    Rigidbody2D body;
    public int power;
    Animator ani;
    GameMaster master;
    bool stop;
    void Start()
    {
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
        onejump = true;
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if (!stop) { 
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && onejump)
            {
                ani.SetTrigger("Jump");
                onejump = false;
                StartCoroutine(Jump());
            }
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.15f);
        body.AddForce(Vector2.up * power);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform == Physics2D.Raycast(transform.position, Vector2.down))
        {
            ani.SetTrigger("lend");
            onejump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.z == 1 && collision.transform.GetComponent<moveob>()) // ¾¦¿¡ ´ê¾ÒÀ» ½Ã
        {
            //StartCoroutine(SpeedDown(master.speed * 0.8f, 1));
            StartCoroutine(SpeedDown2(0.5f, 1));
            Destroy(collision.gameObject);
        }
        if (collision.transform.position.z == 2 && collision.transform.GetComponent<moveob>()) // ¸¶´Ã¿¡ ´ê¾ÒÀ» ½Ã
        {
            //StartCoroutine(speeddown(master.speed, 1));
            StartCoroutine(Stop(1));
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Stop(float cool)
    {
        stop = true;
        yield return new WaitForSeconds(cool);
        stop = false;
    }
    
    IEnumerator SpeedDown(float num, float cool)
    {
        float real = master.speed;
        master.speed -= num;
        yield return new WaitForSeconds(cool);
        master.speed = real;
    }
    IEnumerator SpeedDown2(float num, float cool)
    {
        Time.timeScale = num;
        yield return new WaitForSeconds(cool);
        Time.timeScale = 1;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == Physics2D.Raycast(transform.position, Vector2.down))
        {
            ani.ResetTrigger("lend");
        }
    }
}
