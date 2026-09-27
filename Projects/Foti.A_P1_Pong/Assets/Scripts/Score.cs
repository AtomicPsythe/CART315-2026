using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int activePuckCount = 1;
    public int highestPuckCount = 1;

    public TextMeshProUGUI activePuckText;
    public TextMeshProUGUI highestPuckText;

    public void UpdatePuckCount(int puckCount)
    {
        activePuckCount = puckCount;
        if (activePuckCount > highestPuckCount)
        {
            highestPuckCount = activePuckCount;
        }

        if (activePuckText != null)
        {
            activePuckText.text = activePuckCount.ToString();
        }
    }

    public void ResetScore()
    {
        activePuckCount = 1;
        highestPuckCount = 1;

        if (activePuckText != null)
        {
            activePuckText.text = activePuckCount.ToString();
        }
    }
}