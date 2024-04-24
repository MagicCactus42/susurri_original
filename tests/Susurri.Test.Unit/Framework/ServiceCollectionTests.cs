using Microsoft.Extensions.DependencyInjection;

namespace Susurri.Test.Unit.Framework;

public class ServiceCollectionTests
{
    [Fact]
    public void test()
    {
        var serviceCollection = new ServiceCollection();

        var serviceProvider = serviceCollection.BuildServiceProvider();
    }
    
    private interface IInterface
    {
        void Send();
    }
    
}