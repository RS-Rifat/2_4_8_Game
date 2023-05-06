using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RedZone : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();

        if(cube != null)
        {
            if(!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < 01f)
            {
                // Load Mane GameOver Scene

            }
        }
    }
}
