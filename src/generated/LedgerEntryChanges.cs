          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef LedgerEntryChange LedgerEntryChanges<>;
//  ===========================================================================
public class LedgerEntryChanges {
  public LedgerEntryChange[] InnerValue { get; set; } = default(LedgerEntryChange[]);
            
  public LedgerEntryChanges() { }
  public LedgerEntryChanges(LedgerEntryChange[] LedgerEntryChanges)
  {
    InnerValue = LedgerEntryChanges;
  }
  public static void Encode(IByteWriter stream, LedgerEntryChanges  encodedLedgerEntryChanges) {
  int LedgerEntryChangesSize = encodedLedgerEntryChanges.InnerValue.Length;
  XdrEncoding.EncodeInt32(LedgerEntryChangesSize, stream);
  for (int i = 0; i < LedgerEntryChangesSize; i++) {
    LedgerEntryChange.Encode(stream, encodedLedgerEntryChanges.InnerValue[i]);
  }
  }
  public static LedgerEntryChanges Decode(IByteReader stream) {
    LedgerEntryChanges decodedLedgerEntryChanges = new LedgerEntryChanges();
  int LedgerEntryChangessize = XdrEncoding.DecodeInt32(stream);
  decodedLedgerEntryChanges.InnerValue = new LedgerEntryChange[LedgerEntryChangessize];
  for (int i = 0; i < LedgerEntryChangessize; i++) {
    decodedLedgerEntryChanges.InnerValue[i] = LedgerEntryChange.Decode(stream);
  }
    return decodedLedgerEntryChanges;
  }
}
}
