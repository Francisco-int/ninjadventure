using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoPadre : MonoBehaviour
{
    [SerializeField] float velocidadEnemgio;
    [SerializeField] float posicionIdle;
    [SerializeField] float atacarOtraVez;
    [SerializeField] float dañoDelEnemigo;
    public Animator anim;
    [SerializeField] Vector2 playerPos;
    [SerializeField] bool irAtacar;
    [SerializeField] bool Atacar;
    [SerializeField] bool largaDistancia;
    [SerializeField] bool cortaDistancia;
    [SerializeField] Vector2 enemigoPos;
    [SerializeField] Jugador jugador;
    [SerializeField] float xJugador;
    [SerializeField] float yJugador;
    [SerializeField] float xEnemigo;
    [SerializeField] float yEnemigo;

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

    void MovimientoEnemigos()
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
    void Ataque()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colicion");
        if (collision.gameObject.GetComponent<Jugador>() && largaDistancia!)
        {
            irAtacar = false;
            Atacar = true;
            Ataque();        
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Atacar = false;
        irAtacar = true;  
    } 
    private void OnTriggerEnter2D(Collider2D collider)
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
