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
            Debug.Log("Working");
            if (other.gameObject.CompareTag("Pickup"))
            {
                Debug.Log("Working");
                IncreaseScore(other.gameObject.GetComponent<Pickup>().GetPickedUp());
            }
        } 
    }
}
