using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;
    
    public void Death()
    {
        if (enemyAnimator.enabled == false) return;
        enemyAnimator.SetTrigger("enemyDeath");
    }

    public void Fire()
    {
        if (enemyAnimator.enabled == false) return;
        enemyAnimator.SetTrigger("fire");
    }

    public void EnemyDestroy()
    {
        Debug.Log("girdi");
        transform.parent.gameObject.SetActive(false);
    }

    public void FireSound()
    {
        if (enemyAnimator.enabled == false) return;
        SoundsManager.Instance.EnemyFire();
        HitControlSystem.Instance.ArcherGetTheDamage();
    }
}
