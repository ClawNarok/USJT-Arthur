using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaTemporizador : MonoBehaviour
{
    public GameObject Efeito;
    float tempo = 0;
    bool temporizador = false;

    void Update()
    {
        if (temporizador)
        {
            tempo += Time.deltaTime;
            if (tempo >= 6)
            {
                Explodir();
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        temporizador = true;
    }

    void Explodir()
    {
        Instantiate(Efeito, transform.position, Quaternion.identity);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in  hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(300, transform.position, 10, 15);
            }
        }
        Destroy(gameObject);
    }
}