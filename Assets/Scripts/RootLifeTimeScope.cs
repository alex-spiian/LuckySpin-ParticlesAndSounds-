using System.Collections;
using System.Collections.Generic;
using Hero;
using Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifeTimeScope : LifetimeScope
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private HeroesSpawner _heroesSpawner;
    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<PlayerController>(Lifetime.Singleton);

        builder.RegisterInstance(_playerConfig);
        builder.RegisterInstance(_heroesSpawner);
    }
}
