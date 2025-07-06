---
title: "Helix Service Recent Changes Analysis"
description: "Track recent changes in dotnet-helix-service by analyzing pull requests merged after the last production deployment"
version: "1.0"
tags: ["helix", "pull-requests", "deployment", "analysis"]
organization_url: "https://dev.azure.com/dnceng"
project_name: "internal"
repository_name: "dotnet-helix-service"
production_branch: "production"
main_branch: "main"
cutoff_date: "2025-07-01"
steps:
  - name: "Initialize Azure DevOps Connection"
    description: "Establish connection to Azure DevOps organization"
    instruction: "Initialize the Azure DevOps client with the organization URL to enable API access"
    required_tools: ["initialize_azure_dev_ops_client"]
  - name: "Find Latest Production Deployment Before Cutoff"
    description: "Find the most recent production deployment before the specified cutoff date"
    instruction: "Find the most recent pull request in the {project_name} project's {repository_name} repository that was merged to the {production_branch} branch AND was completed (closed) before {cutoff_date}. Use closed date filtering to ensure we get PRs that were completed before the cutoff date."
    required_tools: ["get_pull_requests_by_closed_date"]
  - name: "Analyze Recent Main Branch Changes"
    description: "List all pull requests merged to main after the production deployment"
    instruction: "Get all pull requests that were merged to the {main_branch} branch after the completion date of the production deployment found in the previous step. Use the completion date from step 2 as the afterClosedDate parameter."
    required_tools: ["get_pull_requests_by_closed_date"]
  - name: "Get pull request descriptions"
    description: "Get detailed descriptions for each pull request to generate release notes"
    instruction: "For each pull request found in step 3, use the pull request id to retrieve the detailed descriptions to create comprehensive release notes"
    required_tools: ["get_pull_request_description"]

expected_output: "A concise set of release notes including all changes merged to the main branch after the production deployment that was completed before the cutoff date. The output should follow the format specified in the sample file at ../samples/release-notes.md"
---

# Helix Service Recent Changes Analysis

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