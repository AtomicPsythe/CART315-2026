using UnityEngine;
using UnityEngine.InputSystem;

namespace Cart315.FirstPerson
{
    public class FlashlightController : MonoBehaviour
    {
        // flashlight variables
        [SerializeField] private Light _flashlight;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _clickSound;

        // battery/power variables
        [SerializeField] private float _maxBattery = 100f;
        // drain amount/rate
        [SerializeField] private float _drainRate = 1f;
        // max brightness
        [SerializeField] private float _maxIntensity = 300f;

        private float _currentBattery;
        private bool _isOn = false;

        private void Start()
        {
            _currentBattery = _maxBattery;
            if (_flashlight != null)
            {
                _flashlight.enabled = _isOn;
                _flashlight.intensity = _maxIntensity;
            }
        }

        private void Update()
        {
            // toggles the flashlight on and off by clicking on the F key
            if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame)
            {
                ToggleFlashlight();
            }

            // if the flashlight is turned on, the battery will begin to drain
            if (_isOn && _currentBattery > 0f)
            {
                _currentBattery -= _drainRate * Time.deltaTime;
                _currentBattery = Mathf.Clamp(_currentBattery, 0f, _maxBattery);

                // once the battery is below 30% the brightness will become dimmer signaling its running low on battery
                if (_flashlight != null)
                {
                    float batteryRatio = _currentBattery / _maxBattery;
                    _flashlight.intensity = batteryRatio < 0.3f 
                        ? Mathf.Lerp(1f, _maxIntensity, batteryRatio / 0.3f) 
                        : _maxIntensity;
                }

                // flashlight dies when its battery reaches 0%
                if (_currentBattery <= 0f)
                {
                    _isOn = false;
                    if (_flashlight != null) _flashlight.enabled = false;
                }
            }
        }

        private void ToggleFlashlight()
        {
            // disables the player from being able to turn on the flashlight if its dead
            if (!_isOn && _currentBattery <= 0f) return;

            _isOn = !_isOn;
            if (_flashlight != null) _flashlight.enabled = _isOn;

            if (_audioSource != null && _clickSound != null)
            {
                _audioSource.PlayOneShot(_clickSound);
            }
        }

        public void AddBattery(float amount)
        {
            _currentBattery = Mathf.Clamp(_currentBattery + amount, 0f, _maxBattery);
        }

        // visual battery bar
        private void OnGUI()
        {
            GUIStyle style = new GUIStyle(GUI.skin.label) { fontSize = 18, fontStyle = FontStyle.Bold };
            GUI.Label(new Rect(850, 20, 250, 30), $"Battery: {Mathf.CeilToInt(_currentBattery)}%", style);
        }
    }
}
