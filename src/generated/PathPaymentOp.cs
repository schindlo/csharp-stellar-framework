          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  struct PathPaymentOp
//  {
//      Asset sendAsset; // asset we pay with
//      int64 sendMax;   // the maximum amount of sendAsset to
//                       // send (excluding fees).
//                       // The operation will fail if can't be met
//  
//      AccountID destination; // recipient of the payment
//      Asset destAsset;       // what they end up with
//      int64 destAmount;      // amount they end up with
//  
//      Asset path<5>; // additional hops it must go through to get there
//  };
//  ===========================================================================
public class PathPaymentOp {
  public PathPaymentOp () {}
  public Asset SendAsset { get; set; }
  public Int64 SendMax { get; set; }
  public AccountID Destination { get; set; }
  public Asset DestAsset { get; set; }
  public Int64 DestAmount { get; set; }
  public Asset[] Path { get; set; }
  public static void Encode(IByteWriter stream, PathPaymentOp encodedPathPaymentOp) {
    Asset.Encode(stream, encodedPathPaymentOp.SendAsset);
    Int64.Encode(stream, encodedPathPaymentOp.SendMax);
    AccountID.Encode(stream, encodedPathPaymentOp.Destination);
    Asset.Encode(stream, encodedPathPaymentOp.DestAsset);
    Int64.Encode(stream, encodedPathPaymentOp.DestAmount);
    int pathsize = encodedPathPaymentOp.Path.Length;
    XdrEncoding.EncodeInt32(pathsize, stream);
    for (int i = 0; i < pathsize; i++) {
      Asset.Encode(stream, encodedPathPaymentOp.Path[i]);
    }
  }
  public static PathPaymentOp Decode(IByteReader stream) {
    PathPaymentOp decodedPathPaymentOp = new PathPaymentOp();
    decodedPathPaymentOp.SendAsset = Asset.Decode(stream);
    decodedPathPaymentOp.SendMax = Int64.Decode(stream);
    decodedPathPaymentOp.Destination = AccountID.Decode(stream);
    decodedPathPaymentOp.DestAsset = Asset.Decode(stream);
    decodedPathPaymentOp.DestAmount = Int64.Decode(stream);
    int pathsize = XdrEncoding.DecodeInt32(stream);
    decodedPathPaymentOp.Path = new Asset[pathsize];
    for (int i = 0; i < pathsize; i++) {
      decodedPathPaymentOp.Path[i] = Asset.Decode(stream);
    }
    return decodedPathPaymentOp;
  }
}
}
