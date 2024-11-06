using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class logic : UdonSharpBehaviour
{
    public GameObject objectToPosition; 
    [Range(0f, 3f)]
    public float distanceFromBone = 1.0f;
    public HumanBodyBones boneToCheck = HumanBodyBones.Head; 

    private VRCPlayerApi localPlayer;

    void Start()
    {
        localPlayer = Networking.LocalPlayer; 
        UpdateObjectPosition();
    }

    void Update()
    {
        if (localPlayer != null)
        {
            UpdateObjectPosition();
        }
    }

    private void UpdateObjectPosition()
    {
        Vector3 bonePosition = localPlayer.GetBonePosition(boneToCheck);
        Quaternion boneRotation = localPlayer.GetBoneRotation(boneToCheck);
        Vector3 position = bonePosition + (boneRotation * Vector3.forward * distanceFromBone);
        objectToPosition.transform.position = position;
        objectToPosition.transform.rotation = boneRotation; 
    }
}
