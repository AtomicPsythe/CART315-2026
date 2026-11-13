using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Cart315.FirstPerson
{
    public class GameEndSequence : MonoBehaviour
    {
        // fade to black variables
        [SerializeField] private Image fadePanel;

        // fade duration
        [SerializeField] private float fadeInDuration = 2.0f;
        [SerializeField] private float readDuration = 5.0f;

        [SerializeField] private float displayDuration = 6f;
        [SerializeField] private float fadeDuration = 2.5f;

        // scream audio variables
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip screamSound;
        [SerializeField] private float screamVolume = 1.0f;

        private void Start()
        {
            // unlocks the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            StartCoroutine(PlayEndingSequence());
        }

        private IEnumerator PlayEndingSequence()
        {
            // makes sure the screen starts as solid black
            Color panelColor = fadePanel.color;
            panelColor.a = 1f;
            fadePanel.color = panelColor;

            // once it fades out of black, it reveals the note
            float elapsed = 0f;
            while (elapsed < fadeInDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / fadeInDuration);
                panelColor.a = 1f - Mathf.SmoothStep(0f, 1f, t);
                fadePanel.color = panelColor;
                yield return null;
            }

            panelColor.a = 0f;
            fadePanel.color = panelColor;

            // keeps the note on the screen for a couple of seconds
            yield return new WaitForSeconds(readDuration);

            // plays the scream sound and cuts to black again
            if (audioSource != null && screamSound != null)
            {
                audioSource.PlayOneShot(screamSound, screamVolume);
            }

            panelColor.a = 1f;
            fadePanel.color = panelColor;
        }
    }
}
