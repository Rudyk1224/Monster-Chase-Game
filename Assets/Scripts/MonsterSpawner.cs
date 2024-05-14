using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update (only called once)
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()  { //IEnumerator allows itself to be called over a time interval
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); //between 1 and 5 seconds, this function will be called
            randomIndex = Random.Range(0, monsterReference.Length); //range is not inclusive of last parameter
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]); //Instantiate creates new game object (a copy of a monster)


            if (randomSide == 0)
            {
                //left side
                spawnedMonster.transform.position = leftPos.position; //set monster's position to the position of left side
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); //set the monster's speed between 4 and 10 (speed is public)
            }
            else
            {
                //right side
                spawnedMonster.transform.position = rightPos.position; //set monster's position to the position of right side
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); //its negative because monster is going in -x direction (from right to left)
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); //flip direction monster is facing and he goes left
            }
        }
    }
}
