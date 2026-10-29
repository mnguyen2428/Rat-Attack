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
        StartCoroutine(SpawnCat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCat(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            int side = Random.Range(0, 4);

            float x;
            float y;
            Vector2 direction;

            // Left side
            if(side == 0){
                x = -0.1f;
                y = Random.Range(0.1f, 0.9f);
                direction  = Vector2.right;
            }
            // Right side
            else if(side == 1){
                x = 1.1f;
                y = Random.Range(0.1f, 0.9f);
                direction  = Vector2.left;
            }
            // Down
            else if(side == 2){
                x = Random.Range(0.1f, 0.9f);
                y = -0.1f;
                direction  = Vector2.up;
            }
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

            //yield return new WaitUntil(() => currentCat == null); // Wait until the cat is destroyed
        }
    }
}
