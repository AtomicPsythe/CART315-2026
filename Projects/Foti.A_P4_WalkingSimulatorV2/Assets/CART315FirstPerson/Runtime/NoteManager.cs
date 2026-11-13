using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cart315.FirstPerson
{
    public class NoteManager : MonoBehaviour
    {
        public static NoteManager Instance;

        // checks for how many notes are needed to trigger the GameEnd
        [SerializeField] private int totalNotesRequired = 3;

        [SerializeField] private Image blackFadeImage;
        [SerializeField] private float delayBeforeFade = 0.8f;
        [SerializeField] private float fadeOutDuration = 3.0f;
        [SerializeField] private float holdBlackDuration = 0.75f;

        // amount of notes collected
        private int notesCollected = 0;

        private bool isTransitioning = false;

        // if the player interacts with the note object, it destroys it after 
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // keeps track of notes that are collected, if all are collected triggers GameEnd
        public void CollectNote()
        {
            notesCollected++;

            if (notesCollected >= totalNotesRequired)
            {
                SceneManager.LoadScene("GameEnd");
            }
        }

        private IEnumerator FadeAndLoadEnding()
        {
            isTransitioning = true;

            yield return new WaitForSeconds(delayBeforeFade);

            float startVolume = AudioListener.volume;

                if (blackFadeImage != null)
                {
                    float elapsed = 0f;
                    Color c = blackFadeImage.color;

                    while (elapsed < fadeOutDuration)
                    {
                        elapsed += Time.deltaTime;
                        float t = Mathf.Clamp01(elapsed / fadeOutDuration);

                        // smoothstep makes the ease in/out more seamless
                        float smoothT = Mathf.SmoothStep(0f, 1f, t);

                        c.a = smoothT;
                        blackFadeImage.color = c;

                        // fades out the audio and flashlight
                        AudioListener.volume = Mathf.Lerp(startVolume, 0f, smoothT);

                        yield return null;
                    }
                }

                // lets the screen remain black for a bit before transitioning to GameEnd
                yield return new WaitForSeconds(holdBlackDuration);

                // resets the audio volume
                AudioListener.volume = 1f;

                SceneManager.LoadScene("GameEnd");
        }
    }
}
