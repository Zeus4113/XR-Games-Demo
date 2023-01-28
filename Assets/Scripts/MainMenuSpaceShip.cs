using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpaceShip : MonoBehaviour
{
    [SerializeField] private float orbitSpeed;
    [SerializeField] private float xAngle, yAngle, zAngle;

    private void Update()
    {
        this.transform.Rotate(xAngle, yAngle, zAngle);
        this.transform.RotateAround(Vector3.zero, Vector3.left, orbitSpeed * Time.deltaTime);
    }
}
