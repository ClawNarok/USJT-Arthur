using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawmPlayer : MonoBehaviour
{
    public GameObject prefabPlayer;
    GameObject Player;


    void Start()
    {
        var p = Player == null ? prefabPlayer : Player;

        if (AutoSave.posUltimaParada == Vector3.zero)
        {
            GameObject Spawn = GameObject.Find("Player");
            Player = Instantiate(p, Spawn.transform.position, Spawn.transform.rotation);
            Destroy(Spawn);
        }
        else
        {
            string cena = SceneManager.GetActiveScene().name;

            switch (cena)
            {
                case "Ilha":
                    GameObject Spawn = GameObject.Find("Player");
                    Destroy(Spawn);
                    Player = Instantiate(p, AutoSave.posUltimaParada, AutoSave.rotUltimaParada);

                    break;
                case "Caverna1":
                case "Caverna2":
                case "Caverna3":
                    GameObject spawnCaverna = GameObject.Find("Player");
                    Player = Instantiate(p, spawnCaverna.transform.position, spawnCaverna.transform.rotation);
                    Destroy(spawnCaverna);
                    break;
            }
        }
    }
}