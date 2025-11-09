using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace WeaponPacks;

/*
public class  : WeaponTemplate
{
    public override string WeaponPack => "Pack";
    public override int SandboxIndex => 0;
    public override Rarity WeaponRarity => Rarity.;
    public override string WeaponName => "";
    public override string CodeName => "";
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;



        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

public class  : AbilityTemplate
{
    public override string WeaponPack => "Pack";
    public override int SandboxIndex => 0;
    public override Rarity AbilityRarity => Rarity.;
    public override string AbilityName => "";
    public override string CodeName => "";
    public override SpriteReference Icon => CreateSpriteReference("");
    public override int upgradeCost => 0;
    public override string upgradeName => "";
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {

    }
}
*/
