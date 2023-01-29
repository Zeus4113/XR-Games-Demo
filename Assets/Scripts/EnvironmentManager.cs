using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] lightingArray;
    [SerializeField] private GameObject exitDoor;

    public void Init()
    {
        for(int i = 0; i < lightingArray.Length; i++)
        {
            lightingArray[i].GetComponent<EmergencyLight>().Init();
        }

        exitDoor.GetComponent<EscapeDoor>().Init();
    }

    
    void Run()
    {
        
    }
}
