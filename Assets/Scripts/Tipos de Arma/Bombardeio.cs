using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombardeio : MonoBehaviour
{
    public GameObject Alvo;
    public GameObject Efeito;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Alvo)
        {
            Instantiate(Efeito, transform.position, Quaternion.identity);
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in  hits)
                {
                    if (!hit.transform.gameObject.CompareTag("Bomba"))
                        if (hit.rigidbody)
                            hit.rigidbody.AddExplosionForce(800, transform.position, 10, 50);
                }
            }
            Destroy(Alvo);
            Destroy(gameObject);
        }
    }
}