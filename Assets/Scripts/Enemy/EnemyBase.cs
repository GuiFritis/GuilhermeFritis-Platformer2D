using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var healthBase = collision.gameObject.GetComponent<HealthBase>();

        if(healthBase != null){
            healthBase.TakeDamage(damage);
        }
    }
}
