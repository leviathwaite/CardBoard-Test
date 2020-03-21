using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterParticleEffect : MonoBehaviour
{
    void Start()
    {
        var psys = this.GetComponent<ParticleSystem>();
        Destroy(this.gameObject, psys.main.duration);
    }

}
