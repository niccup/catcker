using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class PointsManager : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text upgradePPCCostText;
    public TMP_Text upgradePPSCostText;
    public TMP_Text pointsVertsText;
    public TMP_Text pointsTrisText;
    public TMP_Text pointsEdgesText;
    public TMP_Text pointsFacesText;
    public int points = 0;
    private int pointsPerClick = 1;
    private int upgradePointsPerClickCost = 1;
    public float pointsAddInterval = 1;
    private float timer;
    public int pointsPerSecond;
    public int upgradePointsPerSecondCost = 1;
    public int targetWinPoints = 0;
    public GameObject winScreen;
    [SerializeField]private Image fadeScreen;
    private Color white;

    void Start()
    {
        upgradePPCCostText.text = upgradePointsPerClickCost.ToString();
        pointsText.text = points.ToString();
        upgradePPSCostText.text = upgradePointsPerSecondCost.ToString();
        white = new Color(255,255,255,0);
    }

    IEnumerator ScreenAndQuit()
    {
        for (float i = 0; i < 25; i++) {
            white = new Color(1, 1, 1, i/100);
            print(white);
            fadeScreen.color = white;
            yield return new WaitForSeconds(0.005f);
        }
       
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > pointsAddInterval)
        {
            GeneratePoints(pointsPerSecond);
            timer = 0;
        }
        if (points >= targetWinPoints && points != 0)
        {
            if (!winScreen.activeSelf)
            {
                winScreen.SetActive(true);
                StartCoroutine(ScreenAndQuit());
            }
        }
        else
        {
            winScreen.SetActive(false);
        }        
    }

    public void GeneratePoints(int addedPoints)
    {
        points += addedPoints;
        pointsText.text = points.ToString();
        DisplayMultipliedValues();
        // print(points);
    }

    public void DisplayMultipliedValues()
    {
        if (pointsVertsText != null)
        {
            pointsVertsText.text = (points * 4).ToString();
        }
        print(points * 4);
        if (pointsEdgesText != null)
        {
            pointsEdgesText.text = (points * 12).ToString();
        }
        print(points * 12);
        if (pointsTrisText != null)
        {
            pointsTrisText.text = (points * 12).ToString();
        }
        print(points * 12);
        if (pointsFacesText != null)
        {
            pointsFacesText.text = (points * 6).ToString();
        }
        print(points*6);
    }

    public void AddPointsPerClick()
    {
        GeneratePoints(pointsPerClick);
    }

    public void UpgradePointsPerClick()
    {
        if (TrySpendPoints(upgradePointsPerClickCost))
        {
            pointsPerClick += 1;
            upgradePointsPerClickCost = 1 + Mathf.RoundToInt(upgradePointsPerClickCost * 1.5f);
            upgradePPCCostText.text = upgradePointsPerClickCost.ToString();
        }
    }

    public void UpdatePointsPerSecond()
    {
        if (TrySpendPoints(upgradePointsPerSecondCost))
        {
            pointsPerSecond += 1;
            upgradePointsPerSecondCost += 1;
            upgradePPSCostText.text = upgradePointsPerSecondCost.ToString();
        }
    }

    private bool TrySpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            pointsText.text = points.ToString();
            return true;
        }
        return false;
    }
}