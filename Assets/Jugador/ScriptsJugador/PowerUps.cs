using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUps : Jugador
{
    int powerUpSelector; //Esto servira para saber cual tipo de powerUp hay que activar
    [SerializeField] int dañoPowerUp;

    void Start()
    {

    }
    void Update()
    {
        //if(input 1)
        {
            //Esto le dara un valor a la variable powerUpSelector 
        }
        //if(input 2)
        {
            //Esto le dara un valor a la variable powerUpSelector 
        }
        //if(input B)
        {
            //Esto activara el metodo PowerUp pasandole el valor de powerUpSelector
        }
    }

    void PowerUp(int tipoPowerUp)
    {
        //if(tipoPowerUp == 1)
        {
            //Activar metodo BolaDeFuego
        }
        //if(tipoPowerUp == 2)
        {
            //Activar metodo PinchoHielo
        }
    }

    void BolaDeFuego()
    {
        //Se ejecutara la animación y llamara al metodo RecibirDaño del enemigo
        //pasandole un valor(el daño de la habilidad). Y le eliminara el objeto 
        //que activa este powerUp del inventario del player.
    }
    void PinchoHielo()
    {
        //Se ejecutara la animación y llamara al metodo RecibirDaño del enemigo
        //pasandole un valor(el daño de la habilidad). Y le eliminara el objeto 
        //que activa este powerUp del inventario del player.
    }
}