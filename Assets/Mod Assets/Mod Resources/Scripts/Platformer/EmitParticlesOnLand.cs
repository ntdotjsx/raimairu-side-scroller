using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[RequireComponent(typeof(ParticleSystem))]
public class EmitParticlesOnLand : MonoBehaviour
{

    public bool emitOnLand = true;
    public bool emitOnEnemyDeath = true;

#if UNITY_TEMPLATE_NTDOTJSX

    ParticleSystem p;

    void Start()
    {
        p = GetComponent<ParticleSystem>();

        if (emitOnLand) {
            ntdotjsx.Gameplay.PlayerLanded.OnExecute += PlayerLanded_OnExecute;
            void PlayerLanded_OnExecute(ntdotjsx.Gameplay.PlayerLanded obj) {
                p.Play();
            }
        }

        if (emitOnEnemyDeath) {
            ntdotjsx.Gameplay.EnemyDeath.OnExecute += EnemyDeath_OnExecute;
            void EnemyDeath_OnExecute(ntdotjsx.Gameplay.EnemyDeath obj) {
                p.Play();
            }
        }

    }

#endif

}
