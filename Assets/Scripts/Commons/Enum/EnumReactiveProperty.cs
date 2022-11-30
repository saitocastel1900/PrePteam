using UniRx;

namespace Commons.Enum
{
    /*
    public enum STEP
    {
        /// <summary>
        /// �ω��҂����
        /// </summary>
        NONE = -1,

        /// <summary>
        /// �l�̏��������E����
        /// </summary>
        SET,

        /// <summary>
        /// �Q�[���v���C��
        /// </summary>
        PLAY,

        /// <summary>
        /// �Q�[���I����
        /// </summary>
        CLEAR,
    }*/

    [System.Serializable]
    public class EnumReactiveProperty : ReactiveProperty<InGameEnum.State>
    {
        //�R���X�g���N�^
        public EnumReactiveProperty()
        {
        }

        public EnumReactiveProperty(InGameEnum.State initialValue) : base(initialValue)
        {
        }
    }
}