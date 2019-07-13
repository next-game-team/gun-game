using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterWindow : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    // Color of window that set in common time
    private Color _defaultColor;
    public Color DefaultColor => _defaultColor;

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
    }
}
