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
        elementWidth = (int)Mathf.Ceil(renderer.bounds.size.x);
        spawnCount = screenWidth / elementWidth;
        setupPositions();
       // StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {

        while (!endOfLevel)
        {

            int type1s = GameObject.FindGameObjectsWithTag("Enemy Child").Length;
            int type2s = GameObject.FindGameObjectsWithTag("EnemyType2").Length;
            int type3s = GameObject.FindGameObjectsWithTag("EnemyType3").Length;

            if ((type1s + type2s + type3s) == 0 && (typeOneInstances + typeThreeInstances + typeTwoInstances) == 206)
                endGame();
            else
            {
                if (typeOneInstances >= 200)
                {
                    if (type1s < 3)
                    {
                        if (type2s == 0)
                            generateEnemyType2();
                        if (type3s == 0)
                            generateEnemyType3();
                    }
                }
                else generateEnemyType1();
                yield return new WaitForSeconds(0.6f);
            }
        }
    }

    void endGame()
    {
        endOfLevel = true;
        // call uiManager to endLevel successfully;
    }

    void generateEnemyType1()
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
    }
    void generateEnemyType2()
    {
        //center horizontal at the top
       Instantiate(enemyType2, new Vector3(1230f, 2283.9f, 0f), Quaternion.identity);
        typeTwoInstances += 3;
    }
    void generateEnemyType3()
    {
        //anywhere off the screen
        Instantiate(enemyType3, new Vector3(-880f, 1406f, 0f), Quaternion.identity);
        typeThreeInstances += 3;
    }
    void setupPositions()
    {

        for (int i = 0; i < spawnCount; i++)
        {
            spawnPositions.Add(new Vector2((i * elementWidth) + elementWidth / 2, 2991));
        }
    }
}
