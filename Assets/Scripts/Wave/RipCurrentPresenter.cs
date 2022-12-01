using System.Reflection;
using Commons.Utility;
using Player;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentPresenter : MonoBehaviour , IPushable
    {
        [SerializeField] private RipCurrentModel _model;
        [SerializeField] private RipCurrentView _view;

        private void Start()
        {
            Initialized();
            Bind();
        }

        public void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
        }

        public void Bind()
        {
            //Where()
            //_model.PosProp.DistinctUntilChanged().Subscribe().AddTo(this);
        }

        //TODO:流れる方向を変更できるようにする
        public void Push(GameObject game)
        {
//            _model.UpdatePos(game.transform.position);
            
            //とりあえずの移動
            game.GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0));
            DebugUtility.Log("離岸流","当たり判定のサイズを設定",this,MethodBase.GetCurrentMethod());
        }
    }
}