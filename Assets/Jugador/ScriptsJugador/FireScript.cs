using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript :  PowerUps
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collect();
    }
}
