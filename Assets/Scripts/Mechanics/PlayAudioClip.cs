﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayAudioClip : StateMachineBehaviour
{
    public float t = 0.5f;
    public float modulus = 0f;
    public AudioClip clip;
    float last_t = -1f;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var nt = stateInfo.normalizedTime;
        if (modulus > 0f) nt %= modulus;
        if (nt >= t && last_t < t)
            AudioSource.PlayClipAtPoint(clip, animator.transform.position);
        last_t = nt;
    }
}
