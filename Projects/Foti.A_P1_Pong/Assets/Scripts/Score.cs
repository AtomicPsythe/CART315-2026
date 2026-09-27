using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int activePuckCount = 1;

    public TextMeshProUGUI activePuckText;

    public void UpdatePuckCount(int puckCount)
    {
        activePuckCount = puckCount;

        if (activePuckText != null)
        {
            activePuckText.text = activePuckCount.ToString();
        }
    }

    public void ResetScore()
    {
        activePuckCount = 1;

        if (activePuckText != null)
        {
            activePuckText.text = activePuckCount.ToString();
        }
    }
}