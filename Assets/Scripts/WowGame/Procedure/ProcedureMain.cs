using GameFramework.Fsm;
using UnityEngine;

namespace WowGame
{
    public class ProcedureMain : ProcedureBase
    {
        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("Enter_" + GetType().Name);
        }
    }
}