using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{

    public delegate void UpdateScore(int score);
    public static event UpdateScore IncreaseScore;
    public static event UpdateScore IncreaseKeycard;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Pickup>() != null)
        {
            if (!other.gameObject.GetComponent<Pickup>().IsCollected)
            {
                if (other.gameObject.CompareTag("Pickup"))
                {
                    IncreaseScore(other.gameObject.GetComponent<Pickup>().GetPickedUp());
                }
                else if (other.gameObject.CompareTag("Keycard"))
                {
                    IncreaseKeycard(other.gameObject.GetComponent<Pickup>().GetPickedUp());
                }
            }
        } 
    }
}
