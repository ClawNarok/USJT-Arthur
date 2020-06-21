using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tocha : MonoBehaviour
{
    public GameObject Player;


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
            Player = GameObject.FindGameObjectWithTag("Player");
        else
            return;

        transform.position = new Vector3 (MovePlayer.posPlayer.x, MovePlayer.posPlayer.y + 8, MovePlayer.posPlayer.z);
    }
}