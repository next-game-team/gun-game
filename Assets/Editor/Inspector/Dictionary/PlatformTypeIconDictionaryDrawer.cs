using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(PlatformTypeIconDictionary))]
public class PlatformTypeIconDictionaryDrawer : DictionaryDrawer<PlatformType, Sprite> {}