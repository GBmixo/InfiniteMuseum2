using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationHandler : MonoBehaviour
{
    public Animator npcAnimator;
    void Awake()
    {
        npcAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void AnimationChange(string animType)
    {
        if(animType == "Idle")
        {
            npcAnimator.SetBool("IsWalking", false);
            npcAnimator.SetBool("IsRunning", false);
        }
        else if(animType == "Walk")
        {
            npcAnimator.SetBool("IsWalking", true);
        }
        else if(animType == "Run")
        {
            npcAnimator.SetBool("IsRunning", true);
        }
        else if(animType == "GoToBed")
        {
            npcAnimator.SetTrigger("GoToSleep");
        }
        else if(animType == "WakeUp")
        {
            Debug.Log("waking up");
            npcAnimator.SetTrigger("WakeUp");
        }
    }
    void OnEnable()
    {
        TestAI.triggerAnimation += AnimationChange;
    }
    void OnDisable()
    {
        TestAI.triggerAnimation -= AnimationChange;
    }
}
