using Nivalis;
using UnityEngine;

namespace NivalisNights.FlatNivalisTimes;

internal static class ReadingGrip
{
    private static Grip? grip;
    private static Grip? updating;
    private static bool failed;
    internal static bool HasOwnedState => grip != null;
    internal static void AllowRetry() => failed = false;

    internal static void Release(Newspaper paper)
    {
        if (grip == null || grip.Paper.Pointer != paper.Pointer) return;
        grip.Release();
        grip = null;
        updating = null;
        failed = false;
    }

    internal static void Begin(PlayerHandsAnimator hands)
    {
        updating = null;
        if (failed) return;
        var paper = hands.newspaper;
        if (grip != null && (!PaperStates.Alive(grip.Paper) || !PaperStates.IsApplied(grip.Paper) || !grip.IsHolding))
        {
            grip.Release();
            grip = null;
        }
        if (grip != null && (!PaperStates.Alive(grip.Hands) || grip.Hands.Pointer != hands.Pointer ||
            !PaperStates.Alive(grip.Paper) || !PaperStates.Alive(paper) || grip.Paper.Pointer != paper.Pointer))
        {
            grip.Release();
            grip = null;
        }
        if (grip == null && PaperStates.Alive(paper) && PaperStates.IsApplied(paper) &&
            (paper.Equipped || paper.AnimationProgress > 0f))
            grip = new Grip(hands, paper);
        if (grip == null) return;
        // Remove last frame's overlay before the original animator/IK can read it.
        grip.RestoreFingers();
        updating = grip;
    }

    internal static void FreezeIdle(Animator animator, ref float deltaTime)
    {
        if (updating != null && PaperStates.Alive(updating.Animator) && animator.Pointer == updating.Animator.Pointer &&
            updating.Paper.Equipped && updating.Paper.AnimationProgress >= 1f)
            deltaTime = 0f; // Original SafeUpdate still evaluates the controller at the held time.
    }

    internal static void EndManual()
    {
        updating?.MoveTargets();
        updating = null;
    }

    internal static void EndScope() => updating = null;

    internal static void AfterPlayerUpdate(PlayerCharacter character)
    {
        if (failed || grip == null || !PaperStates.Alive(grip.Hands) ||
            !PaperStates.Alive(grip.Hands.character) || grip.Hands.character.Pointer != character.Pointer ||
            grip.Frame != Time.frameCount) return;
        // PlayerCharacter.Update inlines the two solver calls: patching UpdateIK would miss them.
        grip.ApplyFingers();
    }

    internal static void Reject(Exception error)
    {
        failed = true;
        updating = null;
        try { grip?.Release(); }
        catch (Exception restoreError) { Plugin.ReportOnce("grip restore requires restart", restoreError); }
        Plugin.ReportOnce("reading grip rejected", error);
        // The accessibility option is one coherent mode, including its hand pose.
        // Queue original paper restoration at the completed-cloth boundary on failure.
        AccessibilitySettings.Reject(false, error);
    }

    private sealed class Grip
    {
        internal readonly PlayerHandsAnimator Hands;
        internal readonly Newspaper Paper;
        internal readonly Animator Animator;
        internal int Frame = -1;
        private readonly Transform leftTarget, rightTarget;
        private readonly Vector3 leftPosition, rightPosition;
        private readonly Transform[] bones = new Transform[GripPose.Bones.Length];
        private readonly Quaternion[] original = new Quaternion[GripPose.Bones.Length];
        private bool overlaid, announced;
        // Equip progress moves the whole newspaper/arms. Blending finger rotations in its
        // final 20% added a visible thumb adjustment after the hand was already on screen.
        internal bool IsHolding => Paper.Equipped || Paper.AnimationProgress > 0f;

        internal Grip(PlayerHandsAnimator hands, Newspaper paper)
        {
            Hands = hands;
            Paper = paper;
            Animator = hands.Animator;
            if (!PaperStates.Alive(Animator) || !Animator.isHuman)
                throw new InvalidOperationException("Reading hands do not have the investigated humanoid animator.");
            leftTarget = paper.HandTargetL;
            rightTarget = paper.HandTargetR;
            var surface = paper.meshRenderer.transform;
            if (!PaperStates.Alive(leftTarget) || !PaperStates.Alive(rightTarget) ||
                leftTarget.parent.Pointer != surface.Pointer || rightTarget.parent.Pointer != surface.Pointer)
                throw new InvalidOperationException("Reading wrist targets are not children of the paper surface.");
            leftPosition = leftTarget.localPosition;
            rightPosition = rightTarget.localPosition;
            if ((leftPosition - new Vector3(.47499993f, -.10999999f, .04833333f)).sqrMagnitude > 1e-8f ||
                (rightPosition - new Vector3(-.50183326f, -.028f, .04799999f)).sqrMagnitude > 1e-8f)
                throw new InvalidOperationException("Reading wrist target positions differ from the investigated original.");
            for (int i = 0; i < bones.Length; i++)
            {
                var definition = GripPose.Bones[i];
                var bone = Animator.GetBoneTransform(definition.Bone);
                if (!PaperStates.Alive(bone) || bone.name != definition.Name)
                    throw new InvalidOperationException($"Reading finger mapping differs at {definition.Bone}.");
                bones[i] = bone;
            }
        }

        internal void MoveTargets()
        {
            if (!PaperStates.Alive(Paper) || !PaperStates.Alive(leftTarget) || !PaperStates.Alive(rightTarget)) return;
            // Offsets are in the common paper parent's local coordinates, not wrist axes.
            leftTarget.localPosition = IsHolding ? leftPosition + GripPose.LeftOffset : leftPosition;
            rightTarget.localPosition = IsHolding ? rightPosition + GripPose.RightOffset : rightPosition;
            Frame = Time.frameCount;
        }

        internal void ApplyFingers()
        {
            if (!PaperStates.Alive(Paper)) return;
            if (!IsHolding) return;
            // Validate all bones before touching any of them.
            foreach (var bone in bones)
                if (!PaperStates.Alive(bone)) throw new InvalidOperationException("A reading finger bone was destroyed.");
            for (int i = 0; i < bones.Length; i++) original[i] = bones[i].localRotation;
            overlaid = true;
            for (int i = 0; i < bones.Length; i++)
                bones[i].localRotation = GripPose.Bones[i].Rotation;
            if (!announced)
            {
                announced = true;
                Plugin.Logger.LogInfo("Reading grip held through newspaper opening/closing after original arm IK. RuntimeAccepted=false.");
            }
        }

        internal void RestoreFingers()
        {
            if (!overlaid) return;
            for (int i = 0; i < bones.Length; i++)
                if (PaperStates.Alive(bones[i])) bones[i].localRotation = original[i];
            overlaid = false;
        }

        internal void Release()
        {
            RestoreFingers();
            if (PaperStates.Alive(leftTarget)) leftTarget.localPosition = leftPosition;
            if (PaperStates.Alive(rightTarget)) rightTarget.localPosition = rightPosition;
        }
    }
}
