using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class FPSCalculator : MonoBehaviour
{
	enum CountType
	{
		FrameCount,
		DeltaTime
	}

	[SerializeField] CountType countType;
	[SerializeField] KeyCode toggleKey;
	[SerializeField] string prefix;

	new Renderer renderer;
	TextMesh textMesh;
	bool doCalculation = true;
	int countedFps;
	float elapsedTime;

	void Awake()
	{
		renderer = GetComponent<Renderer>();
		textMesh = GetComponent<TextMesh>();
		textMesh.text = "Calculate...";
	}

	void Update()
	{
		if (Input.GetKeyDown(toggleKey))
		{
			doCalculation = !doCalculation;
			renderer.enabled = doCalculation;
		}

		if (doCalculation == false) return;

		switch (countType)
		{
			case CountType.FrameCount:
				CountFrame();
				break;

			case CountType.DeltaTime:
				CalculateFromDeltaTime();
				break;

			default:
				Debug.LogError("Not implemented count type.");
				break;
		}
	}

	void CountFrame()
	{
		++countedFps;
		elapsedTime += Time.deltaTime;
		if (elapsedTime > 1f)
		{
			ShowFps(countedFps.ToString());
			elapsedTime = 0f;
			countedFps = 0;
		}
	}

	void CalculateFromDeltaTime()
	{
		var fps = 1f / Time.deltaTime;
		ShowFps(fps.ToString(@"F2"));
	}

	void ShowFps(string fps)
	{
		textMesh.text = prefix + fps;
	}
}