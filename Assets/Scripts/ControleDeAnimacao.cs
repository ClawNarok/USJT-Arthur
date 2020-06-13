using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleDeAnimacao : MonoBehaviour
{
    Animator anim;
    public bool Atacando = false;
    public bool Morto = false;
    public GameObject particulaMorte;
    public AudioClip somMorte;
    AudioSource SFX;

    void Awake()
    {
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
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
        Morto = true;
        GetComponent<CapsuleCollider>().enabled = false;
        anim.SetTrigger("Morte");
        Instantiate(particulaMorte, transform.position, Quaternion.identity);
        SFX.PlayOneShot(somMorte);
        var inimigos = FindObjectsOfType<ControleDeAnimacaoInimigo>();
        for (int x = 0; x < inimigos.Length; x++)
        {
            inimigos[x].Venceu();
        }
        StartCoroutine(NovoJogo());
    }

    IEnumerator ResetaAtaque()
    {
        Atacando = true;
        yield return new WaitForSeconds(0.75f);
        anim.SetInteger("Ataque", 0);
        Atacando = false;
    }

    IEnumerator NovoJogo()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("SampleScene");
    }
}