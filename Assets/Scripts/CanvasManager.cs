﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public UnityEngine.UI.Toggle musicToggle = null;
    public GameObject titleScreen = null;
    AudioSource music;
    public UnityEngine.UI.RawImage bgImage = null;
    public List<Sprite> backgroundAnimation = null;
    int bgImageStep = 0;
    float timeDelay = 0;
    public GameObject gameObjectsParent = null;
    public GameObject player = null;
    public static CanvasManager Instance;
    [SerializeField]
    private GameObject trackPrefab = null;

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
        player.GetComponent<Rigidbody>().useGravity = false;
        music = GetComponent<AudioSource>();
        bgImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        bgImage.texture = backgroundAnimation[bgImageStep].texture;
        bgImageStep++;
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay += Time.deltaTime;
        if (bgImageStep == 40)
        {
            bgImageStep = 0;
        }
        if (timeDelay >= Time.deltaTime * 3)
        {
            bgImage.texture = backgroundAnimation[bgImageStep].texture;
            bgImageStep++;
            timeDelay = 0;
        }

        if (!musicToggle.isOn)
        {
            music.enabled = false;
        }
        else if (!music.enabled)
        {
            music.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToTitle();
        }
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        GameManager.Instance.running = true;
        Instantiate(trackPrefab, gameObjectsParent.transform.position, Quaternion.identity, gameObjectsParent.transform);
        player.GetComponent<Rigidbody>().useGravity = true; ;
    }

    public void BackToTitle()
    {
        titleScreen.SetActive(true);
        GameManager.Instance.running = false;
    }
}
