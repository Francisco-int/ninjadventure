using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    [SerializeField] float vidaJugador;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float fuerzaSalto;
    bool saltoHabilitado;
    float saltoCoolDown;
    [SerializeField] float kunaiFuerzaDisparo;
    float horizontal;
    float vertical;
    Animator anim;
    int idle;
    GameObject kunai;
    Quaternion kunaiRot;
    protected int monedas;
    protected List<GameObject> inventario;
    Slider barraVida;
    public float GTvidaJugador { get { return vidaJugador; } set { vidaJugador -= value; } }
    
    // Start is called before the first frame update
    void Start()
    {
        saltoHabilitado = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimientos();
        Ataque();
    }

    void Movimientos()  //Movimiento: esta sección se encarga de mover el objeto en el mundo o escena y reproducir las animaciones
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
        //Salto: Esta sección se encarga del salto de jugador
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
    void Ataque()   //Ataques: Esta sección se encarga de los ataques basicos del jugador y de sacarle vida a los enemigos
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

    void UIMAnager()
    {
        //Este método ira actualizando la información, del personaje, que se le de al jugador en pantalla
    }
    void Curacion(int curar)
    {
        //Le suma a la vida del jugador el valor tranferido. 
    }
}

