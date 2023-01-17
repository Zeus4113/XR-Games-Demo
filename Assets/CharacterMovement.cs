using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed;
    private GameObject m_cameraHolder;


    public void Init()
    {
        this.GetComponentInChildren<CameraHolder>().Init();
    }

    public void Run()
    {
        this.GetComponentInChildren<CameraHolder>().Run();
        Move();
    }

    public void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(verticalMovement, 0, -horizontalMovement);

        this.transform.position += movement * m_movementSpeed * Time.deltaTime;
    }


}
