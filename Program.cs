using System;
using System.Collections.Generic;
using VaultSharp;
using VaultSharp.Core;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.AppRole;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;
using VaultSharp.V1.SecretsEngines;
using VaultSharp.V1.SecretsEngines.Transit;
using VaultSharp.V1.SystemBackend;
using VaultSharp.V1.SystemBackend.Plugin;

namespace vault_dotnet_test
{
    class Program
    {
        static void Main(string[] args)
        {
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo("s.C979mWsj0zzHUoZjqgfeobqI");

            // Initialize settings. You can also set proxies, custom delegates etc. here.
            var vaultClientSettings = new VaultClientSettings("http://127.0.0.1:8200", authMethod);
            IVaultClient vaultClient = new VaultClient(vaultClientSettings);

            // Use client to read a key-value secret
            Secret<SecretData> kv2Secret = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync("test", null, "kv").Result;
			Console.WriteLine(kv2Secret.Data.Data["login"]);
        }
    }
}
