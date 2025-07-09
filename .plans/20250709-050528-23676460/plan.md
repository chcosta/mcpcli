# Plan: Azure DevOps Comprehensive Data Retrieval

**Goal**: Initialize the azure devops client, list all projects, for each project get the repositories, for each repository get the latest builds, analyze the build status, identify failed builds, get pull requests for failed builds, and create a summary report

**Created**: 2025-07-09T05:05:28Z
**Status**: InProgress

## Steps

- Step 1: Initialize the Azure DevOps client and authenticate with the organization
- Step 2: Get a comprehensive list of all projects in the organization
- Step 3: For each project retrieved, get all repositories with their branch and commit information
- Step 4: For each repository retrieved, get pull requests filtered by their creation date range with detailed metadata
- Step 5: Analyze the pull request data to identify trends, common issues, or other insights based on metadata and comments
