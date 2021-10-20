using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D Rdb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rdb.velocity = new Vector2(+Speed, 0);

        Destroy(this.gameObject,5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo"))
        {
            Destroy(collision.gameObject);
        }
    }


}
