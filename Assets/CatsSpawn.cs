using UnityEngine;
using System.Collections;

public class CatsSpawn : MonoBehaviour
{
    public GameObject catPrefab;
    private GameObject currentCat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn multiple cats for rat king fight
        StartCoroutine(SpawnCat());
        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat(){
        while(true){
            yield return new WaitForSeconds(Random.Range(0f, 4f));

            int side = Random.Range(0, 3); // Can only spawn on right, down, or up side of the screen

            float x;
            float y;
            Vector2 direction;

            // Right side
            if(side == 0){
                x = 1.1f;
                y = Random.Range(0.1f, 0.9f);
                direction  = Vector2.left;
            }
            // Down
            else if(side == 1){
                x = Random.Range(0.1f, 0.9f);
                y = -0.1f;
                direction  = Vector2.up;
            }
            // Up
            else{
                x = Random.Range(0.1f, 0.9f);
                y = 1.1f;
                direction  = Vector2.down;
            }

            Vector3 viewportPosition = new Vector3(x, y, -Camera.main.transform.position.z);

            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            spawnPosition.z = 0f;

            currentCat = Instantiate(catPrefab, spawnPosition, Quaternion.identity);

            Cat catMovement = currentCat.GetComponent<Cat>();
            catMovement.SetDirection(direction);
        }
    }
}
