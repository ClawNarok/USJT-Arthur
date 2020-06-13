using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos : MonoBehaviour
{
    public int vida;
    public int vidaAtual;
    public int dano;

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
    }

    
}