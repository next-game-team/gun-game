using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpLampPositionController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lamps;

    public List<GameObject> Lamps => _lamps;
}
