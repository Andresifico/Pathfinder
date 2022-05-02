using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endscreen : MonoBehaviour
{
    public static Endscreen instance;
    [SerializeField] private TextMeshProUGUI level;
    public Text timeCounter;
    [SerializeField] private TextMeshProUGUI timeT;
    [SerializeField] private TextMeshProUGUI countdown;
    public int count = 10;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        level.text = BoardManager.Level.ToString();
        timeT.text = timeCounter.text;
        Timer();
    }
    IEnumerator DelayTimer()
    {
        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;
        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;

        countdown.SetText(count.ToString());
        yield return new WaitForSeconds(1);
        count = count - 1;
        if (count == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       
    }
    public void Timer()
    {
        StartCoroutine(DelayTimer());
    }

    // Update is called once per frame
    void Update()
    {
        timeT.text = timeCounter.text;
    }
}
