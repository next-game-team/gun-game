using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

[RequireComponent(typeof(Image))]
public class SeparableImage : MonoBehaviour
{

    [Header("Setup"), SerializeField] private SeparableImageParticle _particlePrefab; 
    [SerializeField] private int _particleCount = 1;
    [SerializeField] private Vector2 _particleMargin;
    [SerializeField] private float _particleSplitSize = 0.1f;
    
    [Header("Current"), SerializeField, ReadOnly] private float _particleWidth;
    [SerializeField, ReadOnly] private float _particleHeight;
     
    private Image _backgroundImage;
    private Rect _backgroundRect;
    private float _particleAreaWidth;

    private readonly List<SeparableImageParticle> _particles = new List<SeparableImageParticle>();
    private int _currentLastParticle;

    public void Init(int particleCount)
    {
        _particleCount = particleCount;
        Init();
    }
    
    public void Init()
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundRect = _backgroundImage.rectTransform.rect;
        _particleAreaWidth = _backgroundRect.width - _particleMargin.x * 2;
        _particleWidth = (_particleAreaWidth - _particleSplitSize * (_particleCount - 1)) / _particleCount;
        _particleHeight = _backgroundRect.height - _particleMargin.y * 2;

        if (_particlePrefab == null) return;

        Clean();
        
        var halfParticleWidth = _particleWidth / 2;
        var currentParticleX = -_particleAreaWidth / 2 + halfParticleWidth;
        // Instantiate particles
        for (var i = 0; i < _particleCount; i++)
        {
            var particleInstance = Instantiate(_particlePrefab,
                    transform.position, Quaternion.identity, transform);
            particleInstance.gameObject.name = "Particle" + i;
            particleInstance.gameObject.SetActive(true);
            var particleRectTransform = particleInstance.GetComponent<RectTransform>();
            // Set rect size
            particleRectTransform.sizeDelta = new Vector2(_particleWidth, _particleHeight);
            // Set position
            particleRectTransform.anchoredPosition = new Vector2(currentParticleX, 0);
            currentParticleX += _particleWidth + _particleSplitSize;
            _particles.Add(particleInstance);
        }

        _currentLastParticle = _particleCount - 1;
    }

    public void Clean()
    {
       // Clean old particles
       foreach (var particle in _particles)
       {
           if (particle != null)
           DestroyImmediate(particle.gameObject);
       }
       _particles.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        _backgroundImage = GetComponent<Image>();
    }

    public void Increase(int value)
    {
        int i;
        for (i = _currentLastParticle + 1;
            i < _particles.Count && (i - _currentLastParticle - 1) < value;
            i++)
        {
            _particles[i].Enable();
        }

        _currentLastParticle = i - 1;
    }

    public void Decrease(int value)
    {
        int i;
        for (i = _currentLastParticle;
            i >= 0 && (_currentLastParticle - i) < value;
            i--)
        {
            _particles[i].Disable();
        }
        _currentLastParticle = i;
    }
}
