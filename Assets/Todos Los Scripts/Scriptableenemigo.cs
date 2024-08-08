using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemigoData", menuName = "Enemy")]
public class Scriptableenemigo : ScriptableObject
{
    [SerializeField] int vida;
    [SerializeField] float velocidad;
    [SerializeField] float timeAtaque;
    [SerializeField] int dañoAtaque;
    [SerializeField] int dañoRecibido;

    public int Vida { get { return vida; } }
    public float Velocidad { get { return vida; } }
    public float TimeAtaque { get { return vida; } }
    public int DañoAtaque { get { return vida; } }
    public int DañoRecibido { get { return vida; } }

}
