using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu_Assets.Script.Menus
{
    /**
     * This class is responsible for managing the main menu
     */
    public class MainMenu : MonoBehaviour
    {
        /**
         * Play the first level
         */
        public void PlayFirstLevel()
        {
            // Load the first level
            SceneManager.LoadScene("Scenes/Levels/Level-1");
        }
    }
}
