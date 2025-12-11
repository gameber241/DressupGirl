using Spine;
using Spine.Unity;
using UnityEngine;

public class SkeletonFollow : MonoBehaviour
{
    [SerializeField] protected SkeletonAnimation bodySketeton;


    protected SkeletonAnimation _currentSkeleton;

    protected Skeleton _master;
    protected Skeleton _skeletonCurrent;
    protected virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        _currentSkeleton = GetComponent<SkeletonAnimation>();

        _master = bodySketeton.Skeleton;
        _skeletonCurrent = _currentSkeleton.Skeleton;
        
    }

    protected virtual void Update()
    {

        if (_master == null || _skeletonCurrent == null)
        {
            return;
        }



        foreach (Bone masterBone in _master.Bones)
        {
            Bone bone = _skeletonCurrent.FindBone(masterBone.Data.Name);
            if (bone != null)
            {
                // bone.SetToSetupPose();

                bone.X = masterBone.X;
                bone.Y = masterBone.Y;
                bone.Rotation = masterBone.Rotation;
                bone.ScaleX = masterBone.ScaleX;
                bone.ScaleY = masterBone.ScaleY;
                bone.ShearX = masterBone.ShearX;
                bone.ShearY = masterBone.ShearY;

                bone.AX = masterBone.AX;
                bone.AY = masterBone.AY;
                bone.Rotation = masterBone.Rotation;
                bone.AScaleX = masterBone.AScaleX;
                bone.AScaleY = masterBone.AScaleY;
                bone.AShearX = masterBone.AShearX;
                bone.AShearY = masterBone.AShearY;
            }
        }

        _skeletonCurrent.UpdateWorldTransform();
    }

}
