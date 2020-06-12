using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooter : MonoBehaviour
{
    public GameObject[] projetilPrefab;
    public int projetilIndice = 0;
    public Text txtArma;

    void Awake()
    {
        if (!txtArma)
        {
            txtArma = GameObject.Find("Armas").GetComponent<Text>();
            txtArma.text = string.Concat("Arma: ", projetilIndice + 1, "/", projetilPrefab.Length);
        }
    }

    void FixedUpdate()
    {
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3 (-movx, 0, 0));
        transform.localRotation = NormalizaY(transform.localRotation);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myprojectile = Instantiate(projetilPrefab[projetilIndice], transform.position + transform.forward, transform.localRotation);
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (FindObjectOfType<BombaRemota>())
            {
                var remotas = FindObjectsOfType<BombaRemota>();
                for (int x = 0; x < remotas.Length; x++)
                {
                    remotas[x].ExplodirRemotamente();
                }
            }
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            projetilIndice -= (int)Input.mouseScrollDelta.y;

            if (projetilIndice >= projetilPrefab.Length)
                projetilIndice = 0;

            if (projetilIndice < 0)
                projetilIndice = projetilPrefab.Length - 1;

            txtArma.text = string.Concat("Arma: ", projetilIndice + 1, "/", projetilPrefab.Length);
        }
    }

    Quaternion NormalizaY(Quaternion pos)
    {
        float x = pos.x;
        if (x > .5f)
            x = .5f;
        if (x < -.5f)
            x = -.5f;
        pos = new Quaternion(x, pos.y, pos.z, pos.w);
        return pos;
    }
}