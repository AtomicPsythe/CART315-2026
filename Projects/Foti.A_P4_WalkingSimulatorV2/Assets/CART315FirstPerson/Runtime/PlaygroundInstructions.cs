using UnityEngine;

namespace Cart315.FirstPerson
{
    // Used only by the demonstration scene; the player prefab has no UI dependency.
    public class PlaygroundInstructions : MonoBehaviour
    {
        public static bool IsReadingNote = false;
        private GUIStyle _title, _body;

        private void OnGUI()
        {
            if (IsReadingNote) return;

            if (Cursor.lockState != CursorLockMode.Locked)
            {
                if (_title == null)
                {
                    _title = new GUIStyle(GUI.skin.label) { fontSize = 26, fontStyle = FontStyle.Bold };
                    _body = new GUIStyle(GUI.skin.label) { fontSize = 18, wordWrap = true };
                }
                GUI.Box(new Rect(16, 16, 440, 300), GUIContent.none);
                GUI.Label(new Rect(32, 26, 410, 38), "Where the Wind Howls", _title);
                GUI.Label(new Rect(32, 68, 408, 240),
                    "CONTROLS:\n" +
                    "\n" +
                    "WASD: Move     Shift: Sprint     Space: Jump\n" +
                    "\n" +
                    "Left click: Capture mouse + interact with notes Right click: Exit notes\n" + 
                    "\n" +
                    "Escape: Release   F: Toggle flashlight\n" +
                    "\n" +
                    "Collect all the note fragments to complete the game!\n", _body);
                GUI.Label(new Rect(Screen.width / 2f - 120, Screen.height / 2f + 100, 280, 35), "Click to Explore", _title);
            }
        }
    }
}
