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

    private EndGameUi endGameUi;

    private GameObject fuelViewWr, shieldWr, scoreBgWr;
    // Start is called before the first frame update
    void Start()
    {
        endGameUi = GameObject.Find("EndGameScreen").GetComponent<EndGameUi>();
        fuelViewWr = GameObject.Find("FuelLevelView");
        scoreBgWr = GameObject.Find("ScoreBg");
        shieldWr = GameObject.Find("ShieldDurationView");
        scoreView.text = ""+ 0;
        fuelView.fillAmount = 1f;
    }

    public void UpdateScore(int playerScore)
    {
        endGameUi.TotalPoints = playerScore;
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

    public void EndGame()
    {
        scoreBgWr.SetActive(false);
        fuelViewWr.SetActive(false);
        shieldWr.SetActive(false);
        endGameUi.Animate();
    }
}
