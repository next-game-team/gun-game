using UnityEngine;
using TMPro;
using System.Collections;

public class TextWaveController : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public int CurrentWave {get; private set;}
    public int TotalWaves {get; private set;}

    [HideInInspector] public bool _starNextWave;

    void Awake()
    {
        _starNextWave = false;
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetWaveNumText(int _curWave, int _totWave)
    {
        CurrentWave = _curWave;
        TotalWaves = _totWave;

        if(_starNextWave)
        StartCoroutine(Type(CurrentWave, TotalWaves));
    }


    IEnumerator Type(int currentW, int totalW)
    {
        _text.text = "";
        string waveText = "Wave " + currentW.ToString() + " / " + totalW.ToString();
        foreach(char letter in waveText.ToCharArray())
        {
            _text.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
    }
   
}
