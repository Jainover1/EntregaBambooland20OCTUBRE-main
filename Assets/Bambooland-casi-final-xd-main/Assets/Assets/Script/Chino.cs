using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chino : MonoBehaviour
{
    public float speed;
    public float altura;
    public float tiempoSalto;
    float salto;
    private Rigidbody2D MyRb;
    private float BufoVelocidad = 1;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movimiento();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= salto)
        {
            MyRb.velocity = new Vector2(MyRb.velocity.x, altura);
            salto = Time.time + tiempoSalto;
        }

    }
    public void movimiento()
    {
        float Hori = Input.GetAxis("Horizontal");
        if (Hori > 0.1f)
        {
            Vector2 caminar = new Vector2(Hori * Time.deltaTime * speed* BufoVelocidad, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(caminar);
        }
        if (Hori <= 0)
        {
            Vector2 caminar = new Vector2(-Hori * Time.deltaTime * speed * BufoVelocidad, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(caminar);
        }
        if (Hori == 0)
        {
            Vector2 caminar = new Vector2(0f, 0f);
            transform.Translate(caminar);
        }


    }
    public void BufoFruta()
    {
        BufoVelocidad = 2;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        BufoVelocidad = 1;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ascensor")
        {
            collision.GetComponentInParent<Ascensor>().Cambio(true);
        }
        if (collision.tag == "Fruta")
        {
            BufoFruta();
            Destroy(collision.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ascensor")
        {
            collision.GetComponentInParent<Ascensor>().Cambio(false);
        }
    }

}

