using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    float speed = 2;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;
    float jumpHeight = 2f;
    Vector3 moveDir = Vector3.zero;

    UnityEngine.CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<UnityEngine.CharacterController>();
        //controller = gameObject.AddComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameController.instance.gamePlaying)
        {
            if (controller.isGrounded)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetFloat("Condition", (float)1.1);
                    moveDir = new Vector3(0, 0, (float)1.1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        anim.SetFloat("Condition", (float)2.1);
                        moveDir = new Vector3(0, 0, (float)2.1);
                        moveDir *= (speed * (float)1.5);
                        moveDir = transform.TransformDirection(moveDir);
                    }
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    anim.SetFloat("Condition", (float)0.9);
                    moveDir = new Vector3(0, 0, 0);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetFloat("JumpCondition", (float)1.1);
                    moveDir.y = Mathf.Sqrt(jumpHeight * -2 * -gravity);
                }
                else
                {
                    anim.SetFloat("JumpCondition", (float)0.9);
                }
            }

            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }
}
