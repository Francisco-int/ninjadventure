using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : PowerUps
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collect();
    }
}