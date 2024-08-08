using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class UI_SkillSlot : UI_Scene
    {
        enum CoolAnimators
        {
            cool1,
        }
        private Animator[] cool = new Animator[4];
        private void Awake()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Bind<Image>(typeof(SkillSlot));
            Bind<Animator>(typeof(CoolAnimators));

            cool[0] = Get<Animator>((int)CoolAnimators.cool1);
        }

        public void SetSkillImage(SkillSlot slot, Sprite image)
        {
            GetImage((int)slot).sprite = image;
        }

        public Animator GetAnimator(SkillSlot slot)
        {
            return cool[(int)slot];
        }
    }
}