          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  struct AccountEntry
//  {
//      AccountID accountID;      // master public key for this account
//      int64 balance;            // in stroops
//      SequenceNumber seqNum;    // last sequence number used for this account
//      uint32 numSubEntries;     // number of sub-entries this account has
//                                // drives the reserve
//      AccountID* inflationDest; // Account to vote for during inflation
//      uint32 flags;             // see AccountFlags
//  
//      string32 homeDomain; // can be used for reverse federation and memo lookup
//  
//      // fields used for signatures
//      // thresholds stores unsigned bytes: [weight of master|low|medium|high]
//      Thresholds thresholds;
//  
//      Signer signers<20>; // possible signers for this account
//  
//      // reserved for future use
//      union switch (int v)
//      {
//      case 0:
//          void;
//      }
//      ext;
//  };
//  ===========================================================================
public class AccountEntry {
  public AccountEntry () {}
  public AccountID AccountID { get; set; }
  public Int64 Balance { get; set; }
  public SequenceNumber SeqNum { get; set; }
  public Uint32 NumSubEntries { get; set; }
  public AccountID InflationDest { get; set; }
  public Uint32 Flags { get; set; }
  public String32 HomeDomain { get; set; }
  public Thresholds Thresholds { get; set; }
  public Signer[] Signers { get; set; }
  public AccountEntryExt Ext { get; set; }
  public static void Encode(IByteWriter stream, AccountEntry encodedAccountEntry) {
    AccountID.Encode(stream, encodedAccountEntry.AccountID);
    Int64.Encode(stream, encodedAccountEntry.Balance);
    SequenceNumber.Encode(stream, encodedAccountEntry.SeqNum);
    Uint32.Encode(stream, encodedAccountEntry.NumSubEntries);
    if (encodedAccountEntry.InflationDest != null) {
    XdrEncoding.EncodeInt32(1, stream);
    AccountID.Encode(stream, encodedAccountEntry.InflationDest);
    } else {
    XdrEncoding.EncodeInt32(0, stream);
    }
    Uint32.Encode(stream, encodedAccountEntry.Flags);
    String32.Encode(stream, encodedAccountEntry.HomeDomain);
    Thresholds.Encode(stream, encodedAccountEntry.Thresholds);
    int signerssize = encodedAccountEntry.Signers.Length;
    XdrEncoding.EncodeInt32(signerssize, stream);
    for (int i = 0; i < signerssize; i++) {
      Signer.Encode(stream, encodedAccountEntry.Signers[i]);
    }
    AccountEntryExt.Encode(stream, encodedAccountEntry.Ext);
  }
  public static AccountEntry Decode(IByteReader stream) {
    AccountEntry decodedAccountEntry = new AccountEntry();
    decodedAccountEntry.AccountID = AccountID.Decode(stream);
    decodedAccountEntry.Balance = Int64.Decode(stream);
    decodedAccountEntry.SeqNum = SequenceNumber.Decode(stream);
    decodedAccountEntry.NumSubEntries = Uint32.Decode(stream);
    int inflationDestPresent = XdrEncoding.DecodeInt32(stream);
    if (inflationDestPresent != 0) {
    decodedAccountEntry.InflationDest = AccountID.Decode(stream);
    }
    decodedAccountEntry.Flags = Uint32.Decode(stream);
    decodedAccountEntry.HomeDomain = String32.Decode(stream);
    decodedAccountEntry.Thresholds = Thresholds.Decode(stream);
    int signerssize = XdrEncoding.DecodeInt32(stream);
    decodedAccountEntry.Signers = new Signer[signerssize];
    for (int i = 0; i < signerssize; i++) {
      decodedAccountEntry.Signers[i] = Signer.Decode(stream);
    }
    decodedAccountEntry.Ext = AccountEntryExt.Decode(stream);
    return decodedAccountEntry;
  }

  public class AccountEntryExt {
    public AccountEntryExt () {}
    public int Discriminant { get; set; } = new int();
    public static void Encode(IByteWriter stream, AccountEntryExt encodedAccountEntryExt) {
    XdrEncoding.EncodeInt32(encodedAccountEntryExt.Discriminant, stream);
    switch (encodedAccountEntryExt.Discriminant) {
    case 0:
    break;
    }
    }
    public static AccountEntryExt Decode(IByteReader stream) {
      AccountEntryExt decodedAccountEntryExt = new AccountEntryExt();
    decodedAccountEntryExt.Discriminant = XdrEncoding.DecodeInt32(stream);
    switch (decodedAccountEntryExt.Discriminant) {
    case 0:
    break;
    }
      return decodedAccountEntryExt;
    }

  }
}
}
