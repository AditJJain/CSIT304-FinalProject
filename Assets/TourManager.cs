using UnityEngine;
using UnityEngine.Rendering;

public class TourManager : MonoBehaviour
{
    public Material[] roomSkyboxes;

    void Start()
    {
        SwitchToRoom(0);
    }

    public void SwitchToRoom(int roomIndex)
    {
        if (roomIndex < 0 || roomIndex >= roomSkyboxes.Length) return;
        RenderSettings.skybox = roomSkyboxes[roomIndex];
        DynamicGI.UpdateEnvironment();
    }
}