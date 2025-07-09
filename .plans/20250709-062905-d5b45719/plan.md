# Plan: Get Recent Pull Requests for Helix Service

**Goal**: get the 2 most recent pull requests from the dnceng organization's internal project's dotnet-helix-service repository targeting the production branch

**Created**: 2025-07-09T06:29:05Z
**Status**: InProgress

## Steps

- Step 1: Check the authentication status for the Azure DevOps client to ensure proper configuration.
- Step 2: Initialize the Azure DevOps client for the dnceng organization using AZURE_DEVOPS_PAT or DefaultAzureCredential.
- Step 3: Get the 2 most recent pull requests from the internal project's dotnet-helix-service repository that target the production branch.
