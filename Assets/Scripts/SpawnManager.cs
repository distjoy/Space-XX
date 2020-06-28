using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField]
    GameObject[] enemiesType1;
    [SerializeField]
    GameObject enemyType2;
    [SerializeField]
    GameObject enemyType3;

    List<Vector2> spawnPositions = new List<Vector2>();
    private UIManager uIManager;
    int elementWidth;
    int spawnCount;
    int typeOneInstances = 0;
    int typeTwoInstances = 0;
    int typeThreeInstances = 0;

    int stage = 0;
    bool endOfLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        int screenWidth = 1740;
        Collider2D m_Collider = enemiesType1[0].GetComponent<Collider2D>();
        Renderer renderer = enemiesType1[0].GetComponent<Renderer>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        elementWidth = (int)Mathf.Ceil(renderer.bounds.size.x);
        spawnCount = screenWidth / elementWidth;
        setupPositions();
        StartCoroutine("GenerateEnemyType1");
    }

    // Update is called once per frame
    void Update()
    {
        if (endOfLevel)
            return;
        int type1s = GameObject.FindGameObjectsWithTag("Enemy Child").Length;
        int type2s = GameObject.FindGameObjectsWithTag("EnemyType2").Length;
        int type3s = GameObject.FindGameObjectsWithTag("EnemyType3").Length;

        if ((type1s + type2s + type3s) == 0 && (typeOneInstances + typeThreeInstances + typeTwoInstances) == 236)
            EndGame();
        else
        {
            if (typeOneInstances >= 200)
                if (typeThreeInstances == 0)
                {
                    GenerateEnemyType2();
                    GenerateEnemyType3();
                }
        }
    }

 

    public void EndGame()
    {
        endOfLevel = true;
        // call uiManager to endLevel successfully;
        StopCoroutine("GenerateEnemyType3");
        StopCoroutine("GenerateEnemyType1");
        uIManager.EndGame();
    }

    IEnumerator GenerateEnemyType1()
    {

        while (typeOneInstances < 200)
        {
           if (spawnPositions.Count > 0)
                {
                    GameObject currentEnemyType = enemiesType1[Random.Range(0, 2)];
                    // Debug.Log("Enemy " + currentEnemyType);
                    int randomIndex = Random.Range(0, spawnPositions.Count);
                    Vector2 pos = spawnPositions[randomIndex];
                    spawnPositions.RemoveAt(randomIndex);
                    GameObject newObject = Instantiate(currentEnemyType, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                    ++typeOneInstances;
                }
            else setupPositions();
            yield return new WaitForSeconds(1f);
        }

    }
    void  GenerateEnemyType2()
    {
        //center horizontal at the top
       Instantiate(enemyType2, new Vector3(1230f, 2463f, 0f), Quaternion.identity);
       Instantiate(enemyType2, new Vector3(138f, 2500f, 0f), Quaternion.identity);
        typeTwoInstances += 6;
    }
    IEnumerator GenerateEnemyType3()
    {
        //anywhere off the screen
        while (typeThreeInstances < 30)
        {
            Instantiate(enemyType3, new Vector3(-880f, 1406f, 0f), Quaternion.identity);
            typeThreeInstances += 3;
            yield return new WaitForSeconds(3f);
        }
    }
    void setupPositions()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            spawnPositions.Add(new Vector2((i * elementWidth) + elementWidth / 2, 2991));
        }
    }
}
