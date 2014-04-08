using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {

    public int MaxResources;
    public Transform agent;
    
    private float randX = 0.0f;
    private float randY = 0.0f;
    private int currentResources;

    void SpawnResource()
    {

        var MapSize = GameObject.Find("Map").transform.localScale;

        randX = (Random.value * 2.0f - 1) * (MapSize.x*2 - 1);
        randY = (Random.value * 2.0f - 1) * (MapSize.y*2 - 1);
        Object coin = Instantiate(agent, new Vector3(randX, randY, 0), Quaternion.identity);
        
        currentResources++;

    }

    public void RegisterPickup() {
        currentResources--;
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
}
