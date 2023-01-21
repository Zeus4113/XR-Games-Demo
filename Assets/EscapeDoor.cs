using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    [SerializeField] bool isPlayerPresent;
    [SerializeField] bool isLocked;
    [SerializeField] GameObject myDoor;

    private void Update()
    {
        if (isPlayerPresent)
        {
            if (!isLocked)
            {
                DoorOpen();
            }
        }
    }

    void DoorOpen()
    {
        float myTime = 0;
        while(myTime < 3.0f)
        {
            myTime = +Time.deltaTime;
            myDoor.transform.Translate(transform.up * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerPresent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerPresent = false;
        }
    }
}
