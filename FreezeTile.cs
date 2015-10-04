using System;
using Server.Mobiles;

namespace Server.Items
{
	public class FreezeTile : Item
	{

		[Constructable]
        public FreezeTile() : base( 1313 )
        {}

        public FreezeTile(Serial serial) : base(serial)
        {
        }
		
		 public override bool OnMoveOver(Mobile m)
        {
            m.Paralyze( TimeSpan.FromSeconds( 5.0 ) );

            return true;
        }
		
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
			
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
			
        }
	}
}