using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelMap))]
[RequireComponent(typeof(CellNeighborFinder))]
public class LevelMapGenerator : AbstractMapGenerator<Cell>
{

    [SerializeField, Range(0, 1)] private float _startGenerateProbability = 0.5f;
    [SerializeField, Range(0, 1)] private float _decreaseGenerateProbabilityDelta = 0.05f;
    [SerializeField, Range(0, 1)] private float _linkProbability = 0.5f;
    [SerializeField] private int _teleportPathLength = 5;
    
    private LevelMap _levelMap;
    private CellNeighborFinder _neighborFinder;

    private Queue<Cell> _generationQueue;
    private Queue<Cell> _mainPathQueue;

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
        
        GenerateMainPath();
        // Handle each main cell
        foreach (var currentMainCell in _mainPathQueue)
        {
            currentMainCell.GenerateProbability = _startGenerateProbability;
            GenerateExtraPath(currentMainCell);
        }

    }

    private void GenerateMainPath()
    {
        _mainPathQueue = new Queue<Cell>();
        
        // Create start cell
        var startCell = Instantiate(PlacePrefab, _levelMap.transform);
        startCell.SidePoints.Init();
        startCell.IsMain = true;
        _mainPathQueue.Enqueue(startCell);
        
        // Create path
        // Generate all other cells
        var currentCell = startCell;
        for (var i = 2; i <= _teleportPathLength; i++)
        {
            var freeDirections = currentCell.GetFreeNeighborDirections()
                .FindAll(direction => _neighborFinder.FindNeighbor(currentCell, direction) == null);
            var nextCellDirection = freeDirections.Count == 0 
                ? DirectionEnum.NONE : RandomUtils.GetRandomObjectFromList(freeDirections); 
            if (nextCellDirection == DirectionEnum.NONE)
            {
                Debug.LogError("There is no neighbors in main cell");
                return;
            }
            
            currentCell = GenerateNeighbor(currentCell, nextCellDirection);
            currentCell.IsMain = true;

            if (i == _teleportPathLength - 1)
            {
                currentCell.Type = CellType.Boss;
            }
            else if (i == _teleportPathLength)
            {
                currentCell.Type = CellType.Teleport;
            }
            else
            {
                _mainPathQueue.Enqueue(currentCell);
            }
        }
    }

    private void GenerateExtraPath(Cell mainCell)
    {
        var cycleIteration = 0;
        _generationQueue = new Queue<Cell>();
        _generationQueue.Enqueue(mainCell);

        while (_generationQueue.Count > 0)
        {
            if (cycleIteration > 10000)
            {
                Debug.LogError("Generating extra path error. Reach limit of operations.");
                return;
            }
            
            var currentCell = _generationQueue.Dequeue();
            currentCell.GetFreeNeighborDirections().ForEach(freeDirection =>
            {
                var neighbor = _neighborFinder.FindNeighbor(currentCell, freeDirection);
                if (neighbor != null)
                {
                    if (neighbor.Type == CellType.Teleport) 
                        return; // Path to teleport must be only from Boss cell
                    HandleExistingNeighbor(currentCell, neighbor, freeDirection);
                }
                else
                {
                    if (!RandomUtils.IsRandomSaysTrue(currentCell.GenerateProbability)) return;
                    neighbor = GenerateNeighbor(currentCell, freeDirection);
                    neighbor.GenerateProbability = currentCell.GenerateProbability - _decreaseGenerateProbabilityDelta;
                    _generationQueue.Enqueue(neighbor);
                }
            });
            cycleIteration++;
        }
    }

    public void HandleQueue()
    {
        if (_generationQueue.Count == 0)
        {
            return;
        }
        
        var cell = _generationQueue.Dequeue();
        foreach (var direction in DirectionUtils.directionList)
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
        var isVertical = DirectionUtils.IsVerticalDirection(direction);
        Vector3 positionDelta = DirectionUtils.vectorDirectionDictionary[direction]
                                * (isVertical ? DistanceBetweenRows : DistanceBetweenColumns);
        var neighbor = Instantiate(PlacePrefab,cell.transform.position + positionDelta,
                    Quaternion.identity, _levelMap.transform);
        neighbor.SidePoints.Init();
        
        GeneratePath(cell, neighbor, direction);
        return neighbor;
    }

    public void RecalculateDistances()
    {
        CalculateDistances(transform.GetChild(0).GetComponent<Cell>());
    }
    
    // BFS min distance algorithm realization
    private void CalculateDistances(Cell cell)
    {
        // Init all distances to max value
        foreach (Transform child in transform)
        {
            child.GetComponent<Cell>().Distance = int.MaxValue;
        }
        
        var cycleIteration = 0;
        cell.Distance = 0;
        var queue = new Queue<Cell>();
        queue.Enqueue(cell);
        while (queue.Count != 0)
        {
            if (cycleIteration > 10000)
            {
                Debug.LogError("Calculation distances error. Reach limit of operations.");
                return;
            }
            
            var currentCell = queue.Dequeue();
            foreach (var neighbor in currentCell.Neighbors.List())
            {
                if (neighbor.Distance > currentCell.Distance + 1)
                {
                    neighbor.Distance = currentCell.Distance + 1;
                    queue.Enqueue(neighbor);
                }
            }

            cycleIteration++;
        }
    }
    
}