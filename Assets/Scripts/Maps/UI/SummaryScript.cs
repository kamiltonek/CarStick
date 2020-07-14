using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScript : MonoBehaviour
{
    [SerializeField] private int map;
    [SerializeField] private int level;
    [SerializeField] private GameObject board;
    [SerializeField] private StarsRequirements requirements;
    [SerializeField] private GameObject requirementsPanel;
    [SerializeField] private TextMeshProUGUI currTime;
    [SerializeField] private TextMeshProUGUI bestTime;
    [SerializeField] private GameObject record;
    [SerializeField] private GameObject levelCompleted;
    [SerializeField] private GameObject levelFailed;
    [SerializeField] private Sprite bigStarTrue;
    [SerializeField] private Sprite bigStarFalse;
    [SerializeField] private GameObject starsHolder;
    [SerializeField] private GameObject coinPopup;

    private Animator animatorBoard;
    private Animator animatorRecord;
    private Color green;
    private Color red;

    public static SummaryScript instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        green = new Color(32, 132, 0, 255);
        red = new Color(200, 40, 0, 255);
        animatorBoard = GetComponent<Animator>();
        animatorRecord = record.GetComponent<Animator>();
    }

    public void showSuccesSummary()
    {
        initializeSummaryPanel(true);
        levelCompleted.SetActive(true);
        SaveTime.instance.Save();
    }

    public void showFailedSummary()
    {
        initializeSummaryPanel(false);
        levelFailed.SetActive(true);
    }

    private void initializeSummaryPanel(bool finish)
    {
        board.SetActive(true);
        animatorBoard.Play("openSummary");    
        loadRequrements(finish);
        setBestTime();
        fillStars(finish);
        setTime(finish);
    }

    private void loadRequrements(bool finish)
    {
        for (int i = 0; i < requirementsPanel.transform.childCount; i++)
        {
            TextMeshProUGUI textMesh = requirementsPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            textMesh.text = requirements.star[i].ToString("f3");
            if ((GameInfo.Instance.Time <= requirements.star[i] && finish)
                || (SaveAndLoad.getMap(map, level) <= requirements.star[i] && SaveAndLoad.getMap(map, level) != 0))
            {
                textMesh.color = Color.green;
            }
            else
            {
                textMesh.color = Color.red;
            }
        }
    }
    private void setTime(bool finish)
    {
        if (finish)
        {
            currTime.text = MyDataTimeConventer.getTime(GameInfo.Instance.Time);
            if (GameInfo.Instance.Time < SaveAndLoad.getMap(map, level) || SaveAndLoad.getMap(map, level) == 0)
            {
                StartCoroutine(playRecord());
            }
        }
        else
        {
            currTime.text = "---";
        }
    }
    private void setBestTime()
    {
        if (SaveAndLoad.getMap(map, level) != 0)
        {
            bestTime.text = MyDataTimeConventer.getTime(SaveAndLoad.getMap(map, level));
        }
        else
        {
            bestTime.text = "---";
        }
    }
    private void fillStars(bool finish)
    {
        float delayed = 0f;
        for(int i = 0; i < starsHolder.transform.childCount; i++)
        {
            GameObject star = starsHolder.transform.GetChild(i).gameObject;
            if (SaveAndLoad.getMap(map, level) <= requirements.star[i] && SaveAndLoad.getMap(map, level) != 0)
            {
                star.GetComponent<Image>().sprite = bigStarTrue;
            }
            else if (GameInfo.Instance.Time <= requirements.star[i] && finish)
            {
                
                StartCoroutine(playStar(star, (0.6f + delayed)));
                delayed += 0.2f;
            }
            else
            {
                star.GetComponent<Image>().sprite = bigStarFalse;
            }
        }
    }

    IEnumerator playStar(GameObject star, float time)
    {
        yield return new WaitForSeconds(time);
        star.GetComponent<Image>().sprite = bigStarTrue;
        star.GetComponent<Animator>().Play("starAnim");
        SaveAndLoad.increaseCoinsAmount(200);
        Instantiate(coinPopup, star.transform.position, Quaternion.identity, board.transform);
    }

    IEnumerator playRecord()
    {
        yield return new WaitForSeconds(0.15f);
        record.SetActive(true);
        animatorRecord.Play("recordAnimStart");
    }
}
