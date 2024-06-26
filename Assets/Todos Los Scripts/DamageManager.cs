using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    // M�todo para infligir da�o a un objeto IDamageable
    public void InflictDamage(IDamageable damageable, int damageAmount)
    {
        // Verificar que el objeto no sea nulo antes de intentar infligir da�o
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("El objeto no implementa la interfaz IDamageable o es nulo.");
        }
    }
}