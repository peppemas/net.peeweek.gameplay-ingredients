using Managers.Implementations;
using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class GamepadRumbleAction : ActionBase
    {
        [Range(0,1)]
        public float lowFrequency = 0.2f;
        [Range(0,1)]
        public float highFrequency = 0.2f;
        public RumblePattern pattern = RumblePattern.Constant;
        public float duration = 1.0f;
        public AnimationCurve patternCurve; // TODO: just for test, I want to use curves instead low/high/pattern values
        
        public override void Execute(GameObject instigator = null)
        {
            if (Manager.TryGet<RumbleManager>(out RumbleManager manager))
            {
                manager.Rumble(null, lowFrequency, highFrequency, duration, pattern);
            }
        }
    }
}