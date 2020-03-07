using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreView;

    [SerializeField]
    private Image fuelView;

    [SerializeField]
    private Image shieldView;

    // Start is called before the first frame update
    void Start()
    {
        scoreView.text = ""+ 0;
        fuelView.fillAmount = 1f;
    }

    public void UpdateScore(int playerScore)
    {
        char[] chars = playerScore.ToString().ToCharArray();
        string score = chars[0].ToString();
        for(int i = 1 ; i < chars.Length; i++)
        {
            score += " " + chars[i];
        }
        scoreView.text = score;
    }

    
    public void UpdateFuelLevel(float fuelLevel)
    {
        fuelView.fillAmount = fuelLevel;
    }

    public void UpdateShieldDuration(float shieldDuration)
    {
     
    }
}
