using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public DamageManager damageManager;

    public int playerDamageAmount;
    public int enemyDamageAmount;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageManager.InflictDamage(damageable, playerDamageAmount);
               
                Debug.Log("Daño inplementado al enemigo: " + playerDamageAmount);
            }
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageManager.InflictDamage(damageable, enemyDamageAmount);
                Debug.Log("Daño inplementado al jugador: " + enemyDamageAmount);
            }
        }

    }  
}
