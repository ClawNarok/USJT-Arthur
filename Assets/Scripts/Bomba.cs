using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    void Start()
    {
        Invoke("fazBoom", 3);
    }

    void fazBoom()
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in  hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(30, transform.position, 10);
            }
        }
    }
}