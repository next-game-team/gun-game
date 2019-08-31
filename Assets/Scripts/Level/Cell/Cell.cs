using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : AbstractPlace<Cell, CellType>
{
    [SerializeField, ReadOnly, Header("Info")] 
    private bool _isMain;
    
    [SerializeField, ReadOnly]
    private bool _isStart;
    
    [SerializeField, ReadOnly]
    private bool _isChecked;

    [SerializeField, ReadOnly] 
    private int _distance = int.MaxValue;
    
    [SerializeField, ReadOnly] 
    private Neighbors<GameObject> _lineNeighbors = new Neighbors<GameObject>();

    [SerializeField, Range(0, 1)] 
    private float _generateProbability = 0.5f;
    
    public bool IsMain
    {
        get { return _isMain; }
        set { _isMain = value; }
    }
    
    public bool IsStart
    {
        get { return _isStart; }
        set { _isStart = value; }
    }

    public bool IsChecked
    {
        get { return _isChecked; }
        set { _isChecked = value; }
    }

    public float GenerateProbability
    {
        get { return _generateProbability; }
        set { _generateProbability = value; }
    }

    public Neighbors<GameObject> LineNeighbors
    {
        get { return _lineNeighbors; }
        set { _lineNeighbors = value; }
    }

    public int Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }

    public bool IsEnabled { get; private set; } = false;

    public void Enable()
    {
        IsEnabled = true;
    }
    
    public void Disable()
    {
        IsEnabled = false;
    }

    public override void SetType(CellType type)
    {
        Type = type;
        Icon.sprite = CellTypeManager.Instance.TypeIconDictionary[type];
    }

    public override bool HasEmptyType()
    {
        return Type == CellType.Empty;
    }

    public List<DirectionEnum> GetFreeNeighborDirections()
    {
        var freeDirections = new List<DirectionEnum>();
        foreach (var pair in Neighbors.DirectionDictionary)
        {
            if (pair.Value == null)
            {
                freeDirections.Add(pair.Key);
            }
        }

        return freeDirections;
    }

    public bool HasNeighborWithType(CellType type)
    {
        return Neighbors.List().Any(neighbor => neighbor.Type == type);
    }

    public override void HandleNewObject()
    {
        
    }

    public override void HandleEmpty()
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        LineNeighbors.List().ForEach(line => line.gameObject.SetActive(false));
    }

    public void Show()
    {
        gameObject.SetActive(true);
        LineNeighbors.List()
            .FindAll(line => line.gameObject.activeSelf != true)
            .ForEach(line => line.gameObject.SetActive(true));
        Neighbors.List()
            .FindAll(neighbor => neighbor.gameObject.activeSelf != true)
            .ForEach(neighbor => neighbor.gameObject.SetActive(true));
    }
}
