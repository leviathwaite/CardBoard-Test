using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 2;
    [SerializeField]
    private bool flyTowardsPlayer = false;
    [SerializeField]
    private float flyTowardPlayerRadius = 1;
    [SerializeField]
    private float findPlayerRadius = 5;
    [SerializeField]
    private bool update = false;

    private GameObject player;
    private SphereCollider playerDetector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDetector = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(update)
        {
            if(flyTowardsPlayer)
            {
                playerDetector.radius = flyTowardPlayerRadius;
            }
            else
            {
                playerDetector.radius = findPlayerRadius;
            }
        }
        if(flyTowardsPlayer)
        {
            FlyTowardsPlayer();
        }
    }

    private void FlyTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(update == false)
        {
            update = true;

            if (flyTowardsPlayer)
            {
                // arrived at player
                flyTowardsPlayer = false;
            }
            else
            {
                // found player
                flyTowardsPlayer = true;
            }
        }
        
    }
}
