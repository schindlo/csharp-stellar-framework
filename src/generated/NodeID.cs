          // Automatically generated by xdrgen 
          // DO NOT EDIT or your changes may be overwritten

          namespace StellarBase.Generated
{


// === xdr source ============================================================
//  typedef PublicKey NodeID;
//  ===========================================================================
public class NodeID {
  public PublicKey InnerValue { get; set; } = default(PublicKey);
            
  public NodeID() { }
  public NodeID(PublicKey NodeID)
  {
    InnerValue = NodeID;
  }
  public static void Encode(IByteWriter stream, NodeID  encodedNodeID) {
  PublicKey.Encode(stream, encodedNodeID.InnerValue);
  }
  public static NodeID Decode(IByteReader stream) {
    NodeID decodedNodeID = new NodeID();
  decodedNodeID.InnerValue = PublicKey.Decode(stream);
    return decodedNodeID;
  }
}
}
