using Fusion;
using UnityEngine;

namespace UI.Scene
{
    public class StatusUIController : NetworkBehaviour
    {
        private UI_Status _view;
        private ActorStat _model;

        public void Awake()
        {
            _view = GetComponent<UI_Status>();
            _model = GameObject.FindWithTag("Player").GetOrAddComponent<ActorStat>();
            _model.HpStatChanged += delegate { _view.UpdateHp(_model.maxHP, _model.hp); };
        }
        
        public override void Spawned()
        {
            RoomManager.Instance.Rpc_LoadDone(Runner.LocalPlayer);
        }
    }
}