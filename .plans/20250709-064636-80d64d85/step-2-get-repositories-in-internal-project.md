# Step 2: Get Repositories in Internal Project

**Plan**: 20250709-064636-80d64d85
**Status**: Completed
**Started**: 2025-07-09T06:46:39Z
**Completed**: 2025-07-09T06:46:41Z
**Duration**: 1.27 seconds

## Goal
Retrieve the list of repositories in the internal project

## Prompt
Get repositories from the internal project in the Azure DevOps organization

## Execution Details

## Response
- **Server**: azure-devops-primary
- **Tool**: get_repositories
- **Results**:
```
[
  {
    "Id": "0fb8b8ae-99ee-41f1-97c4-e9b8ef876b13",
    "Name": "Antigen",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/Antigen"
  },
  {
    "Id": "c3aad48b-429d-4bc3-aa50-f7903375895c",
    "Name": "ARM-LanguageServer",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/ARM-LanguageServer"
  },
  {
    "Id": "4b7f10b6-89f4-46cf-8858-4c21032ec66a",
    "Name": "aspnet-AspLabs",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspLabs"
  },
  {
    "Id": "908f26b7-443e-4544-9984-8fe26352b4f1",
    "Name": "aspnet-AspNetCore",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetCore"
  },
  {
    "Id": "6579f0ed-6878-4ead-85df-6a04d4b6cde2",
    "Name": "aspnet-AspNetIdentity",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetIdentity"
  },
  {
    "Id": "78917a76-6f36-4865-b90e-47f343550f3a",
    "Name": "aspnet-AspNetKatana",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetKatana"
  },
  {
    "Id": "433105d3-d1fc-4232-b0d0-546a7900d9d5",
    "Name": "aspnet-AspNetWebHooks",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks"
  },
  {
    "Id": "dc361fd8-f928-4e3f-ae44-850da35f38be",
    "Name": "aspnet-AspNetWebHooks-Signed",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks-Signed"
  },
  {
    "Id": "221add85-75f1-4303-b09b-8f6028ccc36c",
    "Name": "aspnet-AspNetWebStack",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebStack"
  },
  {
    "Id": "3f12bc76-bc5a-4d7f-a90b-31eabfff881c",
    "Name": "aspnet-Benchmarks",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-Benchmarks"
  },
  {
    "Id": "8ab873cd-74a7-47dd-90b6-4fb6381b9bc9",
    "Name": "aspnet-BrowserLink",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-BrowserLink"
  },
  {
    "Id": "048ab2f0-d7a0-4be5-8bd5-6bd71b56dbad",
    "Name": "aspnet-BuildTools",
    "DefaultBranch": "refs/heads/release/2.1",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-BuildTools"
  },
  {
    "Id": "0ac82848-3e47-47b3-bd88-07b74548be27",
    "Name": "aspnet-Extensions",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-Extensions"
  },
  {
    "Id": "31d35b61-8053-45ec-8653-48f6404abb05",
    "Name": "aspnet-FrameworkBenchmarks",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-FrameworkBenchmarks"
  },
  {
    "Id": "95118702-0e4e-435d-b59e-ff9310cf0b8e",
    "Name": "aspnet-Identity",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-Identity"
  },
  {
    "Id": "5518f25c-7192-4320-a66d-c70324d19a15",
    "Name": "aspnet-Identity-Legacy",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-Identity-Legacy"
  },
  {
    "Id": "b126af0e-1423-4398-99e6-5ef14271220a",
    "Name": "aspnet-internal-tools-archived",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-internal-tools-archived"
  },
  {
    "Id": "474e9f62-3006-456c-a61d-61233698d4de",
    "Name": "aspnet-jquery-validation-unobtrusive",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-jquery-validation-unobtrusive"
  },
  {
    "Id": "45d01372-621f-471a-9c4d-9969f77635f7",
    "Name": "aspnet-LibraryManager",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-LibraryManager"
  },
  {
    "Id": "47f86d0e-9ff6-4901-9f63-8befbbf05b63",
    "Name": "aspnet-SignalR-Client-Cpp",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-SignalR-Client-Cpp"
  },
  {
    "Id": "57d0248f-498b-4785-9648-dd4f2be6dd0a",
    "Name": "aspnet-WebStackRuntime-Build",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Build"
  },
  {
    "Id": "59fd3cc9-1f51-4790-90cd-9c537d676f4f",
    "Name": "aspnet-WebStackRuntime-Legacy",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Legacy"
  },
  {
    "Id": "0d907d53-ad88-40ed-bd2e-4c90d31c9840",
    "Name": "azure-identitymodel",
    "DefaultBranch": "refs/heads/dev",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/azure-identitymodel"
  },
  {
    "Id": "a18923b2-030f-4bc9-96c7-fd88a2242812",
    "Name": "chcosta-cloudtest",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/chcosta-cloudtest"
  },
  {
    "Id": "4b401012-a64d-4042-bd90-d81e252f6de8",
    "Name": "chcosta-playground",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/chcosta-playground"
  },
  {
    "Id": "ed30c7a3-33d8-47c2-ac65-fdcf6ecddcc6",
    "Name": "chcosta-serviceconnection-info",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/chcosta-serviceconnection-info"
  },
  {
    "Id": "952f0784-7a17-49ec-aeaa-794d3b9f5715",
    "Name": "core",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/core"
  },
  {
    "Id": "08aee660-1e7b-49bb-a222-3e059e65146d",
    "Name": "cve-tracker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/cve-tracker"
  },
  {
    "Id": "11bae2ce-65e5-4930-9670-2414bab54f38",
    "Name": "depmon",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/depmon"
  },
  {
    "Id": "621308f4-28ee-4c10-bbdd-c45963a01c1b",
    "Name": "dnceng-ai-experimental",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
  },
  {
    "Id": "c8763941-2e78-47ab-970e-e904e70d7641",
    "Name": "dnceng-azdo-extension",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dnceng-azdo-extension"
  },
  {
    "Id": "91b088f2-b580-4d71-8e8e-2afb8cb032da",
    "Name": "dotnet-ad-wiki",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-ad-wiki"
  },
  {
    "Id": "2727f17c-f5b3-4a73-8a9e-23cdc0e3951f",
    "Name": "dotnet-android",
    "DefaultBranch": "refs/heads/MarkInstantiated",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-android"
  },
  {
    "Id": "b94bcab0-e0db-4a83-8829-2694f366e303",
    "Name": "dotnet-api-catalog-infra",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-api-catalog-infra"
  },
  {
    "Id": "d551d0d5-053b-400b-99d7-56e9c6c469c4",
    "Name": "dotnet-arcade",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-arcade"
  },
  {
    "Id": "b4244e83-7024-4d37-b799-43e60cf72daa",
    "Name": "dotnet-arcade.mmitche",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-arcade.mmitche"
  },
  {
    "Id": "4eb601ef-1520-45ca-aa5c-a72055e4a77a",
    "Name": "dotnet-arcade-extensions",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-extensions"
  },
  {
    "Id": "ec29e881-6ad7-4427-832d-ce639ccba518",
    "Name": "dotnet-arcade-services",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-services"
  },
  {
    "Id": "017fb734-e4b4-4cc1-a90f-98a09ac25cd5",
    "Name": "dotnet-arcade-validation",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-validation"
  },
  {
    "Id": "ecc7dc1d-c809-460e-8d0f-6712313d5180",
    "Name": "dotnet-aspire",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-aspire"
  },
  {
    "Id": "0e513bbe-d00b-478b-b59e-8131bc3e15d7",
    "Name": "dotnet-aspire-samples",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-aspire-samples"
  },
  {
    "Id": "23330b81-8bf6-4092-af7d-db8dfba063b8",
    "Name": "dotnet-aspnetcore",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-aspnetcore"
  },
  {
    "Id": "faaf5a32-61f8-482b-aaab-c41d45ac0905",
    "Name": "dotnet-astra",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-astra"
  },
  {
    "Id": "bb4cf35e-4179-4def-9b65-aecf09681592",
    "Name": "dotnet-binaryen",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-binaryen"
  },
  {
    "Id": "6122397d-05a0-49e6-8c17-22838898ceab",
    "Name": "dotnet-buildanalyzer",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-buildanalyzer"
  },
  {
    "Id": "7bf030f5-9fb7-4a2d-b3cf-b64b78ce6ebb",
    "Name": "dotnet-cecil",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cecil"
  },
  {
    "Id": "23ae4d32-d059-4aae-b3fb-8a9378d076ac",
    "Name": "dotnet-cli",
    "DefaultBranch": "refs/heads/release/3.1.4xx",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cli"
  },
  {
    "Id": "081e1a92-160e-452b-8629-825c3ef60bd5",
    "Name": "dotnet-clickonce-test",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-clickonce-test"
  },
  {
    "Id": "46fc2fc7-f5e8-4aff-aab4-6f44497c0e72",
    "Name": "dotnet-cliCommandLineParser",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cliCommandLineParser"
  },
  {
    "Id": "caf9bd58-889d-4e8a-a79d-ce5b51b695d9",
    "Name": "dotnet-cli-lab",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cli-lab"
  },
  {
    "Id": "784b92ee-524b-4d67-ac23-a67b3063a9e8",
    "Name": "dotnet-cli-migrate",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cli-migrate"
  },
  {
    "Id": "d44655e1-da3a-467f-9ead-988fd5b17ae1",
    "Name": "dotnet-command-line-api",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-command-line-api"
  },
  {
    "Id": "e564d7e2-51dd-4f28-adcc-b44f10b9216f",
    "Name": "dotnet-coreclr",
    "DefaultBranch": "refs/heads/release/3.1",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr"
  },
  {
    "Id": "ee0b6d25-f5f6-4c7b-8188-bc6c65b22a92",
    "Name": "dotnet-coreclr.petersol",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr.petersol"
  },
  {
    "Id": "d3f5a5df-1c0c-4590-a52c-c6347e755d54",
    "Name": "dotnet-corefx",
    "DefaultBranch": "refs/heads/internal/release/3.1-packages",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-corefx"
  },
  {
    "Id": "c084b7c7-0ba9-4b1f-93aa-d8b8f5f877f9",
    "Name": "dotnet-corescan",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-corescan"
  },
  {
    "Id": "a873616e-a561-4197-8b57-50d597e10f79",
    "Name": "dotnet-core-setup",
    "DefaultBranch": "refs/heads/release/3.1",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-core-setup"
  },
  {
    "Id": "61834684-2995-4b3d-886b-594a110fc34e",
    "Name": "dotnet-cpython",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cpython"
  },
  {
    "Id": "3243797b-b8a1-4282-b1be-efaab372b28d",
    "Name": "dotnet-crank",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-crank"
  },
  {
    "Id": "80cd07de-7dde-443b-a0e9-2f9dd2380d7a",
    "Name": "dotnet-cssparser",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cssparser"
  },
  {
    "Id": "9760da74-5bf5-4f53-ad86-23dbee9715f0",
    "Name": "dotnet-cve",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-cve"
  },
  {
    "Id": "4f97fc4f-6e4e-4b09-b4e8-7bd50ecd61ee",
    "Name": "dotnet-ddfun",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-ddfun"
  },
  {
    "Id": "924cd040-9411-4903-932f-12bdaf3f1db3",
    "Name": "dotnet-debugger-contracts",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-debugger-contracts"
  },
  {
    "Id": "9922e4b0-f11d-4071-879d-f8d3171a12be",
    "Name": "dotnet-deployment-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-deployment-tools"
  },
  {
    "Id": "8d7f53cd-f3b5-4b54-a635-31dd397b5cf3",
    "Name": "dotnet-diagnostics",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics"
  },
  {
    "Id": "083b9e02-93f9-460d-8b2b-d555754bab3c",
    "Name": "dotnet-diagnostics-internal-components",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics-internal-components"
  },
  {
    "Id": "e6e646f0-a7a0-4307-bad7-1c12505c8fd5",
    "Name": "dotnet-diagnostictests",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests"
  },
  {
    "Id": "e526d7ad-7188-43ef-89c9-60f5629ba608",
    "Name": "dotnet-diagnostictests.tom.mcdonald",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests.tom.mcdonald"
  },
  {
    "Id": "a7561977-2f83-4138-94d2-dbef522275ad",
    "Name": "dotnet-dnceng",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng"
  },
  {
    "Id": "f7b9a526-8d8a-4570-a59d-e13c6c547617",
    "Name": "dotnet-dnceng-internal",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-internal"
  },
  {
    "Id": "16bcb0ca-49cf-42c6-82d9-cba9ca52e801",
    "Name": "dotnet-dnceng-shared",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-shared"
  },
  {
    "Id": "ba59d1a9-c352-46eb-8566-7ddf9a2bcdba",
    "Name": "dotnet-docker-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools"
  },
  {
    "Id": "5eedc4d6-2029-47cb-ad4b-767d9a48eb00",
    "Name": "dotnet-docker-tools-internal",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools-internal"
  },
  {
    "Id": "ddda0dd6-918f-48ba-ba8f-730d9d8c9320",
    "Name": "dotnet-dotnet",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet"
  },
  {
    "Id": "e1c1cfff-9e98-4865-abbe-c94eeb214875",
    "Name": "dotnet-dotnet.matt.mitchell",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet.matt.mitchell"
  },
  {
    "Id": "fcd803f1-3625-4a55-b725-6ffb6e2a8967",
    "Name": "dotnet-dotnet-buildtools-prereqs-docker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-buildtools-prereqs-docker"
  },
  {
    "Id": "2a545fef-bbd2-4b2c-bd12-601823b64d30",
    "Name": "dotnet-dotnet-cli-archiver",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-cli-archiver"
  },
  {
    "Id": "dbd8d413-6f88-419c-a86d-9323896b8997",
    "Name": "dotnet-dotnet-docker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-docker"
  },
  {
    "Id": "f86a5a24-347b-4698-b3ab-54e3378aab3c",
    "Name": "dotnet-dotnet-monitor",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor"
  },
  {
    "Id": "69ddfe0c-12e8-41f4-a235-5c35bd37c72a",
    "Name": "dotnet-dotnet-monitor-internal-docker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-docker"
  },
  {
    "Id": "1a8964a7-b5e0-4be1-a326-e9f7bdcf676b",
    "Name": "dotnet-dotnet-monitor-internal-extensions",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-extensions"
  },
  {
    "Id": "62677cb9-d786-4489-9a44-a4a10a80f086",
    "Name": "dotnet-dotnet-monitor-release",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-release"
  },
  {
    "Id": "1b53f110-df2e-43ca-b0a2-a6dedd902105",
    "Name": "dotnet-ef6",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-ef6"
  },
  {
    "Id": "75f066b1-b16b-405e-8a98-eaba58437cd7",
    "Name": "dotnet-efcore",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-efcore"
  },
  {
    "Id": "806ff0d0-8761-4e92-a4a5-aa3fdea51fa8",
    "Name": "dotnet-emscripten",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-emscripten"
  },
  {
    "Id": "cffc2737-8b0d-4be2-b2ed-66f5e0185add",
    "Name": "dotnet-emsdk",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-emsdk"
  },
  {
    "Id": "6afad562-b2ee-4a5b-ab3d-2a738b1ecb11",
    "Name": "dotnet-eng-wiki",
    "DefaultBranch": "refs/heads/wikiMaster",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki"
  },
  {
    "Id": "8756d1b0-48ee-40ce-903f-ff870d62447b",
    "Name": "dotnet-eng-wiki.epsitha.ananth",
    "DefaultBranch": "refs/heads/wikiMaster",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki.epsitha.ananth"
  },
  {
    "Id": "73ed6287-581b-49ad-8a63-9c98f5a97fc4",
    "Name": "dotnet-eShop",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-eShop"
  },
  {
    "Id": "81d264ec-3d9c-4bde-a06f-1b771c1efc58",
    "Name": "dotnet-extensions",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-extensions"
  },
  {
    "Id": "a0b2c458-ad9c-4fd9-8287-8b8c5bae840e",
    "Name": "dotnet-format",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-format"
  },
  {
    "Id": "be92e3fd-f77c-4ee9-9bf4-28d26e2ecf5e",
    "Name": "dotnet-fsharp",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-fsharp"
  },
  {
    "Id": "6a6f8dde-7937-4fe3-856f-38bdc6d0e1fe",
    "Name": "dotnet-fuzzing-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-fuzzing-tools"
  },
  {
    "Id": "569090e3-cc96-4250-a2d3-cd9b0039aa14",
    "Name": "dotnet-helix-machines",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines"
  },
  {
    "Id": "4267f8dc-bbe1-4d40-bc69-e53f1497e27b",
    "Name": "dotnet-helix-machines.epsitha.ananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines.epsitha.ananth"
  },
  {
    "Id": "b446d7ab-be6b-4949-aa44-214eef7e35bb",
    "Name": "dotnet-helix-service",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service"
  },
  {
    "Id": "4205878f-43fd-4391-b8ff-a9b6f3cbeefd",
    "Name": "dotnet-helix-service.djuradj.kurepa",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.djuradj.kurepa"
  },
  {
    "Id": "89e96953-80a5-4d1b-9323-cddf6e74d403",
    "Name": "dotnet-helix-service.eananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.eananth"
  },
  {
    "Id": "d18df941-982c-48b2-8121-fb3cbd9a539b",
    "Name": "dotnet-helix-service.epsitha.ananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.epsitha.ananth"
  },
  {
    "Id": "a1795d51-9245-4fd1-95bf-865d12f9d9da",
    "Name": "dotnet-hotreload-utils",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-hotreload-utils"
  },
  {
    "Id": "38d59875-8dbd-482a-b29d-88ba20f17b05",
    "Name": "dotnet-HttpRepl",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-HttpRepl"
  },
  {
    "Id": "060a2d9e-c73d-4f6d-8cae-014a3d77bf09",
    "Name": "dotnet-icu",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-icu"
  },
  {
    "Id": "87545870-fc7b-4a69-8085-60e8714e7e2d",
    "Name": "dotnet-insertions-client",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-insertions-client"
  },
  {
    "Id": "c20f712b-f093-40de-9013-d6b084c1ff30",
    "Name": "dotnet-installer",
    "DefaultBranch": "refs/heads/internal/release/8.0.4xx",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-installer"
  },
  {
    "Id": "2fd71809-ca84-4a26-bc1c-89b22cb1cd08",
    "Name": "dotnet-install-script-monitors",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-install-script-monitors"
  },
  {
    "Id": "bc64e819-1723-40fa-85c5-4fee241b3ea4",
    "Name": "dotnet-install-scripts",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-install-scripts"
  },
  {
    "Id": "33561aa0-bdde-4a4b-9260-1b86f6ad55b8",
    "Name": "dotnet-interactive",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-interactive"
  },
  {
    "Id": "7c34466a-fd79-4441-891f-11a9039974db",
    "Name": "dotnet-interactive-internal",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-internal"
  },
  {
    "Id": "17c7829a-e1d7-465e-8973-cbc6da01f84a",
    "Name": "dotnet-interactive-window",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-window"
  },
  {
    "Id": "ade62c71-67f5-441c-8446-f3520518a5df",
    "Name": "dotnet-jitutils",
    "DefaultBranch": "refs/heads/AndyAyersMS-patch-1",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-jitutils"
  },
  {
    "Id": "cf088168-84f3-44de-991c-1772c0df5c3a",
    "Name": "dotnet-linker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-linker"
  },
  {
    "Id": "c7d0088e-3677-4adb-b40b-5dc6600a7192",
    "Name": "dotnet-llvm-project",
    "DefaultBranch": "refs/heads/dotnet/main-19.x",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project"
  },
  {
    "Id": "30b7e789-d5ab-40dc-9c24-0cf2f6e60055",
    "Name": "dotnet-llvm-project.epsitha.ananth",
    "DefaultBranch": "refs/heads/release/11.x",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project.epsitha.ananth"
  },
  {
    "Id": "9dc604dc-e848-480e-87fd-450b10b6b2fc",
    "Name": "dotnet-machinelearning",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning"
  },
  {
    "Id": "2f49f4d0-c02f-4261-85ee-7186a9e61acc",
    "Name": "dotnet-machinelearning-assets",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning-assets"
  },
  {
    "Id": "881f35c8-201a-44a8-aec4-4e848662623d",
    "Name": "dotnet-macios",
    "DefaultBranch": "refs/heads/2023-01-24-main-backup",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-macios"
  },
  {
    "Id": "f314c194-4581-497d-a61a-bbc4c5ccf7f6",
    "Name": "dotnet-maintenance-packages",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-maintenance-packages"
  },
  {
    "Id": "a8060d6f-4bda-43b2-b0a8-d68d713e502c",
    "Name": "dotnet-maui",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-maui"
  },
  {
    "Id": "6fae92a1-6d6a-4912-9a6a-558211d4a57b",
    "Name": "dotnet-merge-policy-auditor",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-merge-policy-auditor"
  },
  {
    "Id": "51ce3f38-1a43-4370-9a54-3a65bc6952b9",
    "Name": "dotnet-metadata-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-metadata-tools"
  },
  {
    "Id": "4683223d-cb68-4e89-9e5c-d676f9e89b5e",
    "Name": "dotnet-migrate-package",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-migrate-package"
  },
  {
    "Id": "7d88a321-7ea0-4ec5-a5ef-462385618095",
    "Name": "dotnet-mirroring",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-mirroring"
  },
  {
    "Id": "65d3185f-953e-43a3-89fb-6e4a6278bd59",
    "Name": "dotnet-msbuild",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild"
  },
  {
    "Id": "4b35011d-d609-4ed1-a1bb-08297406ced2",
    "Name": "dotnet-msbuild-language-service",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild-language-service"
  },
  {
    "Id": "10f12b95-9b7a-4b3a-8451-577f7232b546",
    "Name": "dotnet-msquic",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-msquic"
  },
  {
    "Id": "c90dccfc-9c61-4f5a-a5e2-289781319b2b",
    "Name": "dotnet-netnativelegacy",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-netnativelegacy"
  },
  {
    "Id": "b1af3915-27a0-4188-862e-1db960b0dc02",
    "Name": "dotnet-node",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-node"
  },
  {
    "Id": "589b9e05-13ef-4116-b484-708cf9cd10f5",
    "Name": "dotnet-Nuget.BuildTasks",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-Nuget.BuildTasks"
  },
  {
    "Id": "0f2ea445-500a-400e-ba80-64f39ad8df33",
    "Name": "dotnet-observer-director-bot",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-observer-director-bot"
  },
  {
    "Id": "0bfc737a-3ef3-4a00-8da1-a91bc88f4034",
    "Name": "dotnet-optimization",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-optimization"
  },
  {
    "Id": "093ca8cd-4927-4f35-85af-f7aba3bfb2a7",
    "Name": "dotnet-org-policy",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-org-policy"
  },
  {
    "Id": "31ae6529-88fc-4a9f-87e1-3f62aa5cc382",
    "Name": "dotnet-orleans",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-orleans"
  },
  {
    "Id": "9015e742-7263-436f-b867-e80787640f30",
    "Name": "dotnet-performance",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-performance"
  },
  {
    "Id": "7f5866c0-e263-4ba8-b019-67463ad0a719",
    "Name": "dotnet-performance-infra",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-performance-infra"
  },
  {
    "Id": "d2000ad2-fe4f-4f44-8bf0-b14904403416",
    "Name": "dotnet-performance-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-performance-tools"
  },
  {
    "Id": "bca46106-12f7-41ce-88d7-2ec572f0401f",
    "Name": "dotnet-prodcon-test",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-prodcon-test"
  },
  {
    "Id": "49ecf959-f1c5-4e02-b526-7cbad8ca89c0",
    "Name": "dotnet-project-system",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-project-system"
  },
  {
    "Id": "17f1b4ee-a043-4210-a704-a8f7fc8e90f1",
    "Name": "dotnet-project-system-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-project-system-tools"
  },
  {
    "Id": "e9669ab7-eab2-4f4a-a461-395c9f9850de",
    "Name": "dotnet-ProjFileTools",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-ProjFileTools"
  },
  {
    "Id": "9754e696-9a03-41fb-8b00-d6d88d858fae",
    "Name": "dotnet-r9",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-r9"
  },
  {
    "Id": "459913a4-9029-44c4-9abd-06c5d8fbf997",
    "Name": "dotnet-razor",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-razor"
  },
  {
    "Id": "eedc9393-3f8c-41e6-b79d-d7c7f7761c8e",
    "Name": "dotnet-razor-compiler",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-razor-compiler"
  },
  {
    "Id": "cc38b149-c759-4a3a-af94-1fa707ea835c",
    "Name": "dotnet-razor-tooling-internal",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-razor-tooling-internal"
  },
  {
    "Id": "c02a7e43-a426-455b-bba9-335409c459ba",
    "Name": "dotnet-release",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-release"
  },
  {
    "Id": "7193af62-2fe6-4391-802f-25b48fa300ba",
    "Name": "dotnet-release.epananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-release.epananth"
  },
  {
    "Id": "13a919be-24f3-4972-8bbe-6d3c1e805a76",
    "Name": "dotnet-release.epsitha.ananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth"
  },
  {
    "Id": "e34ba2c7-8798-4904-b48e-ad5711d38b47",
    "Name": "dotnet-release.epsitha.ananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth"
  },
  {
    "Id": "af85d71f-7e9c-4d38-848e-b069f3713ff9",
    "Name": "dotnet-release.milena.hristova",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-release.milena.hristova"
  },
  {
    "Id": "7b863b8d-8cc3-431d-b06b-7136cc32bbe6",
    "Name": "dotnet-roslyn",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn"
  },
  {
    "Id": "d39990a1-ce82-46a7-b40f-df003f7c7c10",
    "Name": "dotnet-roslyn-analyzers",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-analyzers"
  },
  {
    "Id": "060f1029-4a43-4ca9-9a78-b8c8c353a3a6",
    "Name": "dotnet-roslyn-debug",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug"
  },
  {
    "Id": "33cb5e85-797e-4ccb-8fb7-562139269331",
    "Name": "dotnet-roslyn-debug.epsitha.ananth",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug.epsitha.ananth"
  },
  {
    "Id": "cb6898c9-00a9-409a-9378-0830f61cb61f",
    "Name": "dotnet-roslyn-sdk",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-sdk"
  },
  {
    "Id": "6c3a47fa-4194-4427-9345-5ef530a8cecd",
    "Name": "dotnet-roslyn-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-tools"
  },
  {
    "Id": "a2f9a77f-0d37-4eaf-aecc-5b3ff7457ad6",
    "Name": "dotnet-runtime",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtime"
  },
  {
    "Id": "cbdfe817-472e-4896-af99-4a58ae00884c",
    "Name": "dotnet-runtime.tom.mcdonald",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtime.tom.mcdonald"
  },
  {
    "Id": "573526da-4b93-4a15-bc59-68fbd0ed44ff",
    "Name": "dotnet-runtime-assets",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-assets"
  },
  {
    "Id": "caae7a43-2653-4182-8839-b92266aa59ec",
    "Name": "dotnet-runtimelab",
    "DefaultBranch": "refs/heads/docs",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtimelab"
  },
  {
    "Id": "3693e49f-9d51-4f47-9bf8-1331764908b5",
    "Name": "dotnet-runtime-switch",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-switch"
  },
  {
    "Id": "f8d60813-bd0b-46ba-b616-702e997bffc2",
    "Name": "dotnet-runtime-xbox",
    "DefaultBranch": "refs/heads/8.x-gdk",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-xbox"
  },
  {
    "Id": "b7fa47e7-2361-4fba-a415-2047d3feeaaa",
    "Name": "dotnet-Scaffolding",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-Scaffolding"
  },
  {
    "Id": "877a0ba2-ef60-4914-a2c8-5c2563154654",
    "Name": "dotnet-scenario-tests",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-scenario-tests"
  },
  {
    "Id": "7fa5dddb-89e8-4b26-8595-a6d15593e354",
    "Name": "dotnet-sdk",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-sdk"
  },
  {
    "Id": "d369c65e-97f8-46ed-8adb-c2c512936934",
    "Name": "dotnet-sdk-msbuild-dev-util",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-sdk-msbuild-dev-util"
  },
  {
    "Id": "7c82db9a-6113-4019-940b-fdaddeadd2f8",
    "Name": "dotnet-secret-scanner",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-secret-scanner"
  },
  {
    "Id": "dc55b1f4-ddf2-4ef1-80a7-6046b5d23aa9",
    "Name": "dotnet-setup",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-setup"
  },
  {
    "Id": "c567171f-7e68-4231-a2fb-a14c0ff8946b",
    "Name": "dotnet-sign",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-sign"
  },
  {
    "Id": "63be1e6d-1637-44c9-aa1a-568cfe3cc985",
    "Name": "dotnet-signed-wix",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-signed-wix"
  },
  {
    "Id": "e4b0ff97-ae77-40c1-bc99-9d9e659866c6",
    "Name": "dotnet-sleet",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-sleet"
  },
  {
    "Id": "69c2c970-095b-456e-95a7-815a1303748c",
    "Name": "dotnet-source-build",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build"
  },
  {
    "Id": "32f3599f-eef6-42cc-8abb-daffc95a8cf8",
    "Name": "dotnet-source-build.crummel",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build.crummel"
  },
  {
    "Id": "06e88986-f451-4a51-94b7-e3486b1e7cff",
    "Name": "dotnet-source-build-externals",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-externals"
  },
  {
    "Id": "de34c285-4b5e-4208-bd3b-5c3fe027a516",
    "Name": "dotnet-source-build-reference-packages",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-reference-packages"
  },
  {
    "Id": "801c715e-9ba6-44bb-a97f-446650a133fe",
    "Name": "dotnet-source-build-utilities",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities"
  },
  {
    "Id": "f5795c64-4904-4882-a4bf-54df5dc7154e",
    "Name": "dotnet-source-build-utilities.dan.seefeldt",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities.dan.seefeldt"
  },
  {
    "Id": "50706ae1-6430-4ee9-b8f1-42e212175217",
    "Name": "dotnet-source-indexer",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-source-indexer"
  },
  {
    "Id": "0debd82f-272b-4ae1-a4e3-13d0dd1ce7d3",
    "Name": "dotnet-sourcelink",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-sourcelink"
  },
  {
    "Id": "2af3710c-4941-4d1b-b78d-5d8194a787d4",
    "Name": "dotnet-spark",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-spark"
  },
  {
    "Id": "7d3d3136-6961-4a46-9a68-a3a80635668c",
    "Name": "dotnet-spark-extensions",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions"
  },
  {
    "Id": "c4900de8-3a35-45a8-9a53-82fe13f57969",
    "Name": "dotnet-spark-extensions.long.ltian",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions.long.ltian"
  },
  {
    "Id": "e2d9608a-5e07-45aa-97eb-2470cf1d2c98",
    "Name": "dotnet-spa-templates",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-spa-templates"
  },
  {
    "Id": "747a7e2e-5a1e-40fc-9bbd-1ec1cdc77219",
    "Name": "dotnet-standard",
    "DefaultBranch": "refs/heads/archive",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-standard"
  },
  {
    "Id": "d48d8ed4-4c4a-416e-9cc9-172030a8fc0e",
    "Name": "dotnet-symreader",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-symreader"
  },
  {
    "Id": "6f9a3366-7703-4073-b408-4e8efc0d658a",
    "Name": "dotnet-symreader-converter",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-converter"
  },
  {
    "Id": "312b9e9a-cc52-4b85-902f-5b8093051080",
    "Name": "dotnet-symreader-portable",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-portable"
  },
  {
    "Id": "789956e6-59e0-4c15-8747-dee86fda60bd",
    "Name": "dotnet-symstore",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-symstore"
  },
  {
    "Id": "dc3dbd38-9381-4069-a45b-117c2a038ba4",
    "Name": "dotnet-symuploader",
    "DefaultBranch": "refs/heads/release/pre-2gb-support",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-symuploader"
  },
  {
    "Id": "12820810-4d07-4d8e-ab92-d5c23f3e7c70",
    "Name": "dotnet-systemweb-adapters",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-systemweb-adapters"
  },
  {
    "Id": "04ba14b5-08b5-42ff-9646-b12f3504111e",
    "Name": "dotnet-templating",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-templating"
  },
  {
    "Id": "178a4a27-6c76-4fc9-a386-b6e41d5cdcbc",
    "Name": "dotnet-testimpactanalysis",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-testimpactanalysis"
  },
  {
    "Id": "733a9d86-dd45-4192-afb4-63796bc6722e",
    "Name": "dotnet-test-templates",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-test-templates"
  },
  {
    "Id": "dc259702-907a-4816-8b01-59be9814c0f5",
    "Name": "dotnet-thrive-dataservice",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-thrive-dataservice"
  },
  {
    "Id": "3f3766c5-d236-41a2-8526-a32b4087bdff",
    "Name": "dotnet-toolset",
    "DefaultBranch": "refs/heads/internal/release/3.1.4xx",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-toolset"
  },
  {
    "Id": "a6c178a2-3370-45ff-93bf-db4598cee919",
    "Name": "dotnet-try",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-try"
  },
  {
    "Id": "fd8f00a8-276e-4439-9e80-5ec71885ab67",
    "Name": "dotnet-try-convert",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-try-convert"
  },
  {
    "Id": "6e8cd5d4-e809-435b-a3ec-93cd2691c86b",
    "Name": "dotnet-try-samples",
    "DefaultBranch": "refs/heads/feed-update-azdo-dnceng-internal/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-try-samples"
  },
  {
    "Id": "48023595-579f-4f31-8b9d-a9ace4d92b57",
    "Name": "dotnet-tye",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-tye"
  },
  {
    "Id": "da805f51-c182-4914-97b7-4e81b5865d84",
    "Name": "dotnet-upgrade-assistant",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-upgrade-assistant"
  },
  {
    "Id": "052650a2-0aaf-4766-8a72-b5340ecaedb0",
    "Name": "dotnet-uwp-setup",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-uwp-setup"
  },
  {
    "Id": "a955c2c9-c551-4e85-9f04-089f5e519fd0",
    "Name": "dotnet-versions",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-versions"
  },
  {
    "Id": "63e32aa5-8db9-4c0d-8886-e8ec4b36e8d7",
    "Name": "dotnet-vscode-csharp",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-csharp"
  },
  {
    "Id": "d39a7e10-161c-478c-a0c5-d778070a1e61",
    "Name": "dotnet-vscode-dotnet-installer",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-installer"
  },
  {
    "Id": "3fe94c62-8adb-47db-a753-2b42c5e078de",
    "Name": "dotnet-vscode-dotnet-pack",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-pack"
  },
  {
    "Id": "f2ac372b-f16d-437b-94e7-c306f9ae5431",
    "Name": "dotnet-vscode-dotnet-runtime",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-runtime"
  },
  {
    "Id": "cb3e9a95-7ff9-4779-a5d0-50954998a847",
    "Name": "dotnet-wasi-sdk",
    "DefaultBranch": "refs/heads/dotnet/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wasi-sdk"
  },
  {
    "Id": "f6ee1f5a-68cb-4c7a-99cf-ba29cd78c3f7",
    "Name": "dotnet-wcf",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wcf"
  },
  {
    "Id": "4c393a1f-9ca2-41ad-95b2-df9958c21bdd",
    "Name": "dotnet-websdk",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-websdk"
  },
  {
    "Id": "42923f01-804a-4f66-ba0a-88c8efc9be06",
    "Name": "dotnet-windowsdesktop",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-windowsdesktop"
  },
  {
    "Id": "e17e84b9-496b-4c7d-9107-efa761b0cc2b",
    "Name": "dotnet-winforms",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-winforms"
  },
  {
    "Id": "b8e73b2c-53fe-4e82-9a61-ba1ecc5c876d",
    "Name": "dotnet-winforms-datavisualization",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-datavisualization"
  },
  {
    "Id": "5228f6f0-9f87-453f-b1f4-0461561fb637",
    "Name": "dotnet-winforms-designer",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-designer"
  },
  {
    "Id": "35f83b7f-7477-490a-a7ce-f1dde51bd9d9",
    "Name": "dotnet-wix",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wix"
  },
  {
    "Id": "5ef95d2a-65a5-4fd1-9b1f-139c2a0df5f3",
    "Name": "dotnet-wix3",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wix3"
  },
  {
    "Id": "5804311d-b24f-4628-8ea2-fef23bff0f05",
    "Name": "dotnet-workloads",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-workloads"
  },
  {
    "Id": "9bf23f35-d189-4c1e-b595-09a667b48490",
    "Name": "dotnet-workload-versions",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-workload-versions"
  },
  {
    "Id": "6c03b454-12c7-4c55-add0-b4ac2ab19c36",
    "Name": "dotnet-wpf",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf"
  },
  {
    "Id": "916d3624-e2f6-4b4c-a706-fee903ac8496",
    "Name": "dotnet-wpf-int",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int"
  },
  {
    "Id": "3f6334d6-e7aa-4f0a-9e06-f350b6560b38",
    "Name": "dotnet-wpf-int.ashish.singh",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.ashish.singh"
  },
  {
    "Id": "460782d5-ce3a-4241-a8dc-a93c54dda731",
    "Name": "dotnet-wpf-int.sam.bent",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.sam.bent"
  },
  {
    "Id": "775c39d4-e006-42fb-921b-97f7e747fe7c",
    "Name": "dotnet-wpf-int.vishal.sharma",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.vishal.sharma"
  },
  {
    "Id": "2e0c2b3c-7e82-449e-bc83-fd38faf47f33",
    "Name": "dotnet-wpf-samples",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-samples"
  },
  {
    "Id": "5b07b69f-386b-4827-9ff9-89bcdbede412",
    "Name": "dotnet-wpf-test.sambent",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test.sambent"
  },
  {
    "Id": "8518491f-0b30-443b-8bc0-2a1a9c6a6c0a",
    "Name": "dotnet-wpf-test-internal",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal"
  },
  {
    "Id": "8e7dc39d-ac36-4957-973b-029a0f078007",
    "Name": "dotnet-wpf-test-internal.sam.bent",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal.sam.bent"
  },
  {
    "Id": "5d004463-12ad-4a74-9732-aa1b537294b8",
    "Name": "dotnet-wpf-test-public",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-public"
  },
  {
    "Id": "b4661d8a-71d6-4743-87ea-6670638bbf10",
    "Name": "dotnet-xcsync",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-xcsync"
  },
  {
    "Id": "cb9fa841-d5dc-4c0f-aefd-52a9b43335e1",
    "Name": "dotnet-xdt",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-xdt"
  },
  {
    "Id": "72b98b9a-6908-4506-a490-82f98dd3b263",
    "Name": "dotnet-xharness",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-xharness"
  },
  {
    "Id": "9ba52ca5-54ad-4466-a502-11fb7cc50cab",
    "Name": "dotnet-xliff-tasks",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-xliff-tasks"
  },
  {
    "Id": "8f3fd539-18a8-4487-8713-2b98c164c70b",
    "Name": "dotnet-yarp",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/dotnet-yarp"
  },
  {
    "Id": "48da72e1-2327-4b58-bb37-5a833fe03b00",
    "Name": "em-tools",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/em-tools"
  },
  {
    "Id": "96eef00a-7626-4355-a097-763c01013fd0",
    "Name": "go-canary",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/go-canary"
  },
  {
    "Id": "08fa09fa-03e1-4a19-8149-16be2805c28d",
    "Name": "hello-demo",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/hello-demo"
  },
  {
    "Id": "43638697-b2a0-477d-a1b0-1024688bb072",
    "Name": "levib.dataset-filter",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/levib.dataset-filter"
  },
  {
    "Id": "3092b6af-cca7-49ba-92f2-4a9e5b645fed",
    "Name": "levib.safebinaryformatter",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/levib.safebinaryformatter"
  },
  {
    "Id": "4d7627dd-a5b2-46c1-8f8e-e157658221de",
    "Name": "Linux-Files-Signing",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing"
  },
  {
    "Id": "1ae0da05-ebff-4d67-98eb-c3b13001b28c",
    "Name": "Linux-Files-Signing.epsitha.ananth",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing.epsitha.ananth"
  },
  {
    "Id": "6e331e23-a282-4e77-81f2-023fd5800181",
    "Name": "maestro-test1",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/maestro-test1"
  },
  {
    "Id": "e6f2a2fb-be51-4de9-b065-0f1430bc5f46",
    "Name": "maestro-test2",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/maestro-test2"
  },
  {
    "Id": "75574b97-7a56-42aa-b314-495f409597a5",
    "Name": "maestro-test3",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/maestro-test3"
  },
  {
    "Id": "3be8ae06-5660-4116-9041-0ce72b7c9a15",
    "Name": "Microsoft-clrmd",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/Microsoft-clrmd"
  },
  {
    "Id": "30ea1589-d1f9-4bf5-bf88-c01f336f3adc",
    "Name": "microsoft-code-coverage",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-code-coverage"
  },
  {
    "Id": "ce821efb-3d36-4457-9fad-a05db83fc1e9",
    "Name": "microsoft-dotnet-framework-docker",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-dotnet-framework-docker"
  },
  {
    "Id": "a10d52a7-9b71-4a8a-afc6-7e10d21a46d1",
    "Name": "microsoft-fluentui-blazor",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-fluentui-blazor"
  },
  {
    "Id": "5b09aaa7-b9fb-4319-9f84-64b0b85fe520",
    "Name": "microsoft-go",
    "DefaultBranch": "refs/heads/microsoft/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go"
  },
  {
    "Id": "9544b3b2-ae80-4f22-b4f3-1a550105f3aa",
    "Name": "microsoft-go-images",
    "DefaultBranch": "refs/heads/microsoft/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-images"
  },
  {
    "Id": "da7f3dc8-8bda-455c-bb1c-c35aed69eba6",
    "Name": "microsoft-go-infra",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra"
  },
  {
    "Id": "0de0a4df-7f53-4eeb-8700-001b2bc50060",
    "Name": "microsoft-go-infra-images",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra-images"
  },
  {
    "Id": "96458575-0769-4b0c-baf6-1474a046e547",
    "Name": "microsoft-go-mirror",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-mirror"
  },
  {
    "Id": "966977df-1315-49f8-ac4b-8e75ccca51ba",
    "Name": "microsoft-go-pdb",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-pdb"
  },
  {
    "Id": "d0944467-6a6a-4a22-bf04-3daf78fa95f2",
    "Name": "microsoft-go-x-net",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-go-x-net"
  },
  {
    "Id": "e63b189f-f787-493a-8668-7bbf2041c274",
    "Name": "microsoft-testfx",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-testfx"
  },
  {
    "Id": "ef257391-4d76-4240-8649-3f21ac49c392",
    "Name": "microsoft-vstest",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/microsoft-vstest"
  },
  {
    "Id": "a6d7b578-1ec7-405e-9334-941e6f43cfb6",
    "Name": "mistucke-ownership-test",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mistucke-ownership-test"
  },
  {
    "Id": "645b2533-288b-4806-b3b1-6baa7e183b60",
    "Name": "mono-api-doc-tools",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-api-doc-tools"
  },
  {
    "Id": "3abeed71-8ee1-4164-b704-925ff4d49f96",
    "Name": "mono-api-snapshot",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-api-snapshot"
  },
  {
    "Id": "e4dc65cf-b42d-4d3c-bf8b-ec014d5e60ae",
    "Name": "mono-aspnetwebstack",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-aspnetwebstack"
  },
  {
    "Id": "f499eedd-fd80-483d-a9e7-e08986c79a9a",
    "Name": "mono-bockbuild",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-bockbuild"
  },
  {
    "Id": "71c2f825-610a-451b-ac48-d657799676f4",
    "Name": "mono-boringssl",
    "DefaultBranch": "refs/heads/mono",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-boringssl"
  },
  {
    "Id": "0672a186-a85b-4469-9358-233797afb091",
    "Name": "mono-corefx",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-corefx"
  },
  {
    "Id": "748abe38-f5bc-4d47-845c-e40fdb1f092b",
    "Name": "mono-corert",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-corert"
  },
  {
    "Id": "4f9ef717-3e1d-4e92-a6d4-4b8051149a71",
    "Name": "mono-helix-binaries",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-helix-binaries"
  },
  {
    "Id": "ea861a51-7439-4b13-a94c-74373f021a5e",
    "Name": "mono-ikdasm",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-ikdasm"
  },
  {
    "Id": "a278fdf2-308d-4af5-aeb9-223b94e6e8c2",
    "Name": "mono-ikvm-fork",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-ikvm-fork"
  },
  {
    "Id": "3a1911fb-777f-4b24-b826-bd910d787463",
    "Name": "mono-illinker-test-assets",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-illinker-test-assets"
  },
  {
    "Id": "2ecfb9c3-23c6-42a7-90c2-f5ed3aec6a48",
    "Name": "mono-llvm",
    "DefaultBranch": "refs/heads/release_60",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-llvm"
  },
  {
    "Id": "14ccce4a-b17f-498b-a1a2-8a01e9f00cfb",
    "Name": "mono-mono",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-mono"
  },
  {
    "Id": "2115a432-d772-4792-8522-9923578e881b",
    "Name": "mono-mono.posix",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-mono.posix"
  },
  {
    "Id": "ea107157-da27-461f-8c66-bf9d5272c78f",
    "Name": "mono-Newtonsoft.Json",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-Newtonsoft.Json"
  },
  {
    "Id": "1dfefa6f-cb05-4fbf-b64c-bfea953e31b0",
    "Name": "mono-NuGet.BuildTasks",
    "DefaultBranch": "refs/heads/dev",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-NuGet.BuildTasks"
  },
  {
    "Id": "e14bcca1-36ea-4c9b-ab0f-7349441ee67a",
    "Name": "mono-NUnitLite",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-NUnitLite"
  },
  {
    "Id": "432e7327-56bf-4026-91f4-829c97f1c0de",
    "Name": "mono-reference-assemblies",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-reference-assemblies"
  },
  {
    "Id": "9bff0a55-b1f8-4313-9af8-455e59829a25",
    "Name": "mono-roslyn-binaries",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-roslyn-binaries"
  },
  {
    "Id": "154243fa-07a5-4d88-a22d-302ab86d5ba1",
    "Name": "mono-rx",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-rx"
  },
  {
    "Id": "f2b35dc4-78ce-4965-a63d-ebf478840110",
    "Name": "mono-xunit-binaries",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/mono-xunit-binaries"
  },
  {
    "Id": "ef9ad533-72d4-464e-a99a-c05171750541",
    "Name": "MSBuild-history",
    "DefaultBranch": "refs/heads/sd-feature-msbuild1",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/MSBuild-history"
  },
  {
    "Id": "56ed64ba-3ff0-4233-b3e3-ffba0200ed02",
    "Name": "MSTest",
    "DefaultBranch": null,
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/MSTest"
  },
  {
    "Id": "ca90c8f2-ed36-4b1b-b3eb-9821cfec78f4",
    "Name": "net-acquisition-wiki",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/net-acquisition-wiki"
  },
  {
    "Id": "404672cc-b197-43b1-a295-125f77b24474",
    "Name": "netcoremigrationtools",
    "DefaultBranch": "refs/heads/master",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/netcoremigrationtools"
  },
  {
    "Id": "34f46773-b26a-426f-a1df-c125ff7162b8",
    "Name": "nuget-packageSourceMapper",
    "DefaultBranch": "refs/heads/dev",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/nuget-packageSourceMapper"
  },
  {
    "Id": "ba2bf4f3-a049-4345-8ae3-7eaac37d3278",
    "Name": "razor-toolset-tests",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/razor-toolset-tests"
  },
  {
    "Id": "5cea8b1e-0355-4cbf-b567-88d24d66e934",
    "Name": "rebrand-package",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/rebrand-package"
  },
  {
    "Id": "8514c9b5-5b03-4ce8-ae2a-5702e20b332f",
    "Name": "security-partners-dotnet",
    "DefaultBranch": "refs/heads/release/6.0.1xx",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet"
  },
  {
    "Id": "fab18919-8520-4c7e-9467-4704c32e8152",
    "Name": "SignalR-SignalR",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/SignalR-SignalR"
  },
  {
    "Id": "b6d44ded-d789-46eb-88e5-e4a38f782bff",
    "Name": "SnapshotParser",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/SnapshotParser"
  },
  {
    "Id": "1b7339e4-b184-45d2-ba99-93256efc0937",
    "Name": "source-build-validation",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/source-build-validation"
  },
  {
    "Id": "e9c5424e-c726-4a63-8cca-f69255e13c5b",
    "Name": "source-build-validation-spd",
    "DefaultBranch": "refs/heads/main",
    "WebUrl": "https://dev.azure.com/dnceng/internal/_git/source-build-validation-spd"
  }
]
```


- **Raw Results**:
```json
{
  "ai_tool_selection_response": "{\n  \u0022tool\u0022: \u0022get_repositories\u0022,\n  \u0022parameters\u0022: {\n    \u0022projectName\u0022: \u0022internal\u0022\n  }\n}",
  "raw_result": "{\u0022content\u0022:[{\u0022type\u0022:\u0022text\u0022,\u0022text\u0022:\u0022[\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220fb8b8ae-99ee-41f1-97c4-e9b8ef876b13\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022Antigen\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/Antigen\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c3aad48b-429d-4bc3-aa50-f7903375895c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022ARM-LanguageServer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/ARM-LanguageServer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224b7f10b6-89f4-46cf-8858-4c21032ec66a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspLabs\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspLabs\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022908f26b7-443e-4544-9984-8fe26352b4f1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetCore\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetCore\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226579f0ed-6878-4ead-85df-6a04d4b6cde2\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetIdentity\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetIdentity\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002278917a76-6f36-4865-b90e-47f343550f3a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetKatana\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetKatana\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022433105d3-d1fc-4232-b0d0-546a7900d9d5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetWebHooks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022dc361fd8-f928-4e3f-ae44-850da35f38be\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetWebHooks-Signed\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks-Signed\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022221add85-75f1-4303-b09b-8f6028ccc36c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-AspNetWebStack\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebStack\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223f12bc76-bc5a-4d7f-a90b-31eabfff881c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-Benchmarks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Benchmarks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228ab873cd-74a7-47dd-90b6-4fb6381b9bc9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-BrowserLink\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-BrowserLink\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022048ab2f0-d7a0-4be5-8bd5-6bd71b56dbad\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-BuildTools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/2.1\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-BuildTools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220ac82848-3e47-47b3-bd88-07b74548be27\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-Extensions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Extensions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002231d35b61-8053-45ec-8653-48f6404abb05\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-FrameworkBenchmarks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-FrameworkBenchmarks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002295118702-0e4e-435d-b59e-ff9310cf0b8e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-Identity\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Identity\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225518f25c-7192-4320-a66d-c70324d19a15\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-Identity-Legacy\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Identity-Legacy\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b126af0e-1423-4398-99e6-5ef14271220a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-internal-tools-archived\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-internal-tools-archived\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022474e9f62-3006-456c-a61d-61233698d4de\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-jquery-validation-unobtrusive\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-jquery-validation-unobtrusive\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002245d01372-621f-471a-9c4d-9969f77635f7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-LibraryManager\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-LibraryManager\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002247f86d0e-9ff6-4901-9f63-8befbbf05b63\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-SignalR-Client-Cpp\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-SignalR-Client-Cpp\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002257d0248f-498b-4785-9648-dd4f2be6dd0a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-WebStackRuntime-Build\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Build\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002259fd3cc9-1f51-4790-90cd-9c537d676f4f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022aspnet-WebStackRuntime-Legacy\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Legacy\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220d907d53-ad88-40ed-bd2e-4c90d31c9840\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022azure-identitymodel\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dev\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/azure-identitymodel\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a18923b2-030f-4bc9-96c7-fd88a2242812\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022chcosta-cloudtest\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/chcosta-cloudtest\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224b401012-a64d-4042-bd90-d81e252f6de8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022chcosta-playground\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/chcosta-playground\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ed30c7a3-33d8-47c2-ac65-fdcf6ecddcc6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022chcosta-serviceconnection-info\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/chcosta-serviceconnection-info\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022952f0784-7a17-49ec-aeaa-794d3b9f5715\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022core\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/core\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002208aee660-1e7b-49bb-a222-3e059e65146d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022cve-tracker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/cve-tracker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002211bae2ce-65e5-4930-9670-2414bab54f38\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022depmon\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/depmon\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022621308f4-28ee-4c10-bbdd-c45963a01c1b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dnceng-ai-experimental\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c8763941-2e78-47ab-970e-e904e70d7641\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dnceng-azdo-extension\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dnceng-azdo-extension\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002291b088f2-b580-4d71-8e8e-2afb8cb032da\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-ad-wiki\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ad-wiki\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222727f17c-f5b3-4a73-8a9e-23cdc0e3951f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-android\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/MarkInstantiated\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-android\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b94bcab0-e0db-4a83-8829-2694f366e303\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-api-catalog-infra\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-api-catalog-infra\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d551d0d5-053b-400b-99d7-56e9c6c469c4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-arcade\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b4244e83-7024-4d37-b799-43e60cf72daa\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-arcade.mmitche\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade.mmitche\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224eb601ef-1520-45ca-aa5c-a72055e4a77a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-arcade-extensions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-extensions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ec29e881-6ad7-4427-832d-ce639ccba518\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-arcade-services\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-services\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022017fb734-e4b4-4cc1-a90f-98a09ac25cd5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-arcade-validation\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-validation\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ecc7dc1d-c809-460e-8d0f-6712313d5180\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-aspire\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspire\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220e513bbe-d00b-478b-b59e-8131bc3e15d7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-aspire-samples\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspire-samples\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002223330b81-8bf6-4092-af7d-db8dfba063b8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-aspnetcore\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspnetcore\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022faaf5a32-61f8-482b-aaab-c41d45ac0905\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-astra\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-astra\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022bb4cf35e-4179-4def-9b65-aecf09681592\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-binaryen\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-binaryen\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226122397d-05a0-49e6-8c17-22838898ceab\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-buildanalyzer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-buildanalyzer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227bf030f5-9fb7-4a2d-b3cf-b64b78ce6ebb\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cecil\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cecil\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002223ae4d32-d059-4aae-b3fb-8a9378d076ac\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cli\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/3.1.4xx\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022081e1a92-160e-452b-8629-825c3ef60bd5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-clickonce-test\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-clickonce-test\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002246fc2fc7-f5e8-4aff-aab4-6f44497c0e72\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cliCommandLineParser\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cliCommandLineParser\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022caf9bd58-889d-4e8a-a79d-ce5b51b695d9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cli-lab\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli-lab\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022784b92ee-524b-4d67-ac23-a67b3063a9e8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cli-migrate\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli-migrate\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d44655e1-da3a-467f-9ead-988fd5b17ae1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-command-line-api\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-command-line-api\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e564d7e2-51dd-4f28-adcc-b44f10b9216f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-coreclr\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/3.1\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ee0b6d25-f5f6-4c7b-8188-bc6c65b22a92\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-coreclr.petersol\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr.petersol\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d3f5a5df-1c0c-4590-a52c-c6347e755d54\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-corefx\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/internal/release/3.1-packages\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-corefx\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c084b7c7-0ba9-4b1f-93aa-d8b8f5f877f9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-corescan\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-corescan\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a873616e-a561-4197-8b57-50d597e10f79\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-core-setup\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/3.1\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-core-setup\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002261834684-2995-4b3d-886b-594a110fc34e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cpython\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cpython\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223243797b-b8a1-4282-b1be-efaab372b28d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-crank\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-crank\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002280cd07de-7dde-443b-a0e9-2f9dd2380d7a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cssparser\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cssparser\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229760da74-5bf5-4f53-ad86-23dbee9715f0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-cve\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cve\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224f97fc4f-6e4e-4b09-b4e8-7bd50ecd61ee\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-ddfun\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ddfun\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022924cd040-9411-4903-932f-12bdaf3f1db3\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-debugger-contracts\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-debugger-contracts\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229922e4b0-f11d-4071-879d-f8d3171a12be\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-deployment-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-deployment-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228d7f53cd-f3b5-4b54-a635-31dd397b5cf3\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-diagnostics\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022083b9e02-93f9-460d-8b2b-d555754bab3c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-diagnostics-internal-components\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics-internal-components\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e6e646f0-a7a0-4307-bad7-1c12505c8fd5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-diagnostictests\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e526d7ad-7188-43ef-89c9-60f5629ba608\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-diagnostictests.tom.mcdonald\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests.tom.mcdonald\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a7561977-2f83-4138-94d2-dbef522275ad\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dnceng\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f7b9a526-8d8a-4570-a59d-e13c6c547617\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dnceng-internal\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-internal\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002216bcb0ca-49cf-42c6-82d9-cba9ca52e801\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dnceng-shared\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-shared\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ba59d1a9-c352-46eb-8566-7ddf9a2bcdba\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-docker-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225eedc4d6-2029-47cb-ad4b-767d9a48eb00\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-docker-tools-internal\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools-internal\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ddda0dd6-918f-48ba-ba8f-730d9d8c9320\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e1c1cfff-9e98-4865-abbe-c94eeb214875\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet.matt.mitchell\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet.matt.mitchell\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022fcd803f1-3625-4a55-b725-6ffb6e2a8967\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-buildtools-prereqs-docker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-buildtools-prereqs-docker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222a545fef-bbd2-4b2c-bd12-601823b64d30\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-cli-archiver\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-cli-archiver\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022dbd8d413-6f88-419c-a86d-9323896b8997\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-docker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-docker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f86a5a24-347b-4698-b3ab-54e3378aab3c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-monitor\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002269ddfe0c-12e8-41f4-a235-5c35bd37c72a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-monitor-internal-docker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-docker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00221a8964a7-b5e0-4be1-a326-e9f7bdcf676b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-monitor-internal-extensions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-extensions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002262677cb9-d786-4489-9a44-a4a10a80f086\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-dotnet-monitor-release\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-release\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00221b53f110-df2e-43ca-b0a2-a6dedd902105\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-ef6\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ef6\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002275f066b1-b16b-405e-8a98-eaba58437cd7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-efcore\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-efcore\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022806ff0d0-8761-4e92-a4a5-aa3fdea51fa8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-emscripten\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-emscripten\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cffc2737-8b0d-4be2-b2ed-66f5e0185add\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-emsdk\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-emsdk\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226afad562-b2ee-4a5b-ab3d-2a738b1ecb11\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-eng-wiki\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/wikiMaster\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228756d1b0-48ee-40ce-903f-ff870d62447b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-eng-wiki.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/wikiMaster\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002273ed6287-581b-49ad-8a63-9c98f5a97fc4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-eShop\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eShop\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002281d264ec-3d9c-4bde-a06f-1b771c1efc58\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-extensions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-extensions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a0b2c458-ad9c-4fd9-8287-8b8c5bae840e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-format\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-format\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022be92e3fd-f77c-4ee9-9bf4-28d26e2ecf5e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-fsharp\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-fsharp\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226a6f8dde-7937-4fe3-856f-38bdc6d0e1fe\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-fuzzing-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-fuzzing-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022569090e3-cc96-4250-a2d3-cd9b0039aa14\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-machines\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224267f8dc-bbe1-4d40-bc69-e53f1497e27b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-machines.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b446d7ab-be6b-4949-aa44-214eef7e35bb\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-service\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224205878f-43fd-4391-b8ff-a9b6f3cbeefd\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-service.djuradj.kurepa\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.djuradj.kurepa\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002289e96953-80a5-4d1b-9323-cddf6e74d403\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-service.eananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.eananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d18df941-982c-48b2-8121-fb3cbd9a539b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-helix-service.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a1795d51-9245-4fd1-95bf-865d12f9d9da\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-hotreload-utils\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-hotreload-utils\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002238d59875-8dbd-482a-b29d-88ba20f17b05\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-HttpRepl\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-HttpRepl\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022060a2d9e-c73d-4f6d-8cae-014a3d77bf09\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-icu\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-icu\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002287545870-fc7b-4a69-8085-60e8714e7e2d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-insertions-client\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-insertions-client\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c20f712b-f093-40de-9013-d6b084c1ff30\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-installer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/internal/release/8.0.4xx\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-installer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222fd71809-ca84-4a26-bc1c-89b22cb1cd08\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-install-script-monitors\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-install-script-monitors\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022bc64e819-1723-40fa-85c5-4fee241b3ea4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-install-scripts\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-install-scripts\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002233561aa0-bdde-4a4b-9260-1b86f6ad55b8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-interactive\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227c34466a-fd79-4441-891f-11a9039974db\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-interactive-internal\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-internal\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002217c7829a-e1d7-465e-8973-cbc6da01f84a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-interactive-window\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-window\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ade62c71-67f5-441c-8446-f3520518a5df\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-jitutils\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/AndyAyersMS-patch-1\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-jitutils\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cf088168-84f3-44de-991c-1772c0df5c3a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-linker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-linker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c7d0088e-3677-4adb-b40b-5dc6600a7192\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-llvm-project\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main-19.x\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002230b7e789-d5ab-40dc-9c24-0cf2f6e60055\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-llvm-project.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/11.x\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229dc604dc-e848-480e-87fd-450b10b6b2fc\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-machinelearning\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222f49f4d0-c02f-4261-85ee-7186a9e61acc\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-machinelearning-assets\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning-assets\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022881f35c8-201a-44a8-aec4-4e848662623d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-macios\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/2023-01-24-main-backup\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-macios\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f314c194-4581-497d-a61a-bbc4c5ccf7f6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-maintenance-packages\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-maintenance-packages\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a8060d6f-4bda-43b2-b0a8-d68d713e502c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-maui\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-maui\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226fae92a1-6d6a-4912-9a6a-558211d4a57b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-merge-policy-auditor\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-merge-policy-auditor\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002251ce3f38-1a43-4370-9a54-3a65bc6952b9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-metadata-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-metadata-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224683223d-cb68-4e89-9e5c-d676f9e89b5e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-migrate-package\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-migrate-package\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227d88a321-7ea0-4ec5-a5ef-462385618095\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-mirroring\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-mirroring\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002265d3185f-953e-43a3-89fb-6e4a6278bd59\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-msbuild\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224b35011d-d609-4ed1-a1bb-08297406ced2\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-msbuild-language-service\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild-language-service\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002210f12b95-9b7a-4b3a-8451-577f7232b546\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-msquic\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msquic\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c90dccfc-9c61-4f5a-a5e2-289781319b2b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-netnativelegacy\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-netnativelegacy\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b1af3915-27a0-4188-862e-1db960b0dc02\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-node\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-node\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022589b9e05-13ef-4116-b484-708cf9cd10f5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-Nuget.BuildTasks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-Nuget.BuildTasks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220f2ea445-500a-400e-ba80-64f39ad8df33\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-observer-director-bot\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-observer-director-bot\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220bfc737a-3ef3-4a00-8da1-a91bc88f4034\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-optimization\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-optimization\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022093ca8cd-4927-4f35-85af-f7aba3bfb2a7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-org-policy\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-org-policy\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002231ae6529-88fc-4a9f-87e1-3f62aa5cc382\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-orleans\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-orleans\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229015e742-7263-436f-b867-e80787640f30\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-performance\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227f5866c0-e263-4ba8-b019-67463ad0a719\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-performance-infra\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance-infra\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d2000ad2-fe4f-4f44-8bf0-b14904403416\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-performance-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022bca46106-12f7-41ce-88d7-2ec572f0401f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-prodcon-test\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-prodcon-test\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002249ecf959-f1c5-4e02-b526-7cbad8ca89c0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-project-system\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-project-system\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002217f1b4ee-a043-4210-a704-a8f7fc8e90f1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-project-system-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-project-system-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e9669ab7-eab2-4f4a-a461-395c9f9850de\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-ProjFileTools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ProjFileTools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229754e696-9a03-41fb-8b00-d6d88d858fae\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-r9\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-r9\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022459913a4-9029-44c4-9abd-06c5d8fbf997\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-razor\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022eedc9393-3f8c-41e6-b79d-d7c7f7761c8e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-razor-compiler\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor-compiler\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cc38b149-c759-4a3a-af94-1fa707ea835c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-razor-tooling-internal\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor-tooling-internal\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c02a7e43-a426-455b-bba9-335409c459ba\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-release\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227193af62-2fe6-4391-802f-25b48fa300ba\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-release.epananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002213a919be-24f3-4972-8bbe-6d3c1e805a76\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-release.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e34ba2c7-8798-4904-b48e-ad5711d38b47\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-release.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022af85d71f-7e9c-4d38-848e-b069f3713ff9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-release.milena.hristova\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.milena.hristova\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227b863b8d-8cc3-431d-b06b-7136cc32bbe6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d39990a1-ce82-46a7-b40f-df003f7c7c10\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn-analyzers\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-analyzers\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022060f1029-4a43-4ca9-9a78-b8c8c353a3a6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn-debug\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002233cb5e85-797e-4ccb-8fb7-562139269331\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn-debug.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cb6898c9-00a9-409a-9378-0830f61cb61f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn-sdk\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-sdk\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226c3a47fa-4194-4427-9345-5ef530a8cecd\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-roslyn-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a2f9a77f-0d37-4eaf-aecc-5b3ff7457ad6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtime\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cbdfe817-472e-4896-af99-4a58ae00884c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtime.tom.mcdonald\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime.tom.mcdonald\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022573526da-4b93-4a15-bc59-68fbd0ed44ff\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtime-assets\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-assets\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022caae7a43-2653-4182-8839-b92266aa59ec\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtimelab\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/docs\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtimelab\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223693e49f-9d51-4f47-9bf8-1331764908b5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtime-switch\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-switch\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f8d60813-bd0b-46ba-b616-702e997bffc2\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-runtime-xbox\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/8.x-gdk\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-xbox\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b7fa47e7-2361-4fba-a415-2047d3feeaaa\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-Scaffolding\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-Scaffolding\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022877a0ba2-ef60-4914-a2c8-5c2563154654\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-scenario-tests\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-scenario-tests\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227fa5dddb-89e8-4b26-8595-a6d15593e354\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-sdk\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sdk\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d369c65e-97f8-46ed-8adb-c2c512936934\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-sdk-msbuild-dev-util\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sdk-msbuild-dev-util\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227c82db9a-6113-4019-940b-fdaddeadd2f8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-secret-scanner\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-secret-scanner\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022dc55b1f4-ddf2-4ef1-80a7-6046b5d23aa9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-setup\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-setup\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c567171f-7e68-4231-a2fb-a14c0ff8946b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-sign\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sign\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002263be1e6d-1637-44c9-aa1a-568cfe3cc985\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-signed-wix\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-signed-wix\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e4b0ff97-ae77-40c1-bc99-9d9e659866c6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-sleet\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sleet\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002269c2c970-095b-456e-95a7-815a1303748c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002232f3599f-eef6-42cc-8abb-daffc95a8cf8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build.crummel\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build.crummel\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002206e88986-f451-4a51-94b7-e3486b1e7cff\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build-externals\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-externals\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022de34c285-4b5e-4208-bd3b-5c3fe027a516\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build-reference-packages\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-reference-packages\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022801c715e-9ba6-44bb-a97f-446650a133fe\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build-utilities\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f5795c64-4904-4882-a4bf-54df5dc7154e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-build-utilities.dan.seefeldt\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities.dan.seefeldt\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002250706ae1-6430-4ee9-b8f1-42e212175217\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-source-indexer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-indexer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220debd82f-272b-4ae1-a4e3-13d0dd1ce7d3\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-sourcelink\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sourcelink\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222af3710c-4941-4d1b-b78d-5d8194a787d4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-spark\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00227d3d3136-6961-4a46-9a68-a3a80635668c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-spark-extensions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022c4900de8-3a35-45a8-9a53-82fe13f57969\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-spark-extensions.long.ltian\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions.long.ltian\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e2d9608a-5e07-45aa-97eb-2470cf1d2c98\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-spa-templates\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spa-templates\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022747a7e2e-5a1e-40fc-9bbd-1ec1cdc77219\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-standard\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/archive\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-standard\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d48d8ed4-4c4a-416e-9cc9-172030a8fc0e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-symreader\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226f9a3366-7703-4073-b408-4e8efc0d658a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-symreader-converter\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-converter\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022312b9e9a-cc52-4b85-902f-5b8093051080\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-symreader-portable\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-portable\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022789956e6-59e0-4c15-8747-dee86fda60bd\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-symstore\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symstore\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022dc3dbd38-9381-4069-a45b-117c2a038ba4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-symuploader\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/pre-2gb-support\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symuploader\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002212820810-4d07-4d8e-ab92-d5c23f3e7c70\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-systemweb-adapters\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-systemweb-adapters\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002204ba14b5-08b5-42ff-9646-b12f3504111e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-templating\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-templating\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022178a4a27-6c76-4fc9-a386-b6e41d5cdcbc\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-testimpactanalysis\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-testimpactanalysis\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022733a9d86-dd45-4192-afb4-63796bc6722e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-test-templates\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-test-templates\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022dc259702-907a-4816-8b01-59be9814c0f5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-thrive-dataservice\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-thrive-dataservice\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223f3766c5-d236-41a2-8526-a32b4087bdff\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-toolset\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/internal/release/3.1.4xx\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-toolset\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a6c178a2-3370-45ff-93bf-db4598cee919\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-try\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022fd8f00a8-276e-4439-9e80-5ec71885ab67\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-try-convert\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try-convert\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226e8cd5d4-e809-435b-a3ec-93cd2691c86b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-try-samples\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/feed-update-azdo-dnceng-internal/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try-samples\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002248023595-579f-4f31-8b9d-a9ace4d92b57\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-tye\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-tye\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022da805f51-c182-4914-97b7-4e81b5865d84\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-upgrade-assistant\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-upgrade-assistant\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022052650a2-0aaf-4766-8a72-b5340ecaedb0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-uwp-setup\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-uwp-setup\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a955c2c9-c551-4e85-9f04-089f5e519fd0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-versions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-versions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002263e32aa5-8db9-4c0d-8886-e8ec4b36e8d7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-vscode-csharp\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-csharp\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d39a7e10-161c-478c-a0c5-d778070a1e61\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-vscode-dotnet-installer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-installer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223fe94c62-8adb-47db-a753-2b42c5e078de\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-vscode-dotnet-pack\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-pack\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f2ac372b-f16d-437b-94e7-c306f9ae5431\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-vscode-dotnet-runtime\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-runtime\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cb3e9a95-7ff9-4779-a5d0-50954998a847\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wasi-sdk\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dotnet/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wasi-sdk\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f6ee1f5a-68cb-4c7a-99cf-ba29cd78c3f7\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wcf\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wcf\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224c393a1f-9ca2-41ad-95b2-df9958c21bdd\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-websdk\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-websdk\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002242923f01-804a-4f66-ba0a-88c8efc9be06\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-windowsdesktop\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-windowsdesktop\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e17e84b9-496b-4c7d-9107-efa761b0cc2b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-winforms\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b8e73b2c-53fe-4e82-9a61-ba1ecc5c876d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-winforms-datavisualization\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-datavisualization\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225228f6f0-9f87-453f-b1f4-0461561fb637\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-winforms-designer\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-designer\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002235f83b7f-7477-490a-a7ce-f1dde51bd9d9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wix\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wix\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225ef95d2a-65a5-4fd1-9b1f-139c2a0df5f3\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wix3\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wix3\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225804311d-b24f-4628-8ea2-fef23bff0f05\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-workloads\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-workloads\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229bf23f35-d189-4c1e-b595-09a667b48490\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-workload-versions\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-workload-versions\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226c03b454-12c7-4c55-add0-b4ac2ab19c36\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022916d3624-e2f6-4b4c-a706-fee903ac8496\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-int\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223f6334d6-e7aa-4f0a-9e06-f350b6560b38\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-int.ashish.singh\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.ashish.singh\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022460782d5-ce3a-4241-a8dc-a93c54dda731\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-int.sam.bent\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.sam.bent\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022775c39d4-e006-42fb-921b-97f7e747fe7c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-int.vishal.sharma\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.vishal.sharma\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222e0c2b3c-7e82-449e-bc83-fd38faf47f33\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-samples\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-samples\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225b07b69f-386b-4827-9ff9-89bcdbede412\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-test.sambent\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test.sambent\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228518491f-0b30-443b-8bc0-2a1a9c6a6c0a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-test-internal\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228e7dc39d-ac36-4957-973b-029a0f078007\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-test-internal.sam.bent\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal.sam.bent\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225d004463-12ad-4a74-9732-aa1b537294b8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-wpf-test-public\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-public\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b4661d8a-71d6-4743-87ea-6670638bbf10\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-xcsync\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xcsync\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022cb9fa841-d5dc-4c0f-aefd-52a9b43335e1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-xdt\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xdt\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002272b98b9a-6908-4506-a490-82f98dd3b263\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-xharness\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xharness\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229ba52ca5-54ad-4466-a502-11fb7cc50cab\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-xliff-tasks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xliff-tasks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228f3fd539-18a8-4487-8713-2b98c164c70b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022dotnet-yarp\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/dotnet-yarp\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002248da72e1-2327-4b58-bb37-5a833fe03b00\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022em-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/em-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002296eef00a-7626-4355-a097-763c01013fd0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022go-canary\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/go-canary\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002208fa09fa-03e1-4a19-8149-16be2805c28d\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022hello-demo\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/hello-demo\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002243638697-b2a0-477d-a1b0-1024688bb072\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022levib.dataset-filter\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/levib.dataset-filter\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223092b6af-cca7-49ba-92f2-4a9e5b645fed\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022levib.safebinaryformatter\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/levib.safebinaryformatter\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224d7627dd-a5b2-46c1-8f8e-e157658221de\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022Linux-Files-Signing\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00221ae0da05-ebff-4d67-98eb-c3b13001b28c\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022Linux-Files-Signing.epsitha.ananth\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing.epsitha.ananth\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00226e331e23-a282-4e77-81f2-023fd5800181\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022maestro-test1\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/maestro-test1\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e6f2a2fb-be51-4de9-b065-0f1430bc5f46\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022maestro-test2\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/maestro-test2\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002275574b97-7a56-42aa-b314-495f409597a5\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022maestro-test3\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/maestro-test3\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223be8ae06-5660-4116-9041-0ce72b7c9a15\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022Microsoft-clrmd\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/Microsoft-clrmd\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002230ea1589-d1f9-4bf5-bf88-c01f336f3adc\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-code-coverage\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-code-coverage\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ce821efb-3d36-4457-9fad-a05db83fc1e9\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-dotnet-framework-docker\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-dotnet-framework-docker\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a10d52a7-9b71-4a8a-afc6-7e10d21a46d1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-fluentui-blazor\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-fluentui-blazor\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225b09aaa7-b9fb-4319-9f84-64b0b85fe520\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/microsoft/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229544b3b2-ae80-4f22-b4f3-1a550105f3aa\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-images\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/microsoft/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-images\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022da7f3dc8-8bda-455c-bb1c-c35aed69eba6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-infra\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220de0a4df-7f53-4eeb-8700-001b2bc50060\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-infra-images\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra-images\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002296458575-0769-4b0c-baf6-1474a046e547\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-mirror\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-mirror\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022966977df-1315-49f8-ac4b-8e75ccca51ba\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-pdb\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-pdb\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022d0944467-6a6a-4a22-bf04-3daf78fa95f2\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-go-x-net\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-x-net\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e63b189f-f787-493a-8668-7bbf2041c274\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-testfx\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-testfx\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ef257391-4d76-4240-8649-3f21ac49c392\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022microsoft-vstest\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/microsoft-vstest\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a6d7b578-1ec7-405e-9334-941e6f43cfb6\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mistucke-ownership-test\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mistucke-ownership-test\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022645b2533-288b-4806-b3b1-6baa7e183b60\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-api-doc-tools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-api-doc-tools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223abeed71-8ee1-4164-b704-925ff4d49f96\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-api-snapshot\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-api-snapshot\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e4dc65cf-b42d-4d3c-bf8b-ec014d5e60ae\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-aspnetwebstack\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-aspnetwebstack\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f499eedd-fd80-483d-a9e7-e08986c79a9a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-bockbuild\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-bockbuild\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002271c2f825-610a-451b-ac48-d657799676f4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-boringssl\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/mono\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-boringssl\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00220672a186-a85b-4469-9358-233797afb091\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-corefx\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-corefx\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022748abe38-f5bc-4d47-845c-e40fdb1f092b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-corert\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-corert\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00224f9ef717-3e1d-4e92-a6d4-4b8051149a71\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-helix-binaries\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-helix-binaries\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ea861a51-7439-4b13-a94c-74373f021a5e\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-ikdasm\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-ikdasm\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022a278fdf2-308d-4af5-aeb9-223b94e6e8c2\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-ikvm-fork\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-ikvm-fork\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00223a1911fb-777f-4b24-b826-bd910d787463\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-illinker-test-assets\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-illinker-test-assets\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222ecfb9c3-23c6-42a7-90c2-f5ed3aec6a48\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-llvm\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release_60\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-llvm\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002214ccce4a-b17f-498b-a1a2-8a01e9f00cfb\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-mono\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-mono\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00222115a432-d772-4792-8522-9923578e881b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-mono.posix\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-mono.posix\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ea107157-da27-461f-8c66-bf9d5272c78f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-Newtonsoft.Json\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-Newtonsoft.Json\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00221dfefa6f-cb05-4fbf-b64c-bfea953e31b0\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-NuGet.BuildTasks\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dev\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-NuGet.BuildTasks\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e14bcca1-36ea-4c9b-ab0f-7349441ee67a\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-NUnitLite\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-NUnitLite\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022432e7327-56bf-4026-91f4-829c97f1c0de\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-reference-assemblies\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-reference-assemblies\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00229bff0a55-b1f8-4313-9af8-455e59829a25\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-roslyn-binaries\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-roslyn-binaries\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022154243fa-07a5-4d88-a22d-302ab86d5ba1\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-rx\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-rx\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022f2b35dc4-78ce-4965-a63d-ebf478840110\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022mono-xunit-binaries\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/mono-xunit-binaries\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ef9ad533-72d4-464e-a99a-c05171750541\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022MSBuild-history\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/sd-feature-msbuild1\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/MSBuild-history\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002256ed64ba-3ff0-4233-b3e3-ffba0200ed02\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022MSTest\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: null,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/MSTest\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ca90c8f2-ed36-4b1b-b3eb-9821cfec78f4\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022net-acquisition-wiki\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/net-acquisition-wiki\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022404672cc-b197-43b1-a295-125f77b24474\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022netcoremigrationtools\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/master\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/netcoremigrationtools\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u002234f46773-b26a-426f-a1df-c125ff7162b8\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022nuget-packageSourceMapper\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/dev\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/nuget-packageSourceMapper\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022ba2bf4f3-a049-4345-8ae3-7eaac37d3278\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022razor-toolset-tests\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/razor-toolset-tests\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00225cea8b1e-0355-4cbf-b567-88d24d66e934\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022rebrand-package\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/rebrand-package\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00228514c9b5-5b03-4ce8-ae2a-5702e20b332f\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022security-partners-dotnet\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/release/6.0.1xx\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022fab18919-8520-4c7e-9467-4704c32e8152\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022SignalR-SignalR\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/SignalR-SignalR\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022b6d44ded-d789-46eb-88e5-e4a38f782bff\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022SnapshotParser\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/SnapshotParser\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u00221b7339e4-b184-45d2-ba99-93256efc0937\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022source-build-validation\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/source-build-validation\\u0022\\r\\n  },\\r\\n  {\\r\\n    \\u0022Id\\u0022: \\u0022e9c5424e-c726-4a63-8cca-f69255e13c5b\\u0022,\\r\\n    \\u0022Name\\u0022: \\u0022source-build-validation-spd\\u0022,\\r\\n    \\u0022DefaultBranch\\u0022: \\u0022refs/heads/main\\u0022,\\r\\n    \\u0022WebUrl\\u0022: \\u0022https://dev.azure.com/dnceng/internal/_git/source-build-validation-spd\\u0022\\r\\n  }\\r\\n]\u0022}]}",
  "parsed_results": {
    "content": {
      "items": [
        {
          "type": "text",
          "text": "[\r\n  {\r\n    \u0022Id\u0022: \u00220fb8b8ae-99ee-41f1-97c4-e9b8ef876b13\u0022,\r\n    \u0022Name\u0022: \u0022Antigen\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/Antigen\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c3aad48b-429d-4bc3-aa50-f7903375895c\u0022,\r\n    \u0022Name\u0022: \u0022ARM-LanguageServer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/ARM-LanguageServer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224b7f10b6-89f4-46cf-8858-4c21032ec66a\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspLabs\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspLabs\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022908f26b7-443e-4544-9984-8fe26352b4f1\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetCore\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetCore\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226579f0ed-6878-4ead-85df-6a04d4b6cde2\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetIdentity\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetIdentity\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002278917a76-6f36-4865-b90e-47f343550f3a\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetKatana\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetKatana\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022433105d3-d1fc-4232-b0d0-546a7900d9d5\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetWebHooks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022dc361fd8-f928-4e3f-ae44-850da35f38be\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetWebHooks-Signed\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebHooks-Signed\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022221add85-75f1-4303-b09b-8f6028ccc36c\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-AspNetWebStack\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-AspNetWebStack\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223f12bc76-bc5a-4d7f-a90b-31eabfff881c\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-Benchmarks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Benchmarks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228ab873cd-74a7-47dd-90b6-4fb6381b9bc9\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-BrowserLink\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-BrowserLink\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022048ab2f0-d7a0-4be5-8bd5-6bd71b56dbad\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-BuildTools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/2.1\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-BuildTools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220ac82848-3e47-47b3-bd88-07b74548be27\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-Extensions\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Extensions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002231d35b61-8053-45ec-8653-48f6404abb05\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-FrameworkBenchmarks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-FrameworkBenchmarks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002295118702-0e4e-435d-b59e-ff9310cf0b8e\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-Identity\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Identity\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225518f25c-7192-4320-a66d-c70324d19a15\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-Identity-Legacy\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-Identity-Legacy\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b126af0e-1423-4398-99e6-5ef14271220a\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-internal-tools-archived\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-internal-tools-archived\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022474e9f62-3006-456c-a61d-61233698d4de\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-jquery-validation-unobtrusive\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-jquery-validation-unobtrusive\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002245d01372-621f-471a-9c4d-9969f77635f7\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-LibraryManager\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-LibraryManager\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002247f86d0e-9ff6-4901-9f63-8befbbf05b63\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-SignalR-Client-Cpp\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-SignalR-Client-Cpp\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002257d0248f-498b-4785-9648-dd4f2be6dd0a\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-WebStackRuntime-Build\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Build\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002259fd3cc9-1f51-4790-90cd-9c537d676f4f\u0022,\r\n    \u0022Name\u0022: \u0022aspnet-WebStackRuntime-Legacy\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/aspnet-WebStackRuntime-Legacy\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220d907d53-ad88-40ed-bd2e-4c90d31c9840\u0022,\r\n    \u0022Name\u0022: \u0022azure-identitymodel\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dev\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/azure-identitymodel\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a18923b2-030f-4bc9-96c7-fd88a2242812\u0022,\r\n    \u0022Name\u0022: \u0022chcosta-cloudtest\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/chcosta-cloudtest\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224b401012-a64d-4042-bd90-d81e252f6de8\u0022,\r\n    \u0022Name\u0022: \u0022chcosta-playground\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/chcosta-playground\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ed30c7a3-33d8-47c2-ac65-fdcf6ecddcc6\u0022,\r\n    \u0022Name\u0022: \u0022chcosta-serviceconnection-info\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/chcosta-serviceconnection-info\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022952f0784-7a17-49ec-aeaa-794d3b9f5715\u0022,\r\n    \u0022Name\u0022: \u0022core\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/core\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002208aee660-1e7b-49bb-a222-3e059e65146d\u0022,\r\n    \u0022Name\u0022: \u0022cve-tracker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/cve-tracker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002211bae2ce-65e5-4930-9670-2414bab54f38\u0022,\r\n    \u0022Name\u0022: \u0022depmon\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/depmon\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022621308f4-28ee-4c10-bbdd-c45963a01c1b\u0022,\r\n    \u0022Name\u0022: \u0022dnceng-ai-experimental\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c8763941-2e78-47ab-970e-e904e70d7641\u0022,\r\n    \u0022Name\u0022: \u0022dnceng-azdo-extension\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dnceng-azdo-extension\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002291b088f2-b580-4d71-8e8e-2afb8cb032da\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-ad-wiki\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ad-wiki\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222727f17c-f5b3-4a73-8a9e-23cdc0e3951f\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-android\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/MarkInstantiated\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-android\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b94bcab0-e0db-4a83-8829-2694f366e303\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-api-catalog-infra\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-api-catalog-infra\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d551d0d5-053b-400b-99d7-56e9c6c469c4\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-arcade\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b4244e83-7024-4d37-b799-43e60cf72daa\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-arcade.mmitche\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade.mmitche\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224eb601ef-1520-45ca-aa5c-a72055e4a77a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-arcade-extensions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-extensions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ec29e881-6ad7-4427-832d-ce639ccba518\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-arcade-services\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-services\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022017fb734-e4b4-4cc1-a90f-98a09ac25cd5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-arcade-validation\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-arcade-validation\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ecc7dc1d-c809-460e-8d0f-6712313d5180\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-aspire\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspire\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220e513bbe-d00b-478b-b59e-8131bc3e15d7\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-aspire-samples\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspire-samples\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002223330b81-8bf6-4092-af7d-db8dfba063b8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-aspnetcore\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-aspnetcore\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022faaf5a32-61f8-482b-aaab-c41d45ac0905\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-astra\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-astra\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022bb4cf35e-4179-4def-9b65-aecf09681592\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-binaryen\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-binaryen\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226122397d-05a0-49e6-8c17-22838898ceab\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-buildanalyzer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-buildanalyzer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227bf030f5-9fb7-4a2d-b3cf-b64b78ce6ebb\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cecil\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cecil\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002223ae4d32-d059-4aae-b3fb-8a9378d076ac\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cli\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/3.1.4xx\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022081e1a92-160e-452b-8629-825c3ef60bd5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-clickonce-test\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-clickonce-test\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002246fc2fc7-f5e8-4aff-aab4-6f44497c0e72\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cliCommandLineParser\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cliCommandLineParser\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022caf9bd58-889d-4e8a-a79d-ce5b51b695d9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cli-lab\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli-lab\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022784b92ee-524b-4d67-ac23-a67b3063a9e8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cli-migrate\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cli-migrate\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d44655e1-da3a-467f-9ead-988fd5b17ae1\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-command-line-api\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-command-line-api\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e564d7e2-51dd-4f28-adcc-b44f10b9216f\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-coreclr\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/3.1\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ee0b6d25-f5f6-4c7b-8188-bc6c65b22a92\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-coreclr.petersol\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-coreclr.petersol\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d3f5a5df-1c0c-4590-a52c-c6347e755d54\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-corefx\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/internal/release/3.1-packages\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-corefx\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c084b7c7-0ba9-4b1f-93aa-d8b8f5f877f9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-corescan\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-corescan\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a873616e-a561-4197-8b57-50d597e10f79\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-core-setup\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/3.1\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-core-setup\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002261834684-2995-4b3d-886b-594a110fc34e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cpython\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cpython\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223243797b-b8a1-4282-b1be-efaab372b28d\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-crank\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-crank\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002280cd07de-7dde-443b-a0e9-2f9dd2380d7a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cssparser\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cssparser\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229760da74-5bf5-4f53-ad86-23dbee9715f0\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-cve\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-cve\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224f97fc4f-6e4e-4b09-b4e8-7bd50ecd61ee\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-ddfun\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ddfun\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022924cd040-9411-4903-932f-12bdaf3f1db3\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-debugger-contracts\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-debugger-contracts\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229922e4b0-f11d-4071-879d-f8d3171a12be\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-deployment-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-deployment-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228d7f53cd-f3b5-4b54-a635-31dd397b5cf3\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-diagnostics\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022083b9e02-93f9-460d-8b2b-d555754bab3c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-diagnostics-internal-components\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostics-internal-components\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e6e646f0-a7a0-4307-bad7-1c12505c8fd5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-diagnostictests\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e526d7ad-7188-43ef-89c9-60f5629ba608\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-diagnostictests.tom.mcdonald\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-diagnostictests.tom.mcdonald\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a7561977-2f83-4138-94d2-dbef522275ad\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dnceng\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f7b9a526-8d8a-4570-a59d-e13c6c547617\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dnceng-internal\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-internal\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002216bcb0ca-49cf-42c6-82d9-cba9ca52e801\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dnceng-shared\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dnceng-shared\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ba59d1a9-c352-46eb-8566-7ddf9a2bcdba\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-docker-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225eedc4d6-2029-47cb-ad4b-767d9a48eb00\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-docker-tools-internal\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-docker-tools-internal\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ddda0dd6-918f-48ba-ba8f-730d9d8c9320\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e1c1cfff-9e98-4865-abbe-c94eeb214875\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet.matt.mitchell\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet.matt.mitchell\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022fcd803f1-3625-4a55-b725-6ffb6e2a8967\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-buildtools-prereqs-docker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-buildtools-prereqs-docker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222a545fef-bbd2-4b2c-bd12-601823b64d30\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-cli-archiver\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-cli-archiver\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022dbd8d413-6f88-419c-a86d-9323896b8997\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-docker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-docker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f86a5a24-347b-4698-b3ab-54e3378aab3c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-monitor\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002269ddfe0c-12e8-41f4-a235-5c35bd37c72a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-monitor-internal-docker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-docker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00221a8964a7-b5e0-4be1-a326-e9f7bdcf676b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-monitor-internal-extensions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-internal-extensions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002262677cb9-d786-4489-9a44-a4a10a80f086\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-dotnet-monitor-release\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-dotnet-monitor-release\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00221b53f110-df2e-43ca-b0a2-a6dedd902105\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-ef6\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ef6\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002275f066b1-b16b-405e-8a98-eaba58437cd7\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-efcore\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-efcore\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022806ff0d0-8761-4e92-a4a5-aa3fdea51fa8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-emscripten\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-emscripten\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cffc2737-8b0d-4be2-b2ed-66f5e0185add\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-emsdk\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-emsdk\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226afad562-b2ee-4a5b-ab3d-2a738b1ecb11\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-eng-wiki\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/wikiMaster\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228756d1b0-48ee-40ce-903f-ff870d62447b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-eng-wiki.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/wikiMaster\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eng-wiki.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002273ed6287-581b-49ad-8a63-9c98f5a97fc4\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-eShop\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-eShop\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002281d264ec-3d9c-4bde-a06f-1b771c1efc58\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-extensions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-extensions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a0b2c458-ad9c-4fd9-8287-8b8c5bae840e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-format\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-format\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022be92e3fd-f77c-4ee9-9bf4-28d26e2ecf5e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-fsharp\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-fsharp\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226a6f8dde-7937-4fe3-856f-38bdc6d0e1fe\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-fuzzing-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-fuzzing-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022569090e3-cc96-4250-a2d3-cd9b0039aa14\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-machines\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224267f8dc-bbe1-4d40-bc69-e53f1497e27b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-machines.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-machines.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b446d7ab-be6b-4949-aa44-214eef7e35bb\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-service\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224205878f-43fd-4391-b8ff-a9b6f3cbeefd\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-service.djuradj.kurepa\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.djuradj.kurepa\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002289e96953-80a5-4d1b-9323-cddf6e74d403\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-service.eananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.eananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d18df941-982c-48b2-8121-fb3cbd9a539b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-helix-service.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-helix-service.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a1795d51-9245-4fd1-95bf-865d12f9d9da\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-hotreload-utils\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-hotreload-utils\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002238d59875-8dbd-482a-b29d-88ba20f17b05\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-HttpRepl\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-HttpRepl\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022060a2d9e-c73d-4f6d-8cae-014a3d77bf09\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-icu\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-icu\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002287545870-fc7b-4a69-8085-60e8714e7e2d\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-insertions-client\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-insertions-client\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c20f712b-f093-40de-9013-d6b084c1ff30\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-installer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/internal/release/8.0.4xx\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-installer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222fd71809-ca84-4a26-bc1c-89b22cb1cd08\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-install-script-monitors\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-install-script-monitors\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022bc64e819-1723-40fa-85c5-4fee241b3ea4\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-install-scripts\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-install-scripts\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002233561aa0-bdde-4a4b-9260-1b86f6ad55b8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-interactive\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227c34466a-fd79-4441-891f-11a9039974db\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-interactive-internal\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-internal\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002217c7829a-e1d7-465e-8973-cbc6da01f84a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-interactive-window\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-interactive-window\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ade62c71-67f5-441c-8446-f3520518a5df\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-jitutils\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/AndyAyersMS-patch-1\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-jitutils\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cf088168-84f3-44de-991c-1772c0df5c3a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-linker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-linker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c7d0088e-3677-4adb-b40b-5dc6600a7192\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-llvm-project\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main-19.x\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002230b7e789-d5ab-40dc-9c24-0cf2f6e60055\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-llvm-project.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/11.x\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-llvm-project.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229dc604dc-e848-480e-87fd-450b10b6b2fc\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-machinelearning\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222f49f4d0-c02f-4261-85ee-7186a9e61acc\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-machinelearning-assets\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-machinelearning-assets\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022881f35c8-201a-44a8-aec4-4e848662623d\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-macios\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/2023-01-24-main-backup\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-macios\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f314c194-4581-497d-a61a-bbc4c5ccf7f6\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-maintenance-packages\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-maintenance-packages\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a8060d6f-4bda-43b2-b0a8-d68d713e502c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-maui\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-maui\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226fae92a1-6d6a-4912-9a6a-558211d4a57b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-merge-policy-auditor\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-merge-policy-auditor\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002251ce3f38-1a43-4370-9a54-3a65bc6952b9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-metadata-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-metadata-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224683223d-cb68-4e89-9e5c-d676f9e89b5e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-migrate-package\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-migrate-package\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227d88a321-7ea0-4ec5-a5ef-462385618095\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-mirroring\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-mirroring\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002265d3185f-953e-43a3-89fb-6e4a6278bd59\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-msbuild\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224b35011d-d609-4ed1-a1bb-08297406ced2\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-msbuild-language-service\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msbuild-language-service\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002210f12b95-9b7a-4b3a-8451-577f7232b546\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-msquic\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-msquic\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c90dccfc-9c61-4f5a-a5e2-289781319b2b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-netnativelegacy\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-netnativelegacy\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b1af3915-27a0-4188-862e-1db960b0dc02\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-node\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-node\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022589b9e05-13ef-4116-b484-708cf9cd10f5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-Nuget.BuildTasks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-Nuget.BuildTasks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220f2ea445-500a-400e-ba80-64f39ad8df33\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-observer-director-bot\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-observer-director-bot\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220bfc737a-3ef3-4a00-8da1-a91bc88f4034\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-optimization\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-optimization\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022093ca8cd-4927-4f35-85af-f7aba3bfb2a7\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-org-policy\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-org-policy\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002231ae6529-88fc-4a9f-87e1-3f62aa5cc382\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-orleans\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-orleans\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229015e742-7263-436f-b867-e80787640f30\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-performance\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227f5866c0-e263-4ba8-b019-67463ad0a719\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-performance-infra\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance-infra\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d2000ad2-fe4f-4f44-8bf0-b14904403416\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-performance-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-performance-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022bca46106-12f7-41ce-88d7-2ec572f0401f\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-prodcon-test\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-prodcon-test\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002249ecf959-f1c5-4e02-b526-7cbad8ca89c0\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-project-system\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-project-system\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002217f1b4ee-a043-4210-a704-a8f7fc8e90f1\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-project-system-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-project-system-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e9669ab7-eab2-4f4a-a461-395c9f9850de\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-ProjFileTools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-ProjFileTools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229754e696-9a03-41fb-8b00-d6d88d858fae\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-r9\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-r9\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022459913a4-9029-44c4-9abd-06c5d8fbf997\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-razor\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022eedc9393-3f8c-41e6-b79d-d7c7f7761c8e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-razor-compiler\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor-compiler\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cc38b149-c759-4a3a-af94-1fa707ea835c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-razor-tooling-internal\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-razor-tooling-internal\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c02a7e43-a426-455b-bba9-335409c459ba\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-release\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227193af62-2fe6-4391-802f-25b48fa300ba\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-release.epananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002213a919be-24f3-4972-8bbe-6d3c1e805a76\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-release.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e34ba2c7-8798-4904-b48e-ad5711d38b47\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-release.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022af85d71f-7e9c-4d38-848e-b069f3713ff9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-release.milena.hristova\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-release.milena.hristova\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227b863b8d-8cc3-431d-b06b-7136cc32bbe6\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d39990a1-ce82-46a7-b40f-df003f7c7c10\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn-analyzers\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-analyzers\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022060f1029-4a43-4ca9-9a78-b8c8c353a3a6\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn-debug\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002233cb5e85-797e-4ccb-8fb7-562139269331\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn-debug.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-debug.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cb6898c9-00a9-409a-9378-0830f61cb61f\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn-sdk\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-sdk\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226c3a47fa-4194-4427-9345-5ef530a8cecd\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-roslyn-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-roslyn-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a2f9a77f-0d37-4eaf-aecc-5b3ff7457ad6\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtime\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cbdfe817-472e-4896-af99-4a58ae00884c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtime.tom.mcdonald\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime.tom.mcdonald\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022573526da-4b93-4a15-bc59-68fbd0ed44ff\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtime-assets\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-assets\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022caae7a43-2653-4182-8839-b92266aa59ec\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtimelab\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/docs\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtimelab\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223693e49f-9d51-4f47-9bf8-1331764908b5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtime-switch\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-switch\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f8d60813-bd0b-46ba-b616-702e997bffc2\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-runtime-xbox\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/8.x-gdk\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-runtime-xbox\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b7fa47e7-2361-4fba-a415-2047d3feeaaa\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-Scaffolding\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-Scaffolding\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022877a0ba2-ef60-4914-a2c8-5c2563154654\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-scenario-tests\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-scenario-tests\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227fa5dddb-89e8-4b26-8595-a6d15593e354\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-sdk\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sdk\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d369c65e-97f8-46ed-8adb-c2c512936934\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-sdk-msbuild-dev-util\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sdk-msbuild-dev-util\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227c82db9a-6113-4019-940b-fdaddeadd2f8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-secret-scanner\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-secret-scanner\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022dc55b1f4-ddf2-4ef1-80a7-6046b5d23aa9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-setup\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-setup\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c567171f-7e68-4231-a2fb-a14c0ff8946b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-sign\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sign\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002263be1e6d-1637-44c9-aa1a-568cfe3cc985\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-signed-wix\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-signed-wix\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e4b0ff97-ae77-40c1-bc99-9d9e659866c6\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-sleet\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sleet\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002269c2c970-095b-456e-95a7-815a1303748c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002232f3599f-eef6-42cc-8abb-daffc95a8cf8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build.crummel\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build.crummel\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002206e88986-f451-4a51-94b7-e3486b1e7cff\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build-externals\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-externals\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022de34c285-4b5e-4208-bd3b-5c3fe027a516\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build-reference-packages\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-reference-packages\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022801c715e-9ba6-44bb-a97f-446650a133fe\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build-utilities\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f5795c64-4904-4882-a4bf-54df5dc7154e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-build-utilities.dan.seefeldt\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-build-utilities.dan.seefeldt\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002250706ae1-6430-4ee9-b8f1-42e212175217\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-source-indexer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-source-indexer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220debd82f-272b-4ae1-a4e3-13d0dd1ce7d3\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-sourcelink\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-sourcelink\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222af3710c-4941-4d1b-b78d-5d8194a787d4\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-spark\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00227d3d3136-6961-4a46-9a68-a3a80635668c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-spark-extensions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022c4900de8-3a35-45a8-9a53-82fe13f57969\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-spark-extensions.long.ltian\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spark-extensions.long.ltian\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e2d9608a-5e07-45aa-97eb-2470cf1d2c98\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-spa-templates\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-spa-templates\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022747a7e2e-5a1e-40fc-9bbd-1ec1cdc77219\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-standard\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/archive\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-standard\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d48d8ed4-4c4a-416e-9cc9-172030a8fc0e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-symreader\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226f9a3366-7703-4073-b408-4e8efc0d658a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-symreader-converter\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-converter\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022312b9e9a-cc52-4b85-902f-5b8093051080\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-symreader-portable\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symreader-portable\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022789956e6-59e0-4c15-8747-dee86fda60bd\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-symstore\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symstore\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022dc3dbd38-9381-4069-a45b-117c2a038ba4\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-symuploader\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/pre-2gb-support\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-symuploader\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002212820810-4d07-4d8e-ab92-d5c23f3e7c70\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-systemweb-adapters\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-systemweb-adapters\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002204ba14b5-08b5-42ff-9646-b12f3504111e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-templating\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-templating\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022178a4a27-6c76-4fc9-a386-b6e41d5cdcbc\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-testimpactanalysis\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-testimpactanalysis\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022733a9d86-dd45-4192-afb4-63796bc6722e\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-test-templates\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-test-templates\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022dc259702-907a-4816-8b01-59be9814c0f5\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-thrive-dataservice\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-thrive-dataservice\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223f3766c5-d236-41a2-8526-a32b4087bdff\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-toolset\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/internal/release/3.1.4xx\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-toolset\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a6c178a2-3370-45ff-93bf-db4598cee919\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-try\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022fd8f00a8-276e-4439-9e80-5ec71885ab67\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-try-convert\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try-convert\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226e8cd5d4-e809-435b-a3ec-93cd2691c86b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-try-samples\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/feed-update-azdo-dnceng-internal/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-try-samples\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002248023595-579f-4f31-8b9d-a9ace4d92b57\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-tye\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-tye\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022da805f51-c182-4914-97b7-4e81b5865d84\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-upgrade-assistant\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-upgrade-assistant\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022052650a2-0aaf-4766-8a72-b5340ecaedb0\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-uwp-setup\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-uwp-setup\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a955c2c9-c551-4e85-9f04-089f5e519fd0\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-versions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-versions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002263e32aa5-8db9-4c0d-8886-e8ec4b36e8d7\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-vscode-csharp\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-csharp\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d39a7e10-161c-478c-a0c5-d778070a1e61\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-vscode-dotnet-installer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-installer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223fe94c62-8adb-47db-a753-2b42c5e078de\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-vscode-dotnet-pack\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-pack\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f2ac372b-f16d-437b-94e7-c306f9ae5431\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-vscode-dotnet-runtime\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-vscode-dotnet-runtime\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cb3e9a95-7ff9-4779-a5d0-50954998a847\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wasi-sdk\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dotnet/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wasi-sdk\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f6ee1f5a-68cb-4c7a-99cf-ba29cd78c3f7\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wcf\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wcf\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224c393a1f-9ca2-41ad-95b2-df9958c21bdd\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-websdk\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-websdk\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002242923f01-804a-4f66-ba0a-88c8efc9be06\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-windowsdesktop\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-windowsdesktop\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e17e84b9-496b-4c7d-9107-efa761b0cc2b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-winforms\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b8e73b2c-53fe-4e82-9a61-ba1ecc5c876d\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-winforms-datavisualization\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-datavisualization\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225228f6f0-9f87-453f-b1f4-0461561fb637\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-winforms-designer\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-winforms-designer\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002235f83b7f-7477-490a-a7ce-f1dde51bd9d9\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wix\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wix\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225ef95d2a-65a5-4fd1-9b1f-139c2a0df5f3\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wix3\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wix3\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225804311d-b24f-4628-8ea2-fef23bff0f05\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-workloads\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-workloads\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229bf23f35-d189-4c1e-b595-09a667b48490\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-workload-versions\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-workload-versions\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226c03b454-12c7-4c55-add0-b4ac2ab19c36\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022916d3624-e2f6-4b4c-a706-fee903ac8496\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-int\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223f6334d6-e7aa-4f0a-9e06-f350b6560b38\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-int.ashish.singh\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.ashish.singh\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022460782d5-ce3a-4241-a8dc-a93c54dda731\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-int.sam.bent\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.sam.bent\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022775c39d4-e006-42fb-921b-97f7e747fe7c\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-int.vishal.sharma\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-int.vishal.sharma\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222e0c2b3c-7e82-449e-bc83-fd38faf47f33\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-samples\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-samples\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225b07b69f-386b-4827-9ff9-89bcdbede412\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-test.sambent\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test.sambent\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228518491f-0b30-443b-8bc0-2a1a9c6a6c0a\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-test-internal\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228e7dc39d-ac36-4957-973b-029a0f078007\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-test-internal.sam.bent\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-internal.sam.bent\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225d004463-12ad-4a74-9732-aa1b537294b8\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-wpf-test-public\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-wpf-test-public\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b4661d8a-71d6-4743-87ea-6670638bbf10\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-xcsync\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xcsync\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022cb9fa841-d5dc-4c0f-aefd-52a9b43335e1\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-xdt\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xdt\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002272b98b9a-6908-4506-a490-82f98dd3b263\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-xharness\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xharness\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229ba52ca5-54ad-4466-a502-11fb7cc50cab\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-xliff-tasks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-xliff-tasks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228f3fd539-18a8-4487-8713-2b98c164c70b\u0022,\r\n    \u0022Name\u0022: \u0022dotnet-yarp\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/dotnet-yarp\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002248da72e1-2327-4b58-bb37-5a833fe03b00\u0022,\r\n    \u0022Name\u0022: \u0022em-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/em-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002296eef00a-7626-4355-a097-763c01013fd0\u0022,\r\n    \u0022Name\u0022: \u0022go-canary\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/go-canary\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002208fa09fa-03e1-4a19-8149-16be2805c28d\u0022,\r\n    \u0022Name\u0022: \u0022hello-demo\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/hello-demo\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002243638697-b2a0-477d-a1b0-1024688bb072\u0022,\r\n    \u0022Name\u0022: \u0022levib.dataset-filter\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/levib.dataset-filter\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223092b6af-cca7-49ba-92f2-4a9e5b645fed\u0022,\r\n    \u0022Name\u0022: \u0022levib.safebinaryformatter\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/levib.safebinaryformatter\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224d7627dd-a5b2-46c1-8f8e-e157658221de\u0022,\r\n    \u0022Name\u0022: \u0022Linux-Files-Signing\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00221ae0da05-ebff-4d67-98eb-c3b13001b28c\u0022,\r\n    \u0022Name\u0022: \u0022Linux-Files-Signing.epsitha.ananth\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/Linux-Files-Signing.epsitha.ananth\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00226e331e23-a282-4e77-81f2-023fd5800181\u0022,\r\n    \u0022Name\u0022: \u0022maestro-test1\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/maestro-test1\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e6f2a2fb-be51-4de9-b065-0f1430bc5f46\u0022,\r\n    \u0022Name\u0022: \u0022maestro-test2\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/maestro-test2\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002275574b97-7a56-42aa-b314-495f409597a5\u0022,\r\n    \u0022Name\u0022: \u0022maestro-test3\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/maestro-test3\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223be8ae06-5660-4116-9041-0ce72b7c9a15\u0022,\r\n    \u0022Name\u0022: \u0022Microsoft-clrmd\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/Microsoft-clrmd\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002230ea1589-d1f9-4bf5-bf88-c01f336f3adc\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-code-coverage\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-code-coverage\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ce821efb-3d36-4457-9fad-a05db83fc1e9\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-dotnet-framework-docker\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-dotnet-framework-docker\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a10d52a7-9b71-4a8a-afc6-7e10d21a46d1\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-fluentui-blazor\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-fluentui-blazor\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225b09aaa7-b9fb-4319-9f84-64b0b85fe520\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/microsoft/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229544b3b2-ae80-4f22-b4f3-1a550105f3aa\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-images\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/microsoft/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-images\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022da7f3dc8-8bda-455c-bb1c-c35aed69eba6\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-infra\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220de0a4df-7f53-4eeb-8700-001b2bc50060\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-infra-images\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-infra-images\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002296458575-0769-4b0c-baf6-1474a046e547\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-mirror\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-mirror\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022966977df-1315-49f8-ac4b-8e75ccca51ba\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-pdb\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-pdb\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022d0944467-6a6a-4a22-bf04-3daf78fa95f2\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-go-x-net\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-go-x-net\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e63b189f-f787-493a-8668-7bbf2041c274\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-testfx\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-testfx\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ef257391-4d76-4240-8649-3f21ac49c392\u0022,\r\n    \u0022Name\u0022: \u0022microsoft-vstest\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/microsoft-vstest\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a6d7b578-1ec7-405e-9334-941e6f43cfb6\u0022,\r\n    \u0022Name\u0022: \u0022mistucke-ownership-test\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mistucke-ownership-test\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022645b2533-288b-4806-b3b1-6baa7e183b60\u0022,\r\n    \u0022Name\u0022: \u0022mono-api-doc-tools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-api-doc-tools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223abeed71-8ee1-4164-b704-925ff4d49f96\u0022,\r\n    \u0022Name\u0022: \u0022mono-api-snapshot\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-api-snapshot\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e4dc65cf-b42d-4d3c-bf8b-ec014d5e60ae\u0022,\r\n    \u0022Name\u0022: \u0022mono-aspnetwebstack\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-aspnetwebstack\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f499eedd-fd80-483d-a9e7-e08986c79a9a\u0022,\r\n    \u0022Name\u0022: \u0022mono-bockbuild\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-bockbuild\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002271c2f825-610a-451b-ac48-d657799676f4\u0022,\r\n    \u0022Name\u0022: \u0022mono-boringssl\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/mono\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-boringssl\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00220672a186-a85b-4469-9358-233797afb091\u0022,\r\n    \u0022Name\u0022: \u0022mono-corefx\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-corefx\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022748abe38-f5bc-4d47-845c-e40fdb1f092b\u0022,\r\n    \u0022Name\u0022: \u0022mono-corert\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-corert\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00224f9ef717-3e1d-4e92-a6d4-4b8051149a71\u0022,\r\n    \u0022Name\u0022: \u0022mono-helix-binaries\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-helix-binaries\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ea861a51-7439-4b13-a94c-74373f021a5e\u0022,\r\n    \u0022Name\u0022: \u0022mono-ikdasm\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-ikdasm\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022a278fdf2-308d-4af5-aeb9-223b94e6e8c2\u0022,\r\n    \u0022Name\u0022: \u0022mono-ikvm-fork\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-ikvm-fork\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00223a1911fb-777f-4b24-b826-bd910d787463\u0022,\r\n    \u0022Name\u0022: \u0022mono-illinker-test-assets\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-illinker-test-assets\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222ecfb9c3-23c6-42a7-90c2-f5ed3aec6a48\u0022,\r\n    \u0022Name\u0022: \u0022mono-llvm\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release_60\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-llvm\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002214ccce4a-b17f-498b-a1a2-8a01e9f00cfb\u0022,\r\n    \u0022Name\u0022: \u0022mono-mono\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-mono\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00222115a432-d772-4792-8522-9923578e881b\u0022,\r\n    \u0022Name\u0022: \u0022mono-mono.posix\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-mono.posix\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ea107157-da27-461f-8c66-bf9d5272c78f\u0022,\r\n    \u0022Name\u0022: \u0022mono-Newtonsoft.Json\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-Newtonsoft.Json\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00221dfefa6f-cb05-4fbf-b64c-bfea953e31b0\u0022,\r\n    \u0022Name\u0022: \u0022mono-NuGet.BuildTasks\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dev\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-NuGet.BuildTasks\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e14bcca1-36ea-4c9b-ab0f-7349441ee67a\u0022,\r\n    \u0022Name\u0022: \u0022mono-NUnitLite\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-NUnitLite\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022432e7327-56bf-4026-91f4-829c97f1c0de\u0022,\r\n    \u0022Name\u0022: \u0022mono-reference-assemblies\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-reference-assemblies\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00229bff0a55-b1f8-4313-9af8-455e59829a25\u0022,\r\n    \u0022Name\u0022: \u0022mono-roslyn-binaries\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-roslyn-binaries\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022154243fa-07a5-4d88-a22d-302ab86d5ba1\u0022,\r\n    \u0022Name\u0022: \u0022mono-rx\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-rx\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022f2b35dc4-78ce-4965-a63d-ebf478840110\u0022,\r\n    \u0022Name\u0022: \u0022mono-xunit-binaries\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/mono-xunit-binaries\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ef9ad533-72d4-464e-a99a-c05171750541\u0022,\r\n    \u0022Name\u0022: \u0022MSBuild-history\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/sd-feature-msbuild1\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/MSBuild-history\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002256ed64ba-3ff0-4233-b3e3-ffba0200ed02\u0022,\r\n    \u0022Name\u0022: \u0022MSTest\u0022,\r\n    \u0022DefaultBranch\u0022: null,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/MSTest\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ca90c8f2-ed36-4b1b-b3eb-9821cfec78f4\u0022,\r\n    \u0022Name\u0022: \u0022net-acquisition-wiki\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/net-acquisition-wiki\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022404672cc-b197-43b1-a295-125f77b24474\u0022,\r\n    \u0022Name\u0022: \u0022netcoremigrationtools\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/master\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/netcoremigrationtools\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u002234f46773-b26a-426f-a1df-c125ff7162b8\u0022,\r\n    \u0022Name\u0022: \u0022nuget-packageSourceMapper\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/dev\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/nuget-packageSourceMapper\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022ba2bf4f3-a049-4345-8ae3-7eaac37d3278\u0022,\r\n    \u0022Name\u0022: \u0022razor-toolset-tests\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/razor-toolset-tests\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00225cea8b1e-0355-4cbf-b567-88d24d66e934\u0022,\r\n    \u0022Name\u0022: \u0022rebrand-package\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/rebrand-package\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00228514c9b5-5b03-4ce8-ae2a-5702e20b332f\u0022,\r\n    \u0022Name\u0022: \u0022security-partners-dotnet\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/release/6.0.1xx\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/security-partners-dotnet\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022fab18919-8520-4c7e-9467-4704c32e8152\u0022,\r\n    \u0022Name\u0022: \u0022SignalR-SignalR\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/SignalR-SignalR\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022b6d44ded-d789-46eb-88e5-e4a38f782bff\u0022,\r\n    \u0022Name\u0022: \u0022SnapshotParser\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/SnapshotParser\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u00221b7339e4-b184-45d2-ba99-93256efc0937\u0022,\r\n    \u0022Name\u0022: \u0022source-build-validation\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/source-build-validation\u0022\r\n  },\r\n  {\r\n    \u0022Id\u0022: \u0022e9c5424e-c726-4a63-8cca-f69255e13c5b\u0022,\r\n    \u0022Name\u0022: \u0022source-build-validation-spd\u0022,\r\n    \u0022DefaultBranch\u0022: \u0022refs/heads/main\u0022,\r\n    \u0022WebUrl\u0022: \u0022https://dev.azure.com/dnceng/internal/_git/source-build-validation-spd\u0022\r\n  }\r\n]"
        }
      ],
      "count": 1
    }
  }
}
```
