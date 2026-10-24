using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Vector3 rotationVector;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(rotationVector.x, rotationVector.y, rotationVector.z, Space.World);
    }
}
