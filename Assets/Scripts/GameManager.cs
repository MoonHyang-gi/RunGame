using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int bestScore;
    public int gameStage;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI titleText;

    public delegate void OnPlay(bool isPlay);
    public event OnPlay onPlay;

    public float gameSpeed = 1.5f;
    public bool isPlay = false;

    public float timer;
    public float watingTime;

    public GameObject playBtn;
    public GameObject pauseBtn;
    public GameObject player;

    public static GameManager instance;

    private void Awake()
    {
        /*if (instance != null)
        {
            //Destroy(gameObject);
            return;
        }*/
        instance = this;
    }

    public void PlayBtn()
    {
        player.SetActive(true);
        pauseBtn.SetActive(true);
        score = 0;
        gameStage = 1;
        bestScoreText.text = "";
        scoreText.text = score.ToString();
        playBtn.SetActive(false);
        isPlay = true;
        onPlay?.Invoke(isPlay);
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        pauseBtn.SetActive(false);
        scoreText.text = "";
        timer = 0.0f;
        watingTime = 1f;
    }

    void Update()
    {
        if (isPlay)
        {
            titleText.text = "";
            scoreText.text = score.ToString();

            timer += Time.deltaTime;
            if (timer >= watingTime)
            {
                score++;
                gameSpeed = gameSpeed + 0.01f;

                if (Mathf.Floor(gameSpeed) % 5f == 0f)
                {
                    gameStage++;
                }

                timer = 0;
            }
        }
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public void GameOver()
    {
        isPlay = false;
        gameSpeed = 1.5f;

        player.SetActive(false);
        pauseBtn.SetActive(false);

        playBtn.SetActive(true);

        UpdateBestScoreRanking();
    }

    private void UpdateBestScoreRanking()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        List<int> rankingScores = new List<int>();
        List<int> rankingStages = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            int playerScore = PlayerPrefs.GetInt("PlayerScore" + i.ToString(), 0);
            int playerStage = PlayerPrefs.GetInt("PlayerStage" + i.ToString(), 0);
            rankingScores.Add(playerScore);
            rankingStages.Add(playerStage);
        }

        bool isDuplicate = rankingScores.Contains(score);

        if (!isDuplicate)
        {
            rankingScores.Add(score);
            rankingScores.Sort();
            rankingScores.Reverse();
            rankingScores.RemoveAt(rankingScores.Count - 1);

            rankingStages.Add(gameStage);
            rankingStages.Sort();
            rankingStages.Reverse();
            rankingStages.RemoveAt(rankingStages.Count - 1);

            for (int i = 1; i <= 10; i++)
            {
                PlayerPrefs.SetInt("PlayerScore" + i.ToString(), rankingScores[i - 1]);
                PlayerPrefs.SetInt("PlayerStage" + i.ToString(), rankingStages[i - 1]);
                PlayerPrefs.Save();
            }
        }

        string rankingText = "Ranking:\n";

        for (int i = 1; i <= 10; i++)
        {
            int playerScore = PlayerPrefs.GetInt("PlayerScore" + i.ToString(), 0);
            int playerStage = PlayerPrefs.GetInt("PlayerStage" + i.ToString(), 0);

            if (playerScore == score)
            {
                playerStage = gameStage; // 종료 시점의 스테이지로 갱신
            }

            rankingText += i.ToString() + ". Stage: " + playerStage.ToString() + 
                " Score: " + playerScore.ToString() + "\n";
        }

        bestScoreText.text = rankingText;
        PlayerPrefs.Save();
    }
}
