using UnityEngine;

namespace Menu_Assets.Script.Game_Logic
{
    /**
     * This class is responsible for moving Zanza on the waypoints through the game
     */
    public class Zanza : MonoBehaviour
    {
        // Public parameters
        [Header("Zanza Settings")]
        [SerializeField] 
        private Transform zanza;
    
        [SerializeField]
        private float speed = 1.0f;
    
        [Header("Waypoints")]
        [SerializeField]
        private Transform[] waypoints;
    
        // Internal parameters
        private int _currentWaypointIndex;
        
        /**
         * Put Zanza at the first waypoint
         */
        private void Start()
        {
            zanza.position = waypoints[0].position;
        }
    
        /**
         * Move Zanza to the next waypoint
         */
        private void Update()
        {
            // Keep moving while not at the last waypoint
            if (_currentWaypointIndex >= waypoints.Length) return;
        
            zanza.position = Vector2.MoveTowards(
                zanza.position, 
                waypoints[_currentWaypointIndex].position, 
                speed * Time.deltaTime
            );
            
            // Check if Zanza reached the current waypoint
            if (!Mathf.Approximately(zanza.position.x, waypoints[_currentWaypointIndex].position.x) ||
                !Mathf.Approximately(zanza.position.y, waypoints[_currentWaypointIndex].position.y)) return;
            
            // Move to the next waypoint
            _currentWaypointIndex++;
            
            // Debug log
            Debug.Log("Moving Zanza > W" + (_currentWaypointIndex + 1));
                
            // Check if Zanza reached the last waypoint
            if (_currentWaypointIndex >= waypoints.Length)
            {
                Debug.Log("Zanza reached the last waypoint");
            }
        }
    }
}
