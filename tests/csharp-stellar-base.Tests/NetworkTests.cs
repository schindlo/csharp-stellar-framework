using Xunit;

namespace csharp_stellar_base.Tests
{
    public class NetworkTests
    {
        [Fact]
        public void NetworkId()
        {
            Stellar.Network.CurrentNetwork = "ProjectQ";

            string hexed = Chaos.NaCl.CryptoBytes.ToHexStringLower(Stellar.Network.CurrentNetworkId);

            Assert.Equal(hexed, "89046661f1e50483904e55469c7131b76bcaca59d0db74e9c0c188b35c67b49a");
        }

    }
}