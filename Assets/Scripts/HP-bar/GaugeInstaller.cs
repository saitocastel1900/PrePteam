using Gauge;
using Player;
using Zenject;

public class GaugeInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GaugePresenter>().FromNew().AsCached().NonLazy();
        Container.Bind<PlayerModel>().FromNew().AsCached();
    }
}