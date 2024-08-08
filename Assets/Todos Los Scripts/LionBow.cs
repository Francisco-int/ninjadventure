using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBow : EnemigoPadre
{
    [SerializeField] private Scriptableenemigo enemyData;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = enemyData.Vida;
        velocidadEnemigo = enemyData.Velocidad;
        atacarOtraVez = enemyData.TimeAtaque;
        dañoDelEnemigo = enemyData.DañoAtaque;
        dañoDelJugador = enemyData.DañoRecibido;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarEnemigo();
    }
    protected override void RecibirDaño(int cantidadDeDaño)
    {
        //Hara la cuenta que dara la vida que le queda al enemigo
    }

    void PowerUpRound()
    {
            //Esta función que solo tendra el Jefe, servira para que cada ciertos rounds sus carasteristicas sean mejores
    }
    protected override void Huir()
    {
        //Tendra su propia condición de huida
    }
    protected override void Drop()
    {
        //Tendra sus propios objetos que soltar
    }


}
