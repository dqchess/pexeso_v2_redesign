﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
	public float duration = 0.5f;

	private CanvasGroup m_canvasGroup;

	private void Awake()
	{
		m_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void FadeIn()
	{
		StartCoroutine(RunFadeIn());
	}

	public void FadeOut()
	{
		StartCoroutine(RunFadeOut());
	}

	private IEnumerator RunFadeIn()
	{
		var time = 0.0f;
		var initialAlpha = m_canvasGroup.alpha;

		while (time < duration)
		{
			time += Time.deltaTime;
			m_canvasGroup.alpha = Mathf.Lerp(initialAlpha, 1.0f, time/duration);
			yield return new WaitForEndOfFrame();
		}
        m_canvasGroup.interactable = true;
        m_canvasGroup.blocksRaycasts = true;
	}

	private IEnumerator RunFadeOut()
	{
		var time = 0.0f;
		var initialAlpha = m_canvasGroup.alpha;

		while (time < duration)
		{
			time += Time.deltaTime;
			m_canvasGroup.alpha = Mathf.Lerp(initialAlpha, 0.0f, time/duration);
			yield return new WaitForEndOfFrame();
		}
        m_canvasGroup.interactable = false;
        m_canvasGroup.blocksRaycasts = false;
	}
}