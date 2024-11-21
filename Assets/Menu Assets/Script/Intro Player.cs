using UnityEngine;
using UnityEngine.Video;

namespace Menu_Assets.Script
{
    /**
     * This class is responsible for playing the intro video and fading out the video after 6 seconds
     */
    public class IntroPlayer : MonoBehaviour
    {
        // Public parameters
        [Header("Video Player Settings")]
        [SerializeField]
        private VideoPlayer videoPlayer;
        
        // Internal parameters
        private bool _isFadingOut;

        /**
         * Start the video player and fade out the video after 6 seconds
         */
        private void Start()
        {
            // Wait 1 second
            Invoke(nameof(PlayVideo), 1);
            
            // Wait 6 seconds before gradually reducing the alpha level of the video player
            Invoke(nameof(FadeOut), 6);
        }
        
        /**
         * Play the video
         */
        private void PlayVideo()
        {
            videoPlayer.Play();
        }

        /**
         * Start fading out the video
         */
        private void FadeOut()
        {
            _isFadingOut = true;
        }
        
        /**
         * Gradually reduce the alpha level of the video player if the video player is in the fading out state
         */
        private void Update()
        {
            // Check if the video player is fading out
            if (!_isFadingOut) return;
            
            // Gradually reduce the alpha level of the video player
            videoPlayer.targetCameraAlpha -= Time.deltaTime / 2;
                
            // Stop the video player when the alpha level is 0
            if (!(videoPlayer.targetCameraAlpha <= 0)) return;
                
            // Stop the video player and reset the alpha level
            videoPlayer.Stop();
            videoPlayer.targetCameraAlpha = 0;
            _isFadingOut = false;
        }
    }
}
