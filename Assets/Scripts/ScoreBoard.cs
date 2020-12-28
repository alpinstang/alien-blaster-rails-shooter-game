using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 225;
    public int score = 000000;
    Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = gameObject.GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoretext.text = score.ToString();
    }
}
