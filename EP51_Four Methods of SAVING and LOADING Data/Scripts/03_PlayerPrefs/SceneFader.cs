using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    float alpha;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    IEnumerator FadeIn()
    {
        alpha = 1;

        while(alpha > 0)
        {
            alpha -= Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
    }

    IEnumerator FadeOut(string _sceneName)
    {
        alpha = 0;

        while(alpha < 1)
        {
            alpha += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }

        SceneManager.LoadScene(_sceneName);
    }

}
