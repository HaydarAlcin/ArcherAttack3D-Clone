using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveSystem : MonoBehaviour
{
    private NavMeshAgent agent;

    private AISystem aiSystem;
    private AttackSystem attackSystem;
    private List<GameObject> paths;

    [SerializeField] private Transform currentPath;

    [SerializeField] private GameEvent IdleEvent,MoveEvent;

    [SerializeField] private float minDistance;

    private byte currentPathNumber;
    private bool justOneTime;
    private bool killDelay=true;

    Transform archerParent;

    private void Start()
    {
        archerParent = transform.GetChild(0);
        aiSystem = GetComponent<AISystem>();
        paths = aiSystem.GetPaths();
        currentPath = paths[0].transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(paths[0].transform.position);
        justOneTime = true;
        attackSystem = GetComponent<AttackSystem>();
    }


    public void MoveTheTargetPath()
    {
        if (paths.Count > 0)
        {
            currentPathNumber++;
            if (currentPathNumber >= paths.Count)
            {
                CanvasManager.Instance.LevelWon();
                return;
            }
            agent.SetDestination(paths[currentPathNumber].transform.position);
            currentPath = paths[currentPathNumber].transform;
        }
    }

    private void Update()
    {
        PathDistanceControl();
    }

    public void PathDistanceControl()
    {
        if (Vector3.Distance(transform.position,currentPath.transform.position)>=minDistance)
        {
            MoveEvent.Raise();
            justOneTime = true;
            archerParent.rotation = transform.rotation;
            attackSystem.ReadyToAttackFalse();
            return;
        }

        if (justOneTime)
        {
            IdleEvent.Raise();
            justOneTime = false;
            
        }
    }


    public Transform GetCurrentPath()
    {
        return currentPath.transform;
    }

    public bool HitTheKillDelay()
    {
        StartCoroutine(DeathDelay());
        return killDelay;
    }

    IEnumerator DeathDelay()
    {
        yield return null;
    }
}

