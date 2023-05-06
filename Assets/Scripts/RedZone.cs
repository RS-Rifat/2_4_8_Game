using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RedZone : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    /*private void Awake()
    {
        restartButton.onClick.AddListener(RestartTheGame);
    }*/
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();

        if(cube != null)
        {
            if(!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < 01f)
            {
                gameOverUI.SetActive(true);
                restartButton.onClick.AddListener(RestartTheGame);
            }
        }
    }

    private void RestartTheGame()
    {
        gameOverUI.SetActive(false);
    }
}
