using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Player;
    public float velRotacao = 10f;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!Player)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
                Player = GameObject.FindGameObjectWithTag("Player");

            return;
        }

        transform.position = Player.transform.position;
        float rot = Input.GetAxis("Mouse X");

        transform.Rotate(0, rot * velRotacao * Time.deltaTime, 0);
    }
}