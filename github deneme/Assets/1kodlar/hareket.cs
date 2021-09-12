using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public float hiz;
    public float ziplamahiz;

    private Rigidbody2D rb;

    public Transform yer; //, yer2;
    public LayerMask yerne;
    private bool yerdemi;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * hiz, rb.velocity.y);

        yerdemi = Physics2D.OverlapCircle(yer.position, .1f, yerne); //|| Physics2D.OverlapCircle()

        

        if (Input.GetButtonDown("Jump") && yerdemi)
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamahiz);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y *0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)

    {  

        if (coll.gameObject.tag == "zipzip")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (20,7)   ;
        }
    }
}

