using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISystem : MonoBehaviour
{
    private Transform ParentPath;
    private List<GameObject> Paths = new List<GameObject>();

    private void Awake()
    {
        ParentPath = GameObject.FindGameObjectWithTag("ParentPaths").transform;
        
        if (ParentPath.childCount!=0)
        {
            foreach (Transform path in ParentPath)
            {
                Paths.Add(path.gameObject);
            }
        }
        
    }

    public List<GameObject> GetPaths()
    {
        return Paths;
    }
}
