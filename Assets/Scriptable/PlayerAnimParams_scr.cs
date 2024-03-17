
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerAnimParams",menuName ="ScriptableObjects/PlayerAnimParams",order =0)]
public class PlayerAnimParams_scr : ScriptableObject
{
    public enum ParamName
    {
        IsAttack,IsJumping,IsOnLand,IsHit
    }
    public string IsAttack=ParamName.IsAttack.ToString();
    public string IsJumping=ParamName.IsJumping.ToString();
    public string IsOnland=ParamName.IsOnLand.ToString();
    public string IsHit=ParamName.IsHit.ToString();
    public float get_hit_time = 0.2f;
    public float attack_time = 0.2f;

}
