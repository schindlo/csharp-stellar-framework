          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  struct DataEntry
//  {
//      AccountID accountID; // account this data belongs to
//      string64 dataName;
//      DataValue dataValue;
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
public class DataEntry {
  public DataEntry () {}
  public AccountID AccountID { get; set; }
  public String64 DataName { get; set; }
  public DataValue DataValue { get; set; }
  public DataEntryExt Ext { get; set; }
  public static void Encode(IByteWriter stream, DataEntry encodedDataEntry) {
    AccountID.Encode(stream, encodedDataEntry.AccountID);
    String64.Encode(stream, encodedDataEntry.DataName);
    DataValue.Encode(stream, encodedDataEntry.DataValue);
    DataEntryExt.Encode(stream, encodedDataEntry.Ext);
  }
  public static DataEntry Decode(IByteReader stream) {
    DataEntry decodedDataEntry = new DataEntry();
    decodedDataEntry.AccountID = AccountID.Decode(stream);
    decodedDataEntry.DataName = String64.Decode(stream);
    decodedDataEntry.DataValue = DataValue.Decode(stream);
    decodedDataEntry.Ext = DataEntryExt.Decode(stream);
    return decodedDataEntry;
  }

  public class DataEntryExt {
    public DataEntryExt () {}
    public int Discriminant { get; set; } = new int();
    public static void Encode(IByteWriter stream, DataEntryExt encodedDataEntryExt) {
    XdrEncoding.EncodeInt32(encodedDataEntryExt.Discriminant, stream);
    switch (encodedDataEntryExt.Discriminant) {
    case 0:
    break;
    }
    }
    public static DataEntryExt Decode(IByteReader stream) {
      DataEntryExt decodedDataEntryExt = new DataEntryExt();
    decodedDataEntryExt.Discriminant = XdrEncoding.DecodeInt32(stream);
    switch (decodedDataEntryExt.Discriminant) {
    case 0:
    break;
    }
      return decodedDataEntryExt;
    }

  }
}
}
