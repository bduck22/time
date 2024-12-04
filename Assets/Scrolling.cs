using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float _x, _y;

    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, img.uvRect.size);
    }
}
