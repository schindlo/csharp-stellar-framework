          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef unsigned hyper uint64;
//  ===========================================================================
public class Uint64 {
  public ulong InnerValue { get; set; } = default(ulong);
            
  public Uint64() { }
  public Uint64(ulong Uint64)
  {
    InnerValue = Uint64;
  }
  public static void Encode(IByteWriter stream, Uint64  encodedUint64) {
  XdrEncoding.EncodeUInt64(encodedUint64.InnerValue, stream);
  }
  public static Uint64 Decode(IByteReader stream) {
    Uint64 decodedUint64 = new Uint64();
  decodedUint64.InnerValue = XdrEncoding.DecodeUInt64(stream);
    return decodedUint64;
  }
}
}
