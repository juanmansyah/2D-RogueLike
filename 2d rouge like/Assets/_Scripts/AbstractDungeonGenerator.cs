using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField]
    protected TileMapVisualizer tilemapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField]
    protected AStarGraphUpdater GraphUpdater;


    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear();
        RunProcedrualGeneration();
        GraphUpdater.CreateGrid();
    }

    protected abstract void RunProcedrualGeneration();
}
