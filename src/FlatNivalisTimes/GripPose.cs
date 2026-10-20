using UnityEngine;

namespace NivalisNights.FlatNivalisTimes;

// Original Avatar type-1 conversion + fixed idle t=0; fitted thumb contact. See grip-fit receipt.
internal static class GripPose
{
    internal static readonly Vector3 LeftOffset = new(0.00833126269f, 0f, 0f);
    internal static readonly Vector3 RightOffset = new(-0.00340806305f, 0f, 0f);
    internal static readonly (HumanBodyBones Bone, string Name, Quaternion Rotation)[] Bones =
    {
        (HumanBodyBones.LeftThumbProximal, "L_Thumb00", new Quaternion(0.279182615f, -0.104279716f, -0.0384122198f, 0.953785778f)),
        (HumanBodyBones.LeftThumbIntermediate, "L_Thumb01", new Quaternion(-0.0182567235f, 0.03040306f, -0.05856538f, 0.997653468f)),
        (HumanBodyBones.LeftThumbDistal, "L_Thumb02", new Quaternion(-0.0158317653f, -0.0575273935f, -0.00894788007f, 0.998178285f)),
        (HumanBodyBones.LeftIndexProximal, "L_Index00", new Quaternion(-0.0171115616f, -0.0915029418f, -0.0554234901f, 0.994113999f)),
        (HumanBodyBones.LeftIndexIntermediate, "L_Index01", new Quaternion(-0.0154167586f, 0.00338172254f, -0.105164122f, 0.994329621f)),
        (HumanBodyBones.LeftIndexDistal, "L_Index02", new Quaternion(-0.0157850986f, 0.000657270854f, -0.105718276f, 0.994270609f)),
        (HumanBodyBones.LeftMiddleProximal, "L_Middle00", new Quaternion(0.0303815579f, 0.0144345104f, -0.0879741559f, 0.995554697f)),
        (HumanBodyBones.LeftMiddleIntermediate, "L_Middle01", new Quaternion(0.0219409929f, -0.00528998177f, -0.119318974f, 0.992599411f)),
        (HumanBodyBones.LeftMiddleDistal, "L_Middle02", new Quaternion(0.0222355588f, -0.00371551228f, -0.0961038466f, 0.995115986f)),
        (HumanBodyBones.LeftRingProximal, "L_Ring00", new Quaternion(0.0170344155f, 0.11643354f, -0.124512006f, 0.985215621f)),
        (HumanBodyBones.LeftRingIntermediate, "L_Ring01", new Quaternion(0.0400965557f, -0.000722360536f, -0.140100411f, 0.98932483f)),
        (HumanBodyBones.LeftRingDistal, "L_Ring02", new Quaternion(0.0402954832f, 0.0058781991f, -0.159848143f, 0.986301319f)),
        (HumanBodyBones.LeftLittleProximal, "L_Pinky00", new Quaternion(0.0398992878f, 0.213361526f, -0.13726061f, 0.966459741f)),
        (HumanBodyBones.LeftLittleIntermediate, "L_Pinky01", new Quaternion(0.0301967261f, 0.00310291417f, -0.152612472f, 0.987819803f)),
        (HumanBodyBones.LeftLittleDistal, "L_Pinky02", new Quaternion(0.0308428059f, 0.0126227052f, -0.159313735f, 0.986665355f)),
        (HumanBodyBones.RightThumbProximal, "R_Thumb00", new Quaternion(0.273655351f, -0.215868869f, 0.032900459f, -0.936712838f)),
        (HumanBodyBones.RightThumbIntermediate, "R_Thumb01", new Quaternion(-0.0153579051f, 0.105827039f, 0.114765052f, -0.987620249f)),
        (HumanBodyBones.RightThumbDistal, "R_Thumb02", new Quaternion(-0.0236797127f, 0.0712679471f, 0.105367923f, -0.991593542f)),
        (HumanBodyBones.RightIndexProximal, "R_Index00", new Quaternion(-0.0189242651f, -0.0915625948f, 0.0437520625f, -0.99465769f)),
        (HumanBodyBones.RightIndexIntermediate, "R_Index01", new Quaternion(-0.0151486179f, 0.00499333536f, 0.0589985733f, -0.99813063f)),
        (HumanBodyBones.RightIndexDistal, "R_Index02", new Quaternion(-0.0156201845f, 0.00199426184f, 0.0677384057f, -0.99757884f)),
        (HumanBodyBones.RightMiddleProximal, "R_Middle00", new Quaternion(0.0296610638f, 0.0153419095f, 0.0636334622f, -0.997414472f)),
        (HumanBodyBones.RightMiddleIntermediate, "R_Middle01", new Quaternion(0.0215961724f, -0.00682854251f, 0.0699774139f, -0.997291401f)),
        (HumanBodyBones.RightMiddleDistal, "R_Middle02", new Quaternion(0.0220940324f, -0.00449678144f, 0.0713096782f, -0.997199359f)),
        (HumanBodyBones.RightRingProximal, "R_Ring00", new Quaternion(0.021525104f, 0.121102732f, 0.0860665053f, -0.988667464f)),
        (HumanBodyBones.RightRingIntermediate, "R_Ring01", new Quaternion(0.039302239f, -0.00788320192f, 0.083139875f, -0.995731365f)),
        (HumanBodyBones.RightRingDistal, "R_Ring02", new Quaternion(0.0398024858f, -0.00359936315f, 0.0849122631f, -0.995586618f)),
        (HumanBodyBones.RightLittleProximal, "R_Pinky00", new Quaternion(0.0452210528f, 0.217407853f, 0.0993955237f, -0.969953304f)),
        (HumanBodyBones.RightLittleIntermediate, "R_Pinky01", new Quaternion(0.0295855063f, -0.003208287f, 0.101112648f, -0.994429805f)),
        (HumanBodyBones.RightLittleDistal, "R_Pinky02", new Quaternion(0.0304385071f, 0.006769352f, 0.111470881f, -0.993278368f)),
    };
}
