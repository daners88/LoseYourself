using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spherePrefab = null;
    [SerializeField]
    private GameObject gameObjectsParent = null;
    [SerializeField]
    private GameObject player = null;
    List<GameObject> randomSpheres = new List<GameObject>();
    public Vector3 spawnPos1 = Vector3.zero;
    public Vector3 spawnPos2 = Vector3.zero;
    System.Random rand = new System.Random();
    [SerializeField]
    private GameObject stageCountDownTimer = null;
    [SerializeField]
    private GameObject stage1SuccessRate = null;
    [SerializeField]
    private GameObject stage2SuccessRate = null;
    [SerializeField]
    private GameObject infiniteStageSuccessRate = null;

    public bool running = false;
    [SerializeField]
    private GameObject trackPrefab = null;
    [SerializeField]
    private float stageTimer = 30.0f;
    public static GameManager Instance;
    public bool gameover = false;

    int obstacleCount = 0;
    int obstacleHitCount = 0;

    int stageCount = 0;

    float currentTime = 0f;
    float obstacleCountTime = 0f;
    float obstacleHitTime = 0f;
    float stageTime = 0f;

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
            obstacleCountTime += Time.deltaTime;
            obstacleHitTime += Time.deltaTime;

            if(stageCount < 2)
            {
                if (stageCount == 0)
                {
                    stage1SuccessRate.GetComponent<UnityEngine.UI.Text>().text = ((1f - ((float)obstacleHitCount / ((float)obstacleCount > 0 ? (float)obstacleCount : 1f))) * 100f).ToString();
                }
                else
                {
                    stage2SuccessRate.GetComponent<UnityEngine.UI.Text>().text = ((1f - ((float)obstacleHitCount / ((float)obstacleCount > 0 ? (float)obstacleCount : 1f))) * 100f).ToString();
                }
                stageTime += Time.deltaTime;
                if (stageTime > stageTimer)
                {
                    stageCount++;
                    SwapStages();
                    stageTime = 0f;
                }
                stageCountDownTimer.GetComponent<UnityEngine.UI.Text>().text = (stageTimer - stageTime).ToString();
            }
            else if(stageCount == 2)
            {
                stageCountDownTimer.GetComponent<UnityEngine.UI.Text>().text = "N/A";
                stageCount++;
                infiniteStageSuccessRate.GetComponent<UnityEngine.UI.Text>().text = ((1f - ((float)obstacleHitCount / ((float)obstacleCount > 0 ? (float)obstacleCount : 1f))) * 100f).ToString();
            }
            else
            {
                infiniteStageSuccessRate.GetComponent<UnityEngine.UI.Text>().text = ((1f - ((float)obstacleHitCount / ((float)obstacleCount > 0 ? (float)obstacleCount : 1f))) * 100f).ToString();
            }


            if(rand.Next(0,10) > 5 && stageCount > 0)
            {
                GameObject temp = Instantiate(spherePrefab, player.transform.position + new Vector3(rand.Next(-10, 11), rand.Next(-10, 11), rand.Next(0, 15)), Quaternion.identity, gameObjectsParent.transform);
                temp.transform.rotation = player.transform.rotation;
                temp.GetComponent<Rigidbody>().AddForce(new Vector3(rand.Next(0, 50), rand.Next(0, 0), rand.Next(100, 200)));
                randomSpheres.Add(temp);
            }

            if(randomSpheres.Count > 5)
            {
                List<GameObject> tempList = randomSpheres.GetRange(0, randomSpheres.Count - 4);
                randomSpheres.RemoveRange(0, randomSpheres.Count - 4);
                foreach (GameObject go in tempList)
                {
                    Destroy(go);
                }
            }
        }
        else
        {
  
        }
    }

    public void ResetGame()
    {
        obstacleCount = 0;
        obstacleHitCount = 0;

        stageCount = 0;

        currentTime = 0f;
        obstacleCountTime = 0f;
        obstacleHitTime = 0f;
        stageTime = 0f;
        stage1SuccessRate.GetComponent<UnityEngine.UI.Text>().text = "0";
        stage2SuccessRate.GetComponent<UnityEngine.UI.Text>().text = "0";
        infiniteStageSuccessRate.GetComponent<UnityEngine.UI.Text>().text = "0";
    }

    private void SwapStages()
    {
        obstacleCount = 0;
        obstacleHitCount = 0;
        CanvasManager.Instance.SetBGActive(true);
    }

    public void SpawnTrack(Transform t)
    {
        if (currentTime > 0.1f)
        {
            Instantiate(trackPrefab, t.position + new Vector3(0, -0.05f, 67.0f), Quaternion.identity, t.parent.transform);
            spawnPos2 = spawnPos1;
            spawnPos1 = t.position + new Vector3(0, -0.05f, 67.0f);
            currentTime = 0f;
        }
    }

    public void ObstacleCountIncrease()
    {
        if(obstacleCountTime > 0.1f)
        {
            obstacleCount++;
            obstacleCountTime = 0f;
        }
    }

    public void ObstacleHitIncrease()
    {
        if(obstacleHitTime > 0.1f)
        {
            obstacleHitCount++;
            obstacleHitTime = 0f;
        }
    }


}
