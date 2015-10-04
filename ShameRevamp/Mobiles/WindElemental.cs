using System;
using Server;
using Server.Items;


namespace Server.Mobiles
{
 [CorpseName( "a wind elemental corpse" )]
 public class WindElemental : BaseCreature
 {
  [Constructable]
  public WindElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
  {
   Name = "a wind elemental";
   Body = 131;
   BaseSoundID = 768;
   SetStr( 376, 403 );
   SetDex( 183, 230 );
   SetInt( 164, 213 );
   SetHits( 2500, 2600 );
   SetDamage( 15, 17 );
   SetDamageType( ResistanceType.Physical, 20 );
   SetDamageType( ResistanceType.Cold, 40 );
   SetDamageType( ResistanceType.Energy, 40 );
   SetResistance( ResistanceType.Physical, 65, 75 );
   SetResistance( ResistanceType.Fire, 55, 65 );
   SetResistance( ResistanceType.Cold, 55, 65 );
   SetResistance( ResistanceType.Poison, 100 );
   SetResistance( ResistanceType.Energy, 60, 75 );
   SetSkill( SkillName.EvalInt, 60.1, 75.0 );
   SetSkill( SkillName.Magery, 60.1, 75.0 );
   SetSkill( SkillName.MagicResist, 60.1, 75.0 );
   SetSkill( SkillName.Tactics, 60.1, 75.0 );
   SetSkill( SkillName.Wrestling, 60.1, 80.0 );
   Fame = 4500;
   Karma = -4500;
   VirtualArmor = 56;
  }
  public override void GenerateLoot()
  {
   AddLoot( LootPack.Rich );
   AddLoot( LootPack.Average );
   AddLoot( LootPack.Gems );
   if ( 0.02 > Utility.RandomDouble() )
   {
    switch ( Utility.Random( 5 ) )
    {
     case 0: PackItem( new DaemonArms() ); break;
     case 1: PackItem( new DaemonChest() ); break;
     case 2: PackItem( new DaemonGloves() ); break;
     case 3: PackItem( new DaemonLegs() ); break;
     case 4: PackItem( new DaemonHelm() ); break;
    }
   }
  }
  public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 5; } }
  public WindElemental ( Serial serial ) : base( serial )
  {
  }
  public override void Serialize( GenericWriter writer )
  {
   base.Serialize( writer );
   writer.Write( (int) 0 );
  }
  public override void Deserialize( GenericReader reader )
  {
   base.Deserialize( reader );
   int version = reader.ReadInt();
  }
 }
}