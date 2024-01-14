using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public abstract class GlobalConstants
    {
        public const string SELECT_HERO_SCENE_NAME = "SelectHeroScene";
        public const string LOBBY_SCENE_NAME = "LobbyScene";
        public const string LUCKY_SPIN_SCENE_NAME = "LuckySpinScene";
        public const string GAME_SCENE_NAME = "GameScene";
        
        public const float MAX_ROTATION_ANGEL = 360;
        public const float MIN_ROTATION_ANGEL = 0;

        public const int GOLD_MULTIPLICATOR = 50;
        public const int GEMS_MULTIPLICATOR = 2;
        
        public const string CHEST_ANIM_TRIGER_OPEN = "Open";
        public const string CHEST_ANIM_TRIGER_MOVE = "Move";
        public const string CHEST_ANIM_TRIGER_HIDE = "Hide";
        public const string CHEST_ANIM_TRIGER_SCALE = "Scale";
        public const string CHEST_ANIM_SPINS_COUNT_TRIGGER_NAME = "SpinsCount";

        public const string GOLD_TAG = "Gold";
        public const string GEM_TAG = "Gem";
        public const string RUNE_TAG = "Rune";
        public const string HEART_TAG = "Heart";

        public const string SPIN_ANIM_TRIGGER_FLY = "Fly";
        public const string PRIZE_CARD_TYPE = "Prize";
    }
    
}