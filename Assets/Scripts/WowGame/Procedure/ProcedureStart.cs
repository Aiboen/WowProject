using GameFramework.Fsm;
using UnityEngine;

namespace WowGame
{
    public class ProcedureStart : ProcedureBase
    {
        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("Enter" + GetType().Name);
        }

        protected override void OnUpdate(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ChangeState<ProcedureMain>(procedureOwner);
            }
        }
    }
}