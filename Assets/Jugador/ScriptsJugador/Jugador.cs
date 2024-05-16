using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    [SerializeField]protected int vidaJugador;
    [SerializeField] float velocidadMovimiento;   
    [SerializeField] float fuerzaSalto;
    bool saltoHabilitado;
    [SerializeField] float saltoCoolDown;
    [SerializeField] float kunaiFuerzaDisparo;
    protected int monedas;
    float horizontal;
    float vertical;
    Animator anim;
    int idle;
    GameObject kunai;
    Quaternion kunaiRot;
    Slider barraVida;
    protected List<GameObject> inventario;
    List<SpriteRenderer> UISprites; //Servira para representar visualmente los objeto que el jugador tiene en su inventario
     public int GTvidaJugador { get { return vidaJugador; } set { vidaJugador -= value; } }

    // Start is called before the first frame update
    void Start()
    {
        saltoHabilitado = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimacionYMovimientos();

    }


    void AnimacionYMovimientos() //Esta función abarca desde el movimiento del objeto y
                                 //sus animaciones
    {
        MovimientoJugador();//Movimiento del jugador
        Ataque();//Ataque del jugador

        

            //Salto del Jugador
            if (Input.GetKeyDown(KeyCode.Space) && saltoHabilitado)
        {
            saltoHabilitado = false;
            StartCoroutine(ActivarSalto());      
        }
        IEnumerator ActivarSalto() 
        {
            anim.SetBool("Saltar", true);
            Rigidbody2D rbJugador = GetComponent<Rigidbody2D>();
            rbJugador.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
            yield return new WaitForSeconds(saltoCoolDown);
            saltoHabilitado = true;
        }

        
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (Ataque y colision enemigo)
        {
            //Llamara al metodo RecibirDaño del EnemgioPadre pasandole un valor(la cantidad de daño)
        }
        //if(colision moneda)
        {
           //le suma 1 a la variable monedas
        }
    }
    void UIUpdate()
    {
        //Esta metodo, reflegara de manera visual la información que el
        //jugador necesita saber de su personaje, ademas de informar de los objetos que el jugador tenga a su poseción
    }
    void MovimientoJugador()

    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 movePlayer = new Vector2(horizontal, vertical) * Time.deltaTime * velocidadMovimiento;

        transform.Translate(movePlayer);

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("WalkX", 0);
            idle = 1;
            anim.SetInteger("Idle", idle);
            kunaiRot = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("WalkX", 0);
            idle = 2;
            anim.SetInteger("Idle", idle);
            kunaiRot = new Quaternion(0, 0, 180, 0);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("WalkY", 0);
            idle = 3;
            anim.SetInteger("Idle", idle);
            kunaiRot = new Quaternion(0, 0, 90, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("WalkY", 0);
            idle = 4;
            anim.SetInteger("Idle", idle);
            kunaiRot = new Quaternion(0, 0, -90, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("WalkX", 1);
            idle = 0;
            anim.SetInteger("Idle", idle);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("WalkX", -1);
            idle = 0;
            anim.SetInteger("Idle", idle);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("WalkY", 1);
            idle = 0;
            anim.SetInteger("Idle", idle);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("WalkY", -1);
            idle = 0;
            anim.SetInteger("Idle", idle);
        }
    }
    void Ataque()
    {
        
        if (Input.GetKeyDown(KeyCode.V))
        {

            switch (idle)
            {
                case 1:
                    anim.SetInteger("Ataque", 1);
                    break;
                case 2:
                    anim.SetInteger("Ataque", 2);
                    break;
                case 3:
                    anim.SetInteger("Ataque", 3);
                    break;
                case 4:
                    anim.SetInteger("Ataque", 4);
                    break;
            }
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            //StartCoroutine(Timer(ataqueAnimacionTime));
            anim.SetInteger("Ataque", 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject newKunai = Instantiate(kunai, transform.position, kunaiRot);
            Rigidbody2D rbKunai = newKunai.GetComponent<Rigidbody2D>();
            rbKunai.AddForce(newKunai.transform.right * kunaiFuerzaDisparo);
        }
    }
    protected void Curacion(int curacion) //Esta función sera llamada por una clase hija "Curaciones"
                                          //y le sumara vida al jugador según el valor transferido
    {
        //Cura al jugador
        vidaJugador += curacion;
    }
}
