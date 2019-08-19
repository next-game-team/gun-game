using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelMap : AbstractMap<LevelMap>
{
    public List<Cell> GetAllCells()
    {
        return transform.GetComponentsInChildren<Cell>().ToList();
    }
}
