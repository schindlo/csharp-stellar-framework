          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef opaque UpgradeType<128>;
//  ===========================================================================
public class UpgradeType {
  public byte[] InnerValue { get; set; } = default(byte[]);
            
  public UpgradeType() { }
  public UpgradeType(byte[] UpgradeType)
  {
    InnerValue = UpgradeType;
  }
  public static void Encode(IByteWriter stream, UpgradeType  encodedUpgradeType) {
  int UpgradeTypeSize = encodedUpgradeType.InnerValue.Length;
  XdrEncoding.EncodeInt32(UpgradeTypeSize, stream);
  XdrEncoding.WriteFixOpaque(stream, (uint)UpgradeTypeSize, encodedUpgradeType.InnerValue);
  }
  public static UpgradeType Decode(IByteReader stream) {
    UpgradeType decodedUpgradeType = new UpgradeType();
  int UpgradeTypesize = XdrEncoding.DecodeInt32(stream);
  decodedUpgradeType.InnerValue = XdrEncoding.ReadFixOpaque(stream, (uint)UpgradeTypesize);
    return decodedUpgradeType;
  }
}
}
