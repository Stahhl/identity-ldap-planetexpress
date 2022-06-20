using IdentityServer.LdapExtension.Extensions;
using IdentityServer.LdapExtension.UserModel;
using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
	.AddDeveloperSigningCredential()
	.AddInMemoryIdentityResources(Config.IdentityResources)
	.AddInMemoryApiScopes(Config.ApiScopes)
	.AddInMemoryApiResources(Config.ApiResources)
	.AddInMemoryClients(Config.Clients)
	.AddLdapUsers<OpenLdapAppUser>(builder.Configuration.GetSection("LdapServer"), UserStore.InMemory);

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapDefaultControllerRoute();
});

app.Run();
