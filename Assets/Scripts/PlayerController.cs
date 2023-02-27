using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    private float speedRotate = 270;
    public Animator animator;
    private float horizontalInput;
    private float verticalInput;
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Speed_f", 0.0f);
        if (horizontalInput!=0 || verticalInput != 0)
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
    }

    void Walk()
    {
        animator.SetFloat("Speed_f", 0.26f);

        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * speedRotate);
    }

    void Run()
    {
        animator.SetFloat("Speed_f", 0.6f);
        speed *= 2;
    }
}
