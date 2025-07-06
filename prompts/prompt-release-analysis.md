---
title: "Release Notes Analysis"
description: "Comprehensive analysis of recent pull requests and commits for release notes generation"
version: "1.0"
tags: ["release-notes", "analysis", "azure-devops"]
project_name: "public"
repository_name: "dotnet-core"
from_date: "2024-01-01"
to_date: "2024-12-31"
steps:
  - name: "Initialize Azure DevOps"
    description: "Set up connection to Azure DevOps organization"
    instruction: "Initialize the Azure DevOps client with the organization URL"
    required_tools: ["initialize_azure_dev_ops_client"]
  - name: "Get Project Information"
    description: "Retrieve basic information about the target project"
    instruction: "Get details about the {project_name} project to understand its structure"
    required_tools: ["get_projects"]
  - name: "Analyze Recent Pull Requests"
    description: "Get pull requests closed in the specified date range"
    instruction: "Retrieve pull requests for {repository_name} that were closed between {from_date} and {to_date}"
    required_tools: ["get_pull_requests_by_closed_date"]
  - name: "Generate Release Notes"
    description: "Create comprehensive release notes based on the analysis"
    instruction: "Generate release notes for {repository_name} covering the period from {from_date} to {to_date}"
    required_tools: ["get_release_notes"]
expected_output: "A comprehensive report including project overview, recent pull requests, and formatted release notes"
---

# Release Notes Analysis Workflow

This prompt will guide you through a comprehensive analysis of recent development activity to generate detailed release notes.

## Context

You are tasked with analyzing the **{project_name}** project, specifically the **{repository_name}** repository, to create release notes for the period from **{from_date}** to **{to_date}**.

## Objectives

1. **Establish Connection**: Set up authentication and connection to Azure DevOps
2. **Project Discovery**: Understand the project structure and available repositories
3. **Activity Analysis**: Review recent pull requests and development activity
4. **Documentation Generation**: Create comprehensive release notes

## Expected Deliverables

- Summary of project status
- List of significant pull requests in the date range
- Formatted release notes with categorized changes
- Recommendations for future releases

Please execute each step methodically and provide detailed information at each stage. 