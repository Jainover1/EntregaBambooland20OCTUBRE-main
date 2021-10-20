using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionarVidas : MonoBehaviour
{
    public int vidas;
    private Vector3 posicionOriginal;
    public Text cantidadDeVidas;
    public GameObject ascensor;
    public Transform targetPosition;
    public float speed;
    private bool isInAscensor = false;
    void Start()
    {
        posicionOriginal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (vidas > 0)
        //{
        //    cantidadDeVidas.text = "Vidas: " + vidas;
        //}
        //else
        //{
        //    cantidadDeVidas.text = "Perdiste el juego";
        //}

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.transform.tag.Equals("Agua") || collision.transform.tag.Equals("Enemigo"))
        {
            Debug.Log("PierdesUnaVida");
            vidas--;
            transform.position = posicionOriginal;
        }
        if (collision.transform.tag.Equals("esfera"))
        {
            isInAscensor = true;
        }

        if(collision.transform.tag.Equals("llave"))
        {
            Destroy(collision.gameObject);
            
        }
        if (collision.transform.tag.Equals("carcel"))
        {
            SceneManager.LoadScene("video");
        }



    }
    private void MoverAscensor()
    {
        if (isInAscensor)
        {
            if (ascensor.transform.position.y != targetPosition.position.y)
            {
                float step = speed * Time.deltaTime;
                ascensor.transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, step);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, step);

            }
        }
    }
}
