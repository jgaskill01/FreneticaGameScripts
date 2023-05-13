using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class BlockCharacterCollision : MonoBehaviour
    {

        public CapsuleCollider characterCollider;
        public CapsuleCollider CharacterColliderBlocker;

        private void Start()
        {
            Physics.IgnoreCollision(characterCollider, CharacterColliderBlocker, true);
        }
    }
}
