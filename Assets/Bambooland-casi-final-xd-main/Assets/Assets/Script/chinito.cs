using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chinito : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Armachino;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Instantiate(Armachino, FirePoint.position, Quaternion.identity);
        }
    }
}
