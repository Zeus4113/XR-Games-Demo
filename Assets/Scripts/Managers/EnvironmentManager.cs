using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_lightingArray;
    [SerializeField] private GameObject m_exitDoor;

    public void Init()
    {
        for(int i = 0; i < m_lightingArray.Length; i++)
        {
            m_lightingArray[i].GetComponent<EmergencyLight>().Init();
        }

        m_exitDoor.GetComponent<EscapeDoor>().Init();
    }

    
    void Run()
    {
        
    }
}
