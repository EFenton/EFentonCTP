using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class raycastThing : MonoBehaviour {

    int layerMask;
    List<Vector3> highestPoints;
    public GameObject pSystem;
    public GameObject pSystemChild;
    float timer = 0, hideTimer = 0;
    float waitingTime = 0;
    bool hideLightning = false;
    public ParticleSystem pSystemSpark;
    
    // Use this for initialization
	void Start ()
    {

        highestPoints = new List<Vector3>();
        layerMask = LayerMask.GetMask("Terrain");
        Vector3 down = transform.TransformDirection(Vector3.down);
        for (int i = 0; i < 500; i+=20)
        {
            for (int j = 0; j < 500; j+=20)
            {
                RaycastHit hit = new RaycastHit();
                Ray downRay = new Ray(new Vector3(i, 500, j), down);

                if (Physics.Raycast(downRay, out hit, 1000, layerMask))
                {
                    //do the ray
                }


                float tempResult = hit.distance;
                
                if(highestPoints.Count < 5)
                {
                    highestPoints.Add(new Vector3(i, tempResult, j));
                }
                else if(highestPoints.Count >= 5)
                {
                    bool complete = false;
                    for(int k = 0; k < highestPoints.Count; k++)
                    {
                        if (highestPoints[k].y > tempResult && complete == false)
                            
                            
                            
                            /* && (highestPoints[k].x - i) < 50 && (highestPoints[k].z - j) < 50*/
                        {
                            highestPoints[k] = new Vector3(i, tempResult, j);
                            complete = true;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < highestPoints.Count; i++)
        {
            Vector3 tempVec = highestPoints[i];
            tempVec.y = 500 - tempVec.y;
            highestPoints[i] = tempVec;
            Debug.Log("Point [" + (i+1) + "] distance:" + highestPoints[i].y);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        hideTimer += Time.deltaTime;
        if(timer > waitingTime)
        {
            timer = 0;
            waitingTime = Random.Range(2, 7);
            MoveLightning(highestPoints[Random.Range(0, 5)]);
            ShowLightning(true);
            hideLightning = true;
            hideTimer = 0;
        }
        if (hideTimer > 0.7 && hideLightning == true)
        {
            ShowLightning(false);
            timer = 0;
            hideLightning = false;
        }
    }

	void MoveLightning(Vector3 _pos)
	{
		pSystem.transform.position = _pos + new Vector3(-20, 120, 0);
        pSystemChild.transform.position = _pos + new Vector3(-20, 120, 0);
        pSystemSpark.Emit(10);

	}

	void ShowLightning(bool _show)
	{
        pSystem.gameObject.GetComponent<ParticleSystem>().enableEmission = _show;
        pSystemChild.gameObject.GetComponent<ParticleSystem>().enableEmission = _show;
        //those are deprecated but they still work so it's ok
	}

}
