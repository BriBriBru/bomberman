using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ID")]
    public int id;

    [Header("References")]
    [SerializeField] GameObject bombPrefab;
    Rigidbody rb;

    [Header("Player")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] int numMaxBombs;
    [SerializeField] int numSpawnedBombs;
    List<GameObject> spawnedBombs = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.remainingPlayers.Add(id);
    }

    void Update()
    {
        float moveRate = Input.GetAxisRaw("Vertical");
        float rotateRate = Input.GetAxisRaw("Horizontal");

        rb.MovePosition(transform.position + transform.forward * moveSpeed * moveRate * Time.deltaTime);

        Vector3 angleForSpeed = new Vector3(0f, rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(angleForSpeed * rotateRate * Time.deltaTime);
        rb.MoveRotation(transform.rotation * deltaRotation);

        if (Input.GetKeyDown(KeyCode.Space) && numMaxBombs > numSpawnedBombs)
        {
            if (bombPrefab != null)
            {
                float x = Mathf.RoundToInt(transform.localPosition.x);
                float y = bombPrefab.transform.localPosition.y;
                float z = Mathf.RoundToInt(transform.localPosition.z);
                Vector3 newBombPosition = new Vector3(x, y, z);

                GameObject newBomb = Instantiate(bombPrefab, newBombPosition, bombPrefab.transform.rotation);
                numSpawnedBombs++;
                spawnedBombs.Add(newBomb);
                StartCoroutine(RemoveBomb(newBomb));
            }
        }
    }

    IEnumerator RemoveBomb(GameObject bomb)
    {
        yield return new WaitForSeconds(3f);
        spawnedBombs.Remove(bomb);
        numSpawnedBombs--;
    }
}
