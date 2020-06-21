using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public LayerMask Chao;
    public float velMove = 15f, altura, forcaPulo;
    Rigidbody rdb;
    Vector3 mov;
    ControleDeAnimacao ctrAnim;
    public static Vector3 posPlayer;
    GameObject Seguidor;

    public bool andando;
    public bool noChao;
    public bool ataque;

    void Awake()
    {
        ctrAnim = GetComponent<ControleDeAnimacao>();
        rdb = GetComponent<Rigidbody>();
        Seguidor = FindObjectOfType<MoveCamera>().gameObject;
    }

    void FixedUpdate()
    {
        if (!ctrAnim.Atacando && !ctrAnim.Morto)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            mov = new Vector3(h, 0, v);

            //transform.LookAt(transform.position + mov * 3);
            transform.LookAt(transform.position + Seguidor.transform.TransformDirection(mov) * 3);

            if (mov.magnitude > 1f)
                mov.Normalize();

            andando = mov.magnitude > .1f;
            
            RaycastHit chaoHit;
            noChao = Physics.Raycast(transform.position, Vector3.down, out chaoHit, Mathf.Infinity, Chao);

            if (noChao)
            {
                Vector3 pos = transform.position;
                pos.y = chaoHit.point.y + altura;
                transform.position = pos;

                posPlayer = chaoHit.point;
            }

            if (mov.magnitude > .1f)
                transform.Translate(0,0, mov.magnitude * velMove * Time.deltaTime);

            //transform.rotation = Seguidor.transform.rotation;
            ctrAnim.Move(mov.magnitude);
        }

        rdb.velocity = Vector3.zero;
    }

    void Update()
    {
        if (ctrAnim.Morto)
            return;

        if (!ctrAnim.Atacando)
        {
            if (Input.GetButton("Fire1"))
                ctrAnim.Atk1();

            if (Input.GetButton("Fire2"))
                ctrAnim.Atk2();
        }
    }
}