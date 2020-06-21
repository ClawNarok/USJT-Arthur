using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporte : MonoBehaviour
{
    public enum Ponto { Ilha, Caverna1, Caverna2, Caverna3 }
    public Ponto Destino;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Destino.ToString());
            if (SceneManager.GetActiveScene().name == "Ilha")
            {
                AutoSave.posUltimaParada = other.transform.position;
                AutoSave.rotUltimaParada = other.transform.rotation;
            }
        }
    }
}