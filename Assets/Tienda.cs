using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : Jugador //Es hija del jugador para que los intercambios
                              //de la tienda con el jugador sea mas eficiente.
{
    List<SpriteRenderer> objetosTienda; //Aquí estarán los objetos de la tienda
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(colisiona con jugador)
        {
            //Muestra la UI de la tienda ademas de los objetos disponibles
        }
    }
    public void Comprar(GameObject objetoComprado, int coste)
    {
        //Esta función le agregara el objeto que el jugador compro a su inventario
        //y le sacara las monedas segun el valor del objeto comprado. La lógica es desde un
        //boton llama a esta fución pasandole el objeto y el coste, y agregandoselo al jugador y
        //restadole a las monedas del jugador el valor de coste.
    }
}
