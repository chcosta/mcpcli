---
title: "List Azure DevOps Projects"
description: "Simple workflow to initialize Azure DevOps and list all available projects"
version: "1.0"
tags: ["azure-devops", "projects", "simple"]
organization_url: "https://dev.azure.com/dnceng"
steps:
  - name: "Initialize Connection"
    description: "Set up Azure DevOps client connection"
    instruction: "Initialize the Azure DevOps client with organization URL"
    required_tools: ["initialize_azure_dev_ops_client"]
  - name: "List Projects"
    description: "Get all available projects"
    instruction: "Retrieve and display all projects in the organization"
    required_tools: ["get_projects"]
expected_output: "A list of all available Azure DevOps projects with their descriptions"
---

# Azure DevOps Projects Listing

This is a simple workflow to connect to Azure DevOps and list all available projects.

## What this will do:

1. **Initialize Azure DevOps Client**: Set up authentication and connection to the organization
2. **Retrieve Projects**: Get a comprehensive list of all projects available in the organization

Please initialize the Azure DevOps client and then list all available projects. 