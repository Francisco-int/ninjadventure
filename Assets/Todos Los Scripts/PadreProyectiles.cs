using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PadreProyectiles : MonoBehaviour //Esta clase servirá de base para todos aquellos
                                                       //objetos que son lanzados o son proyectiles
{

    [SerializeField] int dañoDelProyectil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(colision enemigo, jugador, etc)
        {
            //Dependiendo con que colisione obtendra el script o la
            //clase y le sacara vida, ya sea el jugador o un enemigo
        }
    }
}
