using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAmountController : MonoBehaviour
{
    
    private Image _image;

    public float FullImageFillAmount { get; private set; }
    public float CurrentImageFillAmount { get; private set; }
    
    // Start is called before the first frame update
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Init(float fullImageAmount)
    {
        FullImageFillAmount = fullImageAmount;
    }

    public void SetImageAmount(float currentImageAmount)
    {
        CurrentImageFillAmount = currentImageAmount;
        _image.fillAmount = CurrentImageFillAmount / FullImageFillAmount;
    }
    
}
