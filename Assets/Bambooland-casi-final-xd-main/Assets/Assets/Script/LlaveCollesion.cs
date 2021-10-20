using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveCollesion : MonoBehaviour
{
    private void OntriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag.Equals("Player"))
        {
            Debug.Log("colision");
            //  GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
