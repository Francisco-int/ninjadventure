using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoData", menuName = "Enemy")]
public class Scriptableenemigo : ScriptableObject
{
    [SerializeField] int vida;
    [SerializeField] float velocidad;
    [SerializeField] float timeAtaque;
    [SerializeField] int da�oAtaque;
    [SerializeField] int da�oRecibido;

    public int Vida { get { return vida; } }
    public float Velocidad { get { return vida; } }
    public float TimeAtaque { get { return vida; } }
    public int Da�oAtaque { get { return vida; } }
    public int Da�oRecibido { get { return vida; } }

}
