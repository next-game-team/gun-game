using UnityEngine;

public class LineController : MonoBehaviour
{

    [SerializeField, ReadOnly] private Vector2 size;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        size = GetComponent<SpriteRenderer>().size;
    }
}
