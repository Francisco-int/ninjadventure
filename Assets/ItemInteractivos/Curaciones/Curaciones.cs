using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curaciones : Jugador //El propositor de esta clase es tener un script que cure al player, pero que
                                  //lo �nico que hay que hacer es agregarle al objeto este script y
                                  //un collider, ademas de declarar en la variable curaci�n la cantidad
                                  //vida que le hara recuperar al jugador.
                                  //Por el lado contrario s� no tendria que hacer una
                                  //condicion de cada collider que cura en el jugador.
{

   [SerializeField] int curacion;

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
        //if(colision con jugador)
        {
            //Llama a la funci�n Curaci�n() del jugador pasandole el valor de la cantidad de curaci�n 
        }
    }
}
