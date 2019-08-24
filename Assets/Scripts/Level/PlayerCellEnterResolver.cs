using System;
using UnityEngine;

public class PlayerCellEnterResolver : CellEnterResolver
{
    public override void Resolve(Cell place)
    {
        if (place.Type != CellType.Empty) Debug.Log("Enter " + place.Type);
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
}