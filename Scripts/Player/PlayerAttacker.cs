using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class PlayerAttacker : MonoBehaviour
    {

        AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        public string lastAttack;
        public AudioClip swingSound;
        public AudioClip heavySwingSound;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            inputHandler = GetComponent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                }
            }
        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
            AudioSource.PlayClipAtPoint(swingSound, transform.position);
            lastAttack = weapon.OH_Light_Attack_1;
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
            AudioSource.PlayClipAtPoint(heavySwingSound, transform.position);
        }
    }
}
