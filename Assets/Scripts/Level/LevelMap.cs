using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelMap : AbstractMap<LevelMap>
{
    [SerializeField] private Cell _startCell;

    public Cell StartCell
    {
        get { return _startCell; }
        set { _startCell = value; }
    }

    public List<Cell> GetAllCells()
    {
        return transform.GetComponentsInChildren<Cell>().ToList();
    }

    private void Start()
    {
        // Generate Map
        GetComponent<LevelMapGenerator>().GenerateMap();
        
        // Hide all cells exclude start and his neighbors
        GetAllCells().ForEach(cell => cell.Hide());
        StartCell.Show();
        
        // Set player on start position
        var player = GameObjectOnSceneManager.Instance.Player.GetComponent<CellObject>();
        player.SetPlace(StartCell);
        StartCell.SetCurrentObject(player);
    }
}
