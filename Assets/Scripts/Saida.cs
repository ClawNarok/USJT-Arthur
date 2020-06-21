using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saida : MonoBehaviour
{
    public GameObject[] Portal;
    public int qtInimigos;
    public int qtMortes;

    void Start()
    {
        qtInimigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void AtivarSaida()
    {
        qtMortes += 1;
        if (qtMortes == qtInimigos)
        {
            for (int x = 0; x < Portal.Length; x++)
            {
                Portal[x].SetActive(true);
            }
        }
    }
}