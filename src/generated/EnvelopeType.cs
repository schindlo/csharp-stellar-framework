          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  enum EnvelopeType
//  {
//      ENVELOPE_TYPE_SCP = 1,
//      ENVELOPE_TYPE_TX = 2,
//      ENVELOPE_TYPE_AUTH = 3
//  };
//  ===========================================================================
public class EnvelopeType {
  public enum EnvelopeTypeEnum
  {
  ENVELOPE_TYPE_SCP = 1,
  ENVELOPE_TYPE_TX = 2,
  ENVELOPE_TYPE_AUTH = 3,
  }

  public EnvelopeTypeEnum InnerValue { get; set; } = default(EnvelopeTypeEnum);

  public static EnvelopeType Create(EnvelopeTypeEnum v)
  {
    return new EnvelopeType {
      InnerValue = v
    };
  }

  public static EnvelopeType Decode(IByteReader stream) {
    int value = XdrEncoding.DecodeInt32(stream);
    switch (value) {
      case 1: return Create(EnvelopeTypeEnum.ENVELOPE_TYPE_SCP);
      case 2: return Create(EnvelopeTypeEnum.ENVELOPE_TYPE_TX);
      case 3: return Create(EnvelopeTypeEnum.ENVELOPE_TYPE_AUTH);
			default:
			  throw new System.Exception("Unknown enum value: " + value);
		  }
		}

		public static void Encode(IByteWriter stream, EnvelopeType value) {
		  XdrEncoding.EncodeInt32((int)value.InnerValue, stream);
		}
}
}
