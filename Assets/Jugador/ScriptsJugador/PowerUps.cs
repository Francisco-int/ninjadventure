using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Jugador
{
    [SerializeField] int da�oBolaDeFuego;
    [SerializeField] int da�oPinchoHielo;
    int powerUpSelector;
    Transform firePoint; //Esto sirve para saver de donde ser� disparado el PowerUp
    float fuerzaProyectilPowerUp;
    List<GameObject> proyectilPowerUp; //Ac� estar� el proyectil(objeto) del PowerUp

    void Start()
    {

    }
    void Update()
    {
        //if(input 1)
        {
            //Esto le dara un valor a la variable powerUpSelector Ej powerUpSelector == 1
        }
        //if(input 2)
        {
            //Esto le dara un valor a la variable powerUpSelector Ej powerUpSelector == 2
        }
        //if(input B)
        {
            //Esto activara el metodo PowerUp
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(colisiona con enemigo)
        {
            //Le resta vida al enemigo segun da�oPowerUp
        }
    }
    void PowerUp()
    {
        //Esto comprobara el valor del powerUpSelector y activara cierto PowerUp.
        //Ej if(powerUpSelector == 1) 
        {
            //BolaDeFuego()
        }
    }

    void BolaDeFuego()
    {
        //Esto instanciara el objeto BolaDeFuego en la variable proyectilPowerUp(0)
        //y le sacara del iventario del jugador el objeto que le permite activar el PowerUp
    }
    void PinchoHielo()
    {
        //Esto instanciara el objeto PinchoHielo en la variable proyectilPowerUp(1)
        //y le sacara del iventario del jugador el objeto que le permite activar el PowerUp
    }
}
