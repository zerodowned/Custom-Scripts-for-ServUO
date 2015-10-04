using System;

namespace Server.Items
{
    public class RobeOfLight : BaseClothing_ItemOfLight
    {
		[Constructable]
        public RobeOfLight() : base( 0x1F03, Layer.OuterTorso )
        {
			Name = "Robe of Light";
			//ItemID = 0x1F03;
			//Layer = Layer.OuterTorso;
			Weight = 1.0;
        }
		
		

        public RobeOfLight(Serial serial) : base(serial)
        {
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