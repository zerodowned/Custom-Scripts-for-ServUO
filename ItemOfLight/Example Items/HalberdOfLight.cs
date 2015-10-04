using System;

namespace Server.Items
{
    public class HalberdOfLight : BaseWeapon_ItemOfLight
    {
        [Constructable]
        public HalberdOfLight() : base()
        {
			Layer = Layer.TwoHanded;
			ItemID = 0x143E;
            this.Weight = 16.0;
        }

        public HalberdOfLight(Serial serial)
            : base(serial)
        {
        }

        public override int InitMinHits
        {
            get
            {
                return 31;
            }
        }
        public override int InitMaxHits
        {
            get
            {
                return 80;
            }
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