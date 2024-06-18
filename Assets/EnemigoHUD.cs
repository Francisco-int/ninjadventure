using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoHUD : MonoBehaviour
{
    //SLIDER
    [SerializeField] Slider sliderVida;


    private void OnEnable()
    {
        Flam.enemyHit += ActualizarBarraDeVida;
        Jugador.jugadorHit += ActualizarBarraDeVida;
    }

    private void OnDisable()
    {

        Flam.enemyHit -= ActualizarBarraDeVida;
        Jugador.jugadorHit -= ActualizarBarraDeVida;

    }


    public void ActualizarBarraDeVida (int vida)
    {
        sliderVida.value = vida;
    }
}
