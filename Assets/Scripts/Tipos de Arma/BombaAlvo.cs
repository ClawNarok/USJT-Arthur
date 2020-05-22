using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaAlvo : MonoBehaviour
{
    public GameObject Bomba;
    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Bomba"))
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            AcionarBombardeio();
        }
    }

    void AcionarBombardeio()
    {
        var pos = transform.position;
        Quaternion q = new Quaternion(Quaternion.identity.x + 180, Quaternion.identity.y, Quaternion.identity.z, Quaternion.identity.w);
        GameObject b = Instantiate(Bomba, new Vector3(pos.x, pos.y + 50, pos.z), q);
        b.GetComponent<Bombardeio>().Alvo = gameObject;
    }
}