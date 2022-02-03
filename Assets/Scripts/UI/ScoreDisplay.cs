using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{

    public TextMeshProUGUI textMesh;


    private void Start()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        textMesh.SetText(GetScore());
    }

    private string GetScore()
    {
        return PlayerPrefs.GetInt("score").ToString();
    }
}
