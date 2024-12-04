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
    bool slide;
    bool once;
    bool invin;
    void Start()
    {
        invin = false;
        once = true;
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
        onejump = true;
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if (!stop) { 
            if (((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) )&& onejump&&!Input.GetKey(KeyCode.DownArrow))
            {
                ani.SetTrigger("Jump");
                StartCoroutine(Jump());
            }
            if (Input.GetKey(KeyCode.DownArrow) &&onejump)
            {
                slide = true;
                ani.SetBool("Slide", true);
                transform.position = new Vector3(transform.position.x, -6.3f, transform.position.z);
                if (!GetComponent<BoxCollider2D>().enabled) GetComponent<BoxCollider2D>().enabled = true;
                if(GetComponent<CapsuleCollider2D>().enabled)GetComponent<CapsuleCollider2D>().enabled = false;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                slide = false;
                ani.SetBool("Slide", false);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
        else
        {
            slide = false;
            ani.SetBool("Slide", false);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
        if (onejump && transform.position.y != -5.65f && !slide)
        {
            transform.position = new Vector3(transform.position.x, -5.65f, transform.position.z);
        }
    }
    IEnumerator blink()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 150);
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSecondsRealtime(0.1f);
        if(invin)yield return StartCoroutine(blink());
    }
    IEnumerator invinend(float cool)
    {
        yield return new WaitForSecondsRealtime(cool);
        invin = false;
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.15f);
        onejump = false;
        if (once)
        {
            once = false;
            body.AddForce(Vector2.up * power);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == Physics2D.Raycast(transform.position, Vector2.down))//&&collision.transform.position.z<=0
        if(collision.transform == Physics2D.Raycast(transform.position, Vector2.down))
        {
            ani.SetTrigger("lend");
            ani.ResetTrigger("Jump");
            once = true;
            onejump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invin)
        {
            if (collision.transform.position.z == -0.1f && collision.transform.GetComponent<moveob>()) // ¾¦¿¡ ´ê¾ÒÀ» ½Ã
            {
                invin = true;
                StartCoroutine(blink());
                StartCoroutine(invinend(1));
                //StartCoroutine(SpeedDown(master.speed * 0.8f, 1));
                StartCoroutine(SpeedDown2(0.5f, 1));
                Destroy(collision.gameObject);
            }
            if (collision.transform.position.z == -0.2f && collision.transform.GetComponent<moveob>()) // ¸¶´Ã¿¡ ´ê¾ÒÀ» ½Ã
            {
                invin = true;
                StartCoroutine(blink());
                StartCoroutine(invinend(1));
                StartCoroutine(Stop(1));
                Destroy(collision.gameObject);
            }
        }
    }
    IEnumerator Stop(float cool)
    {
        stop = true;
        yield return new WaitForSecondsRealtime(cool);
        stop = false;
    }
    
    //IEnumerator SpeedDown(float num, float cool)
    //{
    //    float real = master.speed;
    //    master.speed -= num;
    //    yield return new WaitForSeconds(cool);
    //    master.speed = real;
    //}
    IEnumerator SpeedDown2(float num, float cool)
    {
        Time.timeScale = num;
        yield return new WaitForSecondsRealtime(cool);
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
