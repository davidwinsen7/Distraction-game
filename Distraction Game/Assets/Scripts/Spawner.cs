using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Distraction
    {
        //Distraction properties
        public string name;
        public Transform prefab;
        public int count; //How many of this we want to spawn in a level
    }
    public Transform[] SpawnPoints; //Where we put bunch of spawn points
    public Distraction[] distractions; //See public class "Distraction" above
    private float totalDistractions = 0;
    private int variations;//The number of variations of distractions

    [Range(1f,5f)]
    public float spawnRate;

    private void Start()
    {       
        variations = distractions.Length;
        for (int i = 0; i < variations; i++)
        {
            totalDistractions += distractions[i].count;
        } 
        StartCoroutine(SpawnDistractions());  
    }
    IEnumerator SpawnDistractions()
    {
        while (true)
        {
            int spawnIndex = Random.Range(0, variations);
            int spawnPos = Random.Range(0, SpawnPoints.Length);
            if (distractions[spawnIndex].count > 0)
            {
                Instantiate(distractions[spawnIndex].prefab, SpawnPoints[spawnPos].position, transform.rotation);
                distractions[spawnIndex].count -= 1;
                totalDistractions -= 1;
                yield return new WaitForSeconds(spawnRate);
            }       
            if(totalDistractions <= 0)
            {
                break;
            }
        } 
    }
}
