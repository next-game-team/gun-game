using UnityEngine;
using TMPro;
using System.Collections;

public class TextWaveController : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public int CurrentWave {get; private set;}
    public int TotalWaves {get; private set;}

    [SerializeField] private float _timeTextSpeed; 

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetWaveNumText(int currentWave, int totalWave)
    {
        CurrentWave = currentWave;
        TotalWaves = totalWave;

        StartCoroutine(Type(CurrentWave, TotalWaves));
    }

    public void ClearText()
    {
        _text.text = "";
    }


    IEnumerator Type(int currentWave, int totalWave)
    {
        _text.text = "";
        string waveText = "Wave " + currentWave.ToString() + " / " + totalWave.ToString();
        foreach(char letter in waveText.ToCharArray())
        {
            _text.text += letter;
            yield return new WaitForSeconds(_timeTextSpeed);
        }
    }
   
}
