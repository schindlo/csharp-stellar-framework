          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef string string64<64>;
//  ===========================================================================
public class String64 {
  public string InnerValue { get; set; } = default(string);
            
  public String64() { }
  public String64(string String64)
  {
    InnerValue = String64;
  }
  public static void Encode(IByteWriter stream, String64  encodedString64) {
  XdrEncoding.WriteString(stream, encodedString64.InnerValue);
  }
  public static String64 Decode(IByteReader stream) {
    String64 decodedString64 = new String64();
  decodedString64.InnerValue = XdrEncoding.ReadString(stream);
    return decodedString64;
  }
}
}
