﻿using System.Collections;
using System.Collections.Generic;
using ntdotjsx.Gameplay;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Mechanics
{
    public class DeathZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var playerHealth = p.GetComponent<Health>();
                if (playerHealth != null)
                {
                    if (playerHealth.CurrentHP != 0)
                    {
                        playerHealth.SetZero();
                    }
                }
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
        }
    }
}