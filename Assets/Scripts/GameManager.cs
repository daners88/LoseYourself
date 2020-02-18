using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    System.Random rand = new System.Random();

    public bool running = false;
    [SerializeField]
    private GameObject trackPrefab = null;
    public static GameManager Instance;
    public bool gameover = false;

    float currentTime = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
  
        }
    }

    public void SpawnTrack(Transform t)
    {
        if (currentTime > 0.1f)
        {
            Instantiate(trackPrefab, t.position + new Vector3(0, -0.01f, 67.0f), Quaternion.identity, t.parent.transform);
            currentTime = 0f;
        }
    }


}
