using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{


    public class WeaponSlotManager : MonoBehaviour
    {
       
        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot leftHandSlot;
        DamageCollider rightHandDamageCollider;

        private void Awake()
        {
            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }  
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
                                
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isRight)
        {
           
            if (isRight)
            {   
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightHandWeaponDamageCollider();
            }
        }

        #region Handle Weapon's Damage Collider       

        private void LoadRightHandWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }        

        public void CloseDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }

        

        #endregion
    }

}