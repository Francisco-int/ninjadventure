using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGold : EnemigoPadre
{
    [SerializeField] private Scriptableenemigo enemyData;

    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = enemyData.Vida;
        velocidadEnemigo = enemyData.Velocidad;
        atacarOtraVez = enemyData.TimeAtaque;
        da�oDelEnemigo = enemyData.Da�oAtaque;
        da�oDelJugador = enemyData.Da�oRecibido;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarEnemigo();
    }
    protected override void RecibirDa�o(int cantidadDeDa�o)
    {
        //Hara la cuenta que dara la vida que le queda al enemigo
    }
    protected override void Huir()
    {
        //Tendra su propia condici�n de huida
    }
    protected override void Drop()
    {
        //Tendra sus propios objetos que soltar
    }

}
