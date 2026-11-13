using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Cart315.FirstPerson
{
    public class NoteController : MonoBehaviour
    {
        // input
        [SerializeField] private KeyCode closeKey;

        [SerializeField] private FPController player;

        // ui text
        [SerializeField] private GameObject noteCanvas;
        [SerializeField] private TMP_Text noteTextAreaUI;

        [SerializeField] [TextArea] private string noteText;

        [SerializeField] private UnityEvent openEvent;
        private bool isOpen = false;

        public void ShowNote()
        {
            noteTextAreaUI.text = noteText;
            noteCanvas.SetActive(true);
            openEvent.Invoke();
            DisablePlayer(true);
            isOpen = true;

            PlaygroundInstructions.IsReadingNote = true;
        }

        void DisableNote()
        {
            noteCanvas.SetActive(false);
            DisablePlayer(false);
            isOpen = false;

            PlaygroundInstructions.IsReadingNote = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (player != null)
            {
                player.enabled = true;
            }

            if (NoteManager.Instance != null)
            {
                NoteManager.Instance.CollectNote();
            }

            // removes the note after its been interacted with
            Destroy(gameObject);
        }

        void DisablePlayer(bool disable)
        {
            player.enabled = !disable;
        }

        private void Update()
        {
            if (isOpen)
            {
                if (Input.GetKey(closeKey))
                {
                    DisableNote();
                }
            }
        }
    }
}
