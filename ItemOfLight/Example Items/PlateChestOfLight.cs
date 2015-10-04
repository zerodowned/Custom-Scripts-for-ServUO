using System;

namespace Server.Items
{
    [FlipableAttribute(0x1415, 0x1416)]
    public class PlateChestOfLight : BaseArmor_ItemOfLight
    {
        [Constructable]
        public PlateChestOfLight() : base()
        {
			ItemID = 0x1415;
            this.Weight = 10.0;
        }

        public PlateChestOfLight(Serial serial) : base(serial)
        {
        }

       
        public override int InitMinHits
        {
            get
            {
                return 50;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 65;
            }
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