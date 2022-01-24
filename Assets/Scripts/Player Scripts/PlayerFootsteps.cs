using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footstepSound;

    [SerializeField]
    private AudioClip[] footstepClip;

    private CharacterController characterController;

    [HideInInspector]
    public float volumeMin, volumeMax;

    private float accumulatedDistance;

    [HideInInspector]
    public float stepDistance;

    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();

        characterController = GetComponentInParent<CharacterController>();
    }

    void Update()
    {
        CheckToPlayFootstepSound();
    }

    void CheckToPlayFootstepSound()
    {

        // if we are NOT on the ground
        if (!characterController.isGrounded)
            return;


        if (characterController.velocity.sqrMagnitude > 0)
        {

            // accumulated distance is the value how far can we go 
            // e.g. make a step or sprint, or move while crouching
            // until we play the footstep sound
            accumulatedDistance += Time.deltaTime;

            if (accumulatedDistance > stepDistance)
            {

                footstepSound.volume = Random.Range(volumeMin, volumeMax);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;

            }

        }
        else
        {
            accumulatedDistance = 0f;
        }
    }


    //void checktoplayfootstepsound()
    //{
    //    if (!charactercontroller.isgrounded)
    //        return;


    //    if (charactercontroller.velocity.sqrmagnitude > 0)
    //    {
    //        accumulateddistance += time.deltatime;

    //        if (accumulateddistance > stepdistance)
    //        {
    //            footstepsound.volume = random.range(volumemin, volumemax);
    //            footstepsound.clip = footstepclip[random.range(0, footstepclip.length)];
    //            footstepsound.play();

    //            accumulateddistance = 0f;
    //        }

    //    }
    //    else
    //        accumulateddistance = 0f;
    //}
}
