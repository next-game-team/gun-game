using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CellTypeIconDictionary))]
public class CellTypeIconDictionaryDrawer : DictionaryDrawer<CellType, Sprite> {}