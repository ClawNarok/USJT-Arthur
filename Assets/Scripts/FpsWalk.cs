using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{
    // public CharacterController chtr;
    // public Camera cam;
    // Vector3 move, rot, rotCam;
    // float ang;
    // public float vel = 10, velRot = 5;

    // void Start()
    // {
    //     if (!chtr)
    //         chtr = GetComponent<CharacterController>();
    //     if (!cam)
    //         cam = FindObjectOfType<Camera>();
    // }

    // void Update()
    // {
    //     rot.y = Input.GetAxis("Mouse X");
    //     rot.x = Input.GetAxis("Mouse Y");
    //     rotCam.x = Input.GetAxis("Mouse X");

    //     if (Input.GetKey(KeyCode.W))
    //         move = transform.forward * vel;
    //     if (Input.GetKey(KeyCode.S))
    //         move = -transform.forward * vel;
    //     if (Input.GetKey(KeyCode.D))
    //         move = transform.right * vel;
    //     if (Input.GetKey(KeyCode.A))
    //         move = -transform.right * vel;


    //     chtr.SimpleMove(move);
    //     transform.Rotate(rot * velRot);

    //     rot = move = Vector3.zero;
    // }

    #region Código do professor

    public CharacterController chtr;
    Vector3 move,rot;
    void Start()
    {
        if(!chtr)
            chtr = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //captura de rotacao do corpo
        rot.y = Input.GetAxis("Mouse X");
        //conversao de direcao local pra global 
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);
    }

    #endregion
}