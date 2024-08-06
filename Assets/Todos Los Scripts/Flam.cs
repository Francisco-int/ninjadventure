using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flam : EnemigoPadre
{

  
    // Start is called before the first frame update
    void Start()
    {
        LanzarBolaFuego();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarEnemigo();
    }
    protected override void Huir()
    {
        //Tendra su propia condición de huida
    }
    protected override void Drop()
    {
        //Tendra sus propios objetos que soltar
    }
    protected override void RecibirDaño(int cantidadDeDaño)
    {
        
    }
    void LanzarBolaFuego() //Este enemigo es el único que tiene un ataque
                           //a distancia lanzando un proyectil, mientras que los
                           //demas atacan a la cernania, siendo inecesario poner este
                           //metodo, unico para este personaje, en la clase padre/base.
    {
        //Lanza bola de fuego
    }
}
