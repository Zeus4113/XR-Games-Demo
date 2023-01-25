using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed;
    private GameObject m_cameraHolder;
    private bool disableInput;


    public void Init()
    {
        GameManager.FailedState += DisableMovement;
        GameEndTrigger.CompleteState += DisableMovement;
        this.GetComponentInChildren<CameraHolder>().Init();
        disableInput = false;
    }

    public void Run()
    {
        this.GetComponentInChildren<CameraHolder>().Run();
        if (!disableInput)
        {
            Move();
        }
    }

    public void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalMovement, 0, -horizontalMovement);

        this.transform.position += movement * m_movementSpeed * Time.deltaTime;
    }

    public void DisableMovement()
    {
        disableInput = true;
    }

}
