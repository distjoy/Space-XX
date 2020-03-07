using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLikeEnemy : MonoBehaviour
{

    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float t;
    private float speedModifier;
    private Vector3 newPosition;
    private bool coroutineOngoing;
    private int spacing = 50;


    bool directionSet = false;
    float currentAngle = -180;

    List<Vector2> bezierPositions = new List<Vector2>();
    int c = 0;
    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
        coroutineOngoing = false;
        speedModifier = 0.19f;
        routeToGo = 0;
          setupPositions(routeToGo);

        // StartCoroutine("RandomDeleteChild");
        if (!coroutineOngoing)
            StartCoroutine(GoByTheRoute());

    }

    // Update is called once per frame
    void Update()
    {
    

    }


    public void MoveInRoute()
    {
        
    }
   

 
    private IEnumerator GoByTheRoute()
    {

        coroutineOngoing = true;
        Debug.Log("herre GoByTheRoute bezierPositions "+ bezierPositions.Count);

        int extras = (2) * spacing;
        int realSize = bezierPositions.Count;
        int loopSize = extras+ bezierPositions.Count;

        for (int i=0; i< loopSize; i++)
        {

            //move each child taking into consideration the gaps
            for(int c=0; c < transform.childCount;c++)
            {
                int childSpacing = c * spacing;
                if (i >= childSpacing && i < (realSize + childSpacing))
                    moveInCurvePoint(transform.GetChild(c), i - childSpacing);
                else continue;
            }
          
            yield return new WaitForEndOfFrame();
        }
        t = 0f;
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
            routeToGo = 0;
        coroutineOngoing = false;
    }


    void moveInCurvePoint(Transform currentTransform, int point)
    {

        var currentDirection = bezierPositions[point];
        if (point < bezierPositions.Count - 6)
        {
            var futurePosition = bezierPositions[point + 5];
            var direction = futurePosition - currentDirection;

            if (direction != Vector2.zero)
            {
                float angle = -90f + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                currentTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        currentTransform.position = currentDirection;
    }

    void setupPositions(int routeIndex)
    {

        routes[routeIndex].GetComponent<Route>().randomizePositions();

        Vector2 p0 = routes[routeIndex].GetChild(0).position;
        Vector2 p1 = routes[routeIndex].GetChild(1).position;
        Vector2 p2 = routes[routeIndex].GetChild(2).position;
        Vector2 p3 = routes[routeIndex].GetChild(3).position;

        Debug.Log("SnakeLikeEnemy " + p0);
        Debug.Log("SnakeLikeEnemy" + p1);
        Debug.Log("SnakeLikeEnemy " + p2);
        Debug.Log("SnakeLikeEnemy " + p3);

        while (t < 1)
        {
            t += Time.deltaTime * speedModifier;
            newPosition = Mathf.Pow(1 - t, 3) * p0 +
                3 * Mathf.Pow(1 - t, 2) * t * p1 +
                3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                Mathf.Pow(t, 3) * p3;

            bezierPositions.Add(newPosition);

        }
    }
}


/*
 * 
 *  if (i < loopSize-extras)
            {
                moveInCurvePoint(transform.GetChild(0), i);
            }
            if (i > spacing &&  i < loopSize-spacing)
            {
                moveInCurvePoint(transform.GetChild(1), i-spacing);
            }
            if (i > extras && i < loopSize)
            {
                moveInCurvePoint(transform.GetChild(2), i - extras);
            }
 * */
