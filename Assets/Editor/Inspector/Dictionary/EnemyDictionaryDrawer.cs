using UnityEditor;

namespace Editor.Inspector
{
    [CustomPropertyDrawer(typeof(EnemyDictionary))]
    public class EnemyDictionaryDrawer : DictionaryDrawer<EnemyType, EnemyConfig> {}
}