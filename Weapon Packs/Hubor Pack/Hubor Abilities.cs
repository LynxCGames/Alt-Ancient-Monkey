using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace WeaponPacks;

// #### Common ####

// #### Rare ####

public class TimeManipulation : AbilityTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Time Manipulation";
    public override string CodeName => "TimeManipulation";
    public override Sprite CustomIcon => GetSprite("TimeManipulationIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override int upgradeCost => 32000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("DartlingGunner-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;

        var windModel = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel.name = "rewind";
        windModel.affectMoab = false;
        windModel.chance = 100;
        windModel.distanceMin = 360;
        windModel.distanceMax = 360;
        windModel.speedMultiplier = 0.3f;
        windModel.distanceScaleForTags = 0.0f;
        windModel.distanceScaleForTagsTags = "Bad";

        var attackModel = Game.instance.model.GetTowerFromId("MonkeySub-300").GetAttackModel(1).Duplicate();
        attackModel.range = 99999;
        attackModel.weapons[0].Rate = 20;
        attackModel.weapons[0].projectile.pierce = 999999;
        attackModel.weapons[0].projectile.maxPierce = 999999;
        attackModel.weapons[0].projectile.radius = 9999;
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        attackModel.weapons[0].projectile.ignoreBlockers = true;
        attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        attackModel.weapons[0].projectile.AddBehavior(windModel);

        AttackModel[] attackArray = { attackModel };

        var createSoundModel = Game.instance.model.GetTowerFromId("Psi 3").GetAbility().GetBehavior<CreateSoundOnAbilityModel>().Duplicate();
        var createEffectModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateEffectOnAbilityModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<TimeBomb>();
        createEffectModel.effectModel.scale *= 4;

        ab.displayName = "timerewind";
        ab.cooldown = 50;
        ab.icon = GetSpriteReference("TimeManipulationAA");
        ab.RemoveBehavior<CreateSoundOnAbilityModel>();
        ab.GetBehavior<ActivateAttackModel>().Lifespan = 0.1f;
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.AddBehavior(createSoundModel);
        ab.AddBehavior(createEffectModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("Mermonkey-040").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedChronomancy";

        var windModel = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel.name = "rewindturbo";
        windModel.affectMoab = true;
        windModel.chance = 100;
        windModel.distanceMin = 999999;
        windModel.distanceMax = 999999;
        windModel.speedMultiplier = 0.7f;
        windModel.distanceScaleForTags = 100f;
        windModel.distanceScaleForTagsTags = "Bad";

        var attackModel = Game.instance.model.GetTowerFromId("MonkeySub-300").GetAttackModel(1).Duplicate();
        attackModel.range = 99999;
        attackModel.weapons[0].Rate = 20;
        attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 25, 0.0f, 360f, null, false, false);
        attackModel.weapons[0].projectile.pierce = 999999;
        attackModel.weapons[0].projectile.maxPierce = 999999;
        attackModel.weapons[0].projectile.radius = 99999;
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        attackModel.weapons[0].projectile.ignoreBlockers = true;
        attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        attackModel.weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().cleanseRegen = true;
        attackModel.weapons[0].projectile.AddBehavior(windModel);

        AttackModel[] attackArray = { attackModel };

        var createSoundModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateSoundOnAbilityModel>().Duplicate();
        createSoundModel.sound.assetId = new AudioClipReference() { guidRef = "cb7486aceab27c441b53463acb9105d8" };

        var createEffectModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateEffectOnAbilityModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<TimeBomb>();
        createEffectModel.effectModel.scale *= 10;

        ab.displayName = "chronomancy";
        ab.cooldown = 150;
        ab.icon = GetSpriteReference("ChronomancyAA");
        ab.RemoveBehavior<CreateSoundOnAbilityModel>();
        ab.GetBehavior<ActivateAttackModel>().Lifespan = 0.1f;
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.AddBehavior(createSoundModel);
        ab.AddBehavior(createEffectModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class Flailnado : AbilityTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Flailnado";
    public override string CodeName => "Flailnado";
    public override Sprite CustomIcon => GetSprite("FlailnadoAAIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("DartlingGunner-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;

        var turboModel = Game.instance.model.GetTowerFromId("MortarMonkey-040").GetAbility().GetBehavior<TurboModel>().Duplicate();
        turboModel.Lifespan = 5;
        turboModel.multiplier = 0.6f;

        var tranceModel = Game.instance.model.GetTowerFromId("Mermonkey-003").GetBehavior<LinkProjectileRadiusToTowerRangeModel>().projectileModel.GetBehavior<TranceBloonModel>().Duplicate();
        tranceModel.duration = 5;
        tranceModel.orbitRadius -= 5;

        var attackModel = Game.instance.model.GetTowerFromId("MonkeySub-300").GetAttackModel(1).Duplicate();
        attackModel.range = 999999;
        attackModel.attackThroughWalls = true;
        attackModel.fireWithoutTarget = true;
        attackModel.RemoveBehavior<RotateToTargetModel>();
        attackModel.weapons[0].Rate = 30;
        attackModel.weapons[0].fireWithoutTarget = true;
        attackModel.weapons[0].projectile.ApplyDisplay<Tornado>();
        attackModel.weapons[0].projectile.scale *= 2;
        attackModel.weapons[0].projectile.pierce = 9999;
        attackModel.weapons[0].projectile.maxPierce = 9999;
        attackModel.weapons[0].projectile.ignoreBlockers = true;
        attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        attackModel.weapons[0].projectile.GetBehavior<AgeModel>().Lifespan = 5;
        attackModel.weapons[0].projectile.AddBehavior(tranceModel);
        attackModel.weapons[0].projectile.AddBehavior(new RotateModel("", 180f));
        attackModel.weapons[0].projectile.SetHitCamo(true);
        attackModel.weapons[0].projectile.AddFilter(new FilterOutTagModel("bfb", "Bfb", null));
        attackModel.weapons[0].projectile.AddFilter(new FilterOutTagModel("zomg", "Zomg", null));

        AttackModel[] attackArray = { attackModel };

        var createSoundModel = Game.instance.model.GetTowerFromId("DartMonkey-040").GetAbility().GetBehavior<CreateSoundOnAbilityModel>().Duplicate();

        ab.displayName = "flailnado";
        ab.cooldown = 80;
        ab.icon = GetSpriteReference("FlailnadoAAIcon");
        ab.GetBehavior<ActivateAttackModel>().Lifespan = 0.5f;
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.GetBehavior<CreateSoundOnAbilityModel>().sound = createSoundModel.sound;
        ab.AddBehavior(turboModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);     
    }
    public override void Upgrade(Tower tower) { }
}
public class Bloonsday : AbilityTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Bloonsday Device";
    public override string CodeName => "Bloonsday";
    public override Sprite CustomIcon => GetSprite("BloonsdayIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("ObynGreenfoot 3").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;

        var attackModel = Game.instance.model.GetTowerFromId("Etienne 10").GetAttackModel(1).Duplicate();
        attackModel.range = 9999;
        attackModel.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        attackModel.weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<BloonsdayProjectile>().Duplicate(), 0.0f, true, false, false, true, false));

        AttackModel[] attackArray = { attackModel };

        var createSoundModel = Game.instance.model.GetTowerFromId("Psi 10").GetAbility(1).GetBehavior<CreateSoundOnAbilityModel>().Duplicate();

        ab.displayName = "Bloonsday";
        ab.cooldown = 40;
        ab.icon = GetSpriteReference("BloonsdayIcon");
        ab.maxActivationsPerRound = 999999;
        ab.canActivateBetweenRounds = true;
        ab.RemoveBehavior<CreateSoundOnAbilityModel>();
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.AddBehavior(createSoundModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class BloonsdayProjectile : ModSubTower
{
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.HeliPilot;
    public override int Cost => 0;
    public override string DisplayName => "ignorethis";
    public override string Name => "BloonsdayBeam";
    public override string Description => "A";
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ignoreTowerForSelection = true;
        towerModel.isSubTower = true;
        towerModel.radius = Game.instance.model.GetTower(TowerType.Piranha, 0, 0, 0).radius;
        towerModel.display = new PrefabReference() { guidRef = "" };
        towerModel.RemoveBehavior<CreateSoundOnTowerPlaceModel>();
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 9, false, false));
        towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));

        var movement = towerModel.GetBehavior<AirUnitModel>().GetBehavior<HeliMovementModel>();
        movement.rotationSpeed = 0.0f;
        movement.tiltAngle = 0.0f;

        var attackModel = Game.instance.model.GetTowerFromId("MonkeyAce-030").GetAttackModel(1).Duplicate();
        attackModel.weapons[0].Rate = 0.55f;
        attackModel.weapons[0].RemoveBehavior<CheckAirUnitOverTrackModel>();
        //attackModel.weapons[0].GetBehavior<DisplayModel>().positionOffset = new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0.0f, 0.0f, 5f);
        attackModel.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        attackModel.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustFractionModel>();
        attackModel.weapons[0].projectile.GetBehavior<FallToGroundModel>().timeToTake = 0.2f;

        var projectile = attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile;
        projectile.radius = 35;
        projectile.pierce = 20;
        projectile.collisionPasses = new int[] { -1, 0 };
        projectile.GetDamageModel().damage = 7;
        projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.RemoveBehavior<CreateSoundOnProjectileExpireModel>();
        projectile.AddBehavior(new DamageModifierForTagModel("Moabsb", "Moabs", 3f, 1f, false, false, false));

        towerModel.GetAttackModel().range = 1;
        towerModel.GetAttackModel().RemoveBehavior<RotateToTargetAirUnitModel>();
        towerModel.GetAttackModel().weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;

        towerModel.AddBehavior(attackModel);
        towerModel.GetBehavior<AirUnitModel>().display = CreatePrefabReference<BloonsdayBeam>();
    }
}

// #### Legendary ####

// #### Upgraded ####

public class Chronomancy : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HuborPack";
    public override string AbilityName => "Chronomancy";
    public override Sprite CustomIcon => GetSprite("ChronomancyIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Mermonkey-040").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedChronomancy";

        var windModel = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel.name = "rewindturbo";
        windModel.affectMoab = true;
        windModel.chance = 100;
        windModel.distanceMin = 999999;
        windModel.distanceMax = 999999;
        windModel.speedMultiplier = 0.7f;
        windModel.distanceScaleForTags = 100f;
        windModel.distanceScaleForTagsTags = "Bad";

        var attackModel = Game.instance.model.GetTowerFromId("MonkeySub-300").GetAttackModel(1).Duplicate();
        attackModel.range = 99999;
        attackModel.weapons[0].Rate = 20;
        attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 25, 0.0f, 360f, null, false, false);
        attackModel.weapons[0].projectile.pierce = 999999;
        attackModel.weapons[0].projectile.maxPierce = 999999;
        attackModel.weapons[0].projectile.radius = 99999;
        attackModel.weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        attackModel.weapons[0].projectile.ignoreBlockers = true;
        attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        attackModel.weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().cleanseRegen = true;
        attackModel.weapons[0].projectile.AddBehavior(windModel);

        AttackModel[] attackArray = { attackModel };

        var createSoundModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateSoundOnAbilityModel>().Duplicate();
        createSoundModel.sound.assetId = new AudioClipReference() { guidRef = "cb7486aceab27c441b53463acb9105d8" };

        var createEffectModel = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().GetBehavior<CreateEffectOnAbilityModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<TimeBomb>();
        createEffectModel.effectModel.scale *= 10;

        ab.displayName = "chronomancy";
        ab.cooldown = 150;
        ab.icon = GetSpriteReference("ChronomancyAA");
        ab.RemoveBehavior<CreateSoundOnAbilityModel>();
        ab.GetBehavior<ActivateAttackModel>().Lifespan = 0.1f;
        ab.GetBehavior<ActivateAttackModel>().attacks = attackArray;
        ab.AddBehavior(createSoundModel);
        ab.AddBehavior(createEffectModel);

        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// Display
public class TimeBomb : ModDisplay
{
    public override string BaseDisplay => "f73f2e12a1827cd40b99cf65312a3a2f";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Renderer genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
            genericRenderer.material.color = new Color(1f, 0.9372549f, 0.396078438f);
    }
}

public class BloonsdayBeam : ModCustomDisplay
{
    public override string AssetBundleName => "gizmo";
    public override string PrefabName => "bloonsday";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 87;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.0f, 0.9411765f, 1f));
        }
    }
}

public class Tornado : ModDisplay
{
    public override string BaseDisplay => "efc680bebf80d1e4584e9548ddfbff34";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[1].GetComponent<ParticleSystem>().startSize /= 30f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[1].GetComponent<ParticleSystem>().maxParticles = 0;
    }
}