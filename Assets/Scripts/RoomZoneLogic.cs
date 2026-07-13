using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomZoneLogic : MonoBehaviour
{
    MeshCollider meshCollider;
    Vector3 maxBound;
    Vector3 minBound;

    //ROOM TYPES: Bathroom, Bedroom, Recreation, Hallway, Other
    public string roomType;
    public  List<GameObject> facilities;
    public List<GameObject> entrances;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        minBound = meshCollider.bounds.min;
        maxBound = meshCollider.bounds.max;
    }

    public Vector3 GetRandomPoint()
    {
        Vector3 randomPoint;
        randomPoint = new Vector3(
                Random.Range(minBound.x, maxBound.x),
                Random.Range(minBound.y, maxBound.y),
                Random.Range(minBound.z, maxBound.z)
            );
        return randomPoint;
    }
}
