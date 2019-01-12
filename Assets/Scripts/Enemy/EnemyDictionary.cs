
using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EnemyDictionary : SerializableDictionary<EnemyType, EnemyConfig> {}

[CustomPropertyDrawer(typeof(EnemyDictionary))]
public class EnemyDictionaryDrawer : DictionaryDrawer<EnemyType, EnemyConfig> {}