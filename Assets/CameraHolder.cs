using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    public void Init()
    {
        m_camera.transform.rotation = this.transform.rotation;
    }

    public void Run()
    {
        m_camera.transform.position = this.transform.position;
        
    }
}
