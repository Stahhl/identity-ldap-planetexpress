// See https://aka.ms/new-console-template for more information

using IdentityModel.Client;

RunAsync().GetAwaiter().GetResult();

async Task RunAsync()
{
    Console.WriteLine("Hello, World!");
    var service = new TokenService();
    var token = await service.GetToken();

    Console.WriteLine(token.IsError);

    service.httpClient.SetBearerToken(token.AccessToken);

    var response = await service.httpClient.GetAsync("https://localhost:5445/api/CoffeeShop");

    Console.WriteLine(response.StatusCode);

    if (response.IsSuccessStatusCode)
    {
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
    }
}


public class TokenService
{
    // public readonly IOptions<IdentityServerSettings> identityServerSettings;
    public readonly DiscoveryDocumentResponse discoveryDocument;
    public readonly HttpClient httpClient;

    public TokenService(
        // IOptions<IdentityServerSettings> identityServerSettings
    )
    {
        //this.identityServerSettings = identityServerSettings;
        httpClient = new HttpClient();
        discoveryDocument = httpClient.GetDiscoveryDocumentAsync("https://localhost:5443").Result;

        if (discoveryDocument.IsError)
        {
            throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
        }
    }

    public async Task<TokenResponse> GetToken(
        // string scope
    )
    {
        var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "m2m.client",
            ClientSecret = "ClientSecret1",
            UserName = "fry",
            Password = "fry",
            // Scope = "CoffeeAPI.read",
            // Resource = new List<string>() { "CoffeeAPI" }
        });

        // var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //          {
        //              Address = discoveryDocument.TokenEndpoint,
        //              ClientId = identityServerSettings.Value.ClientName,
        //              ClientSecret = identityServerSettings.Value.ClientPassword,
        //              Scope = scope
        //          });

        if (tokenResponse.IsError)
        {
            throw new Exception("Unable to get token", tokenResponse.Exception);
        }

        return tokenResponse;
    }
}