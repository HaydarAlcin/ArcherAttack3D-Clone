using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPathsManager : MonoBehaviour
{
    private Transform isTheCurrentPath;
    private Transform archerTransform;
    private List<Transform> childrenPaths = new List<Transform>();

    [SerializeField] GameEvent MoveEvent;

    private MoveSystem moveSystem;
    private void Start()
    {
        archerTransform = GameObject.FindGameObjectWithTag("Archer").transform;
        moveSystem = archerTransform.GetComponent<MoveSystem>();

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                childrenPaths.Add(child);
            }
        }
        isTheCurrentPath=moveSystem.GetCurrentPath();
    }

    public void ArcherFire()
    {
        isTheCurrentPath = moveSystem.GetCurrentPath();
    }

    public void EnemyHit()
    {
        foreach (Transform path in childrenPaths)
        {
            if (path != isTheCurrentPath)
            {
                continue;
            }
            path.GetComponent<PathsManager>().EnemyDeath();
        }
    }

}
