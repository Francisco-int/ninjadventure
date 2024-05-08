using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    Animator anim;
   [SerializeField] int idle;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimacionYMovimiento();



    }


    void AnimacionYMovimiento()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 movePlayer = new Vector2(horizontal, vertical) * Time.deltaTime * velocidadMovimiento;

        transform.Translate(movePlayer);

        if(Input.GetKeyUp(KeyCode.W))
        {

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("Idle", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

        }
        if (Input.GetKeyUp(KeyCode.S))
        {

        }

        if (horizontal > 0)
        {
            anim.SetInteger("WalkX", Mathf.RoundToInt(horizontal));
            anim.SetInteger("Idle", 0);
        }
        else
        {
            anim.SetInteger("WalkX", Mathf.FloorToInt(horizontal));
        }
        if (vertical > 0)
        {
            anim.SetInteger("WalkY", Mathf.RoundToInt(vertical));
        }
        else
        {
            anim.SetInteger("WalkY", Mathf.FloorToInt(vertical));
        }
    }
}
