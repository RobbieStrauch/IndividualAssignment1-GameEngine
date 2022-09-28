using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public Transform playerPosition;
    int health = 100;

    public GameObject star;

    private float raycastRange = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int raycastCount = 40;
        int layerMask = 1 << 6;


        for (int i = 0; i < raycastCount; i++)
        {
            Quaternion raycastRotation = Quaternion.AngleAxis((i / (float)raycastCount) * 180f - 90f, Vector3.up);
            Vector3 lookDirection = transform.rotation * raycastRotation * Vector3.forward;

            RaycastHit rhit;

            if (Physics.Raycast(transform.position + Vector3.up, lookDirection, out rhit, raycastRange, layerMask))
            {
                Debug.DrawRay(transform.position + Vector3.up, lookDirection * rhit.distance, Color.red);
                transform.LookAt(playerPosition);
            }
            else
            {
                Debug.DrawRay(transform.position + Vector3.up, lookDirection * 1000, Color.white);
            }
        }

        if (health <= 0)
        {
            Instantiate(star, transform.position + Vector3.up * 3, star.transform.rotation);
            Destroy(gameObject);
        }
    }

    public void ChangeHealth(int amount)
    {
        health -= amount;
    }

    public int GetHealth()
    {
        return health;
    }
}
