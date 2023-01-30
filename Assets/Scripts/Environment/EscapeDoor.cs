using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    [SerializeField] GameObject m_myDoor;
    [SerializeField] int m_collectedTally;
    [SerializeField] int m_requiredTally;
    [SerializeField] GameObject[] m_doorLights;
    [SerializeField] Material m_greenLight;

    public void Init()
    {
        m_collectedTally = 0;
        PickupTrigger.IncreaseKeycard += TallyPickups;
    }

    void TallyPickups(int increment)
    {
        if(m_doorLights[m_collectedTally]  != null)
        {
            Renderer myRenderer = m_doorLights[m_collectedTally].GetComponent<Renderer>();
            myRenderer.material = m_greenLight;
            m_collectedTally += increment;


            Debug.Log(m_collectedTally);
        }

        if (m_collectedTally >= m_requiredTally)
        {
            Debug.Log("DoorOpen");
            StartCoroutine(DoorOpen());
        }

        if (m_collectedTally >= m_doorLights.Length)
        {
            Debug.Log("ResetTally");
            m_collectedTally = 0;
        }
    }

    IEnumerator DoorOpen()
    {
        float myTime = 400f;
        while(myTime > 0)
        {
            m_myDoor.transform.Translate(0, -0.01f, 0);
            myTime--;
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }
}
