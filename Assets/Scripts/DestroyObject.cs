using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 0.3f);
    }
}
