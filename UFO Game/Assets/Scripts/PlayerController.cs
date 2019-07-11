﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    private Rigidbody2D rb2d;
    private int count;
    public Text winText;
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
       
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical"); 
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);     
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }          
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}