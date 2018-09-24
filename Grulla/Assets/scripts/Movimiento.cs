using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public int velocidad;
    private Collision2D suelo;
    private Rigidbody2D rb;
    int salto = 0;
    public int  maxSalto = 2;
    Vector3 respawn;
    bool movimiento= true;
    public bool vida = true;
    public Sprite grullaSP;
    public Sprite marioSP;
    public SpriteRenderer sr;
    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        respawn = this.transform.position;
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("suelo"))
        {
            //suelo = collision;
            salto = 0;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag.Equals("lava"))
        {
            if (vida==true)
            {
                movimiento = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(transform.up * 600);
                sr.sprite = marioSP;
                vida = false;
                print("yeee");
            StartCoroutine(muerte());
            }
        }
       if (collision.gameObject.tag.Equals("muro"))
        {
            salto = 0;
        }
    }

    IEnumerator muerte()
    {                
        print("waiting");
        yield return new WaitForSeconds(2);
        transform.position = respawn;
        vida = true;
        movimiento = true;                        
        sr.sprite = grullaSP;
        //print("waiting");
    }
    void moverse()
    {
        //derecha
        if (Input.GetKey("d") && movimiento)
        {
            var rot = transform.rotation;
            rot.y = 0;
            transform.rotation = rot;
            rb.velocity = new Vector2(10, rb.velocity.y);
            //this.transform.Translate(Vector2.right * velocidad);
        }
        //izquierda
        else if (Input.GetKey("a") && movimiento)
        {
            var rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
            rb.velocity = new Vector2(-10, rb.velocity.y);
            //this.transform.Translate(Vector2.right * velocidad);
        }
        //quieto
        else { rb.velocity = new Vector2(0, rb.velocity.y); }
        //salto
        if (Input.GetKeyDown("w") && salto< maxSalto && movimiento)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * 600);
            
            salto++;
        }
        //planeo
        if (Input.GetKey("w") && movimiento && rb.velocity.y<-2)
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            //rb.gravityScale = 0.5f;
        }
        else {
            //rb.gravityScale = 1f;
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.x);
        }


    }

    // Update is called once per frame
    void Update () {
        moverse();
        //rb.mass = 0.5f;


    }


    private void FixedUpdate()
    {
        this.rb.freezeRotation = enabled;
        //if (this.transform.rotation != suelo.gameObject.transform.rotation) { this.transform.rotation = suelo.gameObject.transform.rotation; }
    }
}
