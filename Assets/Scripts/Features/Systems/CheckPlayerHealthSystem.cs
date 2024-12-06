using UnityEngine;
using Entitas;

public class CheckPlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerGroup;

    public CheckPlayerHealthSystem(Contexts contexts)
    {
        _playerGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        foreach (var entity in _playerGroup.GetEntities())
        {
            // PlayerDamaged durumunu kontrol et
            if (entity.HasComponent(GameComponentsLookup.PlayerDamaged))
            {
                entity.ReplacePlayerHealth(Mathf.Max(entity.playerHealth.value - 10, 0));
                entity.RemoveComponent(GameComponentsLookup.PlayerDamaged);
            }

            // PlayerHealed durumunu kontrol et
            if (entity.HasComponent(GameComponentsLookup.PlayerHealed))
            {
                entity.ReplacePlayerHealth(Mathf.Min(entity.playerHealth.value + 10, 100));
                entity.RemoveComponent(GameComponentsLookup.PlayerHealed);
            }
        }
    }
}
