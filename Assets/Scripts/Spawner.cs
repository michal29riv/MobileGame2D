using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public float repeatRate = 2;

    public float speedMultiplier = 1.01f;

    public List<GameObject> items;

    public float spawnChance = 0.2f;

    public float itemsSpeed = 5;

    public int numberOfSlots = 5;

    public int defaultSlot = 3;

    public float distanceBetweenSlots = 2f;

    public Text speedText;

    private float startSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItems", 1, repeatRate);

        startSpeed = itemsSpeed;
    }

    void SpawnItems()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            float randomChance = Random.Range(0f, 1f);

            if (randomChance < spawnChance)
            {

                GameObject randomItem = items[Random.Range(0, items.Count)];

                GameObject spawnedItem = Instantiate(randomItem);

                spawnedItem.transform.position = new Vector3(transform.position.x + (i - defaultSlot + 1) * distanceBetweenSlots, transform.position.y, transform.position.z);

                spawnedItem.GetComponent<Rigidbody2D>().velocity = Vector3.down * itemsSpeed;

                int randomDirection = Random.Range(0, 2);

                if (randomDirection == 1)
                {
                    spawnedItem.transform.localScale = new Vector3(-spawnedItem.transform.localScale.x, spawnedItem.transform.localScale.y, spawnedItem.transform.localScale.z);
                }
            }
        }


        itemsSpeed *= speedMultiplier;

        speedText.text = string.Format("Speed: {0}x", (itemsSpeed / startSpeed).ToString("F2"));
    }
}
