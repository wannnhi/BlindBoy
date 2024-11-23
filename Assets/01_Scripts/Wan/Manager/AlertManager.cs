using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
public class AlertManager : MonoSingleton<AlertManager>
{
    private TMP_Text alertText;
    private Queue<string> alertQueue = new Queue<string>();
    private bool isAlertActive = false;

    private void Awake()
    {
        alertText = GetComponent<TMP_Text>();
        alertText.alpha = 0;
    }

    public void SendAlert(string message)
    {
        alertQueue.Enqueue(message);
        if (!isAlertActive)
        {
            StartCoroutine(ProcessAlerts());
        }
    }

    private IEnumerator ProcessAlerts()
    {
        isAlertActive = true;

        while (alertQueue.Count > 0)
        {
            string currentMessage = alertQueue.Dequeue();
            alertText.text = currentMessage;
            yield return ShowAlert();
        }

        isAlertActive = false;
    }

    private IEnumerator ShowAlert()
    {
        alertText.DOFade(1, 0.2f);
        yield return new WaitForSeconds(2.0f);
        alertText.DOFade(0, 0.2f);
        yield return new WaitForSeconds(0.2f);
    }
}
