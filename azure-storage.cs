using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Storage;
using System;
using System.Threading.Tasks;

class Program
{
    private const string subscriptionId = "<Your Subscription ID>";
    private const string resourceGroupName = "<Your Resource Group Name>";
    private const string storageAccountName = "<Your Storage Account Name>";

    static async Task Main(string[] args)
    {
        var credentials = new DefaultAzureCredential();
        var armClient = new ArmClient(credentials);
        var subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{subscriptionId}"));
        var resourceGroup = subscription.GetResourceGroup(resourceGroupName);
        
        var storageAccountData = new StorageAccountData
        {
            Sku = new StorageSku(StorageSkuName.StandardLrs),
            Kind = StorageKind.StorageV2,
            Location = AzureLocation.WestUS
        };

        var storageAccount = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(
            storageAccountName, storageAccountData);

        Console.WriteLine($"Storage account created: {storageAccount.Value.Data.Id}");
    }
}