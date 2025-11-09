using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace AncientMonkey.Menus;

public abstract class ChallengeTemplate : ModContent 
{
    public override void Register() { }
    public abstract string ChallengeName { get; }
    public abstract int Order {  get; }
    public abstract string Background { get; }
    public abstract string Icon { get; }
    public abstract string Description { get; }
    public abstract void Edit();
    public bool isSelected = false;
}

public abstract class PackTemplate : ModContent
{
    public override void Register() { }
    public abstract string PackName { get; }
    public abstract string WeaponPack { get; }
    public abstract int Order { get; }
    public abstract int[/*commonWpn, rareWpn, epicWpn, legendaryWpn, mythicWpn, commonAb, rareAb, epicAb, legendaryAb*/] Upgrades { get; }
    public abstract void Edit();
    public bool isSelected = false;
}

public abstract class ArtifactTemplate : ModContent
{
    public override void Register() { }
    public abstract string ArtifactName { get; }
    public abstract string Icon { get; }
    public abstract string ArtifactDescription { get; }
    public abstract void EditModel(AttackModel model);
    public bool enabled;
}