using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAnimator : MonoBehaviour
{
   public int points = 9876;
    private int DIGIT_LIMIT = 8;
    private Text bg;
    private Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
       bg = this.transform.GetChild(2).gameObject.GetComponent<Text>();
       scoreTxt = this.transform.GetChild(1).gameObject.GetComponent<Text>();
      
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPoints(int points)
    {
        this.points = points;
        StartCoroutine("UpdateScoreField");
    }


    int bCC = 8;
    string prefix = "00000000";
    IEnumerator UpdateScoreField()
    {
        int oldCC = 0;
        int currentPoints = 0;
        while (currentPoints <= points )
        {
            int newCC = currentPoints.ToString().Length;
            if (newCC > oldCC)
            {
                //  prefix =   prefix.TrimEnd('0');
                prefix = prefix.Remove(prefix.Length - 1);
            }
            string newVal = prefix + currentPoints.ToString();
            bg.text = prefix;
            scoreTxt.text = newVal;
            ++currentPoints;
            oldCC = newCC;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
