using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flam : EnemigoPadre, IDamageable
{

    public static Action<int> enemyHit;
  
    // Start is called before the first frame update
    void Start()
    {
        LanzarBolaFuego();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected override void Huir()
    {
        //Tendra su propia condici�n de huida
    }
    protected override void Drop()
    {
        //Tendra sus propios objetos que soltar
    }
    protected override void RecibirDa�o(int cantidadDeDa�o)
    {
        //Hara la cuenta que dara la vida que le queda al enemigo
    }
    void LanzarBolaFuego() //Este enemigo es el �nico que tiene un ataque
                           //a distancia lanzando un proyectil, mientras que los
                           //demas atacan a la cernania, siendo inecesario poner este
                           //metodo, unico para este personaje, en la clase padre/base.
    {
        //Lanza bola de fuego
    }
    public void TakeDamage(int damage)
    {
        vidaEnemigo -= damage;
        enemyHit?.Invoke(vidaEnemigo);
        // La l�gica para que el enemigo reciba da�o
    }

}
