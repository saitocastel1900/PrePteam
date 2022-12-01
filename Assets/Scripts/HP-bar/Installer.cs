using Gauge;
using Zenject;

public class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GaugePresenter>().FromNew().AsCached().NonLazy();
        Container.Bind<GaugeModel>().FromNew().AsCached();
    }
}