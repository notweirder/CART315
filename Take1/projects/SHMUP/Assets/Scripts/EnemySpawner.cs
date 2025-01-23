using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject enemy;
   

    public void Spawn()
    {
        Instantiate(enemy , new Vector3(0, 0,0),Quaternion.identity,this.transform);
    }
    
    
}

