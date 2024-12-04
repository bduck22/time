using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_script : MonoBehaviour
{
    Image image;
    jump jj;
    void Start()
    {
        image = GetComponent<Image>();
        jj = GameObject.FindWithTag("player").GetComponent<jump>();
    }
    void Update()
    {
        image.fillAmount = jj.hp / jj.max_hp;
    }
}
