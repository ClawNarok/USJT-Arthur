using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeAnimacao : MonoBehaviour
{
    Animator anim;
    public AnimationClip atk1;
    public AnimationClip atk2;
    public bool Atacando = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(float vel)
    {
        anim.SetFloat("Velocidade", vel);
    }

    public void Atk1()
    {
        anim.SetInteger("Ataque", 1);
        StartCoroutine(ResetaAtaque());
    }

    public void Atk2()
    {
        anim.SetInteger("Ataque", 2);
        StartCoroutine(ResetaAtaque());
    }

    public void Morte()
    {
        anim.SetTrigger("Morte");
    }

    IEnumerator ResetaAtaque()
    {
        Atacando = true;
        yield return new WaitForSeconds(0.75f);
        anim.SetInteger("Ataque", 0);
        Atacando = false;
    }
}