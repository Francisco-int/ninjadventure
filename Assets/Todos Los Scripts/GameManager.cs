using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Jugador jugador;
    public Flam flam;

    public DamageManager damageManager;

    public int dañoJugador;
    public int dañoEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        damageManager.InflictDamage(jugador, dañoJugador);
        damageManager.InflictDamage(flam, dañoEnemigo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Tendra un colisionador que detecte al jugador, si colisiona el jugador pasara al siguiente nivel
    }

}
