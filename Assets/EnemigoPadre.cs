using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoPadre : MonoBehaviour
{
    [SerializeField] float velocidadEnemgio;
    [SerializeField] float dañoDelEnemigo;
    [SerializeField] Animator anim;
    [SerializeField] Vector2 playerPos;
    [SerializeField] bool irAtacar;
    [SerializeField] Vector2 enemigoPos;
    [SerializeField] Jugador jugador;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Vector2>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (irAtacar)
        {

        }
    }

    void MovimientoEnemigos()
    {



        transform.Translate(playerPos * Time.deltaTime * velocidadEnemgio);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Jugador>())
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.GTvidaJugador = dañoDelEnemigo;
        }

    }

    protected abstract void LanzarBolaFuego();

}
