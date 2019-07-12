using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelMap))]
[RequireComponent(typeof(CellNeighborFinder))]
public class LevelMapGenerator : AbstractMapGenerator<Cell>
{

    [SerializeField, Range(0, 1)] private float _generateProbability = 0.5f;
    [SerializeField, Range(0, 1)] private float _linkProbability = 0.5f;
    
    private LevelMap _levelMap;
    private CellNeighborFinder _neighborFinder;

    private Queue<Cell> _generationQueue;

    private void Awake()
    {
        Init();
    }
    
    private void OnValidate()
    {
        Init();
    }

    private void Init()
    {
        _levelMap = GetComponent<LevelMap>();
        _neighborFinder = GetComponent<CellNeighborFinder>();
        InitConsts();
    }

    public void GenerateMap()
    {
        _levelMap.CleanChildren();

        _generationQueue = new Queue<Cell>();
        var cell = Instantiate(PlacePrefab, _levelMap.transform);
        cell.SidePoints.Init();
        _generationQueue.Enqueue(cell);
        HandleQueue();
    }

    public void HandleQueue()
    {
        if (_generationQueue.Count == 0)
        {
            return;
        }
        
        var cell = _generationQueue.Dequeue();
        foreach (var direction in cell.SidePoints.DirectionDictionary.Keys)
        {
            var neighbor = _neighborFinder.FindNeighbor(cell, direction);
            if (neighbor != null)
            {
                HandleExistingNeighbor(cell, neighbor, direction);
            }
            else
            {
                neighbor = GenerateNeighbor(cell, direction);
                if (neighbor != null) _generationQueue.Enqueue(neighbor);
            }
        }
        HandleQueue();
    }

    private void HandleExistingNeighbor(Cell cell, Cell neighbor, DirectionEnum direction)
    {
        if (!RandomUtils.IsRandomSaysTrue(_linkProbability)) return;

        GeneratePath(cell, neighbor, direction);

        if (cell.Distance > neighbor.Distance + 1)
        {
            cell.Distance = neighbor.Distance + 1;
        }
        else if (cell.Distance + 1 < neighbor.Distance)
        {
            neighbor.Distance = cell.Distance + 1;
        }
    }

    private void GeneratePath(Cell cell, Cell neighbor, DirectionEnum direction)
    {
        // Generate path between neighbors
        cell.Neighbors.SetNeighbor(direction, neighbor);
        neighbor.Neighbors.SetNeighbor(DirectionUtils.GetOppositeDirection(direction), cell);

        var line = CreateLine(direction, cell);
        cell.LineNeighbors.SetNeighbor(direction, line);
        neighbor.LineNeighbors.SetNeighbor(DirectionUtils.GetOppositeDirection(direction), line);
    }

    private Cell GenerateNeighbor(Cell cell, DirectionEnum direction)
    {
        if (!RandomUtils.IsRandomSaysTrue(_generateProbability)) return null;

        // Generate neighbor
        var isVertical = DirectionUtils.IsVerticalDirection(direction);
        Vector3 positionDelta = DirectionUtils.vectorDirectionDictionary[direction]
                                * (isVertical ? DistanceBetweenRows : DistanceBetweenColumns);
        var neighbor = Instantiate(PlacePrefab,cell.transform.position + positionDelta,
                    Quaternion.identity, _levelMap.transform);
        neighbor.SidePoints.Init();
        
        GeneratePath(cell, neighbor, direction);

        neighbor.Distance = cell.Distance + 1;
        return neighbor;
    }
    
    
}