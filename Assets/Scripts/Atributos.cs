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
    public AudioClip somSofrerDano;
    AudioSource SFX;

    void Awake()
    {
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        vidaAtual = vida;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
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

    public void DesferirGolpe(GameObject gbj)
    {
        if (gbj.transform.GetComponent<Atributos>().vidaAtual > 0)
            gbj.transform.GetComponent<Atributos>().ReceberDano(dano);
    }
}