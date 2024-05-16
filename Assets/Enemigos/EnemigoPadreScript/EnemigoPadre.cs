using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoPadre : MonoBehaviour
{
    [SerializeField] protected int vidaEnemigo;
    [SerializeField] protected float velocidadEnemgio;
    float posicionIdle;
    float atacarOtraVez;
    [SerializeField] protected float dañoDelEnemigo;
    Animator anim;
    Vector2 playerPos;
    bool irAtacar;
    bool Atacar;
    [SerializeField] protected bool largaDistancia; //Esto sirve para declarar si un
                                                    //enemigo atacara a corta(false) o larga(true) ditancia
    Vector2 enemigoPos;
    Jugador jugador;
    float xJugador;
    float yJugador;
    float xEnemigo;
    float yEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<Jugador>();
        anim = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (irAtacar)
        {
            MovimientoEnemigos();
        }
        playerPos = jugador.transform.position;
        enemigoPos = gameObject.transform.position;
        
    }

   protected void MovimientoEnemigos() //Movimiento del enemigo hacia el jugador con animaciones
    {
        
        if (playerPos.x > enemigoPos.x)
        {
            anim.SetInteger("Walk", 1);
        }
        if (playerPos.x < enemigoPos.x)
        {
            anim.SetInteger("Walk", 2);
        }
        if (playerPos.y > enemigoPos.y)
        {
            anim.SetInteger("Walk", 3);
        }
        if (playerPos.y < enemigoPos.y)
        {
            anim.SetInteger("Walk", 4);
        }

        transform.Translate(playerPos * Time.deltaTime * velocidadEnemgio);

    }
    void Ataque() //Esto realizara la animación y el intercambio de valores para el daño que recibe el jugador
    {
        DirecionAtaque();
        jugador.GTvidaJugador = dañoDelEnemigo;
        StartCoroutine(AtaqueCoolDownAnimation());
    }


    IEnumerator AtaqueCoolDownAnimation()
    {

        yield return new WaitForSeconds(posicionIdle);

        anim.SetInteger("Ataque", 0);

        yield return new WaitForSeconds(atacarOtraVez);
        if (Atacar)
        {
            Ataque();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Al colisionar con el player empezar a atacar y no perseguir
    {
        Debug.Log("Colicion");
        if (collision.gameObject.GetComponent<Jugador>() && largaDistancia!)
        {
            irAtacar = false;
            Atacar = true;
            Ataque();        
        }
    }
    private void OnCollisionExit2D(Collision2D collision) //Si sale de la colición empezar a perseguir
    {
        Atacar = false;
        irAtacar = true;  
    } 
    private void OnTriggerEnter2D(Collider2D collider) //Detecta al player a una cierta distancia y lo empiza a perseguir
    {
        Debug.Log("Trigger");
        if (collider.gameObject.GetComponent<Jugador>() && largaDistancia!)
        {
            irAtacar = true;
        }
        if (collider.gameObject.GetComponent<Jugador>() && largaDistancia)
        {
            irAtacar = false;
            Atacar = true;
            Ataque();       
        }
    }
    void DirecionAtaque()
    { 
        xJugador = jugador.transform.position.x;
        yJugador = jugador.transform.position.y;
        xEnemigo = gameObject.transform.position.x;
        yEnemigo = gameObject.transform.position.y;

        if (xJugador > xEnemigo && yJugador - yEnemigo < xJugador - xEnemigo)
        {
            anim.SetInteger("Ataque", 1);
        }
        if (xJugador < xEnemigo && yJugador - yEnemigo > xJugador - xEnemigo)
        {
            anim.SetInteger("Ataque", 2);
        }
        if (yJugador > yEnemigo && xJugador - xEnemigo < yJugador - yEnemigo)
        {
            anim.SetInteger("Ataque", 3);
        }
        if (yJugador < yEnemigo && xJugador - xEnemigo > yJugador - yEnemigo)
        {
            anim.SetInteger("Ataque", 4);
        }
        Debug.Log("Animacion Ataque");
        
    } 


    protected abstract void LanzarBolaFuego(); 

}
