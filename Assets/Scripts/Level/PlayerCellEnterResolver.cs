using System;
using UnityEngine;

public class PlayerCellEnterResolver : CellEnterResolver
{
    private Moveble _moveble;
    private Cell _currentCell;
    
    public override void Resolve(Cell place)
    {
        _currentCell = place;
        _moveble.OnMoveEndEvent.AddListener(OnMoveEnd);
        
        switch (place.Type)
        {
            case CellType.Empty:
                break;
            case CellType.Enemy:
                break;
            case CellType.Boss:
                break;
            case CellType.Generator:
                break;
            case CellType.Teleport:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnMoveEnd()
    {
        // Show neighbors
        _currentCell.Show();
        
        // Change type to Empty
        if (_currentCell.Type != CellType.Empty)
        {
            _currentCell.SetType(CellType.Empty);
        }

        // Clean listener
        _moveble.OnMoveEndEvent.RemoveListener(OnMoveEnd);
    }

    private void Awake()
    {
        _moveble = GetComponent<Moveble>();
    }
}