using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointerVR : MonoBehaviour
{
    public GameObject hitEffectPrefab;

    [SerializeField]
    private float rayLength = 100.0f;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            FireRay();
        }
    }

    private void FireRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, cam.transform.forward, out hit, rayLength))
        {
            
            Debug.Log(hit.collider.name);
            if(hit.collider.CompareTag("Fly"))
            {
                // TODO check if dead
                Health hitHealth = hit.collider.gameObject.GetComponent<Health>();
                if(hitHealth)
                {
                    
                    hitHealth.Damage(34);
                }
            }

            Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Instantiate(hitEffectPrefab, hit.point, rot);
        }
    }

    private void OnDrawGizmos()
    {
        if(cam)
        Debug.DrawRay(transform.position, cam.transform.forward * rayLength, Color.green);
    }
}
