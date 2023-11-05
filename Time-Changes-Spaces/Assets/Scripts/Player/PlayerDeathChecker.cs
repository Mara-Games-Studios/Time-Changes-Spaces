using System.Collections;
using UnityEngine;

public class PlayerDeathChecker : MonoBehaviour
{
    private float _screenIntencity;
    private float _screenAlfa;
    private float _intencityDecrese;
    private string _intencityName = "_intencity";
    private string _alfaName = "_alfa";
    [SerializeField] private Material _screenMaterial;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;


    private void Awake()
    {
        _screenIntencity = 0;
        _screenAlfa = 0;
        _intencityDecrese = 0.05f;
        _screenMaterial.SetFloat(_intencityName, 0);
        _screenMaterial.SetFloat(_alfaName, 0);
    }

    public void OnPlayerMove(bool isMoveDone)
    {
        if (isMoveDone)
        {
            DecreeseIntencity(0.05f);
        }
    }

    public void OnPlayerChangeTimeSpeed(TimeSpeed.TimeState state )
    {
        if(state != TimeSpeed.TimeState.Normal)
        {
            DecreeseIntencity(0.05f);
        }        
    }

    private void DecreeseIntencity(float value)
    {
        _screenIntencity += value;

        if (_screenIntencity > 0.55f)
        {
            PlayerDie();
        }
        else
        {
            _screenMaterial.SetFloat(_intencityName, _screenIntencity);
        }       
    }

    private void PlayerDie()
    {
        SetEffectStats(0.9f, 0);
        _losePanel.SetActive(true);
    }

    private void PlayerWin()
    {
        SetEffectStats(0.9f, 1);
        _winPanel.SetActive(true);
    }

    private void SetEffectStats(float intencity, float alfa)
    {
        _screenMaterial.SetFloat(_intencityName, intencity);
        _screenMaterial.SetFloat(_alfaName, alfa);
    }
}
