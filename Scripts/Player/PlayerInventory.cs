using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class PlayerInventory : MonoBehaviour
    {

        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, true);            
        }
    }
}