using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float maxspeed;
    public Text countText;
    public Text winText;
   
    private Rigidbody rb;
    private int count;

    public Text tiempoText;
    public float tiempo= 0.0f;

    private bool condicion = false;

    public GameObject referencia;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
    
        if(rb.velocity.magnitude > maxspeed) {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }

        rb.AddForce (moveVertical * referencia.transform.forward * speed);
        rb.AddForce(moveHorizontal * referencia.transform.right * speed);
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            winText.text = "You Win!!!";
            condicion = true;
          
        }
    }

    public void Update()
    {
       
        if(condicion== false)
        {
            tiempo = Time.time;
            tiempoText.text = "" + tiempo;
        }
        else
        {
            tiempoText.text = tiempo.ToString() + " Segundos";
        }

    }



}
