using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoPadre : MonoBehaviour //Esta clase es abstracta ya que servira como base o modelo para
                                                   //los comportamientos de los enemgios del juego
{
    //Protected: las variables en protected son las cuales son posibles que se modifiquen dentro de una clase hija
    //debido a tal situación en el juego, el valor de estas variables puede cambiar segun el enemigo

    //Las que están en privado pero con [SerializeField] tienen esto ya que brindan infonmación
    //del enemgio, ademas de por si se quiere modificar esas variables del enemigo por default
    [SerializeField] protected int vidaEnemigo; 
    [SerializeField] protected float velocidadEnemigo;  
    float posicionIdle;
    float atacarOtraVez;
    [SerializeField] protected int dañoDelEnemigo;
    Animator anim;
    Vector2 playerPos;
    bool irAtacar;
    bool Atacar;
    [SerializeField] bool largaDistancia; 
    Vector2 enemigoPos;
    Jugador jugador;
    float xJugador;
    float yJugador;
    float xEnemigo;
    float yEnemigo;
    public float GTvidaEnemigo { get { return vidaEnemigo; } set { vidaEnemigo -= value; } }

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<Jugador>();
        anim = GetComponent<Animator>();
        irAtacar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (irAtacar)
        {
            MovimientoEnemigos();
        }        
    }

    void MovimientoEnemigos() //Movimiento del enemigo hacia el jugador con animaciones
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

        transform.Translate(playerPos * Time.deltaTime * velocidadEnemigo);

    }
    void Ataque() //Esto realizara la animación y el intercambio de valores para el daño que reciba el jugador
    {
        DirecionAtaque();
        jugador.GTvidaJugador = dañoDelEnemigo;
        StartCoroutine(AtaqueCoolDownAnimation());
    }

    protected virtual void Huir()
    {
        //Los enemigos al tener poca vida hullen, es virtual ya que cada enemgio huira cuando su vida
        //sea menor a un cierto numero que varia por cada enemigo
        //no abstracta ya que por default tendra ya una condición de huida ya
        //especificada, pero a futuro según el enemigo puede cambiar lo que lleva a cambiaro el una clase hija.
    }

    protected virtual void Drop()//Virtual ya que cada enemigo soltara distintas reconpesas
    {
        //Dropea reconpesa luego de ser derrotado
    }
    protected abstract void RecibirDaño(int cantidadDeDaño);

    IEnumerator AtaqueCoolDownAnimation() //Esto sirve para que no haga un daño continuo cuando
                                          //colisiona con el player, sino que haya daño coodinado con la animación de atacar
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
    void DirecionAtaque() //Controlador de animación
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
}
