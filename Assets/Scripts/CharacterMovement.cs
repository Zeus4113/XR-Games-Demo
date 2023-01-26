using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed;
    [SerializeField] private float m_jumpForce;

    private GameObject m_cameraHolder;
    private bool m_disableInput;
    private Rigidbody m_rigidbody;
    private bool m_isJumping;


    public void Init()
    {
        this.GetComponentInChildren<CameraHolder>().Init();

        m_rigidbody = GetComponent<Rigidbody>();
        GameManager.FailedState += DisableMovement;
        GameEndTrigger.CompleteState += DisableMovement;
        m_disableInput = false;
    }

    public void Run()
    {
        this.GetComponentInChildren<CameraHolder>().Run();

        if (!m_disableInput)
        {
            Move();
            Jump();
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
        m_disableInput = true;
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !m_isJumping)
        {
            m_rigidbody.AddForce(this.transform.up * m_jumpForce, ForceMode.Impulse);
            m_isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            m_isJumping = false;
        }
    }

}
