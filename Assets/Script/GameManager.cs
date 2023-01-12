using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl player;

    [SerializeField] private GameObject restartText;
    [SerializeField] private TextMeshProUGUI roomText;

    private void Awake()
    {
        restartText.SetActive(false);
        roomText.SetText(SceneManager.GetActiveScene().name + " / 11");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isAlive)
        {
            restartText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
