using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 20f;
    public bool running = false;
    public Animator animator;
    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
    }
    void HandleMovementInput()
    {
        float AxisX = Input.GetAxis("Horizontal");
        float AxisZ = Input.GetAxis("Vertical");
        if (AxisX != 0 || AxisZ != 0)
        {
            animator.SetBool("running", true);
        }
        else 
        {
            animator.SetBool("running", false);
        }
        Vector3 _movement = new Vector3(AxisX, 0, AxisZ);
        transform.Translate(_movement * Speed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput() 
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }
}
