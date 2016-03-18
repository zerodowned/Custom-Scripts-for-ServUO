// item that decodes a treasure map 
// attaches xml using AddProperties to treasure map to display the location of the treasure chest within the treasure map hover-over props

using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Engines.XmlSpawner2;
using Server.Items;

namespace Server.Engines.XmlSpawner2
{ 
   
   public class MapDecoderXML : XmlAttachment
   {

      public override void AddProperties(ObjectPropertyList list) 
  		{ 
  		  if (AttachedTo != null) 
   			{ 
   				// new property
   			} 
  
   		} 
   		
   		[Attachable]
      public AddOnEditor_Att() {}
		
  		public override void Serialize( GenericWriter writer )
  		{
              base.Serialize( writer );
              writer.Write( (int) 0 ); // version
  		}
		
  		public override void Deserialize( GenericReader reader )
      {
          base.Deserialize( reader );
          int version = reader.ReadInt();
  		}

   }
}
