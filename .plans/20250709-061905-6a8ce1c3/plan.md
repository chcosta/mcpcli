# Plan: Helix Service Recent Changes Analysis

**Goal**: # Helix Service Recent Changes Analysis

This workflow analyzes recent development activity in the **dotnet-helix-service** repository by identifying changes that have been merged to the main branch since the last production deployment **that occurred before July 1, 2025**.

## Context

The **dotnet-helix-service** is a critical component of the .NET engineering infrastructure. This analysis helps track what changes have been made to the main branch since the last production deployment that was completed before a specific cutoff date.

## Workflow Overview

1. **Establish Connection**: Connect to the Azure DevOps organization to access repository data
2. **Find Latest Production Deployment Before Cutoff**: Identify the most recent pull request that was merged to the production branch **before July 1, 2025**
3. **Track Subsequent Changes**: List all changes merged to main branch **after** that production deployment
4. **Get PR descriptions**: Retrieve descriptions for each pull request to generate release notes

## Analysis Goals

- **Deployment Tracking**: Find the last production deployment that occurred before the cutoff date
- **Change Visibility**: See what changes have been merged to main since that specific deployment
- **Release Planning**: Generate release notes for changes pending deployment

## Expected Results

- Details of the most recent production deployment that was completed **before July 1, 2025**
- Comprehensive list of all pull requests merged to main **after** that deployment
- Release notes suitable for distribution for each merged pull request
- if any errors are encountered, detailed messages and stack traces should be output.

**Output Format**: The final output should follow the format specified in `../samples/release-notes.md`, which provides a structured template for:
- Repository information and branch details
- Date range (since production deployment, up to cutoff date)
- Pull request entries with hyperlinks, merge dates, and concise descriptions

## Important Notes

- **Date Constraint**: Only consider production deployments that were completed **before July 1, 2025**
- **Sequential Logic**: Step 3 depends on the completion date from Step 2
- **No Future Dates**: Ignore any pull requests that have future dates or were completed after the cutoff

Please execute each step methodically to build a complete picture of recent development activity.

## Output Format Reference

The final release notes should match the format shown in the sample file `../samples/release-notes.md`. This includes:

1. **Header**: Repository name, branch, and date range information
2. **Pull Request Entries**: Each entry should include:
   - Pull request title with a valid hyperlink to the Azure DevOps PR
   - Merge/completion date in parentheses
   - 1-3 line summary of the changes based on the PR description
   - Format: `[PR Title](link) (merged YYYY-MM-DD): Brief description of changes`

Ensure all hyperlinks are functional and point to the actual Azure DevOps pull request pages.

## Sequential Steps:

### Step 1: Initialize Azure DevOps Connection
**Instruction**: 

---

### Step 2: Find Latest Production Deployment Before Cutoff
**Instruction**: 

---

### Step 3: Analyze Recent Main Branch Changes
**Instruction**: 

---

### Step 4: Get pull request descriptions
**Instruction**: 

---



**Created**: 2025-07-09T06:19:05Z
**Status**: InProgress

## Steps

- Step 1: Initialize the Azure DevOps client using DefaultAzureCredential or AZURE_DEVOPS_PAT.
- Step 2: Get all projects from the Azure DevOps organization.
- Step 3: Get repositories for the 'dotnet-helix-service' project.
- Step 4: Get pull requests for the production branch in the 'dotnet-helix-service' repository filtered by closed date before 2025-07-01, ordered by creation date descending.
- Step 5: Get pull requests for the main branch in the 'dotnet-helix-service' repository filtered by closed date after the last production deployment date, ordered by creation date descending.
- Step 6: Get descriptions for each pull request merged to the main branch in the 'dotnet-helix-service' repository.
