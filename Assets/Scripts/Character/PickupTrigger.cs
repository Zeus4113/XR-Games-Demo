using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{

    public delegate void UpdateScore(int score);
    public static event UpdateScore IncreaseScore;

    public void Init()
    {

    }

    public void Run()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                IncreaseScore(other.gameObject.GetComponent<Pickup>().GetPickedUp());
            }
        } 
    }
}
