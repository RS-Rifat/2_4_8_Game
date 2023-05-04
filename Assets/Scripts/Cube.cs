using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text[] numbersText;

    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
    [HideInInspector] public Rigidbody CubeRigidbody;
    [HideInInspector] public bool IsMainCube;

    private MeshRenderer cubeMeshRenderer;

    private void Awake()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        CubeRigidbody = GetComponent<Rigidbody>();
    }

    public void SetColor (Color color)
    {
        CubeColor = color;
        cubeMeshRenderer.material.color = color;
    }
    public void SetNumber(int number)
    {
        CubeNumber = number;
        for(int i = 0; i < 6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }

}