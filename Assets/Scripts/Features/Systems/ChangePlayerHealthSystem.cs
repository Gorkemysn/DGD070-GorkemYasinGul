using UnityEngine;
using Entitas;

public class ChangePlayerHealthSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _playerGroup;

    public ChangePlayerHealthSystem(Contexts contexts)
    {
        _playerGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var entity in _playerGroup.GetEntities())
            {
                entity.isPlayerDamaged = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (var entity in _playerGroup.GetEntities())
            {
                entity.isPlayerHealed = true;
            }
        }
    }
}
