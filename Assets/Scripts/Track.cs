using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstacleSpots = null;
    [SerializeField]
    private List<GameObject> obstacles = null;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var spot in obstacleSpots)
        {
            if (obstacles.Count > 0)
            {
                Instantiate(obstacles[rand.Next(0, obstacles.Count)], spot.transform.position, Quaternion.identity, spot.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Spheres temp = other.GetComponent<Spheres>();

        if (temp != null)
        {
            GameManager.Instance.SpawnTrack(transform);
        }

    }
}
