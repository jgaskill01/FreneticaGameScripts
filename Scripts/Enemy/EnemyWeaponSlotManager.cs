using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class EnemyWeaponSlotManager : MonoBehaviour
    {
        PlayerManager playerManager;

        public WeaponItem rightHandWeapon;

        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot leftHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        private void Start()
        {                        
                LoadWeaponOnSlot(rightHandWeapon, false);                        
        }

        private void Awake()
        {
            playerManager = GetComponentInParent<PlayerManager>();

           WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                rightHandSlot = weaponSlot;
            }           
        }

        public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.currentWeapon = weapon;
                leftHandSlot.LoadWeaponModel(weapon);
                LoadWeaponsDamageCollider(true);
            }
            else
            {
                rightHandSlot.currentWeapon = weapon;
                rightHandSlot.LoadWeaponModel(weapon);
                LoadWeaponsDamageCollider(false);
            }
            
        }
       
        public void LoadWeaponsDamageCollider(bool isLeft)
        {
            if (isLeft)
            {
                leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
            }
            else
            {
                rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
            }
           
        }

        public void OpenDamageCollider()
        {          
            rightHandDamageCollider.EnableDamageCollider();
            
        }

        public void CloseDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
           
        }
      
    }
}
