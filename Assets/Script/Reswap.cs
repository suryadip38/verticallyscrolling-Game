using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reswap : MonoBehaviour
{
    [SerializeField] GameObject[] gridPrefabs;
    [SerializeField] Transform[] Lanes;
    [SerializeField] int[] randomLanes;


    [Header("Values")]
    [SerializeField] float spawnRate;

    private void Start()
    {
        StartCoroutine(SpawnGrid());
    }

    [ContextMenu("Spawn grid")]
    public IEnumerator SpawnGrid()
    {
        yield return new WaitForSeconds(spawnRate);
        RandomizeLanes();
        for (int i = 0; i < gridPrefabs.Length; i++)
        {
            GameObject grid = Instantiate(gridPrefabs[i]);
            grid.transform.position = new Vector3(Lanes[i].position.x, transform.position.y, 0);
        }
            StartCoroutine(SpawnGrid());
    }

    private void RandomizeLanes()
    {
        for (int i = 0; i < Lanes.Length; i++)
        {
            Transform temp;
           
            {
                if (i + 1 == Lanes.Length)
                    return;
                int rand = Random.Range(i + 1, Lanes.Length);
                temp = Lanes[i];
                Lanes[i] = Lanes[rand];
                Lanes[rand] = temp;
            }
        }
    }
}