using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{

    public Transform[] controlPoints;

    private Vector2 gizmosPosition;
    public List<Vector2> gizmosPositions = new List<Vector2>();

    private void OnDrawGizmos()
    {
  
      
        for(float t =0; t <=1; t+= 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                   3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                   3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                   Mathf.Pow(t, 3) * controlPoints[3].position;
            if (gizmosPositions.Count < 20)
            {
               
                // Debug.Log("OnDrawGizmos()");
                gizmosPositions.Add(gizmosPosition);
              
            }
            Gizmos.DrawSphere(gizmosPosition, 5.5f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }

    public void randomizePositions()
    {
        float x, y;
        //
        float[] startingX = { 2622f, -1626f };
        controlPoints[0].position = new Vector2(startingX[Random.Range(0,2)], Random.Range(2308f, -1155f));

        controlPoints[1].position = new Vector2(Random.Range(-503f, 697f), Random.Range(1013f, 3263f));

        controlPoints[2].position = new Vector2(Random.Range(97f, 1697f), Random.Range(-1337f, -187f));

        y = Random.Range(-32f, -2616f);//
        if(y> -1337f)
            x = startingX[Random.Range(0, 2)]; //3185
        else
            x = Random.Range(-1677f, 3185);
        controlPoints[3].position = new Vector2(x,y );

        Debug.Log("Route " + controlPoints[0].position);
        Debug.Log("Route" + controlPoints[1].position);
        Debug.Log("Route " + controlPoints[2].position);
        Debug.Log("Route " + controlPoints[3].position);
    }
}
