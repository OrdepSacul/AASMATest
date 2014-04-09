using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {

    public int MaxResources;
    public Transform agent;
    public int resourceValue = 5;
    
    private float randX = 0.0f;
    private float randY = 0.0f;
    private int currentResources;
    private int blueScore, redScore;

    void SpawnResource()
    {
        //get map image scale
        var MapSize = GameObject.Find("Map").transform.localScale;

        //get random coordinates for resouce respawn
        //TODO: add more restrains (outside of river, more distant from spawn, etc..)
        randX = (Random.value * 2.0f - 1) * (MapSize.x*2 - 1);
        randY = (Random.value * 2.0f - 1) * (MapSize.y*2 - 1);

        //instantiate resource gameobject
        Instantiate(agent, new Vector3(randX, randY, 0), Quaternion.identity);        
        currentResources++;

    }

    public void RegisterPickup(string team) {
        currentResources--;
        if (team == "Blue")
            blueScore += resourceValue;
        else
            redScore += resourceValue;
    }



    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < MaxResources; i++)
        {
            SpawnResource();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (currentResources < MaxResources)
            SpawnResource();
                        
    }


    void OnGUI()
    {

        GUILayout.Button("Red Score: " + redScore + " - Blue Score: " + blueScore);

    }
}
