using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    Vector2 input;

    void Start()
    {
        animator = GetComponent<Animator>();   
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        input.x =  Input.GetAxis("Horizontal");
        input.y =  Input.GetAxis("Vertical");

        animator.SetFloat("InputX" , input.x);
        animator.SetFloat("InputY" , input.y);
    }
}
