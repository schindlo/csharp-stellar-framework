          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef opaque Hash[32];
//  ===========================================================================
public class Hash {
  public byte[] InnerValue { get; set; } = default(byte[]);
            
  public Hash() { }
  public Hash(byte[] Hash)
  {
    InnerValue = Hash;
  }
  public static void Encode(IByteWriter stream, Hash  encodedHash) {
  int HashSize = encodedHash.InnerValue.Length;
  XdrEncoding.WriteFixOpaque(stream, (uint)HashSize, encodedHash.InnerValue);
  }
  public static Hash Decode(IByteReader stream) {
    Hash decodedHash = new Hash();
  int Hashsize = 32;
  decodedHash.InnerValue = XdrEncoding.ReadFixOpaque(stream, (uint)Hashsize);
    return decodedHash;
  }
}
}
