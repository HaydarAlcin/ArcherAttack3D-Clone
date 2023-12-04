using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsManager : MonoBehaviour
{
    [SerializeField] private List<Transform> currentEnemies;

    [SerializeField] private Transform isTheCurrentPath;

    [SerializeField] private int numberOfEnemies;

    [SerializeField] GameEvent MoveEvent;

    private List<Animator> enemiesAnimation=new List<Animator>();

    private MoveSystem moveSystem;

    private Transform archerTransform;

    private void Start()
    {
        archerTransform = GameObject.FindGameObjectWithTag("Archer").transform;
        moveSystem = archerTransform.GetComponent<MoveSystem>();

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                enemiesAnimation.Add(child.GetChild(0).gameObject.GetComponent<Animator>());
                currentEnemies.Add(child);
                numberOfEnemies++;
            }
        }
    }


    public void EnemyDeath()
    {   
        
        numberOfEnemies--;

        if (numberOfEnemies <= 0)
        {
                moveSystem.MoveTheTargetPath();
                MoveEvent.Raise(); 
        }
        
    }


    public void EnemyAttack()
    {
        isTheCurrentPath = moveSystem.GetCurrentPath();
        if (transform !=isTheCurrentPath)
        {
            return;
        }

        for (int i = 0; i <= transform.childCount-1; i++)
        {
            Transform child = transform.GetChild(i);
            if (!child.gameObject.activeInHierarchy)
            {
                
                continue;
            }

            child.DOLookAt(archerTransform.position, 1.5f);
            enemiesAnimation[i].SetTrigger("fire");
        }
    }
}
