
using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
    [CorpseName("an OgreStatue corpse")]
    public class OgreStatue : BaseCreatureStatue
    {
		
        [Constructable]
        public OgreStatue() : base(1, ResType.Iron, Direction.Down, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "an OgreStatue";
			BaseSoundID = 427;

            SetStr(166, 195);
            SetDex(46, 65);
            SetInt(46, 70);

            SetHits(100, 117);
            SetMana(0);

            SetDamage(9, 11);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 35);
            SetResistance(ResistanceType.Fire, 15, 25);
            SetResistance(ResistanceType.Cold, 15, 25);
            SetResistance(ResistanceType.Poison, 15, 25);
            SetResistance(ResistanceType.Energy, 25);

            SetSkill(SkillName.MagicResist, 55.1, 70.0);
            SetSkill(SkillName.Tactics, 60.1, 70.0);
            SetSkill(SkillName.Wrestling, 70.1, 80.0);

            Fame = 3000;
            Karma = -3000;

            VirtualArmor = 32;

			
		}
		
		
		public override void Freeze()
		{
			base.Freeze();
			Animate( 5, 5, 1, false, false, 255 );
		}
		
		public OgreStatue(Serial serial) : base(serial)
        { }

        public override bool CanRummageCorpses { get { return true; } }
        public override int TreasureMapLevel { get { return 1; } }
        public override int Meat { get { return 2; } }
		
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
			
        }
    }	
}