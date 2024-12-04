using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.PlayerSettings;
=======
using UnityEngine;
>>>>>>> Stashed changes

public class jump : MonoBehaviour
{
    public CooldownUi coolBar;
    bool onejump;
    Rigidbody2D body;
    public int power;
    Animator ani;
<<<<<<< Updated upstream
    GameMaster master;
    bool stop;
    bool slide;
    bool once;
    void Start()
    {
        once = true;
        master = GameObject.FindWithTag("master").GetComponent<GameMaster>();
=======
    public float cooldownTime = 2f;
    private float currentCooldownTime;

    void Start()
    {
        coolBar.per.fillAmount = 1;
>>>>>>> Stashed changes
        onejump = true;
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        currentCooldownTime = cooldownTime;
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (!stop) { 
            if (((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) )&& onejump&&!Input.GetKey(KeyCode.DownArrow))
            {
                onejump = false;
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
=======
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && onejump && coolBar.per.fillAmount == 1)
        {
            ani.SetTrigger("Jump");
            onejump = false;
            StartCoroutine(Jump());
            coolBar.per.fillAmount -= 0.1f;
        }

        if (coolBar.per.fillAmount < 1)
        {
            currentCooldownTime -= Time.deltaTime;
            coolBar.per.fillAmount = Mathf.Lerp(0, 1, (cooldownTime - currentCooldownTime) / cooldownTime);
            if (currentCooldownTime <= 0)
            {
                currentCooldownTime = cooldownTime;
>>>>>>> Stashed changes
            }
        }
        if (onejump && transform.position.y != -5.65f && !slide) transform.position = new Vector3(transform.position.x, -5.65f, transform.position.z);
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.15f);
        if (once)
        {
            once = false;
            body.AddForce(Vector2.up * power);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< Updated upstream
        if(collision.transform == Physics2D.Raycast(transform.position, Vector2.down))
        {
            ani.SetTrigger("lend");
            once = true;
            onejump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.z ==0.1f && collision.transform.GetComponent<moveob>()) // ���� ����� ��
        {
            //StartCoroutine(SpeedDown(master.speed * 0.8f, 1));
            StartCoroutine(SpeedDown2(0.5f, 1));
            Destroy(collision.gameObject);
        }
        if (collision.transform.position.z == 0.2f && collision.transform.GetComponent<moveob>()) // ���ÿ� ����� ��
        {
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
        yield return new WaitForSeconds(cool);
        Time.timeScale = 1;
    }
=======
        ani.SetTrigger("lend");
        onejump = true;
    }

>>>>>>> Stashed changes
    private void OnCollisionExit2D(Collision2D collision)
    {
        ani.ResetTrigger("lend");
    }
}
