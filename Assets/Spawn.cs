using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject cheesePrefab;
    private GameObject currentCheese;
    
    public GameObject trapPrefab;
    private GameObject currentTrap;

    public GameObject catPrefab;
    private GameObject currentCat;

    public GameObject tunnelPrefab;
    private GameObject currentTunnel;

    public GameObject candyPrefab;
    private GameObject currentCandy;
    public float candyChance = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCheese());
        StartCoroutine(SpawnTrap());
        StartCoroutine(SpawnCat());
    }

    Vector3 GetRandomSpawnPosition(){
        Vector3 viewportPosition = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), -Camera.main.transform.position.z);

        // Generate a random position within the camera's view
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

        spawnPosition.z = 0f;

        return spawnPosition;

    }

    IEnumerator SpawnCheese(){
        // spawn cheese and candy at same time with candy having a 20% probability
        while (true)
        {
            // Wait for a random time between 1 and 5 seconds
            yield return new WaitForSeconds(Random.Range(1f, 5f));

            currentCheese = Instantiate(cheesePrefab, GetRandomSpawnPosition(), Quaternion.identity);

            if(Random.value < candyChance){
                // Spawn candy
                currentCandy = Instantiate(candyPrefab, GetRandomSpawnPosition(), Quaternion.identity);

                CheeseScript cheese = currentCheese.GetComponent<CheeseScript>();
                Candy candy = currentCandy.GetComponent<Candy>();

                cheese.pairedCandy = currentCandy; // Link the candy to the cheese
                candy.pairedCheese = currentCheese; // Link the cheese to the candy
            }
            yield return new WaitUntil(() => currentCheese == null && currentCandy == null); // Wait until the cheese is collected (destroyed)
        }
    }
    IEnumerator SpawnTrap(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3f, 7f));

            currentTrap = Instantiate(trapPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            yield return new WaitUntil(() => currentTrap == null); // Wait until the trap is destroyed
        }
    }
    IEnumerator SpawnCat(){
        while(true){
            yield return new WaitForSeconds(Random.Range(5f, 8f));

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

            yield return new WaitUntil(() => currentCat == null); // Wait until the cat is destroyed
        }
    }
    IEnumerator SpawnCandy(){
        while(true){
            yield return new WaitForSeconds(Random.Range(4f, 9f));

            Vector3 viewportPosition = new Vector3(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), -Camera.main.transform.position.z);

            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(viewportPosition);

            spawnPosition.z = 0f;

            currentCandy = Instantiate(candyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitUntil(() => currentCandy == null); // Wait until the trap is destroyed
        }
    }
}