using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implosao : MonoBehaviour
{
    public GameObject Efeito;

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bomba"))
        {
            Instantiate(Efeito, transform.position, Quaternion.identity);
            GetComponent<Rigidbody>().isKinematic = true;

            RaycastHit[] hits;
            hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in  hits)
                {
                    if (hit.rigidbody)
                        hit.rigidbody.AddExplosionForce(-1000, transform.position, 20);
                }
            }
            Destroy(gameObject);
        }
    }

}