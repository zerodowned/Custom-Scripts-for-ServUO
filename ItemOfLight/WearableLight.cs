using System;
using Server.Mobiles;

namespace Server.Items
{
	public class WearableLight : BaseArmor 
    {
		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		
        [Constructable]
        public WearableLight() : base( 0x1647 )
        {
			Light = LightType.Circle225;
			Layer = Layer.Unused_xF;
            Movable = true;
			Visible = true;
        }
		
		public override bool OnDragLift( Mobile from )
		{
			return false;
		}

        public WearableLight(Serial serial) : base(serial)
        {
        }

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