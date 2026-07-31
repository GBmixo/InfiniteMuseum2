using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationHandler : MonoBehaviour
{
    public Animator npcAnimator;
    void Awake()
    {
        npcAnimator = transform.GetComponent<Animator>();
    }

    void MovementAnimationChange(string movementType)
    {
        if(movementType == "idle")
        {
            //npcAnimator.SetBool;
        }
        else if(movementType == "walk")
        {
            
        }
        else if(movementType == "run")
        {
            
        }
    }
}
