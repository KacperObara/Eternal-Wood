using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int Hardness;

    public bool Spawned = false;

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
