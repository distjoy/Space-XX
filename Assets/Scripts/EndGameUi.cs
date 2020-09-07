using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUi : MonoBehaviour
{
    // Start is called before the first frame update
    private float FADE_IN_DURATION = 0.8f;

    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject scoreView;
    [SerializeField]
    private GameObject playAgain;
    [SerializeField]
    private GameObject hiScore;
    [SerializeField]
    private GameObject coins;
    [SerializeField]
    private GameObject backBtn;
    private int stage = 0;
    private int totalPoints = 0;

    public int TotalPoints { get => totalPoints; set => totalPoints = value; }

    private void Start()
    {
   
    }
    public void Animate()
    {

        switch (stage)
        {
            case 0:
                StartCoroutine(DoFade(this.gameObject, 1f));
                ++stage;
                break;
            case 1:
                if (title != null)
                {
                    /*  title.transform.Translate(new Vector3(title.transform.position.x,
                          321.8f, title.transform.position.z));*/
                    StartCoroutine(DoTranslateY(title, 1810.8f));
                    ++stage;
                }
                break;
            case 2:
                if (scoreView != null)
                {
                    StartCoroutine(DoFade(this.scoreView, 1f));

                    ++stage;
                }
                break;
            case 3:
                if (playAgain != null)
                {
                    ScoreAnimator scoreAnim = scoreView.GetComponent<ScoreAnimator>();
                    if (scoreAnim != null)
                        scoreAnim.setPoints(totalPoints);
                    StartCoroutine(DoFade(this.playAgain, 1f));
                    ++stage;
                }
                break;
            case 4:
                if (coins != null && hiScore != null)
                {
                    StartCoroutine(DoFade(this.coins, 1f));
                    StartCoroutine(DoFade(this.hiScore, 1f));
                    ++stage;
                }
                break;
            case 5:
                if (backBtn != null)
                {
                    StartCoroutine(DoFade(this.backBtn, 1f));
                    ++stage;
                }
                break;
        }
    }

    IEnumerator DoFade(GameObject gameObject, float end)
    {
        CanvasGroup group = gameObject.GetComponent<CanvasGroup>();
        var start = group.alpha;
        float counter = 0f;
        while (counter < FADE_IN_DURATION)
        {
            counter += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, end, counter / FADE_IN_DURATION);
            // Debug.Log("DoFade....() " + stage);
            yield return null;
        }

        Animate();
    }

    IEnumerator DoTranslateY(GameObject gameObject, float end)
    {
        var start = gameObject.transform.position.y;
        float counter = 0f;
     //   float t = 0f;/
        while (counter < FADE_IN_DURATION)
        {
             counter += Time.deltaTime;
          //  t += 0.5f * Time.deltaTime;
            gameObject.transform.position = new Vector3(title.transform.position.x,
                        Mathf.Lerp(start, end, counter/ FADE_IN_DURATION), title.transform.position.z);
            yield return null;
        }

        Animate();
    }
}
