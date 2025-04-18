using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int Score = 0;
    public Text ScoreText;
    public AudioSource AudioStar;
    public AudioSource AudioBarriere;

    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Addpoint(int added){
        if(Score +added >= 0){
        Score += added;
        ScoreText.text = Score.ToString();
        }
        else{
            Score = 0;
        ScoreText.text = Score.ToString();
        }
    }

}
