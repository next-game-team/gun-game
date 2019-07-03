using UnityEditor;

[CustomPropertyDrawer(typeof(EnemyDictionary))]
public class EnemyDictionaryDrawer : DictionaryDrawer<EnemyType, EnemyConfig> {}