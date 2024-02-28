using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
	public Collider bola;
	public Material offMaterial;
	public Material onMaterial;
    public float score;
	
    public SwitchAudioManager switchAudioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

	private bool isOn;
	private Renderer renderer;

	private void Start()
	{
		renderer = GetComponent<Renderer>();

		Set(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == bola)
		{
			StartCoroutine(Blink(2));

            //playsfx
            switchAudioManager.PlaySwitchSFX(other.transform.position);

            //playvfx
            vfxManager.PlayVFX(other.transform.position);
		}
	}

	private void Set(bool active)
	{
		isOn = active;

		if (isOn == true)
		{
			renderer.material = onMaterial;
		}
		else
		{
			renderer.material = offMaterial;
		}
	}

	private void Toggle()
	{

		//score add
		scoreManager.AddScore(score);
	}

	private IEnumerator Blink(int times)
	{
		int blinkTimes = times * 2;

		for (int i =0; i < times; i++)
		{
			Set(!isOn);
			yield return new WaitForSeconds(1f);
		}
	}
}
