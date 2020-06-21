using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public int vida;
    public int vidaAtual;
    public int dano;
    [Space(20)]
    public GameObject particulaSofrerDano;
    public GameObject particulaCura;
    public AudioClip somSofrerDano;
    EfeitoSonoro SFX;
    GameObject Cura = null;

    void Awake()
    {
        SFX = GameObject.Find("CaixaDeSom").GetComponent<EfeitoSonoro>();
        vidaAtual = vida;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        Instantiate(particulaSofrerDano, transform.position, Quaternion.identity);
        SFX.DisparoSFX(somSofrerDano, transform.position);
        if (vidaAtual <= 0)
        {
            switch (tag)
            {
                case "Player":
                    GetComponent<ControleDeAnimacao>().Morte();
                    break;
                case "Enemy":
                    GetComponent<ControleDeAnimacaoInimigo>().Morte();
                    break;
            }
        }
    }

    void Update()
    {
        if (Cura)
            Cura.transform.position = transform.position + (Vector3.up / 2);
    }

    public void RegenVida()
    {
        vidaAtual = vida;
        Cura = Instantiate(particulaCura);
        Destroy(Cura, 3f);
    }
}