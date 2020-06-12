using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{
    public CharacterController chtr;
    public float vel = 5;
    Vector3 move,rot;


    void Start()
    {
        if(!chtr)
            chtr = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rot.y = Input.GetAxis("Mouse X");
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * vel);
        transform.Rotate(rot);
    }
}