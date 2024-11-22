using Fusion;
using UnityEngine;

namespace UI.Scene
{
    public class StatusUIController : NetworkBehaviour
    {
        private UI_Status _view;
        private ActorStat _model;
        private ActorStat[] R_actors;
        private ActorStat[] B_actors;

        public void Awake()
        {
            _view = GetComponent<UI_Status>();
            _model = GameObject.FindWithTag("Player").GetOrAddComponent<ActorStat>();
            _model.HpStatChanged += delegate { _view.UpdateHp(_model.GetMaxHP.Value, _model.hp); };
        }
        
        public override void Spawned()
        {
            Debug.Log("Spawned");
            RoomManager.Instance.Rpc_LoadDone(Runner.LocalPlayer);
            SetHPbar(PlayerRegistry.GetPlayer(Runner.LocalPlayer), _model);

            R_actors = new ActorStat[3];
            B_actors = new ActorStat[3];

            foreach (var player in PlayerRegistry.Players)
            {
                if (player.GetLayer().Equals(LayerMask.NameToLayer("RedTeam")))
                {
                    R_actors[player.TeamNumber] = player.gameObject.GetComponent<ActorStat>();
                }
                else if (player.GetLayer().Equals(LayerMask.NameToLayer("BlueTeam")))
                {
                    B_actors[player.TeamNumber] = player.gameObject.GetComponent<ActorStat>();
                }
            }
        }

        public void SetHPbar(PlayerObject local, ActorStat _model)
        {
            if (local.GetLayer().Equals(LayerMask.NameToLayer("RedTeam")))
            {
                if (local.TeamNumber == 0)
                {
                    _view._RteamhpBar1.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateR1HP(); };
                }
                else if (local.TeamNumber == 1)
                {
                    _view._RteamhpBar2.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateR2HP(); };
                }
                else if (local.TeamNumber == 2)
                {
                    _view._RteamhpBar3.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateR3HP(); };
                }
            }
            else if (local.GetLayer().Equals(LayerMask.NameToLayer("BlueTeam")))
            {
                if (local.TeamNumber == 0)
                {
                    _view._BteamhpBar1.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateB1HP(); };
                }
                else if (local.TeamNumber == 1)
                {
                    _view._BteamhpBar2.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateB2HP(); };
                }
                else if (local.TeamNumber == 2)
                {
                    _view._BteamhpBar3.color = new Color(0, 1, 0);
                    _model.HpStatChanged += delegate { RPC_UpdateB3HP(); };
                }
            }
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateR1HP()
        {
            Debug.Log("R1");
            _view._RteamhpBar1.fillAmount = R_actors[0].hp / R_actors[0].SetMaxHP;
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateR2HP()
        {
            Debug.Log("R2");
            _view._RteamhpBar2.fillAmount = R_actors[1].hp / R_actors[1].SetMaxHP;
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateR3HP()
        {
            Debug.Log("R3");
            _view._RteamhpBar3.fillAmount = R_actors[2].hp / R_actors[2].SetMaxHP;
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateB1HP()
        {
            Debug.Log("B1");
            _view._BteamhpBar1.fillAmount = B_actors[0].hp / B_actors[0].SetMaxHP;
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateB2HP()
        {
            Debug.Log("B2");
            _view._BteamhpBar2.fillAmount = B_actors[1].hp / B_actors[1].SetMaxHP;
        }

        [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
        public void RPC_UpdateB3HP()
        {
            Debug.Log("B3");
            _view._BteamhpBar3.fillAmount = B_actors[2].hp / B_actors[2].SetMaxHP;
        }
    }
}