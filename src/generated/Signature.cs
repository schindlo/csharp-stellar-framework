          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef opaque Signature<64>;
//  ===========================================================================
public class Signature {
  public byte[] InnerValue { get; set; } = default(byte[]);
            
  public Signature() { }
  public Signature(byte[] Signature)
  {
    InnerValue = Signature;
  }
  public static void Encode(IByteWriter stream, Signature  encodedSignature) {
  int SignatureSize = encodedSignature.InnerValue.Length;
  XdrEncoding.EncodeInt32(SignatureSize, stream);
  XdrEncoding.WriteFixOpaque(stream, (uint)SignatureSize, encodedSignature.InnerValue);
  }
  public static Signature Decode(IByteReader stream) {
    Signature decodedSignature = new Signature();
  int Signaturesize = XdrEncoding.DecodeInt32(stream);
  decodedSignature.InnerValue = XdrEncoding.ReadFixOpaque(stream, (uint)Signaturesize);
    return decodedSignature;
  }
}
}
