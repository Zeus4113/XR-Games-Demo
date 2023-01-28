using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlanet : MonoBehaviour
{
    [SerializeField] private float xAngle, yAngle, zAngle;

    private void Update()
    {
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self); ;
    }
}
