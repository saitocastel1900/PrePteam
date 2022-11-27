using UniRx;

public enum STEP
{
    /// <summary>
    /// �ω��҂����
    /// </summary>
    NONE=-1,
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
}

[System.Serializable]
public class StepReactiveProperty : ReactiveProperty<STEP>
{
    //�R���X�g���N�^
    public StepReactiveProperty() { }
    public StepReactiveProperty(STEP initialValue) : base(initialValue) { }
}