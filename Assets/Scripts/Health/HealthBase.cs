using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBase : MonoBehaviour
{
    public int startLife = 5;

    public bool destroyOnKill = false;

    public float delayToKill = 0f;

    public UnityEvent damageCallback;

    private int _curLife;

    private bool _isDead = false;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        _isDead = false;
        _curLife = startLife;
    }

    public void TakeDamage(int damage){

        if(_isDead){
            return;
        }

        _curLife -= damage;
        if(damageCallback != null){
            damageCallback.Invoke();
        }

        if(_curLife <= 0){
            Kill();
        }
    }

    private void Kill(){
        _isDead = true;

        if(destroyOnKill){
            Destroy(gameObject, delayToKill);
        }
    }
}