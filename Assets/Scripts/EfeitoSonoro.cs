using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoSonoro : MonoBehaviour
{
    public GameObject SFX = null;

    public void DisparoSFX(AudioClip som, Vector3 pos)
    {
        var sfx = Instantiate(SFX, pos, Quaternion.identity);
        sfx.GetComponent<AudioSource>().PlayOneShot(som);
        Destroy(sfx, som.length + 1);
    }
}