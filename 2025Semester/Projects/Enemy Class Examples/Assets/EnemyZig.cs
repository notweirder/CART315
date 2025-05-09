using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZig : Enemy
{
public override void Move () {                                      // a

        Vector3 tempPos = pos;  // The pos property is inherited from Enemy

        tempPos.x = Mathf.Sin( Time.time * Mathf.PI * 2 ) * 4;          // b

         pos = tempPos;                                                  // c

         base.Move();  // Calls Move() on the Enemy superclass           // d

     }

}
