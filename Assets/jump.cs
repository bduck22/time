using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class jump : MonoBehaviour
{
    bool onejump;
    Rigidbody2D body;
    public int power;
    Animator ani;
    void Start()
    {
        onejump = true;
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow)) &&onejump)
        {
            ani.SetTrigger("Jump");
            onejump = false;
            StartCoroutine(Jump());
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == Physics2D.Raycast(transform.position, Vector2.down))
        {
            ani.ResetTrigger("lend");
        }
    }
}
