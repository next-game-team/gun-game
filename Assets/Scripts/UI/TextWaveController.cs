using UnityEngine;
using TMPro;

public class TextWaveController : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public int CurrentWave {get; private set;}
    public int TotalWaves {get; private set;}

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetWaveNumText(int _curWave, int _totWave)
    {
        CurrentWave = _curWave;
        TotalWaves = _totWave;

        _text.text = "Wave " + CurrentWave.ToString() + " / " + TotalWaves.ToString();
    }
   
}
