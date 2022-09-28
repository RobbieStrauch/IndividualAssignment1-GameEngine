using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ChangeHealth(5);
        }

        Destroy(gameObject);
    }
}
