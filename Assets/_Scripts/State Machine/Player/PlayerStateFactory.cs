using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory : BaseStateFactory {
    public override void Init(Player player){
        AddState("idle",new PlayerIdleState());
        AddState("run",new PlayerRunState());
        AddState("jump",new PlayerJumpState());
        @default = states["idle"];
        AddTransition(
            from:
                states["idle"],
            // to:
                states["run"],
                states["jump"]
        );
        AddTransition(
            from:
                states["run"],
            // to:
                states["idle"],
                states["jump"]
        );
        AddTransition(
            from:
                states["jump"],
            // to:
                states["idle"],
                states["run"]
        );
        base.Init(player);
    }
}
