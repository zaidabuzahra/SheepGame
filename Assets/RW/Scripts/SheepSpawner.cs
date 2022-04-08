using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool bCanSpawn = true;

    public GameObject SheepPrefab;
    public List<Transform> SSP = new List<Transform>();
    public float TimeBetweenSpawns;

    private List<GameObject> SheepList = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Vector3 RPosition = SSP[Random.Range(0, SSP.Count)].position;
        GameObject Sheep = Instantiate(SheepPrefab, RPosition, SheepPrefab.transform.rotation);

        SheepList.Add(Sheep);

        Sheep.GetComponent<Sheep>().SetSpawner(this); 
    }

    private IEnumerator SpawnRoutine()
    {
        while (bCanSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(TimeBetweenSpawns);
        }
    }

    public void RemoveSheepFromList(GameObject Sheep)
    {
        SheepList.Remove(Sheep);
    }

    public void DestroyAllSheep()
    {
        foreach(GameObject Sheep in SheepList)
        {
            Destroy(Sheep);
        }

        SheepList.Clear();
    }
}
