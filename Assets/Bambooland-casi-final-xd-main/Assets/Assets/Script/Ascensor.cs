using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    private Vector3 Inicio;
    private Vector3 Final;
    bool Direcction;
    bool SeDebeMover=false;
    // Start is called before the first frame update
    void Start()
    {
        Inicio = new Vector3(152, -110, 0);
        Final = new Vector3(152, -71, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (SeDebeMover)
        {

            if (Direcction == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Inicio, 5 * Time.deltaTime);
                if (transform.position == Inicio)
                {
                    Direcction = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Final, 5 * Time.deltaTime);
                if (transform.position == Final)
                {
                    Direcction = true;
                }
            }
        }
        else
        {
            if (transform.position != Inicio)
            {
                transform.position = Vector3.MoveTowards(transform.position, Inicio, 5 * Time.deltaTime);

            }
            else
            { 
                Direcction = true;
            }
        }
    }
    public void Cambio(bool sedebemover)
    {
        SeDebeMover = sedebemover;
    }

}
