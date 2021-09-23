using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStarGraphUpdater : MonoBehaviour
{
 
    private int count = 0;

    public void CreateGrid()
    {
 
        AstarData data = AstarPath.active.data;


        GridGraph gg = data.AddGraph(typeof(GridGraph)) as GridGraph;


        int width = 80;
        int depth = 80;
        float nodeSize = 1;

        gg.center = new Vector3(36.5f, 36.5f, 0);


        gg.SetDimensions(width, depth, nodeSize);


        AstarPath.active.Scan();

        count = 0;
    }

    private void Update()
    {
        if (count < 2)
            {
            count++;
            AstarPath.active.Scan();
        }
    }
}
