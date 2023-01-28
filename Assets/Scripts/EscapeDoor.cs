using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    [SerializeField] bool isPlayerPresent;
    [SerializeField] bool isLocked;
    [SerializeField] GameObject myDoor;
    [SerializeField] int collectedTally;

    private void Start()
    {
        collectedTally = 0;
        PickupTrigger.IncreaseScore += TallyPickups;
    }

    void TallyPickups(int increment)
    {
        collectedTally++;
    }

    IEnumerator DoorOpen()
    {
        float myTime = 400f;
        while(myTime > 0)
        {
            myDoor.transform.Translate(0, -0.01f, 0);
            myTime--;
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(collectedTally >= 5)
            {
                StartCoroutine(DoorOpen());
            }
        }
    }
}
