using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlanet : MonoBehaviour
{
    [SerializeField] private float m_xAngle, m_yAngle, m_zAngle;

    private void Update()
    {
        this.transform.Rotate(m_xAngle, m_yAngle, m_zAngle, Space.Self); ;
    }
}
