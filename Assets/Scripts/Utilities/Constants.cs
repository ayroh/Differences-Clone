// Constants

using UnityEngine;

namespace Utilities.Constants
{
    public static class Constants
    {
        // Camera
        public static float BaseCameraSize = 16;
        public static float BaseCameraAspect = 1080 / 1920f;

        // Sprite Size
        public static float SpriteColliderSizeConstant = 1.2f;

        // Correct Check
        public static float CorrectCheckImageAnimationTime = .3f;
        public static float CorrectCheckClickShakeAnimationTime = .5f;

        // Life
        public static float LifeTimeBetweenCreation = .1f;
        public static float LifeTimeCreationAnimationTime = 1f;
        public static string LifeKillLifeAnimationName = "KillLife";
        public static string LifeColorizeAnimationName = "Colorize";
        public static string LifeReviveLifeAnimationName = "ReviveLife";

        // Score
        public static float ScoreTimeBetweenCreation = .07f;
        public static string ScoreFoundAnimationName = "Found";
        public static string ScoreColorizeAnimationName = "Colorize";
        public static string ScoreCleanAnimationName = "Clean";

        // Found Particle
        public static float FoundParticleAnimationConstant = 1 / 1500f;

        // Wrong Check
        public static float WrongCheckAnimationTime = 1f;

    }
}