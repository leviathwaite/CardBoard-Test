using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifetime : MonoBehaviour
{
    [SerializeField]
    private float destroyAfter = 2;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

}
