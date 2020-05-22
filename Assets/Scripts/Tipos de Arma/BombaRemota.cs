﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaRemota : MonoBehaviour
{
    public GameObject Efeito;

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bomba"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.LookAt(col.gameObject.transform);
        }
    }

    public void ExplodirRemotamente()
    {
        Instantiate(Efeito, transform.position, Quaternion.identity);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in  hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(500, transform.position, 10, 25);
            }
        }
        Destroy(gameObject);
    }
}