using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    [CreateAssetMenu(menuName = "AI / Enemy / Attack Actions")]
    public class EnemyAttackAction : EnemyActions
    {

        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maxAttackAngle = 35;
        public float minAttackAngle = -35;

        public float minDistanceNeededToAttack = 0;
        public float maxDistanceNeededToAttack = 3;
     
    }
}
