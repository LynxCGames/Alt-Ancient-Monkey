using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Audio;
using System.Collections.Generic;

namespace WeaponPacks;

// #### Common ####

// #### Rare ####

// #### Epic ####

// #### Legendary ####

public class MistTempest : AbilityTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Mist Tempest";
    public override string CodeName => "MistTempest";
    public override Sprite CustomIcon => GetSprite("MistTempest-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override int upgradeCost => 0;
    public override string upgradeName => "";
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("BombShooter-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.lifespan = 999999;
        ageModel.rounds = 1;

        var projectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.display = new PrefabReference() { guidRef = "" };
        projectile.RemoveBehavior<CreateSoundOnProjectileCollisionModel>();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 3;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("moaby", "Moabs", 3f, 1f, false, false, false));
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.ApplyDisplay<VampRip>();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale = 1.25f;

        var bat = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        bat.ApplyDisplay<BigBat>();
        bat.pierce = 999999;
        bat.maxPierce = 999999;
        bat.ignoreBlockers = true;
        bat.canCollisionBeBlockedByMapLos = false;
        bat.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        bat.RemoveFilter<FilterAllExceptTargetModel>();
        bat.GetBehavior<TravelStraitModel>().Speed /= 4;
        bat.GetBehavior<TravelStraitModel>().Lifespan = 999;
        bat.AddBehavior(ageModel);
        bat.AddBehavior(new TrackTargetModel("TrackTargetModel_", 2000f, true, false, 180f, true, 360f, false, false, false));
        bat.AddBehavior(new CantBeReflectedModel("c"));
        bat.AddBehavior(new DontDestroyOnContinueModel("u"));
        bat.AddBehavior(new CreateProjectileOnIntervalModel
            ("Dart", projectile, new InstantDamageEmissionModel("sinstantEmission", null), 10, true, 50f, TargetType.Strong, false, false, false, null));
        bat.AddBehavior(new DamageModel("", 2f, 2f, false, false, false, (BloonProperties)8, (BloonProperties)8, false, false));
        bat.AddBehavior(new ClearHitBloonsModel("", 0.2f));

        var createExhaustModel = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel.projectile = bat;

        var attackModel = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
        attackModel.range = 9999;
        attackModel.RemoveBehavior<RotateToTargetModel>();
        attackModel.weapons[0].Rate = 100;
        attackModel.weapons[0].fireWithoutTarget = true;
        attackModel.weapons[0].AddBehavior(new WeaponRateMinModel("min", 100f));
        attackModel.weapons[0].projectile.ApplyDisplay<Coffin>();
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 1E-07f;
        attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 1;
        attackModel.weapons[0].projectile.AddBehavior(createExhaustModel);

        AttackModel[] attackArray = { attackModel };

        var createEffectModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateEffectOnAbilityModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<Ability3FX>();

        ab.displayName = "Mist Tempest";
        ab.cooldown = 120;
        ab.icon = GetSpriteReference("MistTempest-Icon");
        ab.GetBehavior<CreateSoundOnAbilityModel>().sound = new SoundModel("Ability3", GetAudioClipReference("Ability3"));
        ab.GetBehavior<ActivateAttackModel>().Lifespan = 0.5f;
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.AddBehavior(createEffectModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Upgraded ####

// Display

public class BigBat : ModCustomDisplay
{
    public override string AssetBundleName => "vamp";
    public override string PrefabName => "bigbat";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 50;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.239215687f, 0.07058824f, 0.09411765f));
        }
    }
}
public class Coffin : ModCustomDisplay
{
    public override string AssetBundleName => "vamp";
    public override string PrefabName => "trumna";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 80;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.239215687f, 0.07058824f, 0.09411765f));
        }
    }
}
public class Ability3FX : ModDisplay
{
    public Dictionary<string, Color> psColor = new Dictionary<string, Color>()
    {
      { "RadialBlast", Color.red },
      { "PowerPulse", Color.red },
      { "SolidRadialRings", Color.red }
    };
    public override string BaseDisplay => "373bb6317fec0364b89c6cb1db619672";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (ParticleSystem componentsInChild in node.GetComponentsInChildren<ParticleSystem>())
        {
            if (this.psColor.ContainsKey(((Object)componentsInChild.gameObject).name))
                componentsInChild.startColor = this.psColor[((Object)componentsInChild.gameObject).name];
        }
    }
}